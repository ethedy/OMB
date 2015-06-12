using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsOMB.Comun;
using Entidades;
using Servicios;

namespace WindowsOMB.ViewModel
{
  public class LoginViewModel : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    public event EventHandler LoginOK;

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
            UsuarioModel = utemp;
            Debug.WriteLine(UsuarioModel.Persona.CorreoElectronico);
            serv.CrearSesion(utemp, null);

            if (LoginOK != null)
              LoginOK(this, null);
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
}
