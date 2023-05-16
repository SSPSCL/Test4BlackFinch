namespace T4BF
{
    /// <summary>
    /// The specific command parameters class for a WriteLoan command.
    /// </summary>
    public class WriteLoanCommand : CommandParameters
    {
        /// <summary>
        /// Default constructor for a WriteLoan command.
        /// </summary>
        public WriteLoanCommand()
        {
            CommandType = CommandType.WriteLoan;
        }

        /// <summary>
        /// The loan amount the applicant is seeking.
        /// </summary>
        public decimal LoanAmount { get; set; }

        /// <summary>
        /// The security value.
        /// </summary>
        public decimal SecurityValue { get; set; }

        /// <summary>
        /// The credit score.
        /// </summary>
        public uint CreditScore { get; set; }
    }
}
