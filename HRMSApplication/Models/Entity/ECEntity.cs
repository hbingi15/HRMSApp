﻿namespace HRMSApplication.Models.Entity
{
    public class ECEntity
    {
        public string eofr_ref_id { get; set; }
        public int eofr_cand_id { get; set; }
        public DateTime eofr_offerdat { get; set; }
        public string eofr_offeredjob { get; set; }
        public DateTime eofr_reportingdate { get; set; }
        //public long eofr_hrmobileno { get; set; }
        //public string eofr_hremail { get; set; }
        public string eofr_status { get; set; }
        //public List<CandidatesEntity> candidates { get; set; }
    }
   
}

   