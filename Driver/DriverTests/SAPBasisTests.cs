using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Driver.Tests
{
    [TestClass()]
    public class SAPBasisTests
    {
        [TestMethod()]
        public void SAPTableTest()
        {            
            var mySAPTable = new SAPBasis();
            mySAPTable.SetCurrentSession();
            string result = mySAPTable.SAPTable("shell", 1, "From").ToLower();

            Assert.AreEqual("eur", result,false);
        }
    }
}
