using System;

namespace JobListing.Mvc.Models
{
    public class JobOpeningViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ButtonText { get; set; }

        public string UpperButtonText { get; set; }

        public DateTime LastDate { get; set; }

        public DateTime PostingDate { get; set; }

        public string Nationality { get; set; }

        public string Salary { get; set; }

        public string Gender { get; set; }

        public string JobType { get; set; }
    }
}