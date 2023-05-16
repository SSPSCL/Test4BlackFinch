namespace T4BF
{
    /// <summary>
    /// Represents an unknown command.
    /// </summary>
    public class UnknownCommand : CommandParameters
    {
        /// <summary>
        /// An unknown command is by definition invalid. This constructor sets the flag by default.
        /// </summary>
        public UnknownCommand()
        {
            CommandType = CommandType.Unknown;
            Valid = false;
        }
    }
}
