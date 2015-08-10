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
        [XmlElement]
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
        public List<InputDatas> InputDatas;

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
    public class ReportSerialization
    {        
        public void ReportSerialize(ReportRoot rr,string xmlFilePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ReportRoot));
            using (TextWriter writer = new StreamWriter(xmlFilePath))
            {
                serializer.Serialize(writer,rr);
            }
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
