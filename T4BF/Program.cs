namespace T4BF
{

    public static class Program
    {
        private static Dictionary<Type, object> fakeContainer;

        private static IParserService parserService;
        private static IWriteLoanService writeLoanService;

        static Program()
        {
            fakeContainer = new Dictionary<Type, object>();
            fakeContainer.Add (typeof (IParserService), new ParserService ());
            fakeContainer.Add (typeof (IWriteLoanService), new WriteLoanService ());

            parserService = (IParserService) fakeContainer [typeof (IParserService)];
            writeLoanService = (IWriteLoanService) fakeContainer [typeof (IWriteLoanService)];
    }

    static void Main (string [] args)
        {
            CommandType currentCommandType = CommandType.Unknown;
            while (currentCommandType != CommandType.Exit)
            {
                Console.WriteLine ("\nEnter command: ");
                var command = Console.ReadLine ();

                var commandParsed = parserService.ParseCommand (command ?? string.Empty);
                currentCommandType = commandParsed.CommandType;

                switch (commandParsed.CommandType)
                {
                    case CommandType.Unknown:
                        Console.WriteLine ("Command type unknown. Valid commands are Exit and WriteLoan, case insensitive.");
                        break;
                    case CommandType.Exit:
                        break;
                    case CommandType.WriteLoan:
                        WriteLoan ((WriteLoanCommand) commandParsed);
                        break;
                }
            }
        }

        // Command type is known.
        private static void WriteLoan (WriteLoanCommand writeLoanCommand)
        {
            if (writeLoanCommand.Valid == false)
            {
                Console.WriteLine ("WriteLoan command syntax invalid. Syntax WriteLoan <loan amount> <value of security> <credit score>");
                return;
            }

            var loanResult = writeLoanService.DecideLoan (writeLoanCommand.LoanAmount, writeLoanCommand.SecurityValue, writeLoanCommand.CreditScore);

            Console.WriteLine ($"Loan decision: {(loanResult.Success ? "Approved" : "Declined")}");
            Console.WriteLine ($"Applicants to date: {loanResult.ApplicantsToDate}, of which {loanResult.PercentageApplicantsSuccessful:0.00}% were successful and {loanResult.PercentageApplicantsUnsuccessful:0.00}% were unsuccessful.");
            Console.WriteLine ($"Mean loan to value of applications to date: {loanResult.PercentageMeanAverageLoanToValueAllApplications:0.00}%.");
        }
    }
}
