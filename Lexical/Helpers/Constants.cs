namespace Lexical.Helpers
{
    public static class Constants
    {
        public static class RegexPattern
        {
            public const string Identifier = @"[a-zA-Z]+";
            public const string Number = @"(?:\d*\.)?\d+";//old @"([0-9]+(\.[0-9])?)+"
            public const string ParenthesisLeft = @"\(";
            public const string ParenthesisRight = @"\)";
            public const string OperatorAddition = @"\+";
            public const string OperatorSubtraction = @"\-";
            public const string OperatorMultiply = @"\*";
            public const string OperatorDivision = @"\/";
            public const string OperatorPower = @"\^";
            public const string OperatorAssignment = @"\=";
            public const string Whitespace = @"\s+";

        }

        public static class Messages
        {
            public const string InvalidCharacterException = "A expressão digitada está contém caracteres inválidos.";
        }
    }
}
