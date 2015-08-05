﻿using System;
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

            //SAPBasis mySAPBasis = new SAPBasis();
            //DemoScript myScript = new DemoScript();
            //myScript.CreateSalesOrder_Initial();
            //myScript.CreateSalesOrder_Overview();
            //mySAPBasis.MenuBarSelect("Sales");
            //myScript.CreateSalesOrder_Header_Sales();
            //mySAPBasis.MenuBarSelect("Back");
            //mySAPBasis.MenuBarSelect("Additional data B");
            //myScript.CreateSalesOrder_Header_AdditionalB();
            //mySAPBasis.MenuBarSelect("Back");
            //mySAPBasis.MenuBarSelect("Texts");
            

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
            

        }
    }
}
