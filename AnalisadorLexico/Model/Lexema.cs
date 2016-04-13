using AnalisadorLexico.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisadorLexico.Model
{
    class Lexema
    {
        private string _value;    

        public int Index { get; set; }
        public string Value
        {
            get { return "'" + _value + "'"; }
            set { _value = value; }

        }
        public EToken Token { get; set; }
    }
}
