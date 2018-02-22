using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var myObject = GetObject("id");
            if (myObject.Name == "something")
            {
                //do stuff
            }
            else
            {
                //send null exception or something
            }
        }

        private MyObject GetObject(string id)
        {
            return new MyObject
            {
                Name = id,
            };
        }
    }

    public struct MyObject
    {
        public string Name { get; set; }
    }
}
