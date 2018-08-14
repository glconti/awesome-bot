using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using awesome_bot.Dialogs;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace awesome_bot.Giphy
{
    public class GiphyCommand : ICommandHandler
    {
        public IEnumerable<string> Keywords { get; } = Enumerable.Empty<string>();

        public IEnumerable<string> Commands { get; } = new HashSet<string>
        {
            "gif",
            "giphy"
        };

        public async Task Answer(IDialogContext context, Activity activity, string args)
        {
            args = Commands.Aggregate(args, (current, command) => current.Replace(command, string.Empty));

            var build = GiphyEndPoints.Search.Build(args);

            try
            {
                using (var wc = new WebClient())
                {
                    var rawData = await wc.DownloadStringTaskAsync(build);
                    var giphyResponse = GiphyResponse.FromJson(rawData);

                    var reply = activity.CreateReply();
                    reply.TextFormat = TextFormatTypes.Xml;

                    var data = giphyResponse.Data[0];
                    reply.Text =
                        $"<img src=\"{data.Images.Original["url"]}\" alt=\"{data.Title}\" height=\"{data.Images.Original["height"]}\" width=\"{data.Images.Original["width"]}\" />";

                    await context.PostAsync(reply);
                }
            }
            catch (Exception e)
            {
                Trace.TraceError(string.Join(Environment.NewLine,
                    "Error during random gif search",
                    e.Message,
                    e.StackTrace));

                await context.PostAsync("Ops, something went wrong");
                await context.PostAsync("Usage: " + GetHelp());
            }
        }

        public string GetHelp() => string.Join("|", Commands) + " search text";
    }
}