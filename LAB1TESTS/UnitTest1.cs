using LAB1;
using System.Reflection;
namespace LAB1TESTS
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ReturnEmptyZeroCapacity()
        {
            string expected_str = "items: \ntotal value: 0\ntotal weight: 0";
            int seed = 1, n = 10, capacity = 0;
            Problem prb = new(n, seed);
            Result res = prb.Solve(capacity);
            Assert.IsTrue(res.ToString() == expected_str);
        }
        [TestMethod]
        public void ReturnEmptyZeroCapacityAndItems()
        {
            string expected_str = "items: \ntotal value: 0\ntotal weight: 0";
            int seed = 1, n = 0, capacity = 0;
            Problem prb = new(n, seed);
            Result res = prb.Solve(capacity);
            Assert.IsTrue(res.ToString() == expected_str);
        }
       
        [TestMethod]
        public void ReturnEmptyZeroItems()
        {
            string expected_str = "items: \ntotal value: 0\ntotal weight: 0";
            int seed = 1, n = 0, capacity = 10;
            Problem prb = new(n, seed);
            Result res = prb.Solve(capacity);
            Assert.IsTrue(res.ToString() == expected_str);
        }
        [TestMethod]
        public void ReturnNotEmpty()
        {
            int seed = 1, n = 10, capacity = 10;
            Problem prb = new(n, seed);
            Result res = prb.Solve(capacity);
            Assert.IsTrue(res.ToString().Split("\n")[1] != "total value: 0");
        }

        //Konkretny przyk³ad - seed == 10, n == 10, capacity == 10
        [TestMethod]
        public void ProblemInstance()
        {
            string expected_str = "items: 4 8 3 \ntotal value: 17\ntotal weight: 8";
            int seed = 10, n = 10, capacity = 10;
            Problem prb = new(n, seed);
            Result res = prb.Solve(capacity);
            Assert.IsTrue(res.ToString() == expected_str);
        }

        //Sprawdz czy kolejnoœæ ma znaczenie
        [TestMethod]
        public void DoesOrderMatter()
        {
            string expected_str = "items: 4 8 3 \ntotal value: 17\ntotal weight: 8";
            int seed = 10, n = 10, capacity = 10;

            //Making it as random as it can be
            Random rng = new Random(Guid.NewGuid().GetHashCode());

            Problem prb = new(n, seed);
            Result res = prb.Solve(capacity);
            Assert.IsTrue(res.ToString() == expected_str);

            //Accesing private field 
            Type type = prb.GetType();
            FieldInfo? fieldInfo = type.GetField("items", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(fieldInfo);
            List<Item>? list = (List<Item>?)fieldInfo.GetValue(prb);
            Assert.IsNotNull(list);
            
            for(int i = 0; i < 100; i++)
            {
                //OrderBy method does not change the order of list, but returns modified object
                //So setting value is also done by reflection
                fieldInfo.SetValue(prb, list.OrderBy(_ => rng.Next()).ToList()); 
                res = prb.Solve(capacity);
                Assert.IsTrue(res.ToString() == expected_str);
            }
            
        }
        [TestMethod]
        public void NegativeCapacity()
        {
            string expected_str = "items: \ntotal value: 0\ntotal weight: 0";
            int seed = 0, n = 5, capacity = -1;
            Problem prb = new(n, seed);
            Result res = prb.Solve(capacity);
            Assert.IsTrue(res.ToString() == expected_str);
        }
        [TestMethod]
        public void NegativeCount()
        {
            string expected_str = "items: \ntotal value: 0\ntotal weight: 0";
            int seed = 0, n = -5, capacity = 0;
            Problem prb = new(n, seed);
            Result res = prb.Solve(capacity);
            Assert.IsTrue(res.ToString() == expected_str);
        }
    }
}