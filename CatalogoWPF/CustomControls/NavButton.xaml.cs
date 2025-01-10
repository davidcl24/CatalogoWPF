using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CatalogoWPF.CustomControls
{
    /// <summary>
    /// Lógica de interacción para NavButton.xaml
    /// </summary>
    public partial class NavButton : UserControl
    {

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(NavButton));

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(Geometry), typeof(NavButton));

        public static readonly DependencyProperty StrokeProperty =
           DependencyProperty.Register("Stroke", typeof(SolidColorBrush), typeof(NavButton));

        public static readonly DependencyProperty FillProperty =
           DependencyProperty.Register("Fill", typeof(SolidColorBrush), typeof(NavButton));

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(NavButton));

        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked", typeof (bool), typeof(NavButton));

        public static readonly DependencyProperty GroupNameProperty =
            DependencyProperty.Register("GroupName", typeof(string), typeof(NavButton));


        public string GroupName
        {
            get => (string) GetValue(GroupNameProperty);
            set => SetValue(GroupNameProperty, value);
        }
        
        public bool IsChecked
        {
            get => (bool)GetValue(IsCheckedProperty);
            set => SetValue(IsCheckedProperty, value);
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public string Stroke
        {
            get => (string)GetValue(StrokeProperty);
            set => SetValue(StrokeProperty, value);
        }

        public string Fill
        {
            get => (string)GetValue(FillProperty);
            set => SetValue(FillProperty, value);
        }

        public NavButton() => InitializeComponent();
    }
}
