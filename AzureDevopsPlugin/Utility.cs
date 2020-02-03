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
        private static T GetTFSHttpClient<T>() where T: VssHttpClientBase
        {
            var valid = Settings.settings.Validate();
            if (valid)
            {
                var u = new Uri($"https://dev.azure.com/" + Settings.settings.OrgName);
                VssCredentials c = new VssCredentials(new VssBasicCredential(string.Empty, Settings.settings.PatToken));
                var connection = new VssConnection(u, c);
                return connection.GetClient<T>();
            }

            return null;
        }

        /// <summary>
        /// Create attachment in azure devops
        /// </summary>
        /// <param name="filePath">file to copy</param>
        /// <returns></returns>
        public static AttachmentReference CreateAttachment(string filePath)
        {
            var workitemClient = GetTFSHttpClient<WorkItemTrackingHttpClient>();
            if (workitemClient != null)
            {
                using (FileStream attStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    var fileName = Path.GetFileName(filePath);
                    return workitemClient.CreateAttachmentAsync(attStream, uploadType: "simple", fileName: fileName).Result; // upload the file

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
        public static WorkItem CreateWorkItem(string title, string description, string category, Attachments attachments = null, bool withAttachments = false)
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
                        var savedAttachment = CreateAttachment(savePath);
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

                return workitemClient.CreateWorkItemAsync(document, Settings.settings.ProjectName, Settings.settings.WorkItemType).Result;
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
        public static Comment AddCommentToWorkItem(int workItemId, string comment, Attachments attachments = null, bool withAttachments = false)
        {
            var workItemsClient = GetTFSHttpClient<WorkItemTrackingHttpClient>();
            if (workItemsClient != null)
            {
                var workItem = workItemsClient.GetWorkItemAsync(workItemId).Result;
                if (withAttachments && attachments?.Count > 0)
                {
                    var updateDocument = new JsonPatchDocument();
                    var i = 1;
                    foreach (Attachment att in attachments)
                    {
                        var savePath = System.IO.Path.GetTempPath() + att.FileName;
                        att.SaveAsFile(savePath);
                        var attachment = CreateAttachment(savePath);
                        updateDocument.Add(CreateAttachmentJsonPatchOperation(attachment));
                        comment += $"<br>attachment {i} file name: {att.FileName}";
                        File.Delete(savePath);
                        i++;
                    }
                    workItemsClient.UpdateWorkItemAsync(updateDocument, workItem.Id.Value).Wait();
                }
                return workItemsClient.AddCommentAsync(new CommentCreate { Text = comment }, Settings.settings.ProjectName, workItem.Id.Value).Result;
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

                try
                {
                    var result = await workitemClient.QueryByWiqlAsync(wiql);
                    if (result.WorkItems.Count() > 0)
                    {
                        var workItems = workitemClient.GetWorkItemsAsync(result.WorkItems.Select(a => a.Id), new List<string> { "System.State", "System.Title" }).Result;
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
                catch (System.Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        MessageBox.Show("Errors occured: message = " + ex.InnerException.Message);
                    }
                    else
                    {
                        MessageBox.Show("Errors occured: message = " + ex.Message);
                    }
                    throw;
                }

            }
            throw new System.Exception("bad settings file");
        }

        //public static (IList<string> ,string) CheckCategoryExistsAndGetCustomFieldPickList(string customField, string workItemType)
        //{
        //    var witClient = GetTFSHttpClient<WorkItemTrackingHttpClient>();
        //    var witTrackingClient = GetTFSHttpClient<WorkItemTrackingProcessHttpClient>();
        //    string errors = "";
        //    var patIsValid = true;
        //    try
        //    {
        //        witClient.GetWorkItemTypeAsync(Settings.settings.ProjectName, workItemType).Wait();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        if (ex.InnerException != null)
        //        {
        //            errors += "\n" + ex.InnerException.Message;
        //            if (ex.InnerException is VssUnauthorizedException)
        //            {
        //                return (null, errors);
        //            }
        //        }
        //        else
        //        {
        //            errors += "\n" + ex.Message;
        //        }
        //    }

        //    IList<string> pickListValues;
        //    if (patIsValid)
        //    {
        //        var refName = "Custom." + customField;
        //        try
        //        {
        //            pickListValues = GetCustomFieldPickListValue(refName);
        //        }
        //        catch (System.Exception ex)
        //        {
        //            if (ex.InnerException != null)
        //            {
        //                errors += "\n" + ex.InnerException.Message;
        //                if (ex.InnerException is VssUnauthorizedException)
        //                {
        //                    return (null, errors); ;
        //                }
        //            }
        //            else
        //            {
        //                errors += "\n" + ex.Message;
        //            }
        //        }
        //    }

        //    return (null, errors); ;
        //}

        public static IList<string> GetCustomFieldPickListValue(string fieldName)
        {
            var witClient = GetTFSHttpClient<WorkItemTrackingHttpClient>();
            var witTrackingClient = GetTFSHttpClient<WorkItemTrackingProcessHttpClient>();
            if (witClient == null && witTrackingClient == null)
            {
                throw new System.Exception("bad configs file");
            }

            var field =  witClient.GetFieldAsync("Custom." + fieldName).Result;
            if (field.IsPicklist)
            {
                var pickList = witTrackingClient.GetListAsync(field.PicklistId.Value).Result;
                return pickList.Items;
            }
            else
            {
                throw new System.Exception(fieldName + " field is not picklist");
            }
        }

        /// <summary>
        /// Get last reply from message
        /// </summary>
        /// <param name="mailItem"></param>
        /// <returns></returns>
        public static string GetLastMessageFromMessageHTMLBody(MailItem mailItem)
        {
            HtmlAgilityPack.HtmlDocument htmlSnippet = new HtmlAgilityPack.HtmlDocument();
            htmlSnippet.LoadHtml(mailItem.HTMLBody);
            var divsByWordSection1Class = htmlSnippet.DocumentNode.SelectNodes("//div[@class = 'WordSection1']");
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

                return borderSplitted[0];
            }

            //var htmlSplittedByOriginalMessageLabel = html.Split(new string[] { "----Original Message-----" }, StringSplitOptions.None);
            //if (htmlSplittedByOriginalMessageLabel.Length > 1)
            //{
            //    return htmlSplittedByOriginalMessageLabel[0].Trim();
            //}

            /// finding last reply for messages sent from email
            var divsByLtrDir = htmlSnippet.DocumentNode.SelectNodes("//div[@dir = 'ltr']");
            if (divsByLtrDir?.Count > 0)
            {
                return divsByLtrDir[0].OuterHtml.Trim();
            }
            return mailItem.HTMLBody;
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
    }
}
