using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using awesome_bot.Giphy;

namespace awesome_bot.Dialogs
{
    internal static class CommandHandlerFactory
    {
        private static readonly List<ICommandHandler> CommandHandlers =
            new List<ICommandHandler>
            {
                new PickCommand(),
                new GiphyCommand(),
                new JiraSearcher()
            };

        public static ICommandHandler Handle(string message)
        {
            return CommandHandlers.FirstOrDefault(x => x.Keywords.Any(message.Contains)) ?? HandleCommand(message);
        }

        public static ICommandHandler HandleCommand(string message)
        {
            var words = message.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var command = words.FirstOrDefault();

            var commandHandler = CommandHandlers.FirstOrDefault(x =>
                x.Commands.Any(c => string.Equals(c, command, StringComparison.OrdinalIgnoreCase)));

            return commandHandler;
        }

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