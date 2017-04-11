using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace awesome_bot.Dialogs
{
    internal static class CommandHandlerFactory
    {
        private static readonly List<ICommandHandler> CommandHandlers =
            new List<ICommandHandler>
            {
                new PickCommand()
            };

        public static ICommandHandler Handle(string command)
            => CommandHandlers.FirstOrDefault(x => x.Commands.Any(c => c == command));

        public static string GetGuide()
        {
            var builder = new StringBuilder();
            builder.AppendLine("That's what you can ask me:");

            foreach (var commandHandler in CommandHandlers)
                builder.AppendLine(commandHandler.GetHelp());

            return builder.ToString();
        }
    }
}