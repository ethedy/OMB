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
using WindowsOMB.View;
using WindowsOMB.ViewModel;

namespace WindowsOMB
{
    /// <summary>
    /// Interaction logic for winLogin.xaml
    /// </summary>
    public partial class winLogin : Window
    {
        // evitar esto, que la ventana tenga que instanciar el VM, podria usarse Locate...
        private LoginViewModel _viewModel;
        public winLogin()
        {
            InitializeComponent();

            _viewModel = new LoginViewModel();
            this.loginContent.Content = new LoginCredenciales(_viewModel);
        }
    }
}
