namespace Kalkulacka.Test
{
    public class KalkulackaTests
    {
        //pouzivam Theory, coz nam udela obecnou definici testu
        //InlineData nam specifikuje argumenty, tam mam nejed co davam do kalkulacky, ale i co ocekavam
        //To nam dovoli psat mnohem mene metod a testovat o dost vice
        [Theory]
        [InlineData(5.0, 6.0, 11.0)]
        [InlineData(5.0, 7.0, 12.0)]
        [InlineData(155.0, 145.0, 300.0)]
        public void SectiCisla_SpravnyVysledek(double x, double y, double excpectedResult)
        {
            var result = Kalkulacka.Secti(x, y);

            Assert.Equal(excpectedResult, result);
        }

        [Theory]
        [InlineData(25.0, 5.0, 5.0)]
        [InlineData(64.0, 8.0, 8.0)]
        [InlineData(155.0, 155.0, 1.0)]
        public void VydelCisla_SpravnyVysledek(double x, double y, double excpectedResult)
        {
            var result = Kalkulacka.Vydel(x, y);

            Assert.Equal(excpectedResult, result);
        }

        //Jednoduchy a zakladni test
        //Davame schvalne spatny vstup at si otestujeme co to udela
        //Asi bychom meli vracet spis nejakou chybu
        [Fact]
        public void VydelCisla_Error()
        {
            var result = Kalkulacka.Vydel(25.0, 0);
            Assert.Equal(double.PositiveInfinity, result);
        }
    }
}