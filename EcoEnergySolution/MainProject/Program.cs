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
            const string ErrInvalidOption = "EL VALOR INTRODUÏT NO ÉS UNA OPCIÓ VÀLIDA";

            int mainMenuOption = 0;

            Console.WriteLine(MsgMainMenu);

            while (mainMenuOption < 1 || mainMenuOption > 3)
            {
                PrInpArrow();
                mainMenuOption = ParseNumInt(Console.ReadLine());

                if (mainMenuOption != 0 && mainMenuOption < 1 || mainMenuOption > 3)
                {
                    Console.WriteLine(ErrInvalidOption);
                }
            }
            switch (mainMenuOption)
            {
                case 1:
                    SimStart();
                    break;
                case 2:
                    SimReport();
                    break;
                case 3:
                    SimExit();
                    break;
                default:
                    SimExit();
                    break;
            }
        }
        public static void SimStart()
        {
            const string MsgSimQuan = "Quantes simulacions vols generar?";
            const string MsgSysSelectMenu = "Quin sistema d'energia vols utilitzar?\n" +
                "1. Sistema Solar\n" +
                "2. Sistema Eolic\n" +
                "3. Sistema Hdroelèctric";
            const string ErrInvalidOption = "EL VALOR INTRODUÏT NO ÉS UNA OPCIÓ VÀLIDA";
            const string ErrSimLimit = "EL LÍMIT DE SIMULACIÓNS ÉS DE {0}";

            int simQuan = 0;
            int sysMenuOption = 0;

            Console.WriteLine(MsgSimQuan);

            while (simQuan > 30)
            {
                PrInpArrow();
                simQuan = ParseNumInt(Console.ReadLine());

                if (simQuan > 20) { Console.WriteLine(ErrSimLimit, 20); }
            }

            if (simQuan <= 0) { SimExit(); }

            Console.WriteLine(MsgSysSelectMenu);

            while (sysMenuOption < 1 || sysMenuOption > 3)
            {
                PrInpArrow();
                sysMenuOption = ParseNumInt(Console.ReadLine());

                if (sysMenuOption != 0 && sysMenuOption < 1 || sysMenuOption > 3)
                {
                    Console.WriteLine(ErrInvalidOption);
                }
            }

            switch (sysMenuOption)
            {
                case 1:
                    SistemaSolar solarSys = new SistemaSolar();
                    Simulation(solarSys);
                    break;
                case 2:
                    SistemaEolic windSys = new SistemaEolic();
                    Simulation(windSys);
                    break;
                case 3:
                    SistemaHidroelectric hidroSys = new SistemaHidroelectric();
                    Simulation(hidroSys);
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
                par = ParseNumInt(Console.ReadLine());
            }

            TryConfigPar(system, par);
        }
        public static void TryConfigPar(SistemaEnergia system, double par)
        {
            try
            {
                system.ConfigurateParameter(par);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
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
