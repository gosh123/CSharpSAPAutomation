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
           
        static void Main(string[] args)
        {
            SAPTestHelper.Current.SetSession();
            SAPTestHelper.Current.TurnScreenLog(true);
            //string strCellValue = "";
            //SAPTestHelper.Current.SetSession();
            ////strCellValue = SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiUserArea>("usr").FindByName<GuiCustomControl>("GRID1").FindByName<GuiContainerShell>("shellcont").FindByName<GuiGridView>("shell").GetCellValue(1, "From");            
            //var gridView = SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiUserArea>("usr").FindByName<GuiCustomControl>("GRID1").FindByName<GuiContainerShell>("shellcont").FindByName<GuiGridView>("shell");
            //strCellValue = gridView.getCellValue(0, 5);
            //gridView.SelectAll();
            ////foreach(var col in gridView.SelectedColumns)
            ////{
            ////    Console.WriteLine( gridView.GetDisplayedColumnTitle(col));
            ////    Console.WriteLine(col);
            ////}
            ////Console.ReadLine();
            //Console.WriteLine(strCellValue);
            //Console.ReadLine();

            //initialize report
            Reporter.Reporter reporter = new Reporter.Reporter();
            //List<Reporter.InputData> inputdata = new List<Reporter.InputData>();
            //List<Reporter.OutputData> outputdata = new List<Reporter.OutputData>();
            reporter.initialize("VA01Test");
            
            
            //initialize Test 
            SAPBasis mySAPBasis = new SAPBasis();
            VA01 myScript = new VA01();
            //myScript.CreateSalesOrder_Initial();
            //myScript.CreateSalesOrder_Overview();
            //mySAPBasis.MenuBarSelect("Sales");
            //myScript.CreateSalesOrder_Header_Sales();
            //mySAPBasis.MenuBarSelect("Back");
            //mySAPBasis.MenuBarSelect("Additional data B");
            //myScript.CreateSalesOrder_Header_AdditionalB();
            //mySAPBasis.MenuBarSelect("Back");
            //mySAPBasis.MenuBarSelect("Texts");
            //myScript.CreateSalesOrder_Header_Texts();
            //mySAPBasis.MenuBarSelect("Back");
            //string DocNo = myScript.CreateSalesOrder_Save();
            //Console.WriteLine(DocNo);
            //Console.ReadLine();            
            BusinessComponent.SD mySD =new BusinessComponent.SD();
            reporter.AddStep("VA01_CreateSalesOrder", "Pass", "VA01_CreateSalesOrder", 1);
            mySD.VA01_CreateSalesOrder("CreateSO_Initial");
            //inputdata.Add(new Reporter.InputData { FieldName = "OrderType", FieldValue = "ZCR" });
            //inputdata.Add(new Reporter.InputData { FieldName = "SalesOrg", FieldValue = "L8" });
            //inputdata.Add(new Reporter.InputData { FieldName = "DistributionChannel", FieldValue = "ZZ" });
            //inputdata.Add(new Reporter.InputData { FieldName = "Division", FieldValue = "ZZ" });
            mySD.VA01_CreateSalesOrder("CreateSO_Overview");
            //inputdata.Add(new Reporter.InputData { FieldName = "ShipToParty", FieldValue = "110601974" });
            //inputdata.Add(new Reporter.InputData { FieldName = "SoldToParty", FieldValue = "110601974" });
            //inputdata.Add(new Reporter.InputData { FieldName = "PONo", FieldValue = "test201508041620" });
            //inputdata.Add(new Reporter.InputData { FieldName = "PODate", FieldValue = "08/04/2015" });
            //inputdata.Add(new Reporter.InputData { FieldName = "HPReceiveDate", FieldValue = "08/04/2015" });
            mySD.VA01_CreateSalesOrder("Create_Header_Sales");
            //inputdata.Add(new Reporter.InputData { FieldName = "OrderReason", FieldValue = "105" });
            mySD.VA01_CreateSalesOrder("CreateSO_Header_AdditionaldataB");
            //inputdata.Add(new Reporter.InputData { FieldName = "ConfigCheck", FieldValue = "X" });
            //inputdata.Add(new Reporter.InputData { FieldName = "CustBaseNo", FieldValue = "L80014115" });
            mySD.VA01_CreateSalesOrder("CreateSO_Header_Texts");
            //inputdata.Add(new Reporter.InputData { FieldName = "HeaderText", FieldValue = "Comment123123" });
            mySD.VA01_CreateSalesOrder("CreateSO_Save");
            string DocNo = mySD.DocNo;
            //outputdata.Add(new Reporter.OutputData {FieldName="SalesDocNo",FieldValue=DocNo});
            reporter.updateoutputdata("SalesDocNo", DocNo);
            reporter.close();
            //string aa = SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiStatusbar>("sbar").Text;            
            //var myTable = SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiUserArea>("usr").FindByName<GuiTabStrip>("TAXI_TABSTRIP_OVERVIEW").FindByName<GuiTab>("T\\01").FindByName<GuiScrollContainer>("SUBSCREEN_BODY:SAPMV45A:4414").FindByName<GuiSimpleContainer>("SUBSCREEN_TC:SAPMV45A:4902").FindByName<GuiGridView>("SAPMV45ATCTRL_U_ERF_GUTLAST");
            //var myTable = SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiTableControl>("SAPMV45ATCTRL_U_ERF_GUTLAST");
            //myTable.GetCell(1, 1).Text = "asdf";
            //string aaa = myTable.getCellValue(2, 2);
            //Console.WriteLine(aa);
            //Console.ReadLine();
            //SAPTestHelper.Current.SAPGuiSession.FindById<GuiMenu>("wnd[0]/mbar/menu[2]/menu[1]/menu[0]").Select();
            //SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiMenu>("Sales").Select();
            //SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").ResizeWorkingPane(114, 24, false);

            //var guicombobox=SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiComboBox>("VBAK-AUGRU");
            //guicombobox.Key = "105";
            //SAPTestHelper.Current.SAPGuiSession.FindById<GuiMenu>("wnd[0]/mbar/menu[2]/menu[1]/menu[0]").Select();
            //SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiTree>("shell").SelectNode("Txt ty.");
            //SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiTree>("shell").SelectItem
            //SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiTree>("shell").SelectItem("Z157", "Column1");

            //SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiTree>("shell").SelectItem("Z200", "Column2");
        //    SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindById<GuiTextedit>("wnd[0]/usr/tabsTAXI_TABSTRIP_HEAD/tabpT\\09/ssubSUBSCREEN_BODY:SAPMV45A:4152/subSU" + "BSCREEN_TEXT:SAPLV70T:2100/cntlSPLITTER_CONTAINER/shellcont/shellcont/shell/shel" + "lcont[1]/shell").Text = "asdfasdf";

            
            //SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiTree>("shellcont[0]/shell").SelectItem("Z157", "Column1");

            XmlSerializer xs = new XmlSerializer(typeof(List<ScreenData>));
            xs.Serialize(new System.IO.FileStream("screen.xml", System.IO.FileMode.CreateNew),SAPTestHelper.Current.ScreenDatas.ToList());

        }
    }
}
