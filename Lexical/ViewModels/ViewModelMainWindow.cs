using Lexical.DataTypes;
using Lexical.DataTypes.Exceptions;
using Lexical.Models;
using Lexical.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Lexical.ViewModels
{
    class ViewModelMainWindow : ObservableObject
    {
        private string _history;
        public string History
        {
            get { return _history; }
            set { SetProperty(ref _history, value); }
        }

        private Expression _expression;
        public Expression Expression
        {
            get { return _expression; }
            set { SetProperty(ref _expression, value); }
        }

        private ObservableCollection<Lexeme> _lexemesTable;
        public ObservableCollection<Lexeme> LexemesTable
        {
            get
            {
                return _lexemesTable;
            }
        }

        private ICommand _evaluateCommand;
        public ICommand EvaluateCommand
        {
            get
            {
                _evaluateCommand = _evaluateCommand ?? new RelayCommand(EvaluateExpression);
                return _evaluateCommand;
            }
        }

        public ViewModelMainWindow()
        {
            this._expression = new Expression();
#if DEBUG
            this._expression.Text = "a = 3+4*(5+9-98)";
#endif
            this._lexemesTable = new ObservableCollection<Lexeme>();
        }

        /// <summary>
        /// <para>Processa a expressão digitada e trata as mensagens de erro.</para>
        /// <para>Se a expressão digitada for válida, mostra os dados em uma tabela, caso contrário exibe uma mensagem de erro.</para>
        /// </summary>
        private void EvaluateExpression()
        {
            try
            {
                this.History += "\n" + this._expression.Text;
                this._expression.Evaluate();

                if (this._lexemesTable.Any())
                    this._lexemesTable.Clear();

                foreach (Lexeme lexema in this._expression.Lexemes)
                    this._lexemesTable.Add(lexema);
            }
            catch (InvalidCharacterException iie)
            {
                Notification.ShowErrorMessage(iie.Message);
            }
            catch (Exception e)
            {
                Notification.ShowErrorMessage(e.Message);
            }
        }
    }
}
