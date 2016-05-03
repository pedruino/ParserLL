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
    class Parser
    {
        private Stack<Lexeme> _readLexemesStack;
        private Stack<eToken> _expectedTokenStack;
        private Grammar _grammar;

        public Parser(Expression expression)
        {
            this._grammar = new Grammar();
            this._readLexemesStack = this.CreateStackOfLexemes(expression);
            this._expectedTokenStack = new Stack<eToken>(new[] { eToken.End, eToken.Start });
        }

        public void Analyze()
        {
            while (this._readLexemesStack.Peek().Token != eToken.End)
            {
                var readLexeme = this._readLexemesStack.Peek();
                var expectedToken = this._expectedTokenStack.Peek();

                if (expectedToken == readLexeme.Token)
                {
                    this._expectedTokenStack.Pop();
                    this._readLexemesStack.Pop();
                }
                else if (expectedToken == eToken.Empty)
                {
                    this._expectedTokenStack.Pop();
                }
                else if (expectedToken != eToken.Error)
                {
                    this._expectedTokenStack.Pop();

                    var nextExpectedTokenSet = this.FindInGrammarByKey(expectedToken, readLexeme.Token);
                    foreach (var item in nextExpectedTokenSet.Reverse())
                        this._expectedTokenStack.Push(item);
                }
                else
                {
                    Notification.ShowErrorMessage($"Erro de sintaxe. Caractere {readLexeme.Value} inesperado na posição {readLexeme.Index} ");
                    break;
                }
            }
        }

        private Stack<Lexeme> CreateStackOfLexemes(Expression expression)
        {
            var endFakeLexeme = new Lexeme() { Index = expression.Lexemes.Count() - 1, Token = eToken.End, Value = null };
            var newStack = new Stack<Lexeme>(new[] { endFakeLexeme });

            foreach (var item in expression.Lexemes.Reverse())
                newStack.Push(item);

            return newStack;
        }

        private Stack<eToken> FindInGrammarByKey(eToken expectedToken, eToken readToken)
        {
            return this._grammar.FindByKey(expectedToken, readToken);
        }
    }
}
