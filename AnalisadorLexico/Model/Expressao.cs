using AnalisadorLexico.Exceptions;
using AnalisadorLexico.Helper;
using AnalisadorLexico.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System;

namespace AnalisadorLexico.Model
{
    class Expressao : ObservableObject
    {
        private IEnumerable<Match> _numeros;
        private IEnumerable<Match> _identificadores;
        private IEnumerable<Match> _delimitadores;
        private IEnumerable<Match> _operadoresAdicao;
        private IEnumerable<Match> _operadoresSubtracao;
        private IEnumerable<Match> _operadoresMultiplicao;
        private IEnumerable<Match> _operadoresDivisao;
        private IEnumerable<Match> _operadoresPotencia;
        private IEnumerable<Match> _atribuidores;

        private string _newTexto;
        private string _texto;
        public string Texto
        {
            get { return _texto; }
            set { SetProperty(ref _texto, value); }
        }

        private List<Lexema> _lexemas;
        

        public IOrderedEnumerable<Lexema> Lexemas
        {
            get
            {   //retorna a lista ORDENADA de lexemas na mesma sequencia da expressao de entrada
                return _lexemas.OrderBy(lexema => lexema.Index);
            }
        }

        public Expressao()
        {
        }

        /// <summary>
        /// Processa a expressão digitada. Se for válida, mostra os dados em uma tabela, caso contrário exibe uma mensagem de erro.
        /// </summary>
        public void Valida()
        {
            this._newTexto = Regex.Replace(this._texto, Constantes.RegexPattern.WHITE_SPACE, string.Empty);
            this.extractLexemas();

            if (string.IsNullOrEmpty(this._newTexto.Trim()))
            {
                this._lexemas = new List<Lexema>();

                this.addMatchesToListOfLexemas(this._numeros, EToken.NUM);
                this.addMatchesToListOfLexemas(this._identificadores, EToken.ID);
                this.addMatchesToListOfLexemas(this._delimitadores, EToken.DELIM);
                this.addMatchesToListOfLexemas(this._operadoresAdicao, EToken.OP_ADD);
                this.addMatchesToListOfLexemas(this._operadoresSubtracao, EToken.OP_SUB);
                this.addMatchesToListOfLexemas(this._operadoresMultiplicao, EToken.OP_MULT);
                this.addMatchesToListOfLexemas(this._operadoresDivisao, EToken.OP_DIV);
                this.addMatchesToListOfLexemas(this._operadoresPotencia, EToken.OP_POW);
                this.addMatchesToListOfLexemas(this._atribuidores, EToken.ATRIB);
            }
            else
                throw new InvalidCharacterException();
        }

        /// <summary>
        /// Extrai os lexemas de uma expressao
        /// </summary>
        /// <returns>uma lista ordenada pela mesma sequencia da cadeia de caracteres da expressao</returns>
        private void extractLexemas()
        {
            this._numeros = this.extractMatches(Constantes.RegexPattern.NUM);
            this._identificadores = this.extractMatches(Constantes.RegexPattern.ID);
            this._delimitadores = this.extractMatches(Constantes.RegexPattern.DELIM);
            this._operadoresAdicao = this.extractMatches(Constantes.RegexPattern.OP_ADD);
            this._operadoresSubtracao = this.extractMatches(Constantes.RegexPattern.OP_SUB);
            this._operadoresMultiplicao = this.extractMatches(Constantes.RegexPattern.OP_MULT);
            this._operadoresDivisao = this.extractMatches(Constantes.RegexPattern.OP_DIV);
            this._operadoresPotencia = this.extractMatches(Constantes.RegexPattern.OP_POW);
            this._atribuidores = this.extractMatches(Constantes.RegexPattern.ATRIB);
        }

        /// <summary>
        /// Extrai um lista de matches pelo regex e elimina eles da expressao inicial
        /// </summary>
        /// <param name="pattern">o padrão do regex</param>
        /// <returns></returns>
        private IEnumerable<Match> extractMatches(string pattern)
        {
            var numeros = new Regex(pattern).Matches(this._newTexto).Cast<Match>();
            this._newTexto = this.replaceMachesByWhitespace(numeros, this._newTexto);
            return numeros;
        }

        /// <summary>
        /// Converte cada elemento na lista de matches e adiciona a lista de matches
        /// </summary>
        /// <param name="matches">lista de matches de um regex</param>
        /// <param name="token">o grupo ao qual os lexemas pertencem</param>
        private void addMatchesToListOfLexemas(IEnumerable<Match> matches, EToken token)
        {
            if (matches.Any())
                foreach (Match m in matches)
                    this._lexemas.Add(new Lexema() { Index = m.Index, Value = m.Value, Token = token });
        }

        /// <summary>
        /// Substitui os matches por espaços em branco para manter o indice original nos matches restantes
        /// </summary>
        /// <param name="matches">uma lista de matches</param>
        /// <param name="input">a expressao original</param>
        /// <returns>a string de expressao já substituída</returns>
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
