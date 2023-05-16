namespace T4BF
{
    /// <summary>
    /// Class represents information about a command.
    /// </summary>
    public abstract class CommandParameters
    {
        /// <summary>
        /// The CommandType of the command.
        /// </summary>
        public CommandType CommandType { get; protected set; }

        /// <summary>
        /// For an identifiable command, whether its parameters are valid. Commands with no required parameters are always valid. Unidentified commands are always invalid.
        /// </summary>
        public bool Valid { get; set; }
    }
}
