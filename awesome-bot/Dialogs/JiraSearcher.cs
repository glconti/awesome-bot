using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Configuration;
using Atlassian.Jira;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace awesome_bot.Dialogs
{
    public class JiraSearcher : ICommandHandler
    {
        private static readonly IReadOnlyList<string> InnerKeywords =
            WebConfigurationManager.AppSettings["JiraTicketKeywords"].Split(',').ToList();

        private static readonly Regex Regex = new Regex($@"(?<ticket>({string.Join("|", InnerKeywords)})-\d+)",
            RegexOptions.Compiled);

        private static string JiraAddress { get; } = WebConfigurationManager.AppSettings["JiraEndpoint"];

        private static string JiraUser { get; } = WebConfigurationManager.AppSettings["AtlassianUser"];

        private static string JiraApiToken { get; } = WebConfigurationManager.AppSettings["AtlassianAPIKey"];

        public IEnumerable<string> Keywords => InnerKeywords;

        public IEnumerable<string> Commands { get; } = Enumerable.Empty<string>();

        public async Task Answer(IDialogContext context, Activity activity, string message)
        {
            try
            {
                var matchCollection = Regex.Matches(message);

                if (matchCollection.Count == 0) return;

                var tickets = new HashSet<string>();

                foreach (Match o in matchCollection) tickets.Add(o.Groups["ticket"].Value);

                if (tickets.Count == 0) return;

                var jira = Jira.CreateRestClient(JiraAddress, JiraUser, JiraApiToken);

                var searches = tickets.OrderBy(t => t).Select(t => (Ticket: t, Task: jira.Issues.GetIssueAsync(t)))
                    .ToArray();

                await Task.WhenAll(searches.Select(t => t.Task));

                var thumbnailCards = searches.Select(search =>
                {
                    var issue = search.Task.Result;

                    if (issue == null) new ThumbnailCard(search.Ticket, "Not found").ToAttachment();

                    return new ThumbnailCard(issue.Key.ToString(), issue.Summary).ToAttachment();
                }).ToList();


                var reply = context.MakeMessage();

                reply.AttachmentLayout = AttachmentLayoutTypes.List;
                reply.Attachments = thumbnailCards;

                await context.PostAsync(reply);
            }
            catch (Exception e)
            {
                Trace.TraceError(string.Join(Environment.NewLine,
                    "Error during random choice",
                    e.Message,
                    e.StackTrace));

                await context.PostAsync("Ops, something went wrong");
                await context.PostAsync("Usage: " + GetHelp());
            }
        }

        public string GetHelp() => string.Join("|", Commands) + " item1, item2, item3, ...";
    }
}