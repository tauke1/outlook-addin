using HtmlAgilityPack;
using Microsoft.Office.Interop.Outlook;
using Microsoft.TeamFoundation.WorkItemTracking.Process.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using Microsoft.VisualStudio.Services.WebApi.Patch;
using Microsoft.VisualStudio.Services.WebApi.Patch.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureDevopsPlugin
{
    /// <summary>
    /// Utility which contains helper functions
    /// </summary>
    public class Utility
    {
        /// <summary>
        /// Get TFS client
        /// </summary>
        /// <returns></returns>
        public static T GetTFSHttpClient<T>() where T : VssHttpClientBase
        {
            var valid = Settings.settings.Validate();
            if (valid)
            {
                return GetTFSHttpClient<T>(Settings.settings.OrgName, Settings.settings.PatToken);
            }
            return null;
        }

        public static T GetTFSHttpClient<T>(string orgName, string PatToken) where T : VssHttpClientBase
        {
            var u = new Uri($"https://dev.azure.com/" + orgName);
            VssCredentials c = new VssCredentials(new VssBasicCredential(string.Empty, PatToken));
            var connection = new VssConnection(u, c);
            return connection.GetClient<T>();
        }

        public async static Task GetStates(string workItemType)
        {
            var workitemClient = GetTFSHttpClient<WorkItemTrackingHttpClient>();
            var states = await workitemClient.GetWorkItemTypeStatesAsync(Settings.settings.ProjectName, workItemType, GetCancellationToken(20));
            var b = 1 + 1;
        }

        /// <summary>
        /// Create attachment in azure devops
        /// </summary>
        /// <param name="filePath">file to copy</param>
        /// <returns></returns>
        public async static Task<AttachmentReference> CreateAttachment(string filePath)
        {
            var workitemClient = GetTFSHttpClient<WorkItemTrackingHttpClient>();
            if (workitemClient != null)
            {
                using (FileStream attStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    var fileName = Path.GetFileName(filePath);
                    return await workitemClient.CreateAttachmentAsync(attStream, uploadType: "simple", fileName: fileName, cancellationToken: GetCancellationToken(20)); // upload the file

                }
            }

            throw new System.Exception("settings are not valid");
        }

        /// <summary>
        /// Create work item in TFS(Azure Devops)
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="category"></param>
        /// <param name="attachments"></param>
        /// <param name="withAttachments"></param>
        /// <returns></returns>
        public async static Task<WorkItem> CreateWorkItem(string title, string description, string category, Attachments attachments = null, bool withAttachments = false)
        {
            var workitemClient = GetTFSHttpClient<WorkItemTrackingHttpClient>();
            if (workitemClient != null)
            {
                var document = new JsonPatchDocument();
                if (withAttachments && attachments != null)
                {
                    foreach (Attachment att in attachments)
                    {
                        var savePath = System.IO.Path.GetTempPath() + att.FileName;
                        att.SaveAsFile(savePath);
                        var savedAttachment = await CreateAttachment(savePath);
                        document.Add(CreateAttachmentJsonPatchOperation(savedAttachment));
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
                    Path = "/fields/Custom." + Settings.settings.CategoryCustomFieldName,
                    Operation = Operation.Add,
                    Value = category
                });

                return await workitemClient.CreateWorkItemAsync(document, Settings.settings.ProjectName, Settings.settings.WorkItemType);
            }

            throw new System.Exception("Settings is not valid!");
        }

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
        /// <returns></returns>
        public async static Task<Comment> AddCommentToWorkItem(int workItemId, string state , string comment, Attachments attachments = null, bool withAttachments = false)
        {
            var workItemsClient = GetTFSHttpClient<WorkItemTrackingHttpClient>();
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

            throw new System.Exception("Bad settings!");
        }

        /// <summary>
        /// Find work items by title
        /// </summary>
        /// <param name="title">work item title</param>
        /// <returns></returns>
        public static async Task<List<Models.WorkItem>> FindWorkItemsByTitle(string title)
        {
            var workitemClient = GetTFSHttpClient<WorkItemTrackingHttpClient>();
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
                    var workItems = await workitemClient.GetWorkItemsAsync(result.WorkItems.Select(a => a.Id), new List<string> { "System.State", "System.Title" }, cancellationToken: GetCancellationToken(20));
                    foreach (var workItem in workItems)
                    {
                        if (!workItem.Id.HasValue)
                        {
                            continue;
                        }

                        list.Add(new Models.WorkItem { Id = workItem.Id.Value, Title = (string)workItem.Fields["System.Title"], State = (string)workItem.Fields["System.State"], Url = workItem.Url });
                    }
                }

                return list;
            }

            throw new System.Exception("bad settings file");
        }

        public async static Task<IList<string>> GetCustomFieldPickListValue(string fieldName)
        {
            var witClient = GetTFSHttpClient<WorkItemTrackingHttpClient>();
            var witTrackingClient = GetTFSHttpClient<WorkItemTrackingProcessHttpClient>();
            return await GetCustomFieldPickListValue(fieldName, witClient, witTrackingClient);
        }

        public async static Task<IList<string>> GetCustomFieldPickListValue(string fieldName, WorkItemTrackingHttpClient witClient, WorkItemTrackingProcessHttpClient witTrackingClient)
        {
            if (witClient == null && witTrackingClient == null)
            {
                throw new System.Exception("bad configs file");
            }

            var field = await witClient.GetFieldAsync("Custom." + fieldName);
            if (field.IsPicklist)
            {
                var pickList = await witTrackingClient.GetListAsync(field.PicklistId.Value, GetCancellationToken(20));
                if (pickList?.Items?.Count == 0)
                {
                    throw new System.Exception(fieldName + " field zero elements in picklist");
                }

                return pickList.Items;
            }
            else
            {
                throw new System.Exception(fieldName + " field is not picklist");
            }
        }

        public async static Task<bool> ValidateVssSettings()
        {
            try
            {
                if (!Settings.settings.Validate())
                {
                    return false;
                }
                await ValidateVssSettings(Settings.settings.WorkItemType, Settings.settings.ProjectName, Settings.settings.CategoryCustomFieldName, Settings.settings.OrgName, Settings.settings.PatToken);
                return true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ProcessException(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public async static Task ValidateVssSettings(string workItemType, string projectName, string customCategoryField, string orgName, string patToken)
        {
            if (string.IsNullOrEmpty(workItemType) || string.IsNullOrEmpty(projectName) || string.IsNullOrEmpty(customCategoryField) || string.IsNullOrEmpty(orgName) || string.IsNullOrEmpty(patToken))
            {
                throw new ArgumentNullException("bad arguments");
            }

            var witClient = GetTFSHttpClient<WorkItemTrackingHttpClient>(orgName,patToken);
            var witProcessClient = GetTFSHttpClient<WorkItemTrackingProcessHttpClient>(orgName, patToken);
            var type = await witClient.GetWorkItemTypeAsync(projectName, workItemType, cancellationToken: GetCancellationToken(20));
            var customFieldValues = await GetCustomFieldPickListValue(customCategoryField, witClient, witProcessClient);
            var states = await witClient.GetWorkItemTypeStatesAsync(projectName, workItemType, GetCancellationToken(20));
            Models.WorkItem.SetStates(states);
            Settings.settings.CategoryCustomFieldValues = customFieldValues;
        }

        public static string ProcessException(System.Exception ex) => ex.InnerException != null ? ex.InnerException is VssUnauthorizedException ? "PAT token is invalid, or has not enough permissions" : ex.InnerException.Message : ex.Message;

        /// <summary>
        /// Get last reply from message
        /// </summary>
        /// <param name="mailItem"></param>
        /// <returns></returns>
        public static string GetLastMessageFromMessageHTMLBody(string html)
        {
            HtmlAgilityPack.HtmlDocument htmlSnippet = new HtmlAgilityPack.HtmlDocument();
            htmlSnippet.LoadHtml(html);
            var divsByWordSection1Class = htmlSnippet.DocumentNode.SelectNodes("//div[@class = 'WordSection1']");
            HtmlNode headNode = null;
            if (htmlSnippet.DocumentNode.SelectSingleNode("//head") != null)
            {
                headNode = htmlSnippet.DocumentNode.SelectSingleNode("//head");
            }

            // Finding messages created by outlook
            if (divsByWordSection1Class?.Count > 0)
            {
                var borderSplitted = divsByWordSection1Class[0].OuterHtml.Split(new string[] { "<div style=\"border" }, StringSplitOptions.None);
                if (borderSplitted.Length == 1)
                {
                    borderSplitted = borderSplitted[0].Split(new string[] { "<div style='border" }, StringSplitOptions.None);
                    if (borderSplitted.Length == 1)
                    {
                        borderSplitted = borderSplitted[0].Split(new string[] { "<span id=OutlookSignature>" }, StringSplitOptions.None);
                    }
                }

                return headNode != null ? headNode.OuterHtml + borderSplitted[0] : borderSplitted[0];
            }

            /// finding first reply for messages sent from email by dir=ltr tag
            var divsByLtrDir = htmlSnippet.DocumentNode.SelectNodes("//div[@dir = 'ltr']");
            if (divsByLtrDir?.Count > 0)
            {
                var splitted = htmlSnippet.DocumentNode.OuterHtml.Split(new string[] { divsByLtrDir[0].OuterHtml }, StringSplitOptions.None)[0];
                return headNode != null ? headNode.OuterHtml + splitted : splitted;
            }

            return htmlSnippet.DocumentNode.OuterHtml;
        }

        public static string RemoveHeaderFromHtml(string html)
        {
            HtmlAgilityPack.HtmlDocument htmlSnippet = new HtmlAgilityPack.HtmlDocument();
            htmlSnippet.LoadHtml(html);
            if (htmlSnippet.DocumentNode.SelectSingleNode("//head") != null)
            {
                htmlSnippet.DocumentNode.RemoveChild(htmlSnippet.DocumentNode.SelectSingleNode("//head"));
            }

            return htmlSnippet.DocumentNode.OuterHtml;
        }

        public static string ClearFormattingOfHtml(string html)
        {
            HtmlAgilityPack.HtmlDocument htmlSnippet = new HtmlAgilityPack.HtmlDocument();
            htmlSnippet.LoadHtml(html);
            RemoveStyleAttributes(htmlSnippet);
            var htmlElement = htmlSnippet.DocumentNode;
            if (htmlElement.SelectSingleNode("//body") != null)
            {
                htmlElement = htmlElement.SelectSingleNode("//body");
            }

            return htmlElement.OuterHtml;
        }

        public static void RemoveStyleAttributes(HtmlAgilityPack.HtmlDocument html)
        {
            var elementsWithStyleAttribute = html.DocumentNode.SelectNodes("//@style");

            if (elementsWithStyleAttribute != null)
            {
                foreach (var element in elementsWithStyleAttribute)
                {
                    element.Attributes["style"].Remove();
                }
            }
        }

        public static string RemoveSubjectAbbreviationsFromSubject(string subject)
        {
            if (subject.Length > 3)
            {
                var abbr = subject.Substring(0, 3);
                if (abbr.ToLower() == "re:" || abbr.ToLower() == "fw:")
                {
                    return subject.Substring(3, subject.Length - 3).Trim();
                }
            }
            return subject.Trim();
        }

        public static void MoveFormToCenterAndShow(Form form)
        {
            form.StartPosition = FormStartPosition.Manual;
            dynamic window = Globals.ThisAddIn.Application.ActiveWindow();
            form.Location = new Point(window.Left + ((window.Width - form.Width) / 2), window.Top + ((window.Height - form.Height) / 2));
            form.Show();
        }

        public static CancellationToken GetCancellationToken(int seconds) => (new CancellationTokenSource(TimeSpan.FromSeconds(seconds))).Token;
    }
}
