using System;
namespace TextManaging
{
    public static class Text
    {
        // Class Constants
        private const string ErrFormatException = "EL VALOR INTRODUÏT NO ÉS UN NÚMERO";
        private const string ErrOverflowException = "EL VALOR INTRODUÏT ÉS MASSA GRAN";
        private const string ErrException = "HA OCORREGUT UN ERROR INESPERAT";

        /// <summary>
        /// Print an Arrow in Console
        /// </summary>
        public static void PrInpArrow()
        {
            const string InputArrow = "> ";

            Console.Write(InputArrow);
        }

        /// <summary>
        /// Typical 'Press enter to continue'
        /// </summary>
        public static void PressEnter()
        {
            const string MsgEnterPress = "Prem 'Enter' per continuar";

            Console.Write(MsgEnterPress);
            Console.ReadLine();
        }

        /// <summary>
        /// Change value type from String to Int
        /// </summary>
        /// <param name="num"></param>
        /// <returns>num Converted to int if no Exception, 0 if Exception</returns>
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

        /// <summary>
        /// Change value type from String to Double
        /// </summary>
        /// <param name="num"></param>
        /// <returns>num Converted to double if no Exception, 0 if Exception</returns>
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
