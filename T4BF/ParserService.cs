namespace T4BF
{
    /// <summary>
    /// Implementation of IParserService.
    /// </summary>
    public class ParserService : IParserService
    {
        /// <summary>
        /// A method which parses a command and extracts parameters.
        /// </summary>
        /// <param name="command">The string to parse.</param>
        /// <returns>A CommandParameters object representing the command.</returns>
        public CommandParameters ParseCommand (string command)
        {
            if (command == null)
            {
                throw new ArgumentNullException (nameof (command));
            }

            var commandParts = command.Split (' ').Select (soughtCommandPart => soughtCommandPart.Trim ()).ToArray ();
            if (commandParts.Length == 0)
            {
                return new UnknownCommand ();
            }

            var commandWord = commandParts [0].ToUpper ();
            switch (commandWord)
            {
                case "EXIT":
                    return new ExitCommand ();

                case "WRITELOAN":
                    return ParseWriteLoan (commandParts);

                default:
                    return new UnknownCommand ();
            }
        }

        // This is a private method. Its parameter is known not to be null and to have at least one element.
        private WriteLoanCommand ParseWriteLoan(string [] commandParts)
        {
            if (commandParts.Length != 4)
            {
                return new WriteLoanCommand () { Valid = false };
            }

            decimal loanAmount;
            decimal securityValue;
            uint creditScore;

            // Parsability validation.
            if (!decimal.TryParse (commandParts [1], out loanAmount))
            {
                return new WriteLoanCommand () { Valid = false };
            }
            if (!decimal.TryParse (commandParts [2], out securityValue))
            {
                return new WriteLoanCommand () { Valid = false };
            }
            if (!uint.TryParse (commandParts [3], out creditScore))
            {
                return new WriteLoanCommand () { Valid = false };
            }

            // Basic input logical validation.
            if (loanAmount <= 0)
            {
                return new WriteLoanCommand () { Valid = false };
            }
            if (securityValue <= 0)
            {
                return new WriteLoanCommand () { Valid = false };
            }
            if ((creditScore < 1) || (creditScore > 999))
            {
                return new WriteLoanCommand () { Valid = false };
            }

            return new WriteLoanCommand ()
            {
                CreditScore = creditScore,
                LoanAmount = loanAmount,
                SecurityValue = securityValue,
                Valid = true
            };
        }
    }
}
