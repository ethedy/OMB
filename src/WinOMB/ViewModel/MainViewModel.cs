using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsOMB.Comun;
using WindowsOMB.View;
using Infraestructura;

namespace WindowsOMB.ViewModel
{
  public class MainViewModel : ViewModelBase
  {
    private string _usuarioConectado;
    public string UsuarioConectado
    {
      get { return _usuarioConectado; }
      set
      {
        _usuarioConectado = value;
        OnPropertyChanged();
      }
    }

    public ComandoSimple Login { get; set; }
    public ComandoSimple Logout { get; set; }

    public MainViewModel()
    {
      UsuarioConectado = "<Desconectado>";

      Login = new ComandoSimple(TryLogin, () => Context.Current.Sesion == null);
      Logout = new ComandoSimple(TryLogout, () => Context.Current.Sesion != null);
    }

    public void TryLogin()
    {
      LoginService login = Context.Current.ServiceProvider.GetService(typeof(LoginService)) as LoginService;

      login.Show();

      if (Context.Current.Sesion != null)
      {
        UsuarioConectado = Context.Current.Sesion.FullName;
      }
    }

    public void TryLogout()
    {
      //
    }
  }
}
