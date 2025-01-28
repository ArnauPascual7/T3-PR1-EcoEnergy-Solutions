using System;
namespace MainProject
{
    public class SistemaEolic : SistemaEnergia
    {
        // Parameter to configure
        private double WindVelocity { get; set; } = 5;

        // Constructor -> Initializes the name of the parameter to configure
        public SistemaEolic()
        {
            ConfigParName = "Velocitat del vent";
        }

        /// <summary>
        /// Set the Wind Velocity
        /// </summary>
        /// <param name="windVelocity">Parameter to set</param>
        /// <exception cref="ArgumentException">Throw when the parameter is invalid</exception>
        public override void ConfigurateParameter(double windVelocity)
        {
            if (windVelocity >= 5)
            {
                WindVelocity = windVelocity;
            }
            else
            {
                throw new ArgumentException("La velocitat del vent no pot ser inferior a 5 m/s!");
            }
        }

        /// <summary>
        /// Calculate the energy
        /// </summary>
        /// <returns>Energy calculated</returns>
        public override double CalculateEnergy()
        {
            return Math.Pow(WindVelocity, 3) * 0.2d;
        }

        /// <summary>
        /// Show the parent system report and the child system report
        /// </summary>
        public override void ShowReport()
        {
            base.ShowReport();
            Console.WriteLine($"| {GetType().Name,-20} | {WindVelocity,-20:F2} | {CalculateEnergy(),-20:F2} |");
        }
    }
}
