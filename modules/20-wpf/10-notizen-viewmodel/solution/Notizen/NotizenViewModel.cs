using System.Collections.ObjectModel;

public class NotizenViewModel : ViewModelBase
{
    private string _text = "";
    private string? _ausgewaehlt;

    public NotizenViewModel()
    {
        Hinzufuegen = new RelayCommand(_ => FuegeHinzu(), _ => !string.IsNullOrWhiteSpace(Text));
        Loeschen = new RelayCommand(_ => LoescheAusgewaehlte(), _ => Ausgewaehlt is not null);
    }

    public ObservableCollection<string> Notizen { get; } = new();

    public string Text
    {
        get => _text;
        set
        {
            if (SetProperty(ref _text, value))
                Hinzufuegen.RaiseCanExecuteChanged();
        }
    }

    public string? Ausgewaehlt
    {
        get => _ausgewaehlt;
        set
        {
            if (SetProperty(ref _ausgewaehlt, value))
                Loeschen.RaiseCanExecuteChanged();
        }
    }

    public RelayCommand Hinzufuegen { get; }
    public RelayCommand Loeschen { get; }

    private void FuegeHinzu()
    {
        Notizen.Add(Text.Trim());
        Text = "";
    }

    private void LoescheAusgewaehlte()
    {
        Notizen.Remove(Ausgewaehlt!);
        Ausgewaehlt = null;
    }
}
