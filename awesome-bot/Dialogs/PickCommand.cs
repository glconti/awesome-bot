using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace awesome_bot.Dialogs
{
    public class PickCommand : ICommandHandler
    {
        private readonly Random _random = new Random();

        public IEnumerable<string> Commands { get; } = new HashSet<string>
        {
            "choose",
            "pick"
        };

        public async Task Answer(IDialogContext context, Activity activity, string args)
        {
            var items = args.Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();

            if (items.Count < 1)
            {
                await context.PostAsync("I don't know what to choose");
                return;
            }
            if (items.Count == 1)
            {
                await context.PostAsync($"I definitely choose {items[0]}");
                return;
            }

            try
            {
                var chosenItem = items[_random.Next(0, items.Count)];

                await context.PostAsync($"I randomly choose {chosenItem}");
            }
            catch (Exception exception)
            {
                await context.PostAsync("Sorry I didn't understand");
                await context.PostAsync("Usage: " + GetHelp());
            }
        }

        public string GetHelp() => string.Join("|", Commands) + " item1, item2, item3, ...";
    }
}