using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPAutomation;
//using SAPAutomation.Extension;
using SAPFEWSELib;
using System.Data;
using SAPAutomation.Framework.Attributes;
using System.Xml;
using System.Xml.Serialization;
using Young.Data;
using SAPAutomation.Framework;
using Young.Data.Extension;
using Young.Data.Attributes;
//using SAPAutomation.Data;
namespace Driver
{
    static class test001
    {
        public static string getCellValue (this GuiGridView GridView,int row, int col)
        {             
            int index = 0;
            string column = "";
            GridView.SelectAll();
            foreach(var colName in GridView.SelectedColumns)
            {
                if (index == col)
                    column = colName;
                index++;
            }
            return GridView.GetCellValue(row, column);
            
        }
    }
    class Program
    {
        static void ReportDeSerializeTest()
        {
            Driver.Report.SAPReport report = Driver.Report.SAPReport.Restore("Report.xml");
        }

        static void ReportSerializeTest()
        {


            Driver.Report.SAPReport report = new Report.SAPReport();
            report.TurnAutoSave(true);
            report.Summary.TestName = "VA01Test";
            Driver.Report.TestStep step = new Report.TestStep();
            step.CaseName = "VA01_CreateSalesOrder";
            step.BoxName = "VA01";
            step.Name = "VA01_CreateSalesOrder";
            step.Number = 1;
            step.Status = "Pass";
            step.InputDatas.Add(new Report.TestData() { FieldName = "Test", FieldValue = "Test001" });
            report.Detail.Add(step);
            step.InputDatas.Add(new Report.TestData() { FieldName = "abc", FieldValue = "TESTABC" });
            report.Detail.Add(step);

        }
        static void Main(string[] args)
        {
            SAPTestHelper.Current.SetSession();
            //Simple workflow
            //DataTable dt = new DataTable();
            //dt.ReadFromExcel(@"c:\temp\simpleWorkFlow.xlsx", "sheet1");
            //DataTable<va01_initial> myTest = new DataTable<va01_initial>(dt);            
            
            //foreach(var data in myTest)
            //{
            //    va01_initial.RunAction(data);
            //}
            //Simple Workflow
            ReportSerializeTest();            
            SAPTestHelper.Current.TurnScreenLog(true);
            Global.DataSet = ExcelHelper.Current.Open(@"C:\temp\Test.xlsx").ReadAll();
            Global.CurrentId = 0;            
            //initialize report
            Reporter.Reporter reporter = new Reporter.Reporter();            
            reporter.initialize("VA01Test");
            SAPBasis mySAPBasis = new SAPBasis();
            VA01 myScript = new VA01();      
            BusinessComponent.SD mySD = new BusinessComponent.SD();
            reporter.AddStep("VA01_CreateSalesOrder", "Pass", "VA01_CreateSalesOrder", 1);
            mySD.VA01_CreateSalesOrder("CreateSO_Initial");            
            mySD.VA01_CreateSalesOrder("CreateSO_Overview");
            mySD.VA01_CreateSalesOrder("Create_Header_Sales");
            mySD.VA01_CreateSalesOrder("CreateSO_Header_Texts");            
            mySD.VA01_CreateSalesOrder("CreateSO_Save");
            reporter.close();            

        }
        public class testOrderType
        {
            [BizData]
            /// Sales Document Type
            public System.String OrderType { get; set; }

            public static void RunAction(testOrderType Data)
            {   
                SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").ResizeWorkingPane(114, 24, false);
                SAPTestHelper.Current.SAPGuiSession.FindById<GuiCTextField>("wnd[0]/usr/ctxtVBAK-AUART").Text = Data.OrderType;
            }

        }
        public class va01_initial
        {
            [BizData]
            /// Sales Document Type
            public System.String OrderType { get; set; }
            [BizData]
            /// Sales Organization
            public System.String SalesOrg { get; set; }
            [BizData]
            /// Distribution Channel
            public System.String DisChannel { get; set; }
            [BizData]
            /// Division
            public System.String Division { get; set; }

            public static void RunAction(va01_initial Data)
            {
                SAPTestHelper.Current.SAPGuiSession.FindById<GuiOkCodeField>("wnd[0]/tbar[0]/okcd").Text = "/nva01";
                SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").SendVKey(0);
                SAPTestHelper.Current.SAPGuiSession.FindById<GuiCTextField>("wnd[0]/usr/ctxtVBAK-AUART").Text = Data.OrderType;
                SAPTestHelper.Current.SAPGuiSession.FindById<GuiCTextField>("wnd[0]/usr/ctxtVBAK-VKORG").Text = Data.SalesOrg;
                SAPTestHelper.Current.SAPGuiSession.FindById<GuiCTextField>("wnd[0]/usr/ctxtVBAK-VTWEG").Text = Data.DisChannel;
                SAPTestHelper.Current.SAPGuiSession.FindById<GuiCTextField>("wnd[0]/usr/ctxtVBAK-SPART").Text = Data.Division;
                SAPTestHelper.Current.SAPGuiSession.FindById<GuiCTextField>("wnd[0]/usr/ctxtVBAK-SPART").SetFocus();
                SAPTestHelper.Current.SAPGuiSession.FindById<GuiCTextField>("wnd[0]/usr/ctxtVBAK-SPART").CaretPosition = 2;
                SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").SendVKey(0);
            }
        }

    }
}
