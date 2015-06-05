using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Database;
using Entidades;
using Infraestructura;

namespace Servicios
{
  /// <summary>
  /// Provee diferentes funciones de servicios de seguridad: login, cambio de password, encriptacion, auditoria
  /// </summary>
  public class SecurityServices
  {
    public SecurityServices()
    {

    }

    public Usuario Login(Usuario usr, string pwd)
    {
      Usuario userRetorno;

      userRetorno = DB.Usuarios.Find(u => u.Login == usr.Login);
      if (userRetorno != null)
      {
        try
        {
          if (DB.LoginUsuario(userRetorno, pwd))
            return userRetorno;
        }
        catch (OMBLoginException ex)
        {
          Debug.WriteLine(ex.Message);
          throw;
        }
      }
      return null;
    }

    public Sesion Login(string uid, string pwd)
    {
      Usuario user;

      //  usamos exp-L para hallar el usuario que coincide con la info de login
      //
      user = DB.Usuarios.Find(u => u.Login == uid);

      if (user != null)
      {
        if (DB.LoginUsuario(user, pwd))
        {
          Sesion result = new Sesion(user);

          return result;
        }
      }
      return null;
    }
  }
}
