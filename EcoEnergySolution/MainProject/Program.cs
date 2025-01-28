namespace MainProject
{
    public class Program
    {
        public static int CurrentSimulation = 0;
        public static int SimulationLimit = 0;
        public static SimulationSet SimSet = new SimulationSet();
        public static void Main(string[] args)
        {
            DisplayMenu();
        }
        public static void DisplayMenu()
        {
            const string MsgMainMenu =
                "1. Iniciar Simulació\n" +
                "2. Veure informe de simulacions\n" +
                "3. Sortir";

            int mainMenuOption = 0;

            Console.WriteLine(MsgMainMenu);

            mainMenuOption = MenuOptionReadLoop(1, 3, mainMenuOption);

            switch (mainMenuOption)
            {
                case 1:
                    if (CurrentSimulation == 0) { SimSet.InitSimulations(SimCountSetup()); }
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
        public static int SimCountSetup()
        {
            const string MsgSimCount = "Quantes simulacions vols generar?";
            const string ErrSimCountLimit = "EL LÍMIT DE SIMULACIÓNS ÉS DE {0}";
            const string ErrNegativeSimCount = "EL NOMBRE DE SIMULACIONS NO POT SER 0 O INFERIOR";

            Console.WriteLine(MsgSimCount);

            while (SimulationLimit == 0)
            {
                PrInpArrow();
                SimulationLimit = ParseNumInt(Console.ReadLine());

                if (SimulationLimit > 20) { Console.WriteLine(ErrSimCountLimit, 20); SimulationLimit = 0; }
                else if (SimulationLimit <= 0) { Console.WriteLine(ErrNegativeSimCount); SimulationLimit = 0; }
            }
            return SimulationLimit;
        }
        public static void SimulationSetup()
        {
            const string MsgSysSelectMenu = "Quin sistema d'energia vols utilitzar?\n" +
                "1. Sistema Solar\n" +
                "2. Sistema Eolic\n" +
                "3. Sistema Hdroelèctric";

            int sysMenuOption = 0;

            Console.WriteLine(MsgSysSelectMenu);

            sysMenuOption = MenuOptionReadLoop(1, 3, sysMenuOption);

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
        public static void Simulation(SistemaEnergia system)
        {
            const string MsgConfValue = "Introdueix {0}:";

            double parameter = 0d;

            Console.WriteLine(MsgConfValue, system.ConfigParName);

            while (parameter == 0d)
            {
                PrInpArrow();
                parameter = ParseNumDouble(Console.ReadLine());
                if (parameter != 0) { parameter = TryConfigPar(system, parameter); }
            }

            system.ShowReport();

            CurrentSimulation++;

            DisplayMenu();
        }
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
        }
        public static void SimulationExit()
        {
            const string MsgExit = "Fi del programa.";

            Console.WriteLine(MsgExit);
        }
        public static int MenuOptionReadLoop(int min, int max, int num)
        {
            const string ErrInvalidOption = "EL VALOR INTRODUÏT NO ÉS UNA OPCIÓ VÀLIDA";

            while (num < min || num > max)
            {
                PrInpArrow();
                num = ParseNumInt(Console.ReadLine());

                if (num < 1 || num > 3)
                {
                    Console.WriteLine(ErrInvalidOption);
                }
            }
            return num;
        }
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
            }
            return 0d;
        }
        public static void PrInpArrow()
        {
            const string InputArrow = "> ";

            Console.Write(InputArrow);
        }
        public static int ParseNumInt(string num)
        {
            const string ErrFormatException = "EL VALOR INTRODUÏT NO ÉS UN NÚMERO";
            const string ErrOverflowException = "EL VALOR INTRODUÏT ÉS MASSA GRAN";
            const string ErrException = "HA OCORREGUT UN ERROR INESPERAT";

            try
            {
                return int.Parse(num);
            }
            catch (FormatException)
            {
                Console.WriteLine(ErrFormatException);
            }
            catch (OverflowException)
            {
                Console.WriteLine(ErrOverflowException);
            }
            catch (Exception)
            {
                Console.WriteLine(ErrException);
            }
            return 0;
        }
        public static double ParseNumDouble(string num)
        {
            const string ErrFormatException = "EL VALOR INTRODUÏT NO ÉS UN NÚMERO";
            const string ErrOverflowException = "EL VALOR INTRODUÏT ÉS MASSA GRAN";
            const string ErrException = "HA OCORREGUT UN ERROR INESPERAT";

            try
            {
                return double.Parse(num);
            }
            catch (FormatException)
            {
                Console.WriteLine(ErrFormatException);
            }
            catch (OverflowException)
            {
                Console.WriteLine(ErrOverflowException);
            }
            catch (Exception)
            {
                Console.WriteLine(ErrException);
            }
            return 0d;
        }
    }
}
