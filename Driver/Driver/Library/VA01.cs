using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver
{
    public class VA01
    {
        public void CreateSalesOrder_Initial()
        {
            var myScreen = new SC_101();                                   
            var mySAPBasis = new SAPBasis();            
            // Create Sales Doc Initial
            mySAPBasis.StartTransction("VA01");
            myScreen.DataBindingV2();                       
            //myScreen.OrderType = "ZCR";
            //myScreen.SalesOrg = "L8";
            //myScreen.DistributionChannel = "ZZ";
            //myScreen.Division = "ZZ";
            mySAPBasis.PressEnter();                           
            
        }
        public void CreateSalesOrder_Overview()
        {
            var myScreen = new SC_4001();
            var mySAPBasis = new SAPBasis();
            // Create Sales Order           
            myScreen.DataBindingV2();
            
            //myScreen.ShipToParty = "110601974";
            //myScreen.SoldToParty = "110601974";
            //myScreen.PONo = "test201508041620";
            //myScreen.PODate = "08/04/2015";
            //myScreen.HPReceiveDate = "08/04/2015";
            ////input material
            //mySAPBasis.SAPTableInputValue("SAPMV45ATCTRL_U_ERF_GUTLAST", 0, 1, "627808-B21");
            ////input target quantity
            //mySAPBasis.SAPTableInputValue("SAPMV45ATCTRL_U_ERF_GUTLAST", 0, 4, "1");
            //Press enter
            mySAPBasis.PressEnter();
            //error handling
            mySAPBasis.statusBarHandling();

            //mySAPBasis.SAPTableInputValue()
        }
        public void CreateSalesOrder_Header_Sales()
        {
            var myScreen = new SC_4002();
            var mySAPBasis = new SAPBasis();
            myScreen.DataBindingV2();
            //change order reason
            //myScreen.OrderReason = "105";
            //Press enter
            mySAPBasis.PressEnter();
            //error handling
            mySAPBasis.statusBarHandling();
        }
        public void CreateSalesOrder_Header_AdditionalB()
        {
            var myScreen = new SC_4002();
            myScreen.DataBindingV2();
            //myScreen.ConfigCheck = "X";
            //myScreen.CustBaseNo = "L80014115";
        }
        public void CreateSalesOrder_Header_Texts()
        {
            var myScreen = new SC_4002();
            var mySAPBasis = new SAPBasis();
            
            mySAPBasis.TreeActive("wnd[0]/usr/tabsTAXI_TABSTRIP_HEAD/tabpT\\09/ssubSUBSCREEN_BODY:SAPMV45A:4152/subSUBSCREEN_TEXT:SAPLV70T:2100/cntlSPLITTER_CONTAINER/shellcont/shellcont/shell/shellcont[0]/shell", "Z157", "Column1");
            
            mySAPBasis.TreeSelect("wnd[0]/usr/tabsTAXI_TABSTRIP_HEAD/tabpT\\09/ssubSUBSCREEN_BODY:SAPMV45A:4152/subSUBSCREEN_TEXT:SAPLV70T:2100/cntlSPLITTER_CONTAINER/shellcont/shellcont/shell/shellcont[0]/shell", "Z200", "Column2");
            myScreen.DataBindingV2();
            //myScreen.HeaderText = "Comment123123";            
        }
        public string CreateSalesOrder_Save()
        {
            var mySAPBasis = new SAPBasis();
            return mySAPBasis.Save();
        }

    }   
}
