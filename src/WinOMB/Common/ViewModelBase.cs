﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WindowsOMB.Common
{
  public class ViewModelBase : INotifyPropertyChanged
  {

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propName = null)
    {
      if (PropertyChanged != null && propName != null)
        PropertyChanged(this, new PropertyChangedEventArgs(propName));
    }
  }
}
