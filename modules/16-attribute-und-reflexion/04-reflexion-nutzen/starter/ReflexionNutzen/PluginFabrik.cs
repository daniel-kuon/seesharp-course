public static class PluginFabrik
{
    // Erzeugt aus dem Typnamen (z. B. dem AssemblyQualifiedName) ein Plugin.
    // Gibt null zurück, wenn
    // - es den Typ nicht gibt (Type.GetType liefert null),
    // - der Typ IPlugin nicht implementiert (typeof(IPlugin).IsAssignableFrom(typ)) oder
    // - der Typ abstrakt ist (Interfaces zählen mit).
    // Sonst wird mit Activator.CreateInstance(typ) eine Instanz erzeugt.
    public static IPlugin? Erzeuge(string typname)
    {
        // TODO
        throw new NotImplementedException();
    }
}
