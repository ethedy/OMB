using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Entidades.Seguridad;

namespace WindowsOMB.viewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Usuario _usuario;
        public Usuario UsuarioModel {
            get { return _usuario; }
            set {
                    _usuario = value; 
                    OnPropertyChanged("UsuarioModel");
                }
        }

        public string Password { get; set; }

        public LoginViewModel() {
            UsuarioModel = new Usuario();
            UsuarioModel.Login = "mburns";
        }

        private void OnPropertyChanged(string propiedad) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }

        }
    }
}
