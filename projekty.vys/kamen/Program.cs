namespace kamen
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

            {
                Console.WriteLine("Neplatná volba");
                return;
            }
            int indexPocitace = rnd.Next(moznosti.Lenght);
            string volbaPocitace = moznosti[indexPocitace];

            Console.WriteLine($"Počítač zvolil {volbaPocitace}");

            if (volbaPocitace == VolbaHrace)
            {
                Console.WriteLine("remíza");
            }
            else if ((VolbaHrace == "kámen" && volbaPocitace == "Nůžky") ||
                     (VolbaHrace == "nůžky" && volbaPocitace == "papír") ||
                     (VolbaHrace == "papír" && volbaPocitace == "kámen"))

            {
                Console.WriteLine("Vyhrála jsi");
            }

            else
            {
                Console.WriteLine("prohrál jsi!");
            }
        }
    }
}

