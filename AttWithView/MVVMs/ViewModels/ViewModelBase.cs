using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AttWithView.MVVMs.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private Dictionary<string, object?> _properties = new();
        public object? GetValue(object? defaultValue=null, [CallerMemberName]string propertyName = "")
        {
            return _properties.TryGetValue(propertyName, out var value) ? value : defaultValue;
        }
        public void SetValue(object? value, [CallerMemberName]string propertyName = "")
        {
            if(_properties.TryAdd(propertyName, value) is false)
            {
                _properties[propertyName] = value;
            }
            OnPropertyChanged(propertyName);
        }
        public ICommand GetCommand(Func<ICommand> getCommand, [CallerMemberName] string propertyName = "")
        {
            if(_properties.ContainsKey(propertyName) is false)
            {
                SetValue(getCommand.Invoke(), propertyName);
            }
            return (ICommand)(GetValue(null, propertyName) ?? throw new NotImplementedException());
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
