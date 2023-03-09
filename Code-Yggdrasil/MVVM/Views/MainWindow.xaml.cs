using Code_Yggdrasil.MVVM.ViewModels;
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

namespace Code_Yggdrasil
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OverseerViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new OverseerViewModel();
            this.DataContext = _viewModel;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void Off_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Minimise_Button_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState != WindowState.Minimized) { this.WindowState = WindowState.Minimized; }
        }
    }
}
