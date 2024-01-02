namespace ConsoleApp
{
    partial class Program
    {
        private static void Main(string[] args)
        {
            HelloFrom("Generated Code");
            Console.WriteLine(ConstStrings.Message);

            var model = new MyModelObject
            {
                IntField1 = 1,
                IntField2 = 2,
                IntField3 = 3,
                LongField = 4,
            };
            Console.WriteLine($"{model.IntField1}, {model.IntField2}, {model.IntField3}, {model.LongField}");
        }

        static partial void HelloFrom(string name);
    }
}
