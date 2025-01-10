using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CatalogoWPF.Core;

class ObservableObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChaged([CallerMemberName] string name = null)
    => PropertyChanged?.Invoke(this,
    new PropertyChangedEventArgs(name));
}
