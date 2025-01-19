using System.Windows;
using System.Windows.Controls;

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
