using System;
namespace MainProject
{
    public abstract class SistemaEnergia : ICalculEnergia
    {
        // Name of the parameter to configure
        public string? ConfigParName { get; protected set; }
        // Set the Date Time of the system
        public DateTime Date { get; } = DateTime.Now;

        public abstract void ConfigurateParameter(double par);
        public abstract double CalculateEnergy();

        /// <summary>
        /// Show the system report
        /// </summary>
        public virtual void ShowReport()
        {
            Console.WriteLine($"| {"Tipus Sistema",-20} | {ConfigParName,-20} | {"Energia Generada",-20} |");
            Console.WriteLine(new string('-', 70));
        }
    }
}
