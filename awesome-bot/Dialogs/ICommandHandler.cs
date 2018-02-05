using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace awesome_bot.Dialogs
{
    internal interface ICommandHandler
    {
        IEnumerable<string> Keywords { get; }

        IEnumerable<string> Commands { get; }

        Task Answer(IDialogContext context, Activity activity, string args);

        string GetHelp();
    }
}