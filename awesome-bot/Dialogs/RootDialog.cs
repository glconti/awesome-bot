using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace awesome_bot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private static async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            if (activity == null)
            {
                await context.PostAsync("Do you want to ask me something?");
                context.Wait(MessageReceivedAsync);
                return;
            }

            var message = activity.RemoveRecipientMention().Trim();

            var commandHandler = CommandHandlerFactory.Handle(message);
            if (commandHandler == null)
            {
                await context.PostAsync($"Sorry, I don't understand \"{message}\"");
                await context.PostAsync(CommandHandlerFactory.GetGuide());
                context.Wait(MessageReceivedAsync);
                return;
            }

            await commandHandler.Answer(context, activity, message);

            context.Wait(MessageReceivedAsync);
        }
    }
}