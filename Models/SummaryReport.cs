namespace SimpleWKReport.Models
{
    public class SummaryReport
    {
        public int No { get; set; }
        public string MarketingCode { get; set; }
        public string MarketingName { get; set; }
        public string AgentCode { get; set; }
        public string AgentName { get; set; }
        public string Transaction { get; set; }
        public int CheckNCBReqMoreDoc { get; set; }
        public int CheckNCBPass { get; set; }
        public int CheckNCBNotpass { get; set; }
        public int FullRegisterReqMoreDoc { get; set; }
        public int FullRegisterPending { get; set; }
        public int FullRegisterCancelByCustomer { get; set; }
        public int FullRegisterCancelByJDM { get; set; }
        public int FullRegisterApprove { get; set; }
        public int FullRegisterReject { get; set; }

    }
}