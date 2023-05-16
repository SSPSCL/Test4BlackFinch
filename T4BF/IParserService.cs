namespace T4BF
{
    /// <summary>
    /// Represents a parser service that parses text input and returns strongly typed parameters.
    /// </summary>
    public interface IParserService
    {
        /// <summary>
        /// A method which parses a command and extracts parameters.
        /// </summary>
        /// <param name="command">The string to parse.</param>
        /// <returns>A CommandParameters object representing the command.</returns>
        CommandParameters ParseCommand (string command);
    }
}
