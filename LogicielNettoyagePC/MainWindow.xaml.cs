using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace LogicielNettoyagePC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Mise_a_jour_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Votre logiciel est à jour!", "Mise à jour",MessageBoxButton.OK, MessageBoxImage.Information);
        }


        private void Hitorique_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("TODO", "Historique", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Site_web_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo("http://google.fr")
                {
                    UseShellExecute = true
                });

            } catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
            }

        }
    }
}
