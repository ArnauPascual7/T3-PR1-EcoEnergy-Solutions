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
                Console.WriteLine($"| {"Data",-20} | {"Tipus Sistema",-20} | {"Energia Generada",-20} |");
                Console.WriteLine(new string('-', 70));
                foreach (SistemaEnergia sim in simulations)
                {
                    if (sim is not null)
                    {
                        Console.WriteLine($"| {sim.Date,-20} | {sim.GetType(),-20} | {sim.CalculateEnergy(),-20:F2} |");
                    }
                }
            }
        }
    }
}
