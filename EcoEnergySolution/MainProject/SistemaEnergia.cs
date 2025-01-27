using System;
namespace MainProject
{
    public abstract class SistemaEnergia : ICalculEnergia
    {
        public string? ConfigParName { get; set; }
        public DateTime Date { get; } = DateTime.Now;

        public abstract void ConfigurateParameter(double par);
        public abstract double CalculateEnergy();
        public virtual void ShowReport()
        {
            Console.WriteLine($"| {"Tipus Sistema",-20} | {ConfigParName,-20} | {"Energia Generada",-20} |");
            Console.WriteLine(new string('-', 70));
        }
    }
}
