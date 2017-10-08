using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using awesome_bot.Dialogs;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace awesome_bot.Giphy
{
    public class GiphyCommand : ICommandHandler
    {
        public IEnumerable<string> Commands { get; } = new HashSet<string>
        {
            "gif",
            "giphy"
        };

        public async Task Answer(IDialogContext context, Activity activity, string args)
        {
            var build = GiphyEndPoints.Random.Build(args);

            try
            {
                using (var wc = new WebClient())
                {
                    var rawData = await wc.DownloadStringTaskAsync(build);

                    var giphyResponse = GiphyResponse.FromJson(rawData);

                    var animationCard =
                        new AnimationCard(media: new List<MediaUrl>
                        {
                            new MediaUrl(giphyResponse.Data.ImageOriginalUrl)
                        });

                    var reply = activity.CreateReply();
                    reply.Attachments.Add(animationCard.ToAttachment());

                    await context.PostAsync(reply);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            //Console.WriteLine(html);

            //if (items.Count < 1)
            //{
            //    await context.PostAsync("I don't know what to choose");
            //    return;
            //}
            //if (items.Count == 1)
            //{
            //    await context.PostAsync($"I definitely choose {items[0]}");
            //    return;
            //}

            //try
            //{
            //    var chosenItem = items[_random.Next(0, items.Count)];

            //    await context.PostAsync($"I randomly choose {chosenItem}");
            //}
            //catch (Exception exception)
            //{
            //    await context.PostAsync("Sorry I didn't understand");
            //    await context.PostAsync("Usage: " + GetHelp());
            //}
        }

        public string GetHelp() => throw new NotImplementedException();
    }
}