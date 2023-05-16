namespace T4BF
{
    /// <summary>
    /// Enumeration representing the command type of a parsed command.
    /// </summary>
    public enum CommandType
    {
        /// <summary>
        /// The user has entered an unrecognised command.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// The user has entered an exit command.
        /// </summary>
        Exit = 1,

        /// <summary>
        /// The user has entered a write loan command.
        /// </summary>
        WriteLoan = 2
    }
}
