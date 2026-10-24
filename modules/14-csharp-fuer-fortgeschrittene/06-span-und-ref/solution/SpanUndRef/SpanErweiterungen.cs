namespace SpanUndRef;

public static class SpanErweiterungen
{
    extension(ReadOnlySpan<char> s)
    {
        public bool IstPalindrom()
        {
            for (int i = 0, j = s.Length - 1; i < j; i++, j--)
                if (s[i] != s[j]) return false;
            return true;
        }
    }
}
