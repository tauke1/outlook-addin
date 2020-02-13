using HtmlAgilityPack;
using System;

namespace AzureDevopsPlugin.Utilities
{
    /// <summary>
    /// Utility which contains helper functions
    /// </summary>
    public class HtmlUtility
    {
        /// <summary>
        /// Get TFS client
        /// </summary>
        /// <returns></returns>
        
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


    }
}
