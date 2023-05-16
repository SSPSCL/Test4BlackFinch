namespace T4BF
{
    /// <summary>
    /// The interface to IWriteLoanService.
    /// </summary>
    public interface IWriteLoanService
    {
        /// <summary>
        /// This method accepts information about a loan application and returns an outcome.
        /// </summary>
        /// <param name="loanAmount">The loan amount.</param>
        /// <param name="securityValue">The security value.</param>
        /// <param name="creditScore">The credit score.</param>
        /// <returns>A LoanDecisionOutcome containing relevant response data.</returns>
        LoanDecisionOutcome DecideLoan (decimal loanAmount, decimal securityValue, uint creditScore);
    }
}
