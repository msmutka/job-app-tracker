using System;

namespace JobAppTracker.Api.Models
{
    public class JobApplication
    {
        public Guid Id { get; set; }
        public required string Company { get; set; }
        public required string Title { get; set; }
        public required string Stage { get; set; }  // 'applied' | 'interviewing' | 'offer' | 'rejected'
        public DateTime AppliedOn { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public required string Notes { get; set; }
    }
}
