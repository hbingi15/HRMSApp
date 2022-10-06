﻿namespace HRMSApplication.Models.Resource
{
    public class LeaveRequestInput
    {
        public int Id { get; set; }
        public string LeaveType { get; set; }
        public string Reason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
