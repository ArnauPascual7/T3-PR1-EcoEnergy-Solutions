namespace MainProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SistemaSolar mySolarSystem = new SistemaSolar();
            SistemaEolic myWindSystem = new SistemaEolic();
            SistemaHidroelectric myHidroSystem = new SistemaHidroelectric();

            mySolarSystem.ShowReport();
            Console.WriteLine();
            myWindSystem.ShowReport();
            Console.WriteLine();
            myHidroSystem.ShowReport();
        }
    }
}
