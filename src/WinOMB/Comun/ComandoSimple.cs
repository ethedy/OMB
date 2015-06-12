using System;
using System.Windows.Input;

namespace WindowsOMB.Comun
{
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

    public event EventHandler CanExecuteChanged
    {
      add { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }

    public void Execute(object parameter)
    {
      _execute();
    }
  }
}