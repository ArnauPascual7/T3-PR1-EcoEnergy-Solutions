namespace MainProject
{
    public class Program
    {
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
                    SimSetup();
                    break;
                case 2:
                    SimReport();
                    break;
                default:
                    SimExit();
                    break;
            }
        }
        public static void SimSetup()
        {
            const string MsgSimQuan = "Quantes simulacions vols generar?";
            const string MsgSysSelectMenu = "Quin sistema d'energia vols utilitzar?\n" +
                "1. Sistema Solar\n" +
                "2. Sistema Eolic\n" +
                "3. Sistema Hdroelèctric";
            const string ErrSimLimit = "EL LÍMIT DE SIMULACIÓNS ÉS DE {0}";
            const string ErrNegativeSimQuan = "EL NOMBRE DE SIMULACIONS NO POT SER 0 O INFERIOR";

            int simQuan = 0;
            int sysMenuOption = 0;

            Console.WriteLine(MsgSimQuan);

            while (simQuan == 0)
            {
                PrInpArrow();
                simQuan = ParseNumInt(Console.ReadLine());

                if (simQuan > 20) { Console.WriteLine(ErrSimLimit, 20); simQuan = 0;  }
                else if (simQuan <= 0) { Console.WriteLine(ErrNegativeSimQuan); simQuan = 0; }
            }

            Console.WriteLine(MsgSysSelectMenu);

            sysMenuOption = MenuOptionReadLoop(1, 3, sysMenuOption);

            SistemaEnergia system;

            switch (sysMenuOption)
            {
                case 1:
                    system = new SistemaSolar();
                    Simulation(system);
                    break;
                case 2:
                    system = new SistemaEolic();
                    Simulation(system);
                    break;
                case 3:
                    system = new SistemaHidroelectric();
                    Simulation(system);
                    break;
                default:
                    SimExit();
                    break;
            }
        }
        public static void Simulation(SistemaEnergia system)
        {
            const string MsgConfValue = "Introdueix {0}:";

            double par = 0f;

            Console.WriteLine(MsgConfValue, system.ConfigParName);

            while (par == 0)
            {
                PrInpArrow();
                par = ParseNumDouble(Console.ReadLine());
                if (par != 0) { par = TryConfigPar(system, par); }
            }
        }
        public static void SimReport()
        {
            throw new NotImplementedException();
        }
        public static void SimExit()
        {
            const string MsgExit = "Fi del programa.";

            Console.WriteLine(MsgExit);
        }
        public static int MenuOptionReadLoop(int minOption, int maxOption, int num)
        {
            const string ErrInvalidOption = "EL VALOR INTRODUÏT NO ÉS UNA OPCIÓ VÀLIDA";

            while (num < minOption || num > maxOption)
            {
                PrInpArrow();
                num = ParseNumInt(Console.ReadLine());

                if (num != 0 && num < 1 || num > 3)
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
            return 0;
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
            return 0f;
        }
    }
}
