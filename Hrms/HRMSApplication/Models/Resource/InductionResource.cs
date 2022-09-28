namespace HRMSApplication.Models.Resource
{
    public class InductionResource
    {
        public int Indction_ID { get; set; }
        public int Induction_Emof_ID { get; set; }
        public DateTime Induction_Date { get; set; }
        public int Induction_Processed_Ausr_ID{ get; set; }
        public string Induction_Status { get; set; }

    }
}
