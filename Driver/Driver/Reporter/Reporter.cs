using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;


namespace Driver.Reporter
{
    [XmlRoot("ReportRoot")]
    //[XmlInclude(typeof(Summary)), XmlInclude(typeof(Details))]
    public class ReportRoot
    {
        [XmlElement]
        public Summary Summary;
        [XmlElement("Detail")]
        public Details Details;
    }
    public class Summary
    {
        [XmlElement]
        public string TestName;
    }
    public class Details
    {
        [XmlElement]
        public List<TestStep> TestStep;
    }
    public class TestStep
    {
        [XmlAttribute("Name")]
        public string StepName;
        [XmlElement]
        public string CaseName;
        [XmlElement]
        public int Number;
        [XmlElement]
        public string CaseStatus;
        [XmlElement]
        public InputDatas InputDatas;
        [XmlElement]
        public OutputDatas OutputDatas;

    }
    public class InputDatas
    {
        [XmlElement]
        public List<InputData> InputData; 
    }
    public class InputData
    {
        [XmlElement]
        public string FieldName;
        [XmlElement]
        public string FieldValue;
    }
    public class OutputDatas
    {
        [XmlElement]
        public List<OutputData> OutputData;
    }
    public class OutputData
    {
        [XmlElement]
        public string FieldName;
        [XmlElement]
        public string FieldValue;
    }
    public class ReportSerialization
    {        
        public void ReportSerialize(ReportRoot rr,string xmlFilePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ReportRoot));
            using (TextWriter writer = new StreamWriter(xmlFilePath))
            {
                serializer.Serialize(writer,rr);
            }
            //add xml header <?xml-stylesheet type='text/xsl' href='../NewReportTemplate2.xsl'?>
            string[] content = File.ReadAllText(xmlFilePath).Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            content[1] = "<?xml-stylesheet type='text/xsl' href='../NewReportTemplate2.xsl'?>" + "\r\n<ReportRoot>";
            File.WriteAllText(xmlFilePath, string.Join("\r\n", content));
        }
        public ReportRoot ReportDeserialization(string xmlFilePath)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(ReportRoot));
            TextReader reader = new StreamReader(xmlFilePath);
            object obj = deserializer.Deserialize(reader);
            ReportRoot xmldata = (ReportRoot)obj;
            reader.Close();
            return xmldata;
        }
    }
    public class Reporter
    {
        public string TestOutputPath;
        public void initialize(string TestName)
        {
            ReportRoot Report = new ReportRoot();
            ReportSerialization RS = new ReportSerialization();
            var Summary = new Summary();
            Summary.TestName = TestName;
            Report.Summary = Summary;
            string TestFolderName = @"C:\Temp\" + TestName;
            TestOutputPath = @"C:\Temp\" + TestName+"\\output.xml";
            if (!Directory.Exists(TestFolderName))
            {
                Directory.CreateDirectory(TestFolderName);                
            }
            RS.ReportSerialize(Report, TestOutputPath);
            
            //return TestOutputPath;
        }
        public void AddStep(string CaseName,string CaseStatus,string StepName,int Number, List<InputData> inputdata, List<OutputData> outputdata)
        {            
            var reporter = new ReportRoot();
            var reporterDes = new ReportSerialization();
            ReportRoot xmldata = reporterDes.ReportDeserialization(TestOutputPath);
            //add test step info
            reporter = xmldata;
            var inputdatas = new InputDatas();            
            var outputdatas = new OutputDatas();            
            inputdatas.InputData = inputdata;
            outputdatas.OutputData = outputdata;
            List<TestStep> teststep = new List<TestStep>();
            if (reporter.Details != null)
            {
                teststep = reporter.Details.TestStep;
            }
            teststep.Add(new TestStep { CaseName = CaseName, CaseStatus = CaseStatus, StepName = StepName, Number = Number, InputDatas = inputdatas, OutputDatas = outputdatas });
            Details details = new Details();
            details.TestStep = teststep;
            reporter.Details = details;            
            //Serialization new report
            var ReporterSerialization = new ReportSerialization();
            ReporterSerialization.ReportSerialize(reporter, TestOutputPath);
        }        
    }
    //    public void ReporterInitialize()
    //    {
    //        Summary sm = new Summary();
    //        sm.TestName = "TestName123123";
    //        Details dt = new Details();
    //        //dt.TestSteps.Add({TestStep("asdf")});
    //    }
        
    //    public void Serialization(string FileName)
    //    {

    //    }
    //    public void Deserialization(string FileName)
    //    {

    //    }
        
    //}
    //[XmlType("Summary")]
    //public class Summary
    //{
    //    [XmlElement("TestName")]
    //    public string TestName { get; set; }

    //}
    //[XmlType("Details")]
    //[XmlInclude(typeof(TestStep))]
    //public class Details
    //{
    //    public List<TestStep> TestSteps = new List<TestStep>();
    //    public void AddStep(TestStep TestStep)
    //    {
    //        TestSteps.Add(TestStep);
    //    }
    //}
    //[XmlType("TestStep")]
    //public class TestStep
    //{
    //    [XmlElement("StepName")]
    //    public string StepName {get;set;}
    //    public TestStep(string StepName)
    //    {
    //        this.StepName=StepName;
    //    }
    //}
}
