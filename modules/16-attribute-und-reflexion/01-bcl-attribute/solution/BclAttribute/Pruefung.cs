public static class Pruefung
{
    public static void Pruefe(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException($"Parameter '{nameof(name)}' fehlt");
    }
}
