
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Module10_Task2
{
    internal class Program
    {
        static Ilogger Logger { get; set; }

        static void Main(string[] args)
        {
            Logger = new Logger();
            var Calculator = new Calculator(Logger);
            Calculator.Work();

            Console.ReadKey();         
        }
    }

    public interface ICalculator
    {
        int Addition(int a, int b);
    }
    public class Calculator : ICalculator, IWorker
    {
        Ilogger Logger { get; }

        public Calculator(Ilogger logger)
        {
            Logger = logger;
        }

        public int Addition(int a, int b)
        {
            return a + b;
        }

        public void Work()
        {
            Logger.Event("Calculator начал свою работу");

             try
            {
                Logger.Event("a + b = ?");
                Logger.Event("Введите значение a:");

                int a = 0;
                bool successA = int.TryParse(Console.ReadLine(), out a);

                if (!successA)
                {
                    throw new Exception("Не корректное значение а");
                }

                Logger.Event("Введите значение b:");

                int b = 0;
                bool successB = int.TryParse(Console.ReadLine(), out b);

                if (!successB)
                {
                    throw new Exception("Не корректное значение b");
                }

                int result = Addition(a, b);

                Logger.Event("a + b = " + result.ToString());
     
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }

            Logger.Event("Calculator закончил свою работу");
        }
    }

    public interface Ilogger 
    {
        void Event(string message);
        void Error(string message);
    }

    public class Logger : Ilogger
    {
        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);  
        }

        public void Event(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
        }
    }

    public interface IWorker
    { 
        void Work();
    }
}
