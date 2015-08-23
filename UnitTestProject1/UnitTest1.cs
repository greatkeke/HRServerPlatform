using _02BLL;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _04Model;
using System.Linq;

namespace _02BLL.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        [TestMethod()]
        public void AddTest()
        {
            BaseBLL<t_Categories> baseBll = new BaseBLL<t_Categories>();
            baseBll.Add(new t_Categories() { ID = Guid.NewGuid(), CategoryName = "world" });

        }
    }
}

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //var db = _04Model.ModelFactory.GetContext();
            var db = new _04Model.Model1();
            var t = db.Set<t_Categories>().ToList();
            db.Set<t_Categories>().Add(new t_Categories()
            {
                ID = Guid.NewGuid(),
                CategoryName = "Hello"
            });
            db.SaveChanges();

        }
        [TestMethod]
        public void TestMethod2()
        {
            var db = ModelFactory.GetContext();
            db.Set<t_Categories>().Add(new t_Categories()
            {
                ID = Guid.NewGuid(),
                CategoryName = "Hello"
            });
            db.SaveChanges();
        }
    }
}
