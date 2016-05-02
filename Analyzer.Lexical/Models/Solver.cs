using Lexical.DataTypes.Enums;
using Lexical.Models;
using Lexical.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzer.Lexical.Models
{
    class Solver
    {
        private Stack<eToken> _readTokenStack;
        private Stack<eToken> _expectedTokenStack;
        private Grammar _grammar;

        public Solver(Expression expression)
        {
            this._grammar = new Grammar();
            this._readTokenStack = new Stack<eToken>(expression.Lexemes.Reverse().Select(x => x.Token));
            this._expectedTokenStack = new Stack<eToken>(new[] {eToken.End, eToken.Start });
        }

        public void Analyze()
        {
            while (this._readTokenStack.Any())
            {
                var readToken = this._readTokenStack.Peek();

                Compare(readToken, this._expectedTokenStack.Peek());
            }
        }

        private void Compare(eToken readToken, eToken expectedToken)
        {
            try
            {
                if (readToken == expectedToken)
                {
                    this._expectedTokenStack.Pop();
                    this._readTokenStack.Pop();
                }
                else if(this._expectedTokenStack.Peek() == eToken.Empty)
                {
                    this._expectedTokenStack.Pop();
                }
                else if(this._expectedTokenStack.Peek() != eToken.Error){
                    this._expectedTokenStack.Pop();

                    var nextExpectedTokenSet = this.FindInGrammarByKey(expectedToken, readToken);
                    foreach (var item in nextExpectedTokenSet.Reverse())
                        this._expectedTokenStack.Push(item);

                    this.Compare(readToken, this._expectedTokenStack.Peek());
                }
            }
            catch (Exception e)
            {
                Notification.ShowErrorMessage(e.Message);
            }
        }

        private Stack<eToken> FindInGrammarByKey(eToken expectedToken, eToken readToken)
        {
            return this._grammar.FindByKey(expectedToken, readToken);
        }
    }
}
