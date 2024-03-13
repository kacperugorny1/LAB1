namespace LAB1
{
    internal class Item
    {
        int weight;
        int value;
        int nr;
        public Item(int weight, int value, int nr)
        {
            this.weight = weight;
            this.value = value;
            this.nr = nr;
        }

        public int Weight { get => weight; }
        public int Value { get => value; }
        public int Nr { get => nr; }

        
    }
}
