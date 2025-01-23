using System;
namespace MainProject
{
    public class SistemaEolic : SistemaEnergia
    {
        private double WindVelocity { get; set; } = 5;

        public SistemaEolic()
        {
            ConfigParName = "Velocitat del vent";
        }

        public override void ConfigurateParameter(double windVelocity)
        {
            if (windVelocity >= 5)
            {
                WindVelocity = windVelocity;
            }
            else
            {
                throw new ArgumentException("La velocitat del vent no pot ser inferior a 5 m/s");
            }
        }
        public override double CalculateEnergy()
        {
            return Math.Pow(WindVelocity, 3) * 0.2f;
        }
        public override void ShowReport()
        {
            base.ShowReport();
            Console.WriteLine($"| {GetType().Name,-20} | {WindVelocity,-20:F2} | {CalculateEnergy(),-20:F2} |");
        }
    }
}
