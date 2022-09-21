namespace HRMSApplication.Models.Resource
{
    public class CandidateResource
    {
        public int ID { get; set; }
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
