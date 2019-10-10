using System;
using System.Collections.Generic;
using CheckSitemap.BLL.BusinessModels;
using CheckSitemap.DAL.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckSitemap.Test.BLL
{
    [TestClass]
    public class TimeCounter_tests
    {
        [TestMethod]
        public void Test_workable()
        {
            var requests = new List<Request>() { new Request() { TimeRequest = 0.1 }, new Request() { TimeRequest = 0.1 }, new Request() { TimeRequest = 0.1 } };
            TimeCounter tc = new TimeCounter(requests);

            Assert.IsTrue(tc.time != 0);
            Assert.AreEqual(0.3, tc.time, 2);
        }
    }
}
