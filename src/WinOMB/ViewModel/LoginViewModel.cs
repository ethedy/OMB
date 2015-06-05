using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Entidades;
using Servicios;

namespace WindowsOMB.ViewModel
{
  public class LoginViewModel : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    private Usuario _usuario;
    //private string _password;
    private ComandoSimple _ingresoLogin;
    private ComandoSimple _cancelaLogin;

    #region PROPIEDADES PUBLICAS 

    public Usuario UsuarioModel
    {
      get { return _usuario; }
      set
      {
        _usuario = value;
        OnPropertyChanged("UsuarioModel");
      }
    }

    public string Password { get; set; }

    public ComandoSimple IngresoLogin
    {
      get { return _ingresoLogin; }
      set
      {
        _ingresoLogin = value;
        OnPropertyChanged("IngresoLogin");
      }
    }

    #endregion

    public LoginViewModel()
    {
      UsuarioModel = new Usuario();
      //  UsuarioModel.Login = "mburns";

      IngresoLogin = new ComandoSimple(() =>
        {
          Debug.WriteLine(string.Format("Usuario: {0} , Pass: {1}", 
            UsuarioModel.Login, Password));

          //  Establecer el login...
          SecurityServices serv = new SecurityServices();

          Usuario utemp = serv.Login(UsuarioModel, Password);

          if (utemp != null)
          {
            Debug.WriteLine(UsuarioModel.Persona.CorreoElectronico);
          }
          else
          {
            //  error de credenciales...
            Debug.WriteLine("ERROR");
          }
        },
        () => true);
    }


    private void OnPropertyChanged(string propiedad)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
    }
  }

  public class ComandoSimple : ICommand
  {
    private Action _execute;
    private Func<bool> _canExecute;
 
    public ComandoSimple(Action exec, Func<bool> canExec)
    {
      _execute = exec;
      _canExecute = canExec;
    }

    public bool CanExecute(object parameter)
    {
      return _canExecute();
    }

    public event EventHandler CanExecuteChanged;

    public void Execute(object parameter)
    {
      _execute();
    }
  }
}
