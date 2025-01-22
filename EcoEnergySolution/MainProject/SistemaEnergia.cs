using System;
namespace MainProject
{
    public abstract class SistemaEnergia : ICalculEnergia
    {
        public abstract void ConfigurateParameter(float par);
        public abstract float CalculateEnergy();
        public void ShowReport(string configParName, float configPar)
        {
            Console.WriteLine($"| {"Tipus Sistema",-20} | {configParName,-20} | {"Energia Generada",-20} |");
            Console.WriteLine(new string('-', 70));
            Console.WriteLine($"| {GetType().Name,-20} | {configPar,-20:F2} | {CalculateEnergy(),-20:F2} |");
        }
    }
}
