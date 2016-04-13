namespace AnalisadorLexico.Helper
{
    static class Constantes
    {
        public static class RegexPattern
        {
            public const string ID = @"[a-zA-Z]+";
            public const string NUM = @"(?:\d*\.)?\d+";//old @"([0-9]+(\.[0-9])?)+"
            public const string DELIM = @"\(|\)|\\n|\\t|\\r|\.";
            public const string OP_ADD = @"\+";
            public const string OP_SUB = @"\-";
            public const string OP_MULT = @"\*";
            public const string OP_DIV = @"\/";
            public const string OP_POW = @"\^";
            public const string ATRIB = @"\=";
            public const string WHITE_SPACE = @"\s+";

        }

        public static class Messages
        {
            public const string INVALID_CHARACTER_EXCEPTION = "A expressão digitada está contém caracteres inválidos.";
        }
    }
}
