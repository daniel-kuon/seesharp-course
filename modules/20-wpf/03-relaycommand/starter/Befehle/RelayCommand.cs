using System.Windows.Input;

// ICommand liegt in der Assembly System.ObjectModel und braucht kein WPF.
public class RelayCommand : ICommand
{
    // TODO 1: Felder für die beiden Delegaten anlegen; Konstruktor schreiben.
    // Ist ausfuehren null, wirft der Konstruktor eine ArgumentNullException.
    public RelayCommand(Action<object?> ausfuehren, Func<object?, bool>? kannAusfuehren = null)
        => throw new NotImplementedException();

    // WPF abonniert dieses Ereignis und fragt danach CanExecute neu ab.
    public event EventHandler? CanExecuteChanged;

    // TODO 2: Ohne Bedingung ist der Befehl immer ausführbar (true); sonst ruft die Methode die Bedingung
    // mit dem Parameter auf.
    public bool CanExecute(object? parameter) => throw new NotImplementedException();

    // TODO 3: ruft die Aktion mit dem Parameter auf.
    public void Execute(object? parameter) => throw new NotImplementedException();

    // TODO 4: löst CanExecuteChanged aus (sender ist this); ohne Abonnenten passiert nichts.
    public void RaiseCanExecuteChanged() => throw new NotImplementedException();
}
