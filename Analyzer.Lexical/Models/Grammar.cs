using Lexical.DataTypes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzer.Lexical.Models
{
    class Grammar : Dictionary<Tuple<eToken, eToken>, Stack<eToken>>
    {
        private Tuple<eToken, eToken> _tuple;

        public Grammar()
        {
            this.CreateRuleStart();
            this.CreateRuleExpression();
            this.CreateRuleExpressionL();
            this.CreateRuleTerm();
            this.CreateRuleTermL();
            this.CreateRuleFator();
            this.CreateRuleFatorL();
            this.CreateRuleNumero();

            //this.Add(Tuple.CreateUsingKey(eToken.Start).ForValues(eToken.Identifier));

            //this.Add(Tuple.CreateUsingKey(eToken.Identifier).ForValues(eToken.Identifier, eToken.OperatorAssignment, eToken.Expression));

            //this.Add(Tuple.CreateUsingKey(eToken.Start).ForValues(eToken.End));

        }

        private void CreateRuleNumero()
        {
            this.CreateUsingKeys(eToken.Numero, eToken.Identifier).WithValues(eToken.Identifier);
            this.CreateUsingKeys(eToken.Numero, eToken.OperatorAssignment).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Numero, eToken.OperatorAddition).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Numero, eToken.OperatorSubtraction).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Numero, eToken.OperatorMultiply).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Numero, eToken.OperatorDivision).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Numero, eToken.OperatorPower).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Numero, eToken.ParenthesisLeft).WithValues(eToken.ParenthesisRight, eToken.Expression, eToken.ParenthesisLeft);
            this.CreateUsingKeys(eToken.Numero, eToken.ParenthesisRight).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Numero, eToken.Number).WithValues(eToken.Number);
            this.CreateUsingKeys(eToken.Numero, eToken.End).WithValues(eToken.Error);
        }

        private void CreateRuleFatorL()
        {
            this.CreateUsingKeys(eToken.FatorL, eToken.Identifier).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.FatorL, eToken.OperatorAssignment).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.FatorL, eToken.OperatorAddition).WithValues(eToken.Empty);
            this.CreateUsingKeys(eToken.FatorL, eToken.OperatorSubtraction).WithValues(eToken.Empty);
            this.CreateUsingKeys(eToken.FatorL, eToken.OperatorMultiply).WithValues(eToken.Empty);
            this.CreateUsingKeys(eToken.FatorL, eToken.OperatorDivision).WithValues(eToken.Empty);
            this.CreateUsingKeys(eToken.FatorL, eToken.OperatorPower).WithValues(eToken.FatorL, eToken.Numero, eToken.OperatorPower);
            this.CreateUsingKeys(eToken.FatorL, eToken.ParenthesisLeft).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.FatorL, eToken.ParenthesisRight).WithValues(eToken.Empty);
            this.CreateUsingKeys(eToken.FatorL, eToken.Number).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.FatorL, eToken.End).WithValues(eToken.Empty);
        }

        private void CreateRuleFator()
        {
            this.CreateUsingKeys(eToken.Fator, eToken.Identifier).WithValues(eToken.FatorL, eToken.Numero);
            this.CreateUsingKeys(eToken.Fator, eToken.OperatorAssignment).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Fator, eToken.OperatorAddition).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Fator, eToken.OperatorSubtraction).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Fator, eToken.OperatorMultiply).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Fator, eToken.OperatorDivision).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Fator, eToken.OperatorPower).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Fator, eToken.ParenthesisLeft).WithValues(eToken.FatorL, eToken.Numero);
            this.CreateUsingKeys(eToken.Fator, eToken.ParenthesisRight).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Fator, eToken.Number).WithValues(eToken.FatorL, eToken.Numero);
            this.CreateUsingKeys(eToken.Fator, eToken.End).WithValues(eToken.Error);
        }

        private void CreateRuleTermL()
        {
            this.CreateUsingKeys(eToken.TermL, eToken.Identifier).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.TermL, eToken.OperatorAssignment).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.TermL, eToken.OperatorAddition).WithValues(eToken.Empty);
            this.CreateUsingKeys(eToken.TermL, eToken.OperatorSubtraction).WithValues(eToken.Empty);
            this.CreateUsingKeys(eToken.TermL, eToken.OperatorMultiply).WithValues(eToken.TermL, eToken.Fator, eToken.OperatorMultiply);
            this.CreateUsingKeys(eToken.TermL, eToken.OperatorDivision).WithValues(eToken.TermL, eToken.Fator, eToken.OperatorDivision);
            this.CreateUsingKeys(eToken.TermL, eToken.OperatorPower).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.TermL, eToken.ParenthesisLeft).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.TermL, eToken.ParenthesisRight).WithValues(eToken.Empty);
            this.CreateUsingKeys(eToken.TermL, eToken.Number).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.TermL, eToken.End).WithValues(eToken.Empty);
        }

        private void CreateRuleTerm()
        {
            this.CreateUsingKeys(eToken.Term, eToken.Identifier).WithValues(eToken.TermL, eToken.Fator);
            this.CreateUsingKeys(eToken.Term, eToken.OperatorAssignment).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Term, eToken.OperatorAddition).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Term, eToken.OperatorSubtraction).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Term, eToken.OperatorMultiply).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Term, eToken.OperatorDivision).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Term, eToken.OperatorPower).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Term, eToken.ParenthesisLeft).WithValues(eToken.TermL, eToken.Fator);
            this.CreateUsingKeys(eToken.Term, eToken.ParenthesisRight).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Term, eToken.Number).WithValues(eToken.TermL, eToken.Fator);
            this.CreateUsingKeys(eToken.Term, eToken.End).WithValues(eToken.Empty);
        }

        private void CreateRuleExpressionL()
        {
            this.CreateUsingKeys(eToken.ExpressionL, eToken.Identifier).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.ExpressionL, eToken.OperatorAssignment).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.ExpressionL, eToken.OperatorAddition).WithValues(eToken.ExpressionL, eToken.Term, eToken.OperatorAddition);
            this.CreateUsingKeys(eToken.ExpressionL, eToken.OperatorSubtraction).WithValues(eToken.ExpressionL, eToken.Term, eToken.OperatorSubtraction);
            this.CreateUsingKeys(eToken.ExpressionL, eToken.OperatorMultiply).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.ExpressionL, eToken.OperatorDivision).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.ExpressionL, eToken.OperatorPower).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.ExpressionL, eToken.ParenthesisLeft).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.ExpressionL, eToken.ParenthesisRight).WithValues(eToken.Empty);
            this.CreateUsingKeys(eToken.ExpressionL, eToken.Number).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.ExpressionL, eToken.End).WithValues(eToken.Empty);
        }

        private void CreateRuleExpression()
        {
            this.CreateUsingKeys(eToken.Expression, eToken.Identifier).WithValues(eToken.ExpressionL, eToken.Term);
            this.CreateUsingKeys(eToken.Expression, eToken.OperatorAssignment).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Expression, eToken.OperatorAddition).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Expression, eToken.OperatorSubtraction).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Expression, eToken.OperatorMultiply).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Expression, eToken.OperatorDivision).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Expression, eToken.OperatorPower).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Expression, eToken.ParenthesisLeft).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Expression, eToken.ParenthesisRight).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Expression, eToken.Number).WithValues(eToken.ExpressionL, eToken.Term);
            this.CreateUsingKeys(eToken.Expression, eToken.End).WithValues(eToken.Error);
        }
        private void CreateRuleStart()
        {
            this.CreateUsingKeys(eToken.Start, eToken.Identifier).WithValues(eToken.Expression, eToken.OperatorAssignment, eToken.Identifier);
            this.CreateUsingKeys(eToken.Start, eToken.OperatorAssignment).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Start, eToken.OperatorAddition).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Start, eToken.OperatorSubtraction).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Start, eToken.OperatorMultiply).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Start, eToken.OperatorDivision).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Start, eToken.OperatorPower).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Start, eToken.ParenthesisLeft).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Start, eToken.ParenthesisRight).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Start, eToken.Number).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Start, eToken.End).WithValues(eToken.Error);
        }

        private Grammar WithValues(params eToken[] tokensArray)
        {
            this.Add(this._tuple, new Stack<eToken>(tokensArray));
            return this;
        }
        private Grammar CreateUsingKeys(eToken key1, eToken key2)
        {
            this._tuple = Tuple.Create(key1, key2);
            return this;
        }



        //private void Add(Tuple tuple)
        //{
        //    //Add(tuple.Key, tuple.Values);
        //}

        //private class Tuple
        //{
        //    private eToken _key;
        //    public eToken Key { get { return _key; } }

        //    private Stack<eToken> _values;
        //    public Stack<eToken> Values { get { return _values; } }

        //    public Tuple(eToken key)
        //    {
        //        this._key = key;
        //    }

        //    public static Tuple CreateUsingKey(eToken key)
        //    {
        //        return new Tuple(key);
        //    }

        //    public Tuple ForValues(params eToken[] values)
        //    {
        //        this._values = new Stack<eToken>(values.Reverse());
        //        return this;
        //    }
        //}


        public Stack<eToken> FindByKey(eToken expectedToken, eToken readToken)
        {
            return this[Tuple.Create(expectedToken, readToken)];
        }
    }
}
