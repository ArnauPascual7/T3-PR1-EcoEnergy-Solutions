using System;
namespace TextManaging
{
    public static class Text
    {
        private const string ErrFormatException = "EL VALOR INTRODUÏT NO ÉS UN NÚMERO";
        private const string ErrOverflowException = "EL VALOR INTRODUÏT ÉS MASSA GRAN";
        private const string ErrException = "HA OCORREGUT UN ERROR INESPERAT";

        public static void PrInpArrow()
        {
            const string InputArrow = "> ";

            Console.Write(InputArrow);
        }
        public static void PressEnter()
        {
            const string MsgEnterPress = "Prem 'Enter' per continuar";

            Console.Write(MsgEnterPress);
            Console.ReadLine();
        }
        public static int ParseNumInt(string num)
        {
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
