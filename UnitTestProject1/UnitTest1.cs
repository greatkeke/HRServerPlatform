using _02BLL;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _04Model;
using System.Linq;
using _03DAL;
using System.Threading;
using System.Data.Entity;

namespace _02BLL.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        [TestMethod()]
        public void AddTest()
        {
            var bll = new BaseBLL<t_JobNews>();
            var r1 = bll.Query(u => true).FirstOrDefault().Content;

            var bll2 = new BaseBLL<t_JobNews>();
            var r2 = bll2.Query(u => true).FirstOrDefault().Content;
            Assert.AreEqual(true, r1 != r2);


        }

        [TestMethod()]
        public void AddTest2()
        {
            Model1 db = new Model1();
            var r1 = db.Set<t_JobNews>().FirstOrDefault();
            var r2 = db.Set<t_JobNews>().FirstOrDefault();
            Assert.AreEqual(true, r1 != r2);
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
            //var t = db.Set<t_Categories>().ToList();
            //db.Set<t_Categories>().Add(new t_Categories()
            //{
            //    ID = Guid.NewGuid(),
            //    CategoryName = "IOS"
            //});
            //db.SaveChanges();
            //db.Set<t_Requirement>().Add(new t_Requirement()
            //{
            //    ID = Guid.NewGuid(),
            //    CategoryID = Guid.NewGuid(),
            //    Content = "内容",
            //    PostDate = DateTime.Now,
            //    Gread = 1,
            //    PostID = Guid.NewGuid(),
            //    Status = 1,
            //    Title = "标题"
            //});
            
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
