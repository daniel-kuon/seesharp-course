// Eine Warteschlange (FIFO), die von mehreren Threads gleichzeitig benutzt werden darf.
public class SichereWarteschlange<T>
{
    readonly Queue<T> _queue = new();
    readonly object _sperre = new();

    public void Einreihen(T element)
    {
        lock (_sperre)
        {
            _queue.Enqueue(element);
        }
    }

    public bool TryNaechster(out T? element)
    {
        lock (_sperre)
        {
            // Prüfen und Entnehmen unter demselben lock: Es kann kein anderer Thread dazwischenkommen.
            if (_queue.Count > 0)
            {
                element = _queue.Dequeue();
                return true;
            }
        }
        element = default;
        return false;
    }

    public int Anzahl
    {
        get
        {
            lock (_sperre)
            {
                return _queue.Count;
            }
        }
    }
}
