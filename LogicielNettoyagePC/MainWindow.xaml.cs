using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        public DirectoryInfo winTemp;
        public DirectoryInfo appTemp;

        public MainWindow()
        {
            InitializeComponent();
            winTemp = new DirectoryInfo(@"C:\Windows\Temp");
            appTemp = new DirectoryInfo(System.IO.Path.GetTempPath());

        }

        //Calcul de la taille d'un dossier
        public long DirSize(DirectoryInfo dir)
        {
            return dir.GetFiles().Sum(fi => fi.Length) + dir.GetDirectories().Sum(di => DirSize(dir));
        }

        // Vider un dossier
        public void ClearTempData(DirectoryInfo di)
        {
            foreach (FileInfo file in di.GetFiles())
            {
                try
                {
                    file.Delete();
                    Console.WriteLine(file.FullName);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                try
                {
                    dir.Delete();
                    Console.WriteLine(dir.FullName);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

        }

        private void Miss_a_jour_btn_Click(object sender, RoutedEventArgs e)
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

        private void Analyser_btn_Click(object sender, RoutedEventArgs e)
        {
            AanalyseFolders();
        }

        public void AanalyseFolders()
        {
            Console.WriteLine("Début de l'analyse...");
            long totalSize = 0;

            try
            {
                totalSize += DirSize(winTemp) / 1000000;
                totalSize += DirSize(appTemp) / 1000000;
            } catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            espace.Content = totalSize + " Mb";
            titre.Content = "Analyse effectué !";
            date.Content = DateTime.Today;

        }

        private void Nettoyer_btn_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Nettoyage en cours...");
            Nettoyer_btn.Content = "NETTOYAGE EN COURS";

            Clipboard.Clear();

            try
            {
                ClearTempData(winTemp);
            } catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
            }

            try
            {
                ClearTempData(appTemp);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
            }

            Nettoyer_btn.Content = "NETTOYAGE TERMINE";
            titre.Content = "Nettoyage effectué !";
            espace.Content = "0 Mb";
        }
    }
}
