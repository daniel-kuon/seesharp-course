public static class PluginFabrik
{
    public static IPlugin? Erzeuge(string typname)
    {
        Type? typ = Type.GetType(typname);
        if (typ == null || typ.IsAbstract || !typeof(IPlugin).IsAssignableFrom(typ))
            return null;

        return (IPlugin?)Activator.CreateInstance(typ);
    }
}
