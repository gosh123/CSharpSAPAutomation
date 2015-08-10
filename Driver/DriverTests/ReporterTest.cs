using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace Driver.Tests
{
    [TestClass()]
    public class ReporterTest
    {
        [TestMethod()]
        public void ReportTest_Serialize()
        {
            var Reporter = new Reporter.ReportRoot();
            var Summary = new Reporter.Summary();
            var Details = new Reporter.Details();
            List<Reporter.TestStep> TestStep = new List<Reporter.TestStep>();
            List<Reporter.InputDatas> Inputdatas = new List<Reporter.InputDatas>();
            List<Reporter.InputData> Inputdata = new List<Reporter.InputData>();
            Inputdata.Add(new Reporter.InputData {FieldName="Order Type",FieldValue="ZOR" });
            Inputdata.Add(new Reporter.InputData { FieldName = "Organization", FieldValue = "ZZ" });
            Inputdatas.Add(new Reporter.InputDatas { InputData = Inputdata });
            TestStep.Add(new Reporter.TestStep { InputDatas = Inputdatas, CaseName="CaseName 123123",CaseStatus="Pass",StepName="va01_createasdfasdf",Number=1});
            Summary.TestName = "Test Name 123123";
            Reporter.Summary = Summary;
            
            Details.TestStep = TestStep;
            Reporter.Details = Details;
            //Summary.TestName = "Test Name 123123";
            //TestStep.CaseName = "case name 123";
            //TestStep.CaseStatus = "Pass";
            //TestStep.Number = 1;
            //TestStep.StepName = "va01_createsalesorder";
            //inputdata.FieldName = "order type";
            //inputdata.FieldValue = "ZOR";
            //Inputdatas.InputData = inputdata;
            //TestStep.InputDatas = Inputdatas;
            //Details.TestStep = TestStep;
            //Reporter.Summary = Summary;
            
            //Reporter.Summary = Reporter.Summary();
            var ReporterSerialization = new Reporter.ReportSerialization();
            ReporterSerialization.ReportSerialize(Reporter, "c:\\temp\\aaa.xml");
        }
        [TestMethod()]
        public void ReportTest_DeSerialize()
        {
            var reporter = new Reporter.ReportRoot();
            var reporterDes = new Reporter.ReportSerialization();
            Reporter.ReportRoot xmldata = reporterDes.ReportDeserialization("c:\\temp\\bbb.xml");
            Assert.AreEqual("Test Name 123123", xmldata.Summary.TestName);
            Assert.AreEqual("Order Type", xmldata.Details.TestStep[0].InputDatas[0].InputData[0].FieldName);
        }
    }
}
