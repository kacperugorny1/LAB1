namespace LAB1
{
    internal class Result
    {
        List<Item> backpack;
        int total_weight;
        int total_value;
        public Result(List<Item> items)
        {
            backpack = items;
            backpack.ForEach(item =>
            {
                total_value += item.Value;
                total_weight += item.Weight;
            });
        }
        public override string ToString()
        {
            string str = "items: ";
            backpack.ForEach(item => str += $"{item.Nr} ");
            str += $"\ntotal value: {total_value}";
            str += $"\ntotal weight: {total_weight}";

            return str;
        }

    }
}
