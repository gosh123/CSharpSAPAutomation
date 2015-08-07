using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver
{
    public class DemoScript
    {
        public void CreateSalesOrder_Initial()
        {
            var myScreen = new SC_101();
            var mySAPBasis = new SAPBasis();
            // Create Sales Doc Initial
            mySAPBasis.StartTransction("VA01");           
            myScreen.OrderType = "ZCR";
            myScreen.SalesOrg = "L8";
            myScreen.DistributionChannel = "ZZ";
            myScreen.Division = "ZZ";
            mySAPBasis.PressEnter();   
            
            
        }
        public void CreateSalesOrder_Overview()
        {
            var myScreen = new SC_4001();
            var mySAPBasis = new SAPBasis();
            // Create Sales Order
            myScreen.ShipToParty = "110601974";
            myScreen.SoldToParty = "110601974";
            myScreen.PONo = "test201508041620";
            myScreen.PODate = "08/04/2015";
            myScreen.HPReceiveDate = "08/04/2015";
            //input material
            mySAPBasis.SAPTableInputValue("SAPMV45ATCTRL_U_ERF_GUTLAST", 0, 1, "627808-B21");
            //input target quantity
            mySAPBasis.SAPTableInputValue("SAPMV45ATCTRL_U_ERF_GUTLAST", 0, 4, "1");
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
            //change order reason
            myScreen.OrderReason = "105";
            //Press enter
            mySAPBasis.PressEnter();
            //error handling
            mySAPBasis.statusBarHandling();
        }
        public void CreateSalesOrder_Header_AdditionalB()
        {
            var myScreen = new SC_4002();
            myScreen.ConfigCheck = "X";
            myScreen.CustBaseNo = "L80014115";
        }

    }   
}
