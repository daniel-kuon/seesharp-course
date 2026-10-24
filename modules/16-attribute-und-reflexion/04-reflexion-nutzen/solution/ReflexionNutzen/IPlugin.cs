public interface IPlugin
{
    string Name { get; }

    string Ausfuehren(string eingabe);
}
