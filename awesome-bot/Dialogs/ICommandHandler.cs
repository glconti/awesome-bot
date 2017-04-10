using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;

namespace awesome_bot.Dialogs
{
    internal interface ICommandHandler
    {
        IEnumerable<string> Commands { get; }

        Task Answer(IDialogContext context, string args);

        string GetHelp();
    }
}