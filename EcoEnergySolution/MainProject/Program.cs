namespace MainProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string MsgMainMenu =
                "1. Iniciar Simulació\n" +
                "2. Veure informe de simulacions\n" +
                "3. Sortir";
            const string ErrInvalidOption = "El valor introduït no és una opció vàlida";

            int mainMenuOption = 0;

            Console.WriteLine(MsgMainMenu);
            
            while (mainMenuOption < 1 || mainMenuOption > 3)
            {
                PrInpArrow();
                mainMenuOption = ParseNum(Console.ReadLine());

                if (mainMenuOption != 0)
                {
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
                            Console.WriteLine(ErrInvalidOption);
                            break;
                    }
                }
            }
        }
        public static void SimStart()
        {
            const string MsgSimQuan = "Quantes simulacions vols generar?";
            const string MsgSysSelectMenu = "Quin sistema d'energia vols utilitzar?\n" +
                "1. Sistema Solar\n" +
                "2. Sistema Eolic\n" +
                "3. Sistema Hdroelèctric";

            int simQuan = 0;
            int sysMenuOption = 0;

            Console.WriteLine(MsgSimQuan);
            PrInpArrow();
            simQuan = ParseNum(Console.ReadLine());

            Console.WriteLine(MsgSysSelectMenu);
            PrInpArrow();
            sysMenuOption = ParseNum(Console.ReadLine());

            switch (sysMenuOption)
            {
                case 1:
                    SistemaSolarSim();
                    break;
                case 2:
                    SistemaEolicSim();
                    break;
                case 3:
                    SistemaHidroelectricSim();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("El valor introduït no és una opció vàlida");
            }
        }
        public static void SistemaSolarSim()
        {
            const string MsgConfValue = "Introdueix les hores de sol:";

            SistemaSolar sistemaSolar = new SistemaSolar();
            Console.WriteLine(MsgConfValue);
            PrInpArrow();
            sistemaSolar.ConfigurateParameter(ParseNum(Console.ReadLine()));
        }
        public static void SistemaEolicSim()
        {
            const string MsgConfValue = "Introdueix la velocitat del vent:";

            SistemaEolic sistemaEolic = new SistemaEolic();
            Console.WriteLine(MsgConfValue);
            PrInpArrow();
            sistemaEolic.ConfigurateParameter(ParseNum(Console.ReadLine()));
        }
        public static void SistemaHidroelectricSim()
        {
            const string MsgConfValue = "Introdueix el cabal d'aigua:";

            SistemaHidroelectric sistemaHidroelectric = new SistemaHidroelectric();
            Console.WriteLine(MsgConfValue);
            PrInpArrow();
            sistemaHidroelectric.ConfigurateParameter(ParseNum(Console.ReadLine()));
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
        public static int ParseNum(string num)
        {
            const string ErrFormatException = "El valor introduït no és un número";
            const string ErrException = "Ha ocorregut un error inesperat";

            try
            {
                return int.Parse(num);
            }
            catch (FormatException)
            {
                Console.WriteLine(ErrFormatException);
            }
            catch (Exception)
            {
                Console.WriteLine(ErrException);
            }
            return 0;
        }
    }
}
