public class FloatMatrixTests
{
    static FloatMatrix Gefuellt(int z, int s)
    {
        var m = new FloatMatrix(z, s);
        for (int i = 0; i < z; i++)
            for (int j = 0; j < s; j++)
                m[i, j] = i * s + j + 1;
        return m;
    }

    [Fact]
    public void Konstruktor_setzt_Zeilen_und_Spalten()
    {
        var m = new FloatMatrix(3, 5);

        Assert.Equal((3, 5), (m.Zeilen, m.Spalten));
    }

    [Fact]
    public void Ungueltige_Groesse_ergibt_eine_leere_Matrix()
    {
        Assert.Equal((0, 0), (new FloatMatrix(0, 5).Zeilen, new FloatMatrix(0, 5).Spalten));
        Assert.Equal((0, 0), (new FloatMatrix(-1, 5).Zeilen, new FloatMatrix(-1, 5).Spalten));
        Assert.Equal((0, 0), (new FloatMatrix(10_000, 10_000).Zeilen, new FloatMatrix(10_000, 10_000).Spalten));
    }

    [Fact]
    public void Indexer_schreibt_und_liest()
    {
        var m = new FloatMatrix(2, 2);

        m[1, 0] = 4.5f;

        Assert.Equal(4.5f, m[1, 0]);
        Assert.Equal(0f, m[0, 1]);
    }

    [Fact]
    public void Transponieren_einer_3x5_Matrix_ergibt_5x3()
    {
        var m = Gefuellt(3, 5);

        m.Transponieren();

        Assert.Equal((5, 3), (m.Zeilen, m.Spalten));
        Assert.Equal(1f, m[0, 0]);
        Assert.Equal(6f, m[0, 1]);   // vorher [1, 0]
        Assert.Equal(2f, m[1, 0]);   // vorher [0, 1]
        Assert.Equal(15f, m[4, 2]);  // vorher [2, 4]
    }

    [Fact]
    public void Transponieren_einer_quadratischen_Matrix_in_place()
    {
        var m = Gefuellt(3, 3);

        m.Transponieren();

        Assert.Equal((3, 3), (m.Zeilen, m.Spalten));
        Assert.Equal(4f, m[0, 1]);
        Assert.Equal(2f, m[1, 0]);
        Assert.Equal(5f, m[1, 1]);
        Assert.Equal(3f, m[2, 0]);
    }

    [Fact]
    public void Zweimal_transponieren_ist_die_Identitaet()
    {
        var m = Gefuellt(2, 4);

        m.Transponieren();
        m.Transponieren();

        Assert.Equal((2, 4), (m.Zeilen, m.Spalten));
        for (int i = 0; i < 2; i++)
            for (int j = 0; j < 4; j++)
                Assert.Equal(i * 4 + j + 1, m[i, j]);
    }
}
