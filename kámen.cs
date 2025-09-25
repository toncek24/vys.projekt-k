namespace vys.projekt_
{
    internal class Program
    {
        static void Main()
        {
            string[] moznosti = { "kámen", "nůžky", "papír" };
            Random rnd = new Random();

            Console.Write("Vyber si Kámen, nůžky, nebo papír!");
            string VolbaHrace = Console.Readline().To.Lower();

            if (!Array.Exists(moznosti, prvek => prvek == VolbaHrace))


        }
    }
}
