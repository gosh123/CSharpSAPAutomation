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
            string strCellValue = "";
            SAPTestHelper.Current.SetSession();
            //strCellValue = SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiUserArea>("usr").FindByName<GuiCustomControl>("GRID1").FindByName<GuiContainerShell>("shellcont").FindByName<GuiGridView>("shell").GetCellValue(1, "From");            
            var gridView = SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiUserArea>("usr").FindByName<GuiCustomControl>("GRID1").FindByName<GuiContainerShell>("shellcont").FindByName<GuiGridView>("shell");
            strCellValue=gridView.getCellValue(0,5);
            gridView.SelectAll();
            //foreach(var col in gridView.SelectedColumns)
            //{
            //    Console.WriteLine( gridView.GetDisplayedColumnTitle(col));
            //    Console.WriteLine(col);
            //}
            //Console.ReadLine();
            Console.WriteLine(strCellValue);
            Console.ReadLine();
        }
    }
}
