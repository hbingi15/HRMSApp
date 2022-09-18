namespace HRMSApplication.Models
{
    public class InductionEnitity
    {
        public int indc_id { get; set; }
        public int indc_emof_id { get; set; }
        public string indc_date { get; set; }
        public int indc_processed_ausr_id { get; set; }
        public char indc_status { get; set; }
        public int EOFR_id { get; set; }
        public int eofr_ref_id { get; set; }
        public int eofr_cand_id { get; set; }
        public string eofr_offerdate { get; set; }
        public string eofr_offeredjob { get; set; }
        public string eofr_reportingdate { get; set; }
        public int eofr_hrmobileno { get; set; }
        public string eofr_hremail { get; set; }
        public char eofr_status { get; set; }
        public int cand_id { get; set; }
        public string cand_firstname { get; set; }
        public string cand_middlename { get; set; }
        public string cand_lastname { get; set; }
        public string cand_rdate { get; set; }
        public char cand_gender { get; set; }
        public string cand_dob { get; set; }

        public string cand_email { get; set; }
        public int cand_mobile { get; set; }
        public string cand_address { get; set; }
        public string cand_ludate { get; set; }
        public char cand_status { get; set; }



    }
}
