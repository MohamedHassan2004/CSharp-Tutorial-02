using System;
using System.Reflection;

namespace ReflectionTask
{
    public class MathOperations
    {
        public int Add(int x, int y) => x + y;
        public int Subtract(int x, int y) => x - y;
        public int Multiply(int x, int y) => x * y;
        public int Divide(int x, int y)
        {
            if (y == 0) throw new ArgumentException("Cannot divide by zero", nameof(y));
            return x / y;
        }
    }

    internal class Program
    {
        private static readonly string[] Methods = { "Add", "Subtract", "Multiply", "Divide" };
        static int ReadValidInt(string prompt)
        {
            int result;
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
            } while (!int.TryParse(input, out result));

            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Available methods:");
            foreach (var method in Methods)
                Console.WriteLine(method);

            Console.WriteLine("Write the method you want:");
            string inputMethod = Console.ReadLine();

            // Array.Exists(array , condition[lambda expression]))
            if (!Array.Exists(Methods, method => method.Equals(inputMethod,StringComparison.OrdinalIgnoreCase))){
                Console.WriteLine("Invalid Operation");
                return;
            }

            MethodInfo methodInfo = typeof(MathOperations).GetMethod(inputMethod);

            if (methodInfo == null){
                Console.WriteLine("method not found");
                return;
            }

            int firstNumber = ReadValidInt("Write the first number: ");
            int secondNumber = ReadValidInt("Write the second number: ");
            object[] parameters = new object[] { firstNumber, secondNumber };

            try{
                object result = methodInfo.Invoke(new MathOperations(), parameters);
                Console.WriteLine($"Answer => {result}");
            }catch (TargetInvocationException ex){
                Console.WriteLine($"An error occurred: {ex.InnerException?.Message}");
            }
        }

        
    }
}
