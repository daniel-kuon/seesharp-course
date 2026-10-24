public class RechnerTests
{
    [MeinTest]
    public void Plus_funktioniert()
    {
        if (1 + 1 != 2)
            throw new Exception("Plus ist kaputt");
    }

    [MeinTest]
    public void Geteilt_wirft_absichtlich()
    {
        int null_ = 0;
        _ = 1 / null_;
    }

    public void Hilfsmethode() { }
}
