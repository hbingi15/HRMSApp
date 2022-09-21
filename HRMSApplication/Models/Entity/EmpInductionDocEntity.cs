namespace HRMSApplication.Models.Entity
{
    public class EmpInductionDocEntity
    {
            public int empl_ind_id { get; set; }
            public int emid_docindex { get; set; }
            public int emid_idty_id { get; set; }
            public string emid_document { get; set; }
            public int emid_processed_ausr_id { get; set; }
            public int emid_verified { get; set; }
        public IFormFile Resume { get; set; }
        public IFormFile SSCCertificates { get; set; }
        public IFormFile Intercertificates { get; set; }
        public IFormFile BtechCertificate { get; set; }


    }
}


