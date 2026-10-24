using System.ComponentModel;
using System.Runtime.CompilerServices;

public abstract class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    protected bool SetProperty<T>(ref T feld, T wert, [CallerMemberName] string? name = null)
    {
        if (EqualityComparer<T>.Default.Equals(feld, wert))
            return false;
        feld = wert;
        OnPropertyChanged(name);
        return true;
    }
}
