using HtmlAgilityPack;
using Microsoft.Office.Interop.Outlook;
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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDevopsPlugin
{
    public class Utility
    {
        private static WorkItemTrackingHttpClient GetWorkItemTrackingHttpClient()
        {
            var valid = Settings.settings.Validate();
            if (valid)
            {
                var u = new Uri($"https://dev.azure.com/" + Settings.settings.OrgName);
                VssCredentials c = new VssCredentials(new VssBasicCredential(string.Empty, Settings.settings.PatToken));
                var connection = new VssConnection(u, c);

                return connection.GetClient<WorkItemTrackingHttpClient>();
            }

            return null;
        }

        public static AttachmentReference CreateAttachment(string filePath)
        {
            var workitemClient = GetWorkItemTrackingHttpClient();
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

        public static WorkItem CreateWorkItem(string title, string description, string category, Attachments attachments = null, bool withAttachments = false)
        {
            var workitemClient = GetWorkItemTrackingHttpClient();
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
                    Path = "/fields/System.Tags",
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

        public static Comment AddCommentToWorkItem(int workItemId, string comment, Attachments attachments = null, bool withAttachments = false)
        {
            var workItemsClient = GetWorkItemTrackingHttpClient();
            if (workItemsClient != null)
            {
                var workItem = workItemsClient.GetWorkItemAsync(workItemId).Result;
                if (withAttachments && attachments != null)
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

        public static List<Models.WorkItem> FindWorkItemsByTitle(string title)
        {
            var workitemClient = GetWorkItemTrackingHttpClient();
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
                        "And [System.Title] = '" + title.Replace("'", "''") + "' " +
                        "And [System.State] <> 'Closed' " +
                        "Order By [State] Asc, [Changed Date] Desc",
                };

                var result = workitemClient.QueryByWiqlAsync(wiql).Result;
                if (result.WorkItems.Count() > 0)
                {
                    var workItems = workitemClient.GetWorkItemsAsync(result.WorkItems.Select(a => a.Id), new List<string> { "System.State" }).Result;
                    foreach (var workItem in workItems)
                    {
                        if (!workItem.Id.HasValue)
                        {
                            continue;
                        }

                        list.Add(new Models.WorkItem { Id = workItem.Id.Value, State = (string)workItem.Fields["System.State"], Url = workItem.Url });
                    }
                }

                return list;
            }
            throw new System.Exception("bad settings file");
        }

        public static string GetLastMessageFromMessageHTMLBody(MailItem mailItem)
        {
            HtmlDocument htmlSnippet = new HtmlDocument();
            htmlSnippet.LoadHtml(mailItem.HTMLBody);
            var divsByWordSection1Class = htmlSnippet.DocumentNode.SelectNodes("//div[@class = 'WordSection1']");
            if (divsByWordSection1Class?.Count > 0)
            {
                var borderSplitted = divsByWordSection1Class[0].OuterHtml.Split(new string[] { "<div style=\"border" }, StringSplitOptions.None);
                if (borderSplitted.Length == 1)
                {
                    borderSplitted = borderSplitted[0].Split(new string[] { "<div style='border" }, StringSplitOptions.None);
                    //if (borderSplitted.Length == 1)
                    //{
                    //    borderSplitted = borderSplitted[0].Split(new string[] { $"[mailto:{mailItem.SenderEmailAddress}]" }, StringSplitOptions.None);
                    //}
                }

                return borderSplitted[0];
            }

            //var htmlSplittedByOriginalMessageLabel = html.Split(new string[] { "----Original Message-----" }, StringSplitOptions.None);
            //if (htmlSplittedByOriginalMessageLabel.Length > 1)
            //{
            //    return htmlSplittedByOriginalMessageLabel[0].Trim();
            //}

            var divsByLtrDir = htmlSnippet.DocumentNode.SelectNodes("//div[@dir = 'ltr']");
            if (divsByLtrDir?.Count > 0)
            {
                return divsByLtrDir[0].OuterHtml.Trim();
            }
            return mailItem.HTMLBody;
        }
    }
}
