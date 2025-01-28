using System;
using TextManaging;
namespace MainProject
{
    public class Program
    {
        // Class Variables
        private static int CurrentSimulation = 0;
        private static int SimulationLimit = 0;
        private static SimulationSet SimSet = new SimulationSet();

        public static void Main(string[] args)
        {
            DisplayMenu();
        }

        /// <summary>
        /// Handles the main menu:
        /// Displays the menu on the screen, requests a menu option and calls a function depending on the option.
        /// </summary>
        public static void DisplayMenu()
        {
            const string MsgWelcome = "Benvingut! Aquí podrás fer simulacions de sistemes d'energia.";
            const string MsgMainMenu =
                "Que vols fer?\n" +
                "1. Iniciar Simulació\n" +
                "2. Veure informe de simulacions\n" +
                "3. Sortir";
            const string MsgLimitSimReached = "Has arribat al límit de simulacions!";

            const int minMenuOption = 1;
            const int maxMenuOption = 3;

            if (CurrentSimulation < SimulationLimit || CurrentSimulation == 0)
            {
                int mainMenuOption = 0;

                if (CurrentSimulation == 0)
                {
                    Console.WriteLine(MsgWelcome);
                    Console.WriteLine();
                    Text.PressEnter();

                    Console.Clear();
                }

                Console.WriteLine(MsgMainMenu);

                mainMenuOption = MenuOptionReadLoop(minMenuOption, maxMenuOption);
                Console.Clear();

                switch (mainMenuOption)
                {
                    case 1:
                        if (CurrentSimulation == 0) { SimCountSetup(); SimSet.InitSimulations(SimulationLimit); }
                        SimulationSetup();
                        break;
                    case 2:
                        SimulationReport();
                        break;
                    default:
                        SimulationExit();
                        break;
                }
            }
            else
            {
                Console.WriteLine(MsgLimitSimReached);
                Console.WriteLine();

                SimulationExit();
            }
        }

        /// <summary>
        /// Configure the number of simulations
        /// </summary>
        public static void SimCountSetup()
        {
            const string MsgSimCount = "Quantes simulacions vols generar?";
            const string ErrSimCountLimit = "EL LÍMIT DE SIMULACIÓNS ÉS DE {0}";
            const string ErrNegativeSimCount = "EL NOMBRE DE SIMULACIONS NO POT SER 0 O INFERIOR";

            const int SimLimit = 20;

            Console.WriteLine(MsgSimCount);

            while (SimulationLimit == 0)
            {
                Text.PrInpArrow();
                SimulationLimit = Text.ParseNumInt(Console.ReadLine());

                if (SimulationLimit > SimLimit) { Console.WriteLine(ErrSimCountLimit, SimLimit); SimulationLimit = 0; }
                else if (SimulationLimit <= 0) { Console.WriteLine(ErrNegativeSimCount); SimulationLimit = 0; }

                Console.WriteLine();
            }
            Console.Clear();
        }

        /// <summary>
        /// Establishes the energy system
        /// </summary>
        public static void SimulationSetup()
        {
            const string MsgCurrentSimulation = "Simulació actual: {0}";
            const string MsgSysSelectMenu = "Quin sistema d'energia vols utilitzar?\n" +
                "1. Sistema Solar\n" +
                "2. Sistema Eolic\n" +
                "3. Sistema Hdroelèctric";

            const int minMenuOption = 1;
            const int maxMenuOption = 3;

            int sysMenuOption = 0;

            Console.WriteLine(MsgCurrentSimulation, CurrentSimulation + 1);
            Console.WriteLine();
            Console.WriteLine(MsgSysSelectMenu);

            sysMenuOption = MenuOptionReadLoop(minMenuOption, maxMenuOption);

            SistemaEnergia system;

            switch (sysMenuOption)
            {
                case 1:
                    system = new SistemaSolar();
                    SimSet.AddSimulation(system, CurrentSimulation);
                    Simulation(system);
                    break;
                case 2:
                    system = new SistemaEolic();
                    SimSet.AddSimulation(system, CurrentSimulation);
                    Simulation(system);
                    break;
                case 3:
                    system = new SistemaHidroelectric();
                    SimSet.AddSimulation(system, CurrentSimulation);
                    Simulation(system);
                    break;
                default:
                    SimulationExit();
                    break;
            }
        }

        /// <summary>
        /// Run the simulation:
        /// Set the parameter and show the report
        /// </summary>
        /// <param name="system">Current Simulation System</param>
        public static void Simulation(SistemaEnergia system)
        {
            const string MsgConfValue = "Introdueix {0}:";

            double parameter = 0d;

            Console.WriteLine();
            Console.WriteLine(MsgConfValue, system.ConfigParName);

            while (parameter == 0d)
            {
                Text.PrInpArrow();
                parameter = Text.ParseNumDouble(Console.ReadLine());
                if (parameter != 0d) { parameter = TryConfigPar(system, parameter); }
            }

            Console.WriteLine();
            system.ShowReport();
            Console.WriteLine();
            Text.PressEnter();
            Console.Clear();

            CurrentSimulation++;

            DisplayMenu();
        }

        /// <summary>
        /// Show all simulations in a table
        /// </summary>
        public static void SimulationReport()
        {
            try
            {
                SimSet.ShowSimulationReport();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            Text.PressEnter();
            Console.Clear();

            DisplayMenu();
        }

        /// <summary>
        /// Show all simulations in a table and exit the simulation
        /// </summary>
        public static void SimulationExit()
        {
            const string MsgExit = "Fi de la simulació - Quantitat de simulacions: {0}";

            try
            {
                SimSet.ShowSimulationReport();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            Console.WriteLine(MsgExit, CurrentSimulation);
        }

        /// <summary>
        /// Enters a loop until a correct value is entered, and returns it.
        /// </summary>
        /// <param name="min">Min Menu Option</param>
        /// <param name="max">Max Menu Option</param>
        /// <returns>Menu Option</returns>
        public static int MenuOptionReadLoop(int min, int max)
        {
            const string ErrInvalidOption = "EL VALOR INTRODUÏT NO ÉS UNA OPCIÓ VÀLIDA";

            int num = 0;

            while (num < min || num > max)
            {
                Text.PrInpArrow();
                num = Text.ParseNumInt(Console.ReadLine());

                if (num < min || num > max)
                {
                    Console.WriteLine(ErrInvalidOption);
                    Console.WriteLine();
                }
            }
            return num;
        }

        /// <summary>
        /// Try to configure the system parameter
        /// </summary>
        /// <param name="system">Current Simulation System</param>
        /// <param name="par">Parameter to set</param>
        /// <returns>Parameter if no Exception, 0 if Exception</returns>
        public static double TryConfigPar(SistemaEnergia system, double par)
        {
            try
            {
                system.ConfigurateParameter(par);
                return par;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }
            return 0d;
        }
    }
}
