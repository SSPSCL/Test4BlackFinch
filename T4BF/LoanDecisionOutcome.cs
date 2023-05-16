namespace T4BF
{
    /// <summary>
    /// Represents a loan decision outcome.
    /// </summary>
    public class LoanDecisionOutcome
    {
        /// <summary>
        /// The number of applicants to date.
        /// </summary>
        public uint ApplicantsToDate { get; set; }

        /// <summary>
        /// The percentage of successful applicants to date.
        /// </summary>
        public decimal PercentageApplicantsSuccessful { get; set; }

        /// <summary>
        /// The percentage of unsuccessful applicants to date.
        /// </summary>
        public decimal PercentageApplicantsUnsuccessful { get; set; }

        /// <summary>
        /// The mean average of the loan to value ratio of loans written.
        /// </summary>
        public decimal PercentageMeanAverageLoanToValueAllApplications { get; set; }

        /// <summary>
        /// The number of successful applicants to date.
        /// </summary>
        public uint SuccessfulApplicantsToDate { get; set; }

        /// <summary>
        /// The number of unsuccessful applicants to date.
        /// </summary>
        public uint UnsuccessfulApplicantsToDate { get; set; }

        /// <summary>
        /// The total value of loans written to date.
        /// </summary>
        public decimal ValueOfLoansToDate { get; set; }

        /// <summary>
        /// Whether the application was successful.
        /// </summary>
        public bool Success { get; set;}
    }
}
