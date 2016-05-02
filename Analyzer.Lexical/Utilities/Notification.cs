using System.Windows;

namespace Lexical.Utilities

{
    class Notification
    {    
        /// <summary>
        /// Exibe uma mensagem de erro
        /// </summary>
        /// <param name="message">a mensagem a ser exibida</param>
        public static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, null, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
