using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPAutomation;
using SAPAutomation.Extension;
using SAPFEWSELib;
using System.Data;
using SAPAutomation.Framework.Attributes;
using SAPAutomation.Data;

namespace Driver
{
    public class SAPBasis
    {
        public void SetCurrentSession()
        {
            SAPTestHelper.Current.SetSession();
        }
        public string SAPTable(string strTableName, int intRowIndex, string strColumnName)
        {
            string strCellValue = "";
            //SAPTestHelper.Current.SetSession();
            strCellValue=SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiUserArea>("usr").FindByName<GuiCustomControl>("GRID1").FindByName<GuiContainerShell>("shellcont").FindByName<GuiGridView>(strTableName).GetCellValue(intRowIndex, strColumnName);
            return strCellValue;
        }
    }
}
