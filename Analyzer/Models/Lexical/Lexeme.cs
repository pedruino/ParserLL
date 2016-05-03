using Analyzer.DataTypes.Enums;

namespace Analyzer.Models.Lexical
{
    class Lexeme
    {
        private string _value;    

        public int Index { get; set; }
        public string Value
        {
            get { return "'" + _value + "'"; }
            set { _value = value; }

        }
        public eToken Token { get; set; }
    }
}
