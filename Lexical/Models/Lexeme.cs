using Lexical.DataTypes.Enums;
using Lexical.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexical.Models
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
