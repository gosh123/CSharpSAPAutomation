using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver.BusinessComponent
{
    public class SD
    {
        public string DocNo;

        public void VA01_CreateSalesOrder(string strFlowName)
        {
            VA01 va01 = new VA01();
            SAPBasis mySAPBasis = new SAPBasis();
            switch (strFlowName)
            {
                case "CreateSO_Initial":
                    va01.CreateSalesOrder_Initial();break;
                case "CreateSO_Overview":
                    va01.CreateSalesOrder_Overview();break;
                case "Create_Header_Sales":
                    mySAPBasis.MenuBarSelect("Sales");
                    va01.CreateSalesOrder_Header_Sales();
                    mySAPBasis.MenuBarSelect("Back");break;
                case "CreateSO_Header_AdditionaldataB":
                    mySAPBasis.MenuBarSelect("Additional data B");
                    va01.CreateSalesOrder_Header_AdditionalB();
                    mySAPBasis.MenuBarSelect("Back");break;
                case "CreateSO_Header_Texts":
                    mySAPBasis.MenuBarSelect("Texts");
                    va01.CreateSalesOrder_Header_Texts();
                    mySAPBasis.MenuBarSelect("Back");break;
                case "CreateSO_Save":
                   DocNo=va01.CreateSalesOrder_Save();break;

            }            
        }
    }
}
