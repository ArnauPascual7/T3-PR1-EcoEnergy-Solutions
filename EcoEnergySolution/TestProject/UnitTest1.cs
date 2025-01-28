using MainProject;
using TextManaging;
namespace TestProject
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1.0001d)]
        [InlineData(2d)]
        [InlineData(23d)]
        public void SistemaSolarTryConfigParTrue(double par)
        {
            // Arrange & Act
            SistemaEnergia system = new SistemaSolar();
            double result = Program.TryConfigPar(system, par);
            double exp = par;

            //Assert
            Assert.Equal(exp, result);
        }

        [Theory]
        [InlineData(-1d)]
        [InlineData(1d)]
        [InlineData(0.9999d)]
        public void SistemaSolarTryConfigParFalse(double par)
        {
            // Arrange & Act
            SistemaEnergia system = new SistemaSolar();
            double result = Program.TryConfigPar(system, par);
            double exp = 0d;

            //Assert
            Assert.Equal(exp, result);
        }

        [Theory]
        [InlineData(5d)]
        [InlineData(6d)]
        [InlineData(150d)]
        public void SistemaEolicTryConfigParTrue(double par)
        {
            // Arrange & Act
            SistemaEnergia system = new SistemaEolic();
            double result = Program.TryConfigPar(system, par);
            double exp = par;

            //Assert
            Assert.Equal(exp, result);
        }

        [Theory]
        [InlineData(4.9999d)]
        [InlineData(0d)]
        [InlineData(-54d)]
        public void SistemaEolicTryConfigParFalse(double par)
        {
            // Arrange & Act
            SistemaEnergia system = new SistemaEolic();
            double result = Program.TryConfigPar(system, par);
            double exp = 0d;

            //Assert
            Assert.Equal(exp, result);
        }

        [Theory]
        [InlineData(20d)]
        [InlineData(25d)]
        [InlineData(234d)]
        public void SistemaHidroelectricTryConfigParTrue(double par)
        {
            // Arrange & Act
            SistemaEnergia system = new SistemaHidroelectric();
            double result = Program.TryConfigPar(system, par);
            double exp = par;

            //Assert
            Assert.Equal(exp, result);
        }

        [Theory]
        [InlineData(19.9999d)]
        [InlineData(0d)]
        [InlineData(-4)]
        public void SistemaHidroelectricTryConfigParFalse(double par)
        {
            // Arrange & Act
            SistemaEnergia system = new SistemaHidroelectric();
            double result = Program.TryConfigPar(system, par);
            double exp = 0d;

            //Assert
            Assert.Equal(exp, result);
        }

        [Theory]
        [InlineData(2d)]
        [InlineData(14d)]
        [InlineData(24d)]
        public void SistemaSolarCalculateEnergy(double par)
        {
            // Arrange & Act
            SistemaEnergia system = new SistemaSolar();
            system.ConfigurateParameter(par);
            double result = system.CalculateEnergy();
            double exp = par * 1.5d;

            // Assert
            Assert.Equal(exp, result);
        }

        [Theory]
        [InlineData(5d)]
        [InlineData(16d)]
        [InlineData(28d)]
        public void SistemaEolicCalculateEnergy(double par)
        {
            // Arrange & Act
            SistemaEnergia system = new SistemaEolic();
            system.ConfigurateParameter(par);
            double result = system.CalculateEnergy();
            double exp = Math.Pow(par, 3) * 0.2d;

            // Assert
            Assert.Equal(exp, result);
        }

        [Theory]
        [InlineData(20d)]
        [InlineData(23d)]
        [InlineData(39d)]
        public void SistemaHidroelectricCalculateEnergy(double par)
        {
            // Arrange & Act
            SistemaEnergia system = new SistemaHidroelectric();
            system.ConfigurateParameter(par);
            double result = system.CalculateEnergy();
            double exp = par * 9.8d * 0.8d;

            // Assert
            Assert.Equal(exp, result);
        }

        [Theory]
        [InlineData("1")]
        [InlineData("340")]
        [InlineData("-13")]
        public void ParseNumIntTrue(string str)
        {
            // Arrange & Act
            int result = Text.ParseNumInt(str);
            int exp = int.Parse(str);

            // Assert
            Assert.Equal(exp, result);
        }

        [Theory]
        [InlineData("l")]
        [InlineData("/")]
        [InlineData("1a")]
        public void ParseNumIntFalse(string str)
        {
            // Arrange & Act
            int result = Text.ParseNumInt(str);
            int exp = 0;

            // Assert
            Assert.Equal(exp, result);
        }

        [Theory]
        [InlineData("1.56")]
        [InlineData("123.4567")]
        [InlineData("-9.45")]
        public void ParseNumDoubleTrue(string str)
        {
            // Arrange & Act
            double result = Text.ParseNumDouble(str);
            double exp = double.Parse(str);

            // Assert
            Assert.Equal(exp, result);
        }

        [Theory]
        [InlineData("k")]
        [InlineData("<")]
        [InlineData("4b")]
        public void ParseNumDoubleFalse(string str)
        {
            // Arrange & Act
            double result = Text.ParseNumDouble(str);
            double exp = 0d;

            // Assert
            Assert.Equal(exp, result);
        }
    }
}