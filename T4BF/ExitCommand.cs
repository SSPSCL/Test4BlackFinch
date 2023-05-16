namespace T4BF
{
    /// <summary>
    /// Represents an exit command parameters.
    /// </summary>
    public class ExitCommand : CommandParameters
    {
        /// <summary>
        /// An exit command has no parameters and is always valid. This default constructor sets it valid.
        /// </summary>
        public ExitCommand()
        {
            CommandType = CommandType.Exit;
            Valid = true;
        }
    }
}
