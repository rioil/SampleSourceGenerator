namespace ConsoleApp
{
    partial class Program
    {
        private static void Main(string[] args)
        {
            HelloFrom("Generated Code");
            Console.WriteLine(ConstStrings.Message);
        }

        static partial void HelloFrom(string name);
    }
}
