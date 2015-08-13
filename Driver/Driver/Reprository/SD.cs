using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPFEWSELib;
using SAPAutomation;
using SAPAutomation.Framework;
//using SAPAutomation.Extension;
using SAPAutomation.Framework.Attributes;
//using SAPAutomation.Data;
namespace Driver
{
    [TableBinding("Sheet1","Id")]
    public class SC_101:SAPGuiScreen //va01 initial
    {
        [ColumnBinding("Order",0)]
        //va01 repository
        public string OrderType
        {
            get{
                return SAPTestHelper.Current.GetElementById<GuiCTextField>("wnd[0]/usr/VBAK-AUART").Text;
            }
            set
            {
                var reporter = new Reporter.Reporter();
                reporter.updateinputdata("OrderType", value);
                SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiUserArea>("usr").FindByName<GuiCTextField>("VBAK-AUART").Text = value;
               //var myOrderType = SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiUserArea>("usr").FindByName<GuiCTextField>("VBAK-AUART");
                //var myOrderType = SAPTestHelper.Current.GetElementById<GuiCTextField>("wnd[0]/usr/VBAK-AUART");
                //myOrderType.Text = value;
                //SAPTestHelper.Current.GetElementById<GuiCTextField>("wnd[0]/usr/VBAK-AUART").Text = value;
            }
        }

        public string SalesOrg
        { 
            get
            {                
                return SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiUserArea>("usr").FindByName<GuiCTextField>("VBAK-VKORG").Text;
            }
            set
            {
                var reporter = new Reporter.Reporter();
                reporter.updateinputdata("SalesOrg", value);
                SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiUserArea>("usr").FindByName<GuiCTextField>("VBAK-VKORG").Text = value;
            }
        }
        public string DistributionChannel 
        {
            get
            {
                return SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiUserArea>("usr").FindByName<GuiCTextField>("VBAK-VTWEG").Text;
            }
            set
            {
                var reporter = new Reporter.Reporter();
                reporter.updateinputdata("DistributionChannel", value);
                SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiUserArea>("usr").FindByName<GuiCTextField>("VBAK-VTWEG").Text = value;
            }
        }
        public string Division
        {
            get
            {
                return SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiUserArea>("usr").FindByName<GuiCTextField>("VBAK-SPART").Text;
            }
            set
            {
                var reporter = new Reporter.Reporter();
                reporter.updateinputdata("Division", value);
                SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiUserArea>("usr").FindByName<GuiCTextField>("VBAK-SPART").Text = value;
            }
        }


