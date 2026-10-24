using System.Windows.Input;

public class RelayCommand : ICommand
{
    private readonly Action<object?> _ausfuehren;
    private readonly Func<object?, bool>? _kannAusfuehren;

    public RelayCommand(Action<object?> ausfuehren, Func<object?, bool>? kannAusfuehren = null)
    {
        _ausfuehren = ausfuehren ?? throw new ArgumentNullException(nameof(ausfuehren));
        _kannAusfuehren = kannAusfuehren;
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter) => _kannAusfuehren?.Invoke(parameter) ?? true;

    public void Execute(object? parameter) => _ausfuehren(parameter);

    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}
