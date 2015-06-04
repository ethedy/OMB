using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Entidades.Seguridad;

namespace Servicios
{
  public class Sesion
  {
      private Task _wdTask;
      private CancellationTokenSource _tokenSource;

      public event Action<string, DateTime> WatchDog;
    public Usuario Usuario { get; private set; }

    public string FullName
    {
      get { return string.Format("{0} {1}", Usuario.Persona.Nombre, Usuario.Persona.Apellido); }
    }

    public DateTime PasswordExpira
    {
      get
      {
        return Usuario.FechaExpiracionPassword;
      }
    }

    public Sesion(Usuario connected)
    {
      Usuario = connected;
      CancellationToken tkn;
      _tokenSource = new CancellationTokenSource();
      tkn = _tokenSource.Token;

      _wdTask = new Task(() =>
        {
            while (true)
            {
                if (tkn.IsCancellationRequested)
                    break;
                Thread.Sleep(2000);
                if (WatchDog != null)
                    WatchDog("Estoy vivo", DateTime.Now);
            }
        }, tkn);
      _wdTask.Start();
    }
      public void Logout()
    {
        _tokenSource.Cancel();
        _wdTask.Wait();
        _tokenSource.Dispose();

    }
  }
}
