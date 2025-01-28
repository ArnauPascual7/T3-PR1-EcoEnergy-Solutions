using System;
namespace MainProject
{
    public class SimulationSet
    {
        private SistemaEnergia[] simulations;

        public void InitSimulations(int simulationCount)
        {
            simulations = new SistemaEnergia[simulationCount];
        }

        public void AddSimulation(SistemaEnergia system, int position)
        {
            simulations[position] = system;
        }

        public void ShowSimulationReport()
        {
            if (simulations is not null)
            {
                Console.WriteLine($"| {"Informe de Simulacions",45} {"",-20} |");
                Console.WriteLine(new string('-', 70));
                Console.WriteLine($"| {"Data",-20} | {"Tipus Sistema",-20} | {"Energia Generada",-20} |");
                Console.WriteLine(new string('-', 70));
                foreach (SistemaEnergia sim in simulations)
                {
                    if (sim is not null)
                    {
                        Console.WriteLine($"| {sim.Date,-20} | {sim.GetType().Name,-20} | {sim.CalculateEnergy(),-20:F2} |");
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("No s'ha creat cap simulació!");
            }
        }
    }
}
