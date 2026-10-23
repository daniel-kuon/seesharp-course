public class BruchlaborTests
{
    [Fact]
    public void Vier_Achtel_gekuerzt_ist_ein_Halb() => Assert.Equal("1/2", Bruchlabor.KuerzeVierAchtel());

    [Fact]
    public void Nenner_null_wird_abgelehnt() => Assert.Equal("3/1", Bruchlabor.NennerNull());

    [Fact]
    public void Ein_Halb_plus_ein_Drittel_ist_fuenf_Sechstel() => Assert.Equal("5/6", Bruchlabor.EinHalbPlusEinDrittel());
}
