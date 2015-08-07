using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Driver.Tests
{
    [TestClass()]
    public class SAPBasisTests
    {
        [TestMethod()]
        public void SAPTableTestGetValue()
        {
                  
            var mySAPTable = new SAPBasis();
            mySAPTable.SetCurrentSession();
            string result = mySAPTable.SAPTable("shell", 0, 2).ToLower();

            Assert.AreEqual("eur", result,false);
        }
        [TestMethod()]
        public void SAPTableTestInput()
        {            
            var mySAPTable = new SAPBasis();
            mySAPTable.SetCurrentSession();
            mySAPTable.SAPTableInputValue("SAPMV45ATCTRL_U_ERF_GUTLAST", 0, 1, "627808-B21");
            Assert.AreEqual("eur", "eur", false);
            
        }
         [TestMethod()]
        public void MenuBarOperation()
        {
            var mySAPBasis = new SAPBasis();
            mySAPBasis.SetCurrentSession();
            mySAPBasis.MenuBarSelect("Sales"); //goto;header;sales
        }
        [TestMethod()]
        public void TreeOperation() //goto;header;texts tree Customer Comment 
        {
            var mySAPBasis = new SAPBasis();
            mySAPBasis.SetCurrentSession();
            mySAPBasis.TreeSelect("wnd[0]/usr/tabsTAXI_TABSTRIP_HEAD/tabpT\\09/ssubSUBSCREEN_BODY:SAPMV45A:4152/subSUBSCREEN_TEXT:SAPLV70T:2100/cntlSPLITTER_CONTAINER/shellcont/shellcont/shell/shellcont[0]/shell", "Z157", "Column1");
            //SAPTestHelper.Current.SAPGuiSession.FindById<GuiTree>("wnd[0]/usr/tabsTAXI_TABSTRIP_HEAD/tabpT\\09/ssubSUBSCREEN_BODY:SAPMV45A:4152/subSUBSCREEN_TEXT:SAPLV70T:2100/cntlSPLITTER_CONTAINER/shellcont/shellcont/shell/shellcont[0]/shell").SelectItem("Z157", "Column1");

        }
    }
}
