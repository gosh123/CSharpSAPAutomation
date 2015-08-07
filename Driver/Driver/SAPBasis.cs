using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public string statusBarGetDocNo()
        {
            string status = SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiStatusbar>("sbar").Text;
            Regex re = new Regex("[^0-9]");
            string DocNo = re.Replace(status, "");
            return DocNo;
        }

        public void MenuBarSelect(string strMenuName)
        {
            //SAPTestHelper.Current.SAPGuiSession.FindById<GuiMenu>("wnd[0]/mbar/" + strindex).Select();
            SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiMenu>(strMenuName).Select(); 
        }
        public void TreeSelect(string strTreeID,string strNodeKey, string strItemName)
        {
            SAPTestHelper.Current.SAPGuiSession.FindById<GuiTree>(strTreeID).SelectItem(strNodeKey, strItemName);            
        }
        public void TreeActive(string strTreeID,string strNodeKey,string strItemName)
        {
            SAPTestHelper.Current.SAPGuiSession.FindById<GuiTree>(strTreeID).SelectItem(strNodeKey, strItemName);            
            SAPTestHelper.Current.SAPGuiSession.FindById<GuiTree>(strTreeID).DoubleClickItem(strNodeKey, strItemName);            
        }
        public string Save()
        {
            SAPTestHelper.Current.SAPGuiSession.FindById<GuiButton>("wnd[0]/tbar[0]/btn[11]").Press();
            if (SAPTestHelper.Current.SAPGuiSession.FindById<GuiModalWindow>("wnd[1]").Text == "Information" && SAPTestHelper.Current.SAPGuiSession.FindById<GuiModalWindow>("wnd[1]").FindByName<GuiUserArea>("usr").FindByName<GuiTextField>("MESSTXT1").Text == "You are not assigned to a team code. Please")
            {
                SAPTestHelper.Current.SAPGuiSession.FindById<GuiButton>("wnd[1]/tbar[0]/btn[0]").Press();
            }
            if (SAPTestHelper.Current.SAPGuiSession.FindById<GuiModalWindow>("wnd[1]").Text == "Save Incomplete Document")
            {
                SAPTestHelper.Current.SAPGuiSession.FindById<GuiButton>("wnd[1]/usr/btnSPOP-VAROPTION2").Press();
                if (SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiUserArea>("usr").FindByName<GuiCustomControl>("GRID1").FindByName<GuiContainerShell>("shellcont").FindByName<GuiSplit>("shell").FindByName<GuiContainerShell>("shellcont[1]").FindByName<GuiGridView>("shell").RowCount == 1 && SAPTestHelper.Current.SAPGuiSession.FindById<GuiGridView>("wnd[0]/usr/cntlGRID1/shellcont/shell/shellcont[1]/shell").getCellValue(0, 2) == "Customer Base No.")
                {
                    MenuBarSelect("Back");
                    
                    Save(false);
                }
                else 
                {
                    //edit incomplete log
                }
                
            }
            return statusBarGetDocNo();
        }
        public void Save(Boolean Incompletelog)
        {
            SAPTestHelper.Current.SAPGuiSession.FindById<GuiButton>("wnd[0]/tbar[0]/btn[11]").Press();
            if (SAPTestHelper.Current.SAPGuiSession.FindById<GuiModalWindow>("wnd[1]").Text == "Information" && SAPTestHelper.Current.SAPGuiSession.FindById<GuiModalWindow>("wnd[1]").FindByName<GuiUserArea>("usr").FindByName<GuiTextField>("MESSTXT1").Text == "You are not assigned to a team code. Please")
            {
                SAPTestHelper.Current.SAPGuiSession.FindById<GuiButton>("wnd[1]/tbar[0]/btn[0]").Press();
            }
            if (SAPTestHelper.Current.SAPGuiSession.FindById<GuiModalWindow>("wnd[1]").Text == "Save Incomplete Document" && Incompletelog == true)
            {
                SAPTestHelper.Current.SAPGuiSession.FindById<GuiButton>("wnd[1]/usr/btnSPOP-VAROPTION2").Press();
                if (SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiUserArea>("usr").FindByName<GuiCustomControl>("GRID1").FindByName<GuiContainerShell>("shellcont").FindByName<GuiSplit>("shell").FindByName<GuiContainerShell>("shellcont[1]").FindByName<GuiGridView>("shell").RowCount == 1 && SAPTestHelper.Current.SAPGuiSession.FindById<GuiGridView>("wnd[0]/usr/cntlGRID1/shellcont/shell/shellcont[1]/shell").getCellValue(0, 2) == "Customer Base No.")
                {
                    MenuBarSelect("Back");
                    //edit incomplete log
                }
                
            }
            else
            {
                SAPTestHelper.Current.SAPGuiSession.FindById<GuiButton>("wnd[1]/usr/btnSPOP-VAROPTION1").Press();
            }
        }
    }
}
