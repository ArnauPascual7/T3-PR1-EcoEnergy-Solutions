using System;
namespace MainProject
{
    public class SistemaHidroelectric : SistemaEnergia
    {
        private double WaterFlow { get; set; } = 20f;

        public SistemaHidroelectric()
        {
            ConfigParName = "Cabal d'aigua";
        }

        public override void ConfigurateParameter(double waterFlow)
        {
            if (waterFlow >= 20)
            {
                WaterFlow = waterFlow;
            }
            else
            {
                throw new ArgumentException("El cabal d'aigua no pot ser inferior a 20 m^3!");
            }
        }
        public override double CalculateEnergy()
        {
            return WaterFlow * 9.8f * 0.8;
        }
        public override void ShowReport()
        {
            base.ShowReport();
            Console.WriteLine($"| {GetType().Name,-20} | {WaterFlow,-20:F2} | {CalculateEnergy(),-20:F2} |");
        }
    }
}
