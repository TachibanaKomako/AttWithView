using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttWithView.MVVMs.ViewModels
{
    public class SelectableItemsViewModel<T> : ViewModelBase
    {
        public ObservableCollection<T> Items { get; } = new();
        public int SelectedIndex { get => (int)(GetValue() ?? -1); set => SetValue(value); }
        public T? SelectedItem { get => Items.ElementAtOrDefault(SelectedIndex); set => SelectedIndex = value is null ? -1 : Items.IndexOf(value); }

        public bool SelectedIsEnabled { get => SelectedItem is not null; }
        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            switch (propertyName)
            {
                case nameof(SelectedIndex):
                    OnPropertyChanged(nameof(SelectedItem));
                    OnPropertyChanged(nameof(SelectedIsEnabled));
                    break;
            }
        }
    }
}