        public void Sales()
        {
            SAPTestHelper.Current.GetElementById<GuiButton>("wnd[0]/usr").Press();
        }
       

    }
    public class SC_4001//va01 create sales order overview
    {
        public string SoldToParty
        {
            get
            {
                return SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiUserArea>("usr").FindByName<GuiSimpleContainer>("SUBSCREEN_HEADER:SAPMV45A:4021").FindByName<GuiSimpleContainer>("PART-SUB:SAPMV45A:4701").FindByName<GuiCTextField>("KUAGV-KUNNR").Text;
            }
            set
            {
                var reporter = new Reporter.Reporter();
                reporter.updateinputdata("SoldToParty", value);
                SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiUserArea>("usr").FindByName<GuiSimpleContainer>("SUBSCREEN_HEADER:SAPMV45A:4021").FindByName<GuiSimpleContainer>("PART-SUB:SAPMV45A:4701").FindByName<GuiCTextField>("KUAGV-KUNNR").Text=value;
            }
        }
        public string ShipToParty
        {
            get
            {
                return SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiUserArea>("usr").FindByName<GuiSimpleContainer>("SUBSCREEN_HEADER:SAPMV45A:4021").FindByName<GuiSimpleContainer>("PART-SUB:SAPMV45A:4701").FindByName<GuiCTextField>("KUWEV-KUNNR").Text;
            }
            set
            {
                var reporter = new Reporter.Reporter();
                reporter.updateinputdata("ShipToParty", value);
                SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiUserArea>("usr").FindByName<GuiSimpleContainer>("SUBSCREEN_HEADER:SAPMV45A:4021").FindByName<GuiSimpleContainer>("PART-SUB:SAPMV45A:4701").FindByName<GuiCTextField>("KUWEV-KUNNR").Text = value;
            }
        }
        public string PONo
        {
            get
            {
                return SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiUserArea>("usr").FindByName<GuiSimpleContainer>("SUBSCREEN_HEADER:SAPMV45A:4021").FindByName<GuiTextField>("VBKD-BSTKD").Text;
            }
            set
            {
                var reporter = new Reporter.Reporter();
                reporter.updateinputdata("PONo", value);
                SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiUserArea>("usr").FindByName<GuiSimpleContainer>("SUBSCREEN_HEADER:SAPMV45A:4021").FindByName<GuiTextField>("VBKD-BSTKD").Text = value;
            }
        }
        public string PODate
        {
            get
            {
                return SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiUserArea>("usr").FindByName<GuiSimpleContainer>("SUBSCREEN_HEADER:SAPMV45A:4021").FindByName<GuiCTextField>("VBKD-BSTDK").Text;
            }
            set
            {
                var reporter = new Reporter.Reporter();
                reporter.updateinputdata("PODate", value);
                SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiUserArea>("usr").FindByName<GuiSimpleContainer>("SUBSCREEN_HEADER:SAPMV45A:4021").FindByName<GuiCTextField>("VBKD-BSTDK").Text = value;
            }
        }
        public string HPReceiveDate
        {
            get
            {
                return SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiUserArea>("usr").FindByName<GuiSimpleContainer>("SUBSCREEN_HEADER:SAPMV45A:4021").FindByName<GuiCTextField>("VBAK-ZZHPRECDT").Text;
            }
            set
            {
                var reporter = new Reporter.Reporter();
                reporter.updateinputdata("HPReceiveDate", value);
                SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiUserArea>("usr").FindByName<GuiSimpleContainer>("SUBSCREEN_HEADER:SAPMV45A:4021").FindByName<GuiCTextField>("VBAK-ZZHPRECDT").Text = value;
            }
        }                        
    }
    public class SC_4002//va01 create sales order goto;header;sales
    {
        public string OrderReason
        {
            get
            {
                return SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiComboBox>("VBAK-AUGRU").Key;
            }
            set
            {
                var reporter = new Reporter.Reporter();
                reporter.updateinputdata("OrderReason", value);
                SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiComboBox>("VBAK-AUGRU").Key = value;
            }
        }
        public string ConfigCheck
        {
            get
            {
                return SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiCTextField>("VBAK-ZZCNFGCHK").Text;
            }
            set
            {
                var reporter = new Reporter.Reporter();
                reporter.updateinputdata("ConfigCheck", value);
                SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiCTextField>("VBAK-ZZCNFGCHK").Text = value;
            }
        
        }
        public string CustBaseNo
        {
            get
            {
                return SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiTextField>("VBAK-ZZCUSTBASE").Text;
            }
            set
            {
                var reporter = new Reporter.Reporter();
                reporter.updateinputdata("CustBaseNo", value);
                SAPTestHelper.Current.SAPGuiSession.FindById<GuiMainWindow>("wnd[0]").FindByName<GuiTextField>("VBAK-ZZCUSTBASE").Text = value;
            }
        }
        public string HeaderText
        {
            get
            {
                return null;
            }
            set
            {
                var reporter = new Reporter.Reporter();
                reporter.updateinputdata("HeaderText", value);
                SAPTestHelper.Current.SAPGuiSession.FindById<GuiTextedit>("wnd[0]/usr/tabsTAXI_TABSTRIP_HEAD/tabpT\\09/ssubSUBSCREEN_BODY:SAPMV45A:4152/subSUBSCREEN_TEXT:SAPLV70T:2100/cntlSPLITTER_CONTAINER/shellcont/shellcont/shell/shellcont[1]/shell").Text = value;
            }
        }
    }    

    
}
