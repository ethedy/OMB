using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Entidades;
using System.Diagnostics;
using Servicios;

using System.Windows.Input;
using Infraestructura;

namespace WindowsOMB.viewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        #region PROPIEDADES PUBLICAS
            public string Password { get; set; }
            public Usuario UsuarioModel
            {
                get { return _usuario; }
                set {
                    _usuario = value;
                    OnPropertyChanged("UsuarioModel");
                }
            }

            public ComandoSimple IngresoLogin {
                get { return _ingresoLogin; }
                set { 
                      _ingresoLogin = value;
                      OnPropertyChanged("IngresoLogin");
                }
            }

        #endregion

        #region PROPIEDADES PRIVADOS
            private Usuario _usuario;
            private ComandoSimple _ingresoLogin;
            private ComandoSimple _cancelaLogin;
        #endregion
            
        

        
        public LoginViewModel() {
            Usuario utemp;
            UsuarioModel = new Usuario();
            //UsuarioModel.Login = "mburns";

            IngresoLogin = new ComandoSimple(() =>
            {
                
                SecurityServices serv = new SecurityServices();



                utemp = serv.Login(UsuarioModel,Password);

                if (utemp != null)
                {
                    Debug.WriteLine(string.Format("Usuario: {0}", UsuarioModel.Persona.CorreoElectronico));
                }
                else {
                    throw new OMBLoginException("error");
                }
                
            },
            () => true);


        }

        private void OnPropertyChanged(string propiedad) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }

        }
    }

    public class ComandoSimple : ICommand {

        private Action _execute;
        private Func<bool> _canExecute;

        public ComandoSimple(Action exec, Func<bool> canExec) {
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
