namespace HRMSApplication.Models.Resource
{
    public class EOCandidateReource
    {
        public string Eofr_Ref_Id { get; set; }
        public int Eofr_Cand_Id { get; set; }
        public DateTime Eofr_Offerdat { get; set; }
        public string Eofr_Offeredjob { get; set; }
        public DateTime Eofr_Reportingdate { get; set; }
        public string Eofr_Status { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime Rdate { get; set; }
        public char Gender { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public string Address { get; set; }
        public string Candidate_Status { get; set; }
    }
}
