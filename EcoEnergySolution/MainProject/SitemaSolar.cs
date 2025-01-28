using System;
namespace MainProject
{
    public class SistemaSolar : SistemaEnergia
    {
        private double SunHours { get; set; } = 1.1f;

        public SistemaSolar()
        {
            ConfigParName = "Hores de sol";
        }
        
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
        public override double CalculateEnergy()
        {
            return SunHours * 1.5d;
        }
        public override void ShowReport()
        {
            base.ShowReport();
            Console.WriteLine($"| {GetType().Name,-20} | {SunHours,-20:F2} | {CalculateEnergy(),-20:F2} |");
        }
    }
}
