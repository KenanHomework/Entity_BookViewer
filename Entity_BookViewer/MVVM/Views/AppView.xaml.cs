using Entity_BookViewer.MVVM.ViewModels;
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
using System.Windows.Shapes;

namespace Entity_BookViewer.MVVM.Views
{
    /// <summary>
    /// Interaction logic for AppView.xaml
    /// </summary>
    public partial class AppView : Window
    {
        public AppView()
        {
            InitializeComponent();
            DataContext = App.Container.GetInstance<AppViewVM>();
            App.Container.GetInstance<AppViewVM>().ReadContext();
            App.Container.GetInstance<AppViewVM>().Window = this;

        }

        private void ResizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                switch (btn.Content.ToString())
                {
                    case "_":
                        this.WindowState = WindowState.Minimized;
                        break;
                    case "X":
                        Application.Current.Shutdown();
                        break;
                    default:
                        break;
                }
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            => App.Container.GetInstance<AppViewVM>().FilterSelectionChanged(FilterComboBox.SelectedIndex);

        private void TypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            => App.Container.GetInstance<AppViewVM>().TypeSelectionChanged(TypeComboBox.SelectedIndex);

    }
}
