using Microsoft.Office.Interop.Outlook;
using Microsoft.TeamFoundation.WorkItemTracking.Process.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using Microsoft.VisualStudio.Services.WebApi.Patch;
using Microsoft.VisualStudio.Services.WebApi.Patch.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureDevopsPlugin.Utilities
{
    /// <summary>
    /// Functions which works with TFS
    /// </summary>
    public class TfsUtility
    {
        /// <summary>
        /// Get instance of needed http client, credentials take from settings
        /// </summary>
        /// <typeparam name="T">Http client type</typeparam>
        /// <returns></returns>
        public async static Task<T> GetTFSHttpClient<T>() where T : VssHttpClientBase
        {
            var valid = Settings.settings.Validate();
            if (valid)
            {
                return await GetTFSHttpClient<T>(Settings.settings.OrgName, Settings.settings.PatToken);
            }
            return null;
        }

        /// <summary>
        /// Parametrized method which returns http client of TFS
        /// </summary>
        /// <typeparam name="T">Http client type</typeparam>
        /// <param name="orgName">TFS organization name</param>
        /// <param name="PatToken">TFS PAT token</param>
        /// <returns></returns>
        public async static Task<T> GetTFSHttpClient<T>(string orgName, string PatToken) where T : VssHttpClientBase
        {
            var u = new Uri($"https://dev.azure.com/" + orgName);
            VssCredentials c = new VssCredentials(new VssBasicCredential(string.Empty, PatToken));
            var connection = new VssConnection(u, c);
            // check connection
            await connection.ConnectAsync();
            return await connection.GetClientAsync<T>();
        }

        /// <summary>
        /// Create attachment in azure devops
        /// </summary>
        /// <param name="filePath">file to copy</param>
        /// <returns></returns>
        public async static Task<AttachmentReference> CreateAttachment(string filePath)
        {
            var workitemClient = await GetTFSHttpClient<WorkItemTrackingHttpClient>();
            if (workitemClient != null)
            {
                // open file steam on temporary saved attachment path
                using (FileStream attStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    var fileName = Path.GetFileName(filePath);
                    return await workitemClient.CreateAttachmentAsync(attStream, uploadType: "simple", fileName: fileName, cancellationToken: GetCancellationToken(30)); // upload the file
                }
            }

            // this case will not occur in reality
            throw new System.Exception("settings are not valid");
        }

        /// <summary>
        /// Create work item in TFS(Azure Devops)
        /// </summary>
        /// <param name="title">work item title</param>
        /// <param name="description">work item description</param>
        /// <param name="category">work item category</param>
        /// <param name="attachments">work item attachments</param>
        /// <param name="withAttachments">include attachments flag</param>
        /// <returns></returns>
        public async static Task<WorkItem> CreateWorkItem(string title, string description, string category, Attachments attachments = null, bool withAttachments = false)
        {
            var workitemClient = await GetTFSHttpClient<WorkItemTrackingHttpClient>();
            if (workitemClient != null)
            {
                var document = new JsonPatchDocument();
                if (withAttachments && attachments != null)
                {
                    foreach (Attachment att in attachments)
                    {
                        // save file to temporary path
                        var savePath = System.IO.Path.GetTempPath() + att.FileName;
                        att.SaveAsFile(savePath);
                        var savedAttachment = await CreateAttachment(savePath);
                        document.Add(CreateAttachmentJsonPatchOperation(savedAttachment));
                        // delete after attachment created
                        File.Delete(savePath);
                    }
                }

                document.Add(
                new JsonPatchOperation()
                {
                    Path = "/fields/Microsoft.VSTS.Common.Discipline",
                    Operation = Operation.Add,
                    Value = "development"
                });
                document.Add(
                new JsonPatchOperation()
                {
                    Path = "/fields/System.Title",
                    Operation = Operation.Add,
                    Value = title
                });

                document.Add(
                new JsonPatchOperation()
                {
                    Path = "/fields/System.Description",
                    Operation = Operation.Add,
                    Value = description
                });

                document.Add(
                new JsonPatchOperation()
                {
                    Path = "/fields/" + Models.WorkItem.CategoryBySourceReferenceName,
                    Operation = Operation.Add,
                    Value = category
                });

                return await workitemClient.CreateWorkItemAsync(document, Settings.settings.ProjectName, Settings.settings.WorkItemType);
            }

            throw new System.Exception("Settings is not valid!");
        }

        /// <summary>
        /// Create document for work item with attachment info
        /// </summary>
        /// <param name="reference">attachment reference</param>
        /// <returns></returns>
        private static JsonPatchOperation CreateAttachmentJsonPatchOperation(AttachmentReference reference)
        {
            return new JsonPatchOperation()
            {
                Operation = Operation.Add,
                Path = "/relations/-",
                Value = new
                {
                    rel = "AttachedFile",
                    url = reference.Url
                }
            };
        }

        /// <summary>
        /// Add comment to work item
        /// </summary>
        /// <param name="workItemId">id of work item</param>
        /// <param name="comment">comment text</param>
        /// <param name="attachments">attachments</param>
        /// <param name="withAttachments">include attachments flag</param>
        /// <param name="state">State of work item</param>
        /// <param name="complexity">Complexity</param>
        /// <returns></returns>
        public async static Task<Comment> AddCommentToWorkItem(int workItemId, string state, string comment, Attachments attachments = null, bool withAttachments = false, string complexity = null)
        {
            var workItemsClient = await GetTFSHttpClient<WorkItemTrackingHttpClient>();
            if (workItemsClient != null)
            {
                var workItem = await workItemsClient.GetWorkItemAsync(workItemId, cancellationToken: GetCancellationToken(20));
                var updateDocument = new JsonPatchDocument();
                if (withAttachments && attachments?.Count > 0)
                {
                    var i = 1;
                    foreach (Attachment att in attachments)
                    {
                        var savePath = System.IO.Path.GetTempPath() + att.FileName;
                        att.SaveAsFile(savePath);
                        var attachment = await CreateAttachment(savePath);
                        updateDocument.Add(CreateAttachmentJsonPatchOperation(attachment));
                        comment += $"<br>attachment {i} file name: {att.FileName}";
                        File.Delete(savePath);
                        i++;
                    }
                }

                if (!string.IsNullOrEmpty(complexity))
                {
                    updateDocument.Add(
                    new JsonPatchOperation()
                    {
                        Path = "/fields/" + Models.WorkItem.CategoryByComplexityReferenceName,
                        Operation = Operation.Replace,
                        Value = complexity
                    });
                }
                // updating state
                updateDocument.Add(
                    new JsonPatchOperation()
                    {
                        Path = "/fields/System.State",
                        Operation = Operation.Replace,
                        Value = state
                    });

                await workItemsClient.UpdateWorkItemAsync(updateDocument, workItem.Id.Value);
                return await workItemsClient.AddCommentAsync(new CommentCreate { Text = comment }, Settings.settings.ProjectName, workItem.Id.Value, cancellationToken: GetCancellationToken(20));
            }
            // in reality this case should not occur
            throw new System.Exception("Bad settings!");
        }

        /// <summary>
        /// Find work items by title containing substring
        /// </summary>
        /// <param name="title">work item title</param>
        /// <returns></returns>
        public static async Task<List<Models.WorkItem>> FindWorkItemsByTitle(string title)
        {
            var workitemClient = await GetTFSHttpClient<WorkItemTrackingHttpClient>();
            if (workitemClient != null)
            {
                var list = new List<Models.WorkItem>();
                var workItemIds = new List<int>();
                var wiql = new Wiql()
                {
                    // NOTE: Even if other columns are specified, only the ID & URL will be available in the WorkItemReference
                    Query = "Select [Id] " +
                        "From WorkItems " +
                        "Where [Work Item Type] = '" + Settings.settings.WorkItemType + "' " +
                        "And [System.TeamProject] = '" + Settings.settings.ProjectName + "' " +
                        "And [System.Title] Contains '" + title.Replace("'", "''") + "' " +
                        "And [System.State] <> 'Closed' " +
                        "Order By [State] Asc, [Changed Date] Desc",
                };

                var result = await workitemClient.QueryByWiqlAsync(wiql);
                if (result.WorkItems.Count() > 0)
                {
                    var workItems = await workitemClient.GetWorkItemsAsync(result.WorkItems.Select(a => a.Id), new List<string> { "System.State", "System.Title", Models.WorkItem.CategoryByComplexityReferenceName }, cancellationToken: GetCancellationToken(20));
                    foreach (var workItem in workItems)
                    {
                        // avoid cases when id is null
                        if (!workItem.Id.HasValue)
                        {
                            continue;
                        }

                        list.Add(new Models.WorkItem { Id = workItem.Id.Value, Title = (string)workItem.Fields["System.Title"], State = (string)workItem.Fields["System.State"], Complexity = workItem.Fields.ContainsKey(Models.WorkItem.CategoryByComplexityReferenceName) ? (string)workItem.Fields[Models.WorkItem.CategoryByComplexityReferenceName] : null });
                    }
                }

                return list;
            }

            // in reality this case will not occur
            throw new System.Exception("bad settings file");
        }

        /// <summary>
        /// Get custom field picklist values
        /// </summary>
        /// <param name="fieldName">custom field name</param>
        /// <returns></returns>
        public async static Task<(string, IList<string>)> GetCustomFieldPickListValue(string fieldName)
        {
            if (Settings.settings.Validate())
            {
                return await GetCustomFieldPickListValue(fieldName, Settings.settings.OrgName, Settings.settings.PatToken);
            }

            // in reality this case should not occur
            throw new System.Exception("bad config file");
        }

        /// <summary>
        /// Get custom field picklist values with credentials parameters 
        /// </summary>
        /// <param name="fieldName">custom field name</param>
        /// <param name="orgName">organization name</param>
        /// <param name="pat">PAT token</param>
        /// <returns></returns>
        public async static Task<(string, IList<string>)> GetCustomFieldPickListValue(string fieldName, string orgName, string pat)
        {
            var witTrackingPClient = await GetTFSHttpClient<WorkItemTrackingProcessHttpClient>(orgName, pat);
            var witTrackingClient = await GetTFSHttpClient<WorkItemTrackingHttpClient>(orgName, pat);
            var workItemField = await witTrackingClient.GetFieldAsync(fieldName, GetCancellationToken(20));
            if (workItemField.IsPicklist)
            {
                var pickList = await witTrackingPClient.GetListAsync(workItemField.PicklistId.Value,GetCancellationToken(20));
                if (pickList?.Items?.Count == 0)
                {
                    throw new System.Exception(fieldName + " field has zero elements in picklist");
                }

                return (workItemField.ReferenceName, pickList.Items);
            }
            else
            {
                throw new System.Exception(fieldName + " field is not picklist");
            }
        }

        /// <summary>
        /// Validate VSS connection based on settings
        /// </summary>
        /// <returns></returns>
        public async static Task<bool> ValidateVssSettings()
        {
            try
            {
                if (!Settings.settings.Validate())
                {
                    return false;
                }
                await ValidateVssSettings(Settings.settings.WorkItemType, Settings.settings.ProjectName, Settings.settings.CategoryBySourceField, Settings.settings.CategoryByComplexityField, Settings.settings.OrgName, Settings.settings.PatToken);
                return true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ProcessException(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        /// <summary>
        /// Validate VSS connection
        /// </summary>
        /// <param name="workItemType">work item type</param>
        /// <param name="projectName">project name</param>
        /// <param name="categoryBySourceField">category by source</param>
        /// <param name="categoryByComplexityField">category by complexity</param>
        /// <param name="orgName">organization name</param>
        /// <param name="patToken">PAT token</param>
        /// <returns></returns>
        public async static Task ValidateVssSettings(string workItemType, string projectName, string categoryBySourceField, string categoryByComplexityField, string orgName, string patToken)
        {
            if (string.IsNullOrEmpty(workItemType) || string.IsNullOrEmpty(projectName) || string.IsNullOrEmpty(categoryBySourceField) || string.IsNullOrEmpty(orgName) || string.IsNullOrEmpty(patToken))
            {
                throw new ArgumentNullException("bad arguments");
            }

            var witClient = await GetTFSHttpClient<WorkItemTrackingHttpClient>(orgName, patToken);
            var type = await witClient.GetWorkItemTypeAsync(projectName, workItemType, cancellationToken: GetCancellationToken(20));
            (string categoryByComplexityRefName, IList<string> categoriesByComplexity) = await GetCustomFieldPickListValue(categoryByComplexityField, orgName, patToken);
            (string categoryBySourceRefName, IList<string> categoriesBySource) = await GetCustomFieldPickListValue(categoryBySourceField, orgName, patToken);
            var states = await witClient.GetWorkItemTypeStatesAsync(projectName, workItemType, GetCancellationToken(20));
            Models.WorkItem.SetStates(states);
            Models.WorkItem.CategoryByComplexityReferenceName = categoryByComplexityRefName;
            Models.WorkItem.CategoryBySourceReferenceName = categoryBySourceRefName;
            Models.WorkItem.CategoriesByComplexity = categoriesByComplexity.ToList();
            Models.WorkItem.CategoriesBySource = categoriesBySource.ToList();
        }

        /// <summary>
        /// Process exceptions to take right text
        /// </summary>
        /// <param name="ex">exception</param>
        /// <returns></returns>
        public static string ProcessException(System.Exception ex) => ex.InnerException != null ? ex.InnerException is VssUnauthorizedException ? "PAT token is invalid, or has not enough permissions" : ex.InnerException.Message : ex.Message;
        
        /// <summary>
        /// Get cancellation token with timeout
        /// </summary>
        /// <param name="seconds">seconds of timeout</param>
        /// <returns></returns>
        public static CancellationToken GetCancellationToken(int seconds) => (new CancellationTokenSource(TimeSpan.FromSeconds(seconds))).Token;
    }
}
