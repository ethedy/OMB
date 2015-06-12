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
using WindowsOMB.Comun;
using WindowsOMB.ViewModel;
using Syncfusion.Windows.Tools.Controls;

using Infraestructura;

namespace WindowsOMB.View
{
  /// <summary>
  /// Interaction logic for winMain.xaml
  /// </summary>
  public partial class winMain : RibbonWindow
  {
    private MainViewModel _vm;

    public winMain()
    {
      InitializeComponent();
      //
      _vm = new MainViewModel();
      this.DataContext = _vm;
      
      Context.Current.ServiceProvider.AddService(typeof(LoginService), 
        new LoginService());
    }
  }
}
