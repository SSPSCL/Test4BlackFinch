namespace T4BF
{
    /// <summary>
    /// Implementation of IWriteLoanService.
    /// </summary>
    public class WriteLoanService : IWriteLoanService
    {
        // The number of applicants to date.
        private uint applicantsToDate;

        // A list of all LTV values for all applications.
        private List<decimal> loanToValueRatioAllApplications = new List<decimal> ();

        // The number of successful applicants to date.
        private uint successfulApplicantsToDate;

        // The number of unsuccessful applicants to date.
        private uint unsuccessfulApplicantsToDate;

        // The total value of loans written to date.
        private decimal valueOfLoansWritten;

        /// <summary>
        /// This method accepts information about a loan application and returns an outcome.
        /// </summary>
        /// <param name="loanAmount">The loan amount.</param>
        /// <param name="securityValue">The security value.</param>
        /// <param name="creditScore">The credit score.</param>
        /// <returns>A LoanDecisionOutcome containing relevant response data.</returns>
        public LoanDecisionOutcome DecideLoan (decimal loanAmount, decimal securityValue, uint creditScore)
        {
            // Validate inputs again. In a real implementation this would be server side, whereas the parser would likely be client side.
            if (loanAmount <= 0)
            {
                throw new ArgumentOutOfRangeException (nameof (loanAmount));
            }
            if (securityValue <= 0)
            {
                throw new ArgumentOutOfRangeException (nameof (securityValue));
            }
            if ((creditScore < 1) || (creditScore >  999))
            {
                throw new ArgumentOutOfRangeException (nameof (creditScore));
            }

            var loanToValue = loanAmount / securityValue;

            var success = false;
            // M suffix means decimal type literal. Typeof (10M) = typeof (decimal).
            // Loan must be declined if less than 100K or > 1.5M.
            if (!((loanAmount < 100000M) || (loanAmount > 1500000M)))
            {
                if (loanAmount >= 1000000M)
                {
                    if ((loanToValue <= 0.6M) && (creditScore >= 950))
                    {
                        success = true;
                    }
                }
                else
                {
                    // All loans where LTV >= 90% must be declined 
                    if (loanToValue < 0.9M)
                    {
                        if ((loanToValue < 0.6M) && (creditScore >= 750))
                        {
                            success = true;
                        }
                        if ((loanToValue < 0.8M) && (creditScore >= 800))
                        {
                            success = true;
                        }
                        if ((loanToValue < 0.9M) && (creditScore >= 900))
                        {
                            success = true;
                        }
                    }
                }
            }

            applicantsToDate += 1;
            loanToValueRatioAllApplications.Add (loanToValue);
            if (success)
            {
                successfulApplicantsToDate += 1;
                valueOfLoansWritten += loanAmount;
            }
            else
            {
                unsuccessfulApplicantsToDate += 1;
            }

            var result = new LoanDecisionOutcome ()
            {
                ApplicantsToDate = applicantsToDate,
                PercentageApplicantsSuccessful = 100 * ((decimal) successfulApplicantsToDate) / ((decimal) applicantsToDate),
                PercentageApplicantsUnsuccessful = 100 * ((decimal) unsuccessfulApplicantsToDate) / ((decimal) applicantsToDate),
                PercentageMeanAverageLoanToValueAllApplications = 100 * loanToValueRatioAllApplications.Average (),
                Success = success,
                SuccessfulApplicantsToDate = successfulApplicantsToDate,
                UnsuccessfulApplicantsToDate = unsuccessfulApplicantsToDate,
                ValueOfLoansToDate = valueOfLoansWritten
            };

            return result;
        }
    }
}
