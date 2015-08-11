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
        public void ReportTest_Initial()
        {
            var reporter = new Reporter.ReportRoot();
            var ReporterSerialization = new Reporter.ReportSerialization();
            var summary = new Reporter.Summary();
            summary.TestName = "asdfasdf";
            reporter.Summary = summary;
            ReporterSerialization.ReportSerialize(reporter, "c:\\temp\\aaa.xml");
        }
        [TestMethod()]
        public void ReportTest_Serialize()
        {
            var reporter = new Reporter.ReportRoot();
            var Summary = new Reporter.Summary();
            var Details = new Reporter.Details();
            List<Reporter.TestStep> TestStep = new List<Reporter.TestStep>();
            Reporter.InputDatas Inputdatas = new Reporter.InputDatas();
            List<Reporter.InputData> Inputdata = new List<Reporter.InputData>();
            Reporter.OutputDatas OutputDatas = new Reporter.OutputDatas();
            List<Reporter.OutputData> OutputData = new List<Reporter.OutputData>();
            Inputdata.Add(new Reporter.InputData {FieldName="Order Type",FieldValue="ZOR" });
            Inputdata.Add(new Reporter.InputData { FieldName = "Organization", FieldValue = "ZZ" });
            Inputdatas.InputData = Inputdata;
            OutputData.Add(new Reporter.OutputData { FieldName = "DocNo", FieldValue = "5555555" });
            OutputDatas.OutputData = OutputData;
            //Inputdatas.Add(new Reporter.InputDatas { InputData = Inputdata });
            TestStep.Add(new Reporter.TestStep {  CaseName="CaseName 123123",CaseStatus="Pass",StepName="va01_createasdfasdf",Number=1,InputDatas=Inputdatas,OutputDatas=OutputDatas});
            Summary.TestName = "Test Name 123123";
            reporter.Summary = Summary;
            
            Details.TestStep = TestStep;
            reporter.Details = Details;
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
            ReporterSerialization.ReportSerialize(reporter, "c:\\temp\\aaa.xml");
        }
        [TestMethod()]
        public void ReportTest_DeSerialize()
        {
            var reporter = new Reporter.ReportRoot();
            var reporterDes = new Reporter.ReportSerialization();
            Reporter.ReportRoot xmldata = reporterDes.ReportDeserialization("c:\\temp\\bbb.xml");
            Assert.AreEqual("Test Name 123123", xmldata.Summary.TestName);
            Assert.AreEqual("Order Type", xmldata.Details.TestStep[0].InputDatas.InputData[0].FieldName);
        }
        [TestMethod()]
        public void ReportTest_AddTestStep()
        {
            //Deserialization Latest report
            var reporter = new Reporter.ReportRoot();
            var reporterDes = new Reporter.ReportSerialization();
            Reporter.ReportRoot xmldata = reporterDes.ReportDeserialization("c:\\temp\\bbb.xml");
            //add test step info
            reporter = xmldata;
            var inputdatas = new Reporter.InputDatas();
            List<Reporter.InputData> inputdata = new List<Reporter.InputData>();
            var outputdatas = new Reporter.OutputDatas();
            List<Reporter.OutputData> outputdata = new List<Reporter.OutputData>();
            inputdata.Add(new Reporter.InputData { FieldName = "SalesDocNo", FieldValue = "555555" });
            outputdata.Add(new Reporter.OutputData { FieldName = "changed", FieldValue = "true" });
            inputdatas.InputData=inputdata;
            outputdatas.OutputData=outputdata;
            reporter.Details.TestStep.Add(new Reporter.TestStep { CaseName = "va02_asdafsdf", CaseStatus = "Pass", StepName = "va02_stepname", Number = 2, InputDatas = inputdatas, OutputDatas = outputdatas });
            //Serialization new report
            var ReporterSerialization = new Reporter.ReportSerialization();
            ReporterSerialization.ReportSerialize(reporter, "c:\\temp\\bbb.xml");
        }
    }
}
