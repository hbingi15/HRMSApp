namespace HRMSApplication.Models.Entity
{
    public class EOCandidateEntity
    {
        public int eofr_id { get; set; }
        public string eofr_ref_id { get; set; }
        public int eofr_cand_id { get; set; }
        public DateTime eofr_Offerdate { get; set; }
        public string eofr_offeredjob { get; set; }
        public DateTime eofr_reportingdate { get; set; }
        public string eofr_status { get; set; }
        public int cand_id { get; set; }
        public string cand_firstname { get; set; }
        public string cand_middlename { get; set; }
        public string cand_lastname { get; set; }
        public DateTime cand_rdate { get; set; }
        public char cand_gender { get; set; }
        public DateTime cand_dob { get; set; }
        public string cand_email { get; set; }
        public long cand_mobile { get; set; }
        public string cand_address { get; set; }
    }
}
