using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Windows.Input;
using System.Diagnostics;

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
                OnPropertyChanged("IngresoLogin"); // falta
            }
        }
        
#endregion

        public LoginViewModel()
        {
            UsuarioModel = new Usuario() ;
            IngresoLogin = new ComandoSimple(() =>
                {
                    Debug.WriteLine(string.Format("usuario {0} password {1}", UsuarioModel.Login, Password));

                    // establecer el login ...

                },() => true);
            // UsuarioModel.Login = "mburns";
        }

        private void OnPropertyChanged (string propiedad)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
        }
       
    }

    public class ComandoSimple : ICommand
    {
        private Action _execute;
        private Func<bool> _canExecute
        public ComandoSimple(Action exec, Func<bool> canExct)
        {
            _execute = exec;
            _canExecute = canExct;

        }
        bool ICommand.CanExecute(object parameter)
        {
            return _canExecute();
        }

        event EventHandler ICommand.CanExecuteChanged
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        void ICommand.Execute(object parameter)
        {
            return _execute();
        }
    }
}
