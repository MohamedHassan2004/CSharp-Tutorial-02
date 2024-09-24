using System.Reflection;
namespace AttrTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region print the InfoAtrr of MathOperations Cls:

            Type ClsType = typeof(MathOperations);
            var InfoAttr = ClsType.GetCustomAttribute<InfoAttribute>();
            Console.WriteLine(InfoAttr?.Description);
            #endregion

            #region print the InfoAtrr(s) of MathOperations Methods:

            // get methods
            MethodInfo[] MethodsInfo = ClsType.GetMethods();
            // looping on every methods
            foreach (var m in MethodsInfo)
            {
                // get attr of every method
                var MethodAttr = m.GetCustomAttributes<InfoAttribute>(false);
                // looping on all attr of every method
                foreach (var attr in MethodAttr)
                {
                    Console.WriteLine($"{m.Name} :: {attr.Description}");
                }
            }
            #endregion
        }
    }


    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    class InfoAttribute : Attribute
    {
        string description;
        public InfoAttribute(string description)
        {
            this.description = description;
        }
        public string Description { get { return description; } }
    }

    
    [Info("Math operations class")]
    class MathOperations
    {
        [Info("Addition")]
        [Info("Example : 5 + 1 = 6")]
        public int Add(int a, int b)
        {
            return a + b;
        }

        [Info("Subtraction like 2 - 2 = 0")]
        public int Subtract(int a, int b)
        {
            return a - b;
        }

        [Info("Multiplication like 2 * 2 = 4")]
        public int Multiply(int a, int b)
        {
            return a * b;
        }

        [Info("Division like 2 / 2 = 1")]
        public int Divide(int a, int b)
        {
            return a / b;
        }
    }
}
