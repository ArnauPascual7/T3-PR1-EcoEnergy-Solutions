using System;
namespace MainProject
{
    public class SistemaSolar : SistemaEnergia
    {
        // Parameter to configure
        private double SunHours { get; set; } = 1.1f;

        // Constructor -> Initializes the name of the parameter to configure
        public SistemaSolar()
        {
            ConfigParName = "Hores de sol";
        }

        /// <summary>
        /// Set the Sun Hours
        /// </summary>
        /// <param name="sunHours">Parameter to set</param>
        /// <exception cref="ArgumentException">Throw when the parameter is invalid</exception>
        public override void ConfigurateParameter(double sunHours)
        {
            if (sunHours > 1)
            {
                SunHours = sunHours;
            }
            else
            {
                throw new ArgumentException("Les hores de sol no poden ser inferiors a 1 hora!");
            }
        }

        /// <summary>
        /// Calculate the energy
        /// </summary>
        /// <returns>Energy calculated</returns>
        public override double CalculateEnergy()
        {
            return SunHours * 1.5d;
        }

        /// <summary>
        /// Show the parent system report and the child system report
        /// </summary>
        public override void ShowReport()
        {
            base.ShowReport();
            Console.WriteLine($"| {GetType().Name,-20} | {SunHours,-20:F2} | {CalculateEnergy(),-20:F2} |");
        }
    }
}
