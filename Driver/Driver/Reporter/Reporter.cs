using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Collections.ObjectModel;

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
        //public string TestOutputPath;
        public void initialize(string TestName)
        {
            string TestOutputPath;
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
            if(!File.Exists(@"C:\temp\DriverTemp.txt"))
            {
                FileStream fs = new FileStream(@"C:\temp\DriverTemp.txt", FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(TestOutputPath);
                sw.Close();
                fs.Close();
            }
            else
            {
                close();
                FileStream fs = new FileStream(@"C:\temp\DriverTemp.txt", FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(TestOutputPath);
                sw.Close();
                fs.Close();
            }
            RS.ReportSerialize(Report, TestOutputPath);
            
            //return TestOutputPath;
        }
        public void AddStep(string CaseName,string CaseStatus,string StepName,int Number)
        {
            string TestOutputPath = "";
            if(File.Exists(@"C:\temp\DriverTemp.txt"))
            {
                FileStream fs = new FileStream(@"c:\temp\DriverTemp.txt",FileMode.Open,FileAccess.Read);
                StreamReader sw = new StreamReader(fs);
                TestOutputPath = sw.ReadLine();
            }

            var reporter = new ReportRoot();
            var reporterDes = new ReportSerialization();
            ReportRoot xmldata = reporterDes.ReportDeserialization(TestOutputPath);
            //add test step info
            reporter = xmldata;
            var inputdatas = new InputDatas();            
            var outputdatas = new OutputDatas();            
            //inputdatas.InputData = inputdata;
            //outputdatas.OutputData = outputdata;
            List<TestStep> teststep = new List<TestStep>();
            if (reporter.Details != null)
            {
                teststep = reporter.Details.TestStep;
            }
            teststep.Add(new TestStep { CaseName = CaseName, CaseStatus = CaseStatus, StepName = StepName, Number = Number, InputDatas = null, OutputDatas = null });
            Details details = new Details();
            details.TestStep = teststep;
            reporter.Details = details;            
            //Serialization new report
            var ReporterSerialization = new ReportSerialization();
            ReporterSerialization.ReportSerialize(reporter, TestOutputPath);
        }
        public void updateinputdata(string fieldname, string fieldvalue)
        {
            string TestOutputPath = "";
            if (File.Exists(@"C:\temp\DriverTemp.txt"))
            {                
                FileStream fs = new FileStream(@"c:\temp\DriverTemp.txt", FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(fs);
                TestOutputPath = sw.ReadLine();
                sw.Close();
                fs.Close();
                sw.Dispose();
                fs.Dispose();
            }
            var reporter = new ReportRoot();
            var reporterDes = new ReportSerialization();
            ReportRoot xmldata = reporterDes.ReportDeserialization(TestOutputPath);
            //add step inputdata 
            reporter = xmldata;            
            List<InputData> updatedata = new List<InputData>();
            InputDatas updatedatas = new InputDatas();
            updatedata.Add(new InputData { FieldName = fieldname, FieldValue = fieldvalue });
            updatedatas.InputData = updatedata;
            int LastStepNum = reporter.Details.TestStep.Count();
            if (reporter.Details.TestStep[LastStepNum-1].InputDatas==null)
            {
                reporter.Details.TestStep[LastStepNum-1].InputDatas = updatedatas;
            }
            else
            {
                reporter.Details.TestStep[LastStepNum-1].InputDatas.InputData.Add(new InputData { FieldName = fieldname, FieldValue = fieldvalue });
            }
            //Serialization new report
            var ReporterSerialization = new ReportSerialization();
            ReporterSerialization.ReportSerialize(reporter, TestOutputPath);
        }
        public void updateoutputdata(string fieldname,string fieldvalue)
        {
            string TestOutputPath = "";
            if (File.Exists(@"C:\temp\DriverTemp.txt"))
            {
                FileStream fs = new FileStream(@"c:\temp\DriverTemp.txt", FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(fs);
                TestOutputPath = sw.ReadLine();
                sw.Close();
                fs.Close();
                fs.Dispose();
                sw.Dispose();
            }
            var reporter = new ReportRoot();
            var reporterDes = new ReportSerialization();
            ReportRoot xmldata = reporterDes.ReportDeserialization(TestOutputPath);
            //add step inputdata 
            reporter = xmldata;
            List<OutputData> updatedata = new List<OutputData>();
            OutputDatas updatedatas = new OutputDatas();
            updatedata.Add(new OutputData { FieldName = fieldname, FieldValue = fieldvalue });
            updatedatas.OutputData = updatedata;
            int LastStepNum = reporter.Details.TestStep.Count();
            if (reporter.Details.TestStep[LastStepNum - 1].OutputDatas == null)
            {
                reporter.Details.TestStep[LastStepNum - 1].OutputDatas = updatedatas;
            }
            else
            {
                reporter.Details.TestStep[LastStepNum - 1].OutputDatas.OutputData.Add(new OutputData { FieldName = fieldname, FieldValue = fieldvalue });
            }
            //Serialization new report
            var ReporterSerialization = new ReportSerialization();
            ReporterSerialization.ReportSerialize(reporter, TestOutputPath);
        }
        public void close()
        {
            if (File.Exists(@"C:\Temp\DriverTemp.txt"))
            {
                File.Delete(@"C:\Temp\DriverTemp.txt");
            }
        }

        //public void updateStep(List<InputData> inputdata, List<OutputData> outputdata)
        //{
        //    var reporter = new ReportRoot();
        //    var reporterDes = new ReportSerialization();
        //    ReportRoot xmldata = reporterDes.ReportDeserialization(TestOutputPath);
        //    //update test step info
        //    var inputdatas = new InputDatas();
        //    var outputdatas = new OutputDatas();
        //    List<InputData> originalinputdata = new List<InputData>();
        //    List<OutputData> originaloutputdata = new List<OutputData>();
        //    originalinputdata = inputdatas.InputData;
        //    originaloutputdata = outputdatas.OutputData;
        //    originalinputdata.Add(new InputData[inputdata]);
        //    inputdatas.InputData = inputdata;
        //    outputdatas.OutputData = outputdata;            
        //    //Serialization new report
        //    var ReporterSerialization = new ReportSerialization();
        //    ReporterSerialization.ReportSerialize(reporter, TestOutputPath);
        //}
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
