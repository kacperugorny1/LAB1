
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("LAB1TESTS")]
[assembly: InternalsVisibleTo("FormsApp")]
namespace LAB1
{
    internal class Problem
    {
        int n;
        int seed;
        List<Item> items;
        public Problem(int n, int seed)
        {
            this.n = n;
            this.seed = seed;
            Random rnd = new Random(seed);
            items = new List<Item>();
            for (int i = 0; i < n; i++)
            {
                items.Add(new Item(rnd.Next(10) + 1, rnd.Next(10) + 1, i));
            }
        }

        public Result Solve(int capacity)
        {
            List<Item> backpack = new List<Item>();
            items.Sort((x, y) => { 
                float res = ((float)x.Value / (float)x.Weight - (float)y.Value / (float)y.Weight) < 0 ? 1 : -1;
                if (res < 0) return 1;
                if (res > 0) return -1;
                return 0;
            });
            items.ForEach(item =>
            {
                if (capacity >= item.Weight)
                {
                    backpack.Add(item);
                    capacity -= item.Weight;
                }
            });
            return new Result(backpack);
        }



    }
}
