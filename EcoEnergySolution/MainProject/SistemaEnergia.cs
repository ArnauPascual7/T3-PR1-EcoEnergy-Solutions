using System;
namespace MainProject
{
    public abstract class SistemaEnergia : ICalculEnergia
    {
        public abstract void ConfigurarParametres();
        public abstract float CalcularEnergia();
        public void MostrarInforme(string configParName, float configPar)
        {
            Console.WriteLine($"| {"Tipus Sistema",-20} | {configParName,-20} | {"Energia Generada",-20} |");
            Console.WriteLine(new string('-', 70));
            Console.WriteLine($"| {GetType().Name,-20} | {configPar,-20:F2} | {CalcularEnergia(),-20:F2} |");
        }
    }
}
