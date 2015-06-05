using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura
{
  public class OMBLoginException : ApplicationException
  {
    public OMBLoginException(string msg) : base(msg)
    {
    }

    public string LoginFallido { get; set; }
  }
}
