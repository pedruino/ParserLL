using AnalisadorLexico.Exceptions;
using AnalisadorLexico.Helper;
using AnalisadorLexico.Model;
using AnalisadorLexico.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AnalisadorLexico.ViewModel
{
    class ViewModelMainWindow : ObservableObject
    {
        private string _historico;
        public string Historico
        {
            get { return _historico; }
            set { SetProperty(ref _historico, value); }
        }

        private Expressao _expressao;
        public Expressao Expressao
        {
            get { return _expressao; }
            set { SetProperty(ref _expressao, value); }
        }

        private ObservableCollection<Lexema> _tabelaDeLexemas;
        public ObservableCollection<Lexema> TabelaDeLexemas
        {
            get
            {
                return _tabelaDeLexemas;
            }
        }

        private ICommand _validaCommand;
        public ICommand ValidaCommand
        {
            get
            {
                _validaCommand = _validaCommand ?? new RelayCommand(ValidaExpressao);
                return _validaCommand;
            }
        }

        public ViewModelMainWindow()
        {
            this._expressao = new Expressao();
#if DEBUG
            this._expressao.Texto = "a = 3+4*(5+9-98)";
#endif
            this._tabelaDeLexemas = new ObservableCollection<Lexema>();
        }

        /// <summary>
        /// <para>Processa a expressão digitada e trata as mensagens de erro.</para>
        /// <para>Se a expressão digitada for válida, mostra os dados em uma tabela, caso contrário exibe uma mensagem de erro.</para>
        /// </summary>
        private void ValidaExpressao()
        {
            try
            {
                this._historico += "\n" + this._expressao.Texto;
                this._expressao.Valida();

                if (this._tabelaDeLexemas.Any())
                    this._tabelaDeLexemas.Clear();

                foreach (Lexema lexema in this._expressao.Lexemas)
                    this._tabelaDeLexemas.Add(lexema);
            }
            catch (InvalidCharacterException iie)
            {
                Utils.ShowErrorMessage(iie.Message);
            }
            catch (Exception e)
            {
                Utils.ShowErrorMessage(e.Message);
            }
        }
    }
}
