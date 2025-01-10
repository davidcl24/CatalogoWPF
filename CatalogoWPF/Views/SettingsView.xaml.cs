using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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

namespace CatalogoWPF.Views
{
    /// <summary>
    /// Lógica de interacción para SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {

        public SettingsView()
        {
            InitializeComponent();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string opc = comboBox.SelectedValue.ToString();

            switch(opc)
            {
                case "es":
                    Thread.CurrentThread.CurrentCulture = new(Properties.Settings.Default.Spanish);
                    Thread.CurrentThread.CurrentUICulture = new(Properties.Settings.Default.Spanish);
                    MainWindow newWindow = new MainWindow();
                    newWindow.Show();
                    Application.Current.MainWindow.Close();
                    Application.Current.MainWindow = newWindow;
                    break;
                case "en":
                    Thread.CurrentThread.CurrentCulture = new(Properties.Settings.Default.English);
                    Thread.CurrentThread.CurrentUICulture = new(Properties.Settings.Default.English);
                    newWindow = new MainWindow();
                    newWindow.Show();
                    Application.Current.MainWindow.Close();
                    Application.Current.MainWindow = newWindow;
                    break;
            }
        }
    }
}
