namespace HRMSApplication.Models.Resource
{
    public class CandidateResource
    {
        public int ID { get; set; }
        public string Cand_FirstName { get; set; }
        public string Cand_MiddleName { get; set; }
        public string Cand_LastName { get; set; }
        public DateTime Cand_Rdate { get; set; }
        public char Cand_Gender { get; set; }
        public DateTime Cand_Dob { get; set; }
        public string Cand_Email { get; set; }
        public long Cand_Mobile { get; set; }
        public string Cand_Address { get; set; }
        public string Candidate_Status { get; set; }
    }
}
