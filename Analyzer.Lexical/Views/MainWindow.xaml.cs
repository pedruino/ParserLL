using Analyzer.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace Analyzer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModelMainWindow();
        }
    }
}
