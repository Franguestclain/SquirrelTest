using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Squirrel;

namespace SquirrelTest
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using(var mgr = UpdateManager.GitHubUpdateManager("https://github.com/Franguestclain/SquirrelTest"))
                {
                    MessageBoxResult result = MessageBox.Show("Hay una actualizacion del software, ¿Desea instalarla?", "Test advice", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        await mgr.Result.UpdateApp();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error {ex.Message}");
            }
        }
    }
}
