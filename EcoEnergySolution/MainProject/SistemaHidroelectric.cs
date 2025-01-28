using System;
namespace MainProject
{
    public class SistemaHidroelectric : SistemaEnergia
    {
        // Parameter to configure
        private double WaterFlow { get; set; } = 20f;

        // Constructor -> Initializes the name of the parameter to configure
        public SistemaHidroelectric()
        {
            ConfigParName = "Cabal d'aigua";
        }

        /// <summary>
        /// Set the Water Flow
        /// </summary>
        /// <param name="waterFlow">Parameter to set</param>
        /// <exception cref="ArgumentException">Throw when the parameter is invalid</exception>
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

        /// <summary>
        /// Calculate the energy
        /// </summary>
        /// <returns>Energy calculated</returns>
        public override double CalculateEnergy()
        {
            return WaterFlow * 9.8d * 0.8d;
        }

        /// <summary>
        /// Show the parent system report and the child system report
        /// </summary>
        public override void ShowReport()
        {
            base.ShowReport();
            Console.WriteLine($"| {GetType().Name,-20} | {WaterFlow,-20:F2} | {CalculateEnergy(),-20:F2} |");
        }
    }
}
