using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class RawData
    {
        [Key]
        public int IDRawData { get; set; }

        public string FileNo { get; set; }

        public string District { get; set; } //205
        public string County { get; set; }

        public string Control { get; set; }
        public string Section { get; set; }

        public string Milepnt { get; set; }
        public string StrNo { get; set; }

        public string DupRtOver { get; set; }
        public string RtStrFunc { get; set; }

        public string Blanks1 { get; set; }
        public string RtDesign { get; set; }

        public string RtBusSfx { get; set; }
        public string RtSystem { get; set; }

        public string RtNo { get; set; }
        public string RtDir { get; set; }

        public string BRefMrk { get; set; }
        public string BRefMkSfx { get; set; }

        public string BRfMkign { get; set; }
        public string BRfMkDispl { get; set; }

        public string PlaceCode { get; set; }
        public string FeatXed { get; set; }

        public string CritBdg { get; set; }
        public string MiPtDatePr { get; set; }

        public string AMiPtDateInt { get; set; }
        public string Blanks2 { get; set; }

        public string FacCarried { get; set; }
        public string Location { get; set; }

        public string RtMinVrtClear { get; set; }
        public float? OLD16Latitude { get; set; }

        public float? OLD17Longitude { get; set; }
        public string DetourLgth { get; set; }

        public string Toll { get; set; }
        public string Custodian { get; set; }

        public string Owner { get; set; }
        public string MaintSect { get; set; }

        public string ProjType { get; set; }
        public double? CSJWhnBlt { get; set; }

        public string FuncClass { get; set; }

        public string YrBuilt { get; set; }

        public string LanesOn { get; set; }

        public string LanesUnder { get; set; }

        public double? AADT { get; set; }

        public string AADTYear { get; set; }

        public string DesignLoad { get; set; }

        public string ApprWidth { get; set; }

        public string Median { get; set; }

        public string Skew { get; set; }
        public string StrFlared { get; set; }

        public string TrfSafeFeat { get; set; }

        public string HistSignif { get; set; }

        public string NavControls { get; set; }

        public string NavHrzClear { get; set; }

        public string OperStatus        { get; set; }

        public string LoadType { get; set; }

        public string Load1000lb { get; set; }

        public string ServOnUnder { get; set; }

        public string MnSpanTy { get; set; }

        public string MjAprSpTy { get; set; }

        public string MnAprSpTy { get; set; }

        public string CulvType { get; set; }

        public string TunnelTy        { get; set; }

        public string SubstrMSpan { get; set; }

        public string SubMjAprSp { get; set; }

        public string SubMnAprSp { get; set; }

        public string NoMSpan { get; set; }

        public string NoMjAprSp { get; set; }

        public string NoMnAprSp { get; set; }

        public string TotalNoSpans { get; set; }

        public string TotHrzClear { get; set; }


        public string MaxSpLgth { get; set; }
        public string StrLgth { get; set; }
        public string LtSdwalk { get; set; }
        public string RtSdwalk { get; set; }
        public string RdwyWidth { get; set; }
        public string DeckWidth { get; set; }
        public string VrtClrOver { get; set; }
        public string VrtClrRefFeat { get; set; }
        public string VrtClrUnder { get; set; }
        public string LatClrRefFeat { get; set; }
        public string RtLatClear { get; set; }
        public string LtLatClear { get; set; }
        public string Blanks3 { get; set; }
        public string DeckCond { get; set; }
        public string SuperCond { get; set; }
        public string SubstrCond { get; set; }
        public string ChanProt { get; set; }
        public string Culvert { get; set; }
        public string OperRate { get; set; }
        public string RdApprCond { get; set; }
        public string InvRate { get; set; }

        public string StrEval { get; set; }
        public string DeckGeom { get; set; }
        public string UClrVrtHrz { get; set; }
        public string SafeLoadCap { get; set; }
        public string WaterwayAdeq { get; set; }
        public string ApprRdAlign { get; set; }
        public string TyWrkRepl { get; set; }
        public double? LgthImprov { get; set; }
        public string SpecFlags { get; set; }
        public string FHWAResvd { get; set; }
        public string CostImprov1 { get; set; }

        public double? LastInspec { get; set; }

        public string DesInspFreq { get; set; } //205
        public string FracCritDet { get; set; }

        public string UndwtrInspec { get; set; }
        public string SpecialInspec { get; set; }

        public string FracCritDate { get; set; }
        public string UwtrInsDate { get; set; }

        public string SpecInspDate { get; set; }
        public double? BdgImprCost { get; set; }

        public double? RdImprCost { get; set; }
        public double? TotProjCost { get; set; }

        public string YrImprCostEst { get; set; }
        public double? BorderBdg { get; set; }

        public string BorderBdgNo { get; set; }
        public string DefHwyDesn { get; set; }

        public string ParlStrDesn { get; set; }
        public string DirofTraffic { get; set; }

        public string TempStrDesn { get; set; }
        public string NHS { get; set; }

        public string OldFAU { get; set; }
        public string FHWAResvd_105 { get; set; }

        public string YrReconstr { get; set; }
        public string WidenCode { get; set; }

        public string DeckTyMSp { get; set; }
        public string MSpWrSurf { get; set; }

        public string DeckMjAprSp { get; set; }
        public string MjAprSpWrSrf { get; set; }

        public string DkMnAprSp { get; set; }
        public string MnAprSpWrSrf { get; set; }

        public string AADTTruckPct { get; set; }
        public string DesNatlNtwk { get; set; }

        public string PierProtect { get; set; }
        public string NBIBdgLgth { get; set; }

        public string ScourCrit { get; set; }
        public double? FutureAADT { get; set; }

        public string FutAADTYear { get; set; }
        public string MnNavVrtClear { get; set; }

        public string OrigCost { get; set; }

        public string DefObs { get; set; }

        public double? SuffRate { get; set; }

        public string XrefPrinRtID { get; set; }

        public string XrfStrFncPRt { get; set; }

        public string SuffRatFlag { get; set; }

        public string ScourVuln { get; set; }

        public string OvHtLoadDmg { get; set; }

        public string Blanks4 { get; set; }

        public string XRfIRID { get; set; }
        public string XRfIRStrFunc { get; set; }

        public double? Blanks5 { get; set; }

        public string DistUse { get; set; }

        public string AIRControl { get; set; }

        public string AIRSection { get; set; }

        public string AIRMilept { get; set; }

        public string AIRStrNo { get; set; }

        public string AIRDuplOver { get; set; }

        public string AIRStrFunct { get; set; }

        public string AIRDesignation { get; set; }

        public string AIRBusSfx { get; set; }

        public string AIRHwySys { get; set; }

        public string AIRHwyNo { get; set; }

        public string AIRDir { get; set; }

        public string CIRRefMrk { get; set; }

        public string CIRRefMkSfx { get; set; }

        public string CIRRfMkSign { get; set; }

        public string CIRRfMkDispl { get; set; }

        public string AIRHrzClear { get; set; }

        public string AIRMnVrtClear { get; set; }

        public string AIRBypsLgth { get; set; }

        public string AIRToll { get; set; }


        public string AIRFuncClass { get; set; }
        public string AIRAADT { get; set; }
        public string AIRAADTYr { get; set; }
        public string AIRDefHwyDes { get; set; }
        public string AIRParlStr { get; set; }
        public string AIRTrafDir { get; set; }
        public string AIRTempStr { get; set; }
        public string AIRNHS { get; set; }
        public string OldFAU_IR { get; set; }
        public string AIRAADTTrkPct { get; set; }
        public string AIRNatlNtwk { get; set; }
        public string AIRFutAADT { get; set; }
        public string AIRFAADTYr { get; set; }
        public string Blanks6 { get; set; }
        public string FHWAStrEval { get; set; }
        public string FHWADkGeom { get; set; }
        public string FHWAUClrVrtHrz { get; set; }
        public string BaseHwyNet { get; set; }
        public string LRSInvRte { get; set; }
        public string LRSSubRte { get; set; }
        public string Blanks7 { get; set; }
        public double? GPSLatitude { get; set; }
        public string Blanks8 { get; set; }
        public double? GPSLongitude { get; set; }
        public string GPSColMeth { get; set; }
        public string MethOperRate { get; set; }
        public string MethInvRate { get; set; }
        public string FedLand { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string AIRBaseHwyNet { get; set; }

        public string AIRLRSInvRte { get; set; }
        public string AIRLRSSubRte { get; set; }
        public string Blanks9 { get; set; }
        
    }
}
