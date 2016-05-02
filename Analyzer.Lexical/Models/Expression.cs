using Lexical.DataTypes.Exceptions;
using Lexical.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Lexical.DataTypes;
using Lexical.DataTypes.Enums;

namespace Lexical.Models
{
    class Expression : ObservableObject
    {
        private IEnumerable<Match> _numbers;
        private IEnumerable<Match> _identifiers;
        private IEnumerable<Match> _operatorsAssignment;
        private IEnumerable<Match> _operatorsAddition;
        private IEnumerable<Match> _operatorsSubtraction;
        private IEnumerable<Match> _operatorsMultiply;
        private IEnumerable<Match> _operatorsDivision;
        private IEnumerable<Match> _operatorsPower;
        private IEnumerable<Match> _parenthesisLeft;
        private IEnumerable<Match> _parenthesisRight;

        private string _newText;
        private string _text;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        private List<Lexeme> _lexemes;

        public IOrderedEnumerable<Lexeme> Lexemes
        {
            get
            {   //retorna a lista ORDENADA de lexemas na mesma sequencia da expressao de entrada
                return _lexemes.OrderBy(lexema => lexema.Index);
            }
        }

        public void Evaluate()
        {
            this._newText = Regex.Replace(this._text, Constants.RegexPattern.Whitespace, string.Empty);
            this.extractLexemes();

            if (string.IsNullOrEmpty(this._newText.Trim()))
            {
                this._lexemes = new List<Lexeme>();

                this.addMatchesToListOfLexemas(this._numbers, eToken.Number);
                this.addMatchesToListOfLexemas(this._identifiers, eToken.Identifier);
                this.addMatchesToListOfLexemas(this._parenthesisLeft, eToken.ParenthesisLeft);
                this.addMatchesToListOfLexemas(this._parenthesisRight, eToken.ParenthesisRight);
                this.addMatchesToListOfLexemas(this._operatorsAddition, eToken.OperatorAddition);
                this.addMatchesToListOfLexemas(this._operatorsSubtraction, eToken.OperatorSubtraction);
                this.addMatchesToListOfLexemas(this._operatorsMultiply, eToken.OperatorMultiply);
                this.addMatchesToListOfLexemas(this._operatorsDivision, eToken.OperatorDivision);
                this.addMatchesToListOfLexemas(this._operatorsPower, eToken.OperatorPower);
                this.addMatchesToListOfLexemas(this._operatorsAssignment, eToken.OperatorAssignment);
            }
            else
                throw new InvalidCharacterException();
        }

        private void extractLexemes()
        {
            this._numbers = this.extractMatches(Constants.RegexPattern.Number);
            this._identifiers = this.extractMatches(Constants.RegexPattern.Identifier);
            this._parenthesisLeft = this.extractMatches(Constants.RegexPattern.ParenthesisLeft);
            this._parenthesisRight = this.extractMatches(Constants.RegexPattern.ParenthesisRight);
            this._operatorsAddition = this.extractMatches(Constants.RegexPattern.OperatorAddition);
            this._operatorsSubtraction = this.extractMatches(Constants.RegexPattern.OperatorSubtraction);
            this._operatorsMultiply = this.extractMatches(Constants.RegexPattern.OperatorMultiply);
            this._operatorsDivision = this.extractMatches(Constants.RegexPattern.OperatorDivision);
            this._operatorsPower = this.extractMatches(Constants.RegexPattern.OperatorPower);
            this._operatorsAssignment = this.extractMatches(Constants.RegexPattern.OperatorAssignment);
        }

        private IEnumerable<Match> extractMatches(string pattern)
        {
            var numbers = new Regex(pattern).Matches(this._newText).Cast<Match>();
            this._newText = this.replaceMachesByWhitespace(numbers, this._newText);
            return numbers;
        }

        private void addMatchesToListOfLexemas(IEnumerable<Match> matches, eToken token)
        {
            if (matches.Any())
                foreach (Match m in matches)
                    this._lexemes.Add(new Lexeme() { Index = m.Index, Value = m.Value, Token = token });
        }

        private string replaceMachesByWhitespace(IEnumerable<Match> matches, string input)
        {
            char whitespace = ' ';
            char[] result = input.ToCharArray();

            foreach (Match match in matches)
                if (match.Length > 1)
                    for (int i = match.Index; i < match.Index + match.Length; i++)
                        result[i] = whitespace;
                else
                    result[match.Index] = whitespace;

            return string.Concat(result);
        }
    }
}
