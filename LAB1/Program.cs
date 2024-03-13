namespace LAB1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the seed :");
            int seed = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter items count :");
            int count = int.Parse(Console.ReadLine());
            Problem prb = new(count, seed);

            Console.WriteLine(prb);
            Console.WriteLine("Enter capacity :");
            int capacity = int.Parse(Console.ReadLine());

            Result res = prb.Solve(capacity);
            Console.WriteLine(res);
            
        }
    }
}
