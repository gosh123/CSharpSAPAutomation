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
        public void StartTransction(string strTcode)
        {
            SAPTestHelper.Current.SAPGuiSession.StartTransaction(strTcode);            
        }
        public void SetCurrentSession()
        {
            SAPTestHelper.Current.SetSession();
        }
        public string SAPTable(string strTableName, int intRowIndex, int intColumnName)
        {
            string strCellValue = "";            
            //SetCurrentSession();
            strCellValue=SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiUserArea>("usr").FindByName<GuiCustomControl>("GRID1").FindByName<GuiContainerShell>("shellcont").FindByName<GuiGridView>(strTableName).getCellValue(intRowIndex, intColumnName);
            return strCellValue;
        }
        public void SAPTableInputValue(string strTableName, int intRowIndex, int intColumnIndex,string strInputValue)
        {
            SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiTableControl>("SAPMV45ATCTRL_U_ERF_GUTLAST").GetCell(intRowIndex, intColumnIndex).Text = strInputValue;              
        }
        public void PressEnter()
        {
            SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").SendVKey(0);
        }
        public void statusBarHandling()
        {
            int intRepeat = 0;
            while (SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiStatusbar>("sbar").Text != ""&&intRepeat<=3)
            {
                PressEnter();
                intRepeat++;
            }            
        }
        public void MenuBarSelect()
        {
            //SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiMenubar>("mbar").
        }

    }
}
