using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using Young.Data;
using Young.Data.Extension;
using Young.Data.Attributes;
using DocumentFormat.OpenXml;
using SAPAutomation;
using System.Xml;
using System.Linq;
namespace DriverTests
{
    [TestClass()]
    public class SimpleWorkflow
    {
        [TestMethod()]
        public void va01_initial()
        {
            SAPTestHelper.Current.SetSession();
            //Simple workflow
            DataTable dt = new DataTable();
            dt.ReadFromExcel(@"c:\temp\simpleWorkFlow.xlsx", "sheet1");
            DataTable<Program.va01_initial> myTest = new DataTable<Program.va01_initial>(dt);

            foreach (var data in myTest)
            {
                Program.va01_initial.RunAction(data);
            }
            //Simple Workflow
        }
    }
}
