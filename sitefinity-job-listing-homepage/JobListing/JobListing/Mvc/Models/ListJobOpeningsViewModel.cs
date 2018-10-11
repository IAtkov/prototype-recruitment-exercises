using System;
using System.Collections.Generic;

namespace JobListing.Mvc.Models
{
    public class ListJobOpeningsViewModel
    {
        public IList<string> TypeOfJobs { get; set; } = new List<string>();

        public IList<SelectViewModel> PostingDate { get; set; } = new List<SelectViewModel>();

        public IList<SelectViewModel> Nationalities { get; set; } = new List<SelectViewModel>();

        public IList<SelectViewModel> Genders { get; set; } = new List<SelectViewModel>();

        public IList<JobOpeningViewModel> JobOpenings { get; set; } = new List<JobOpeningViewModel>();

        public int ItemsPerPage { get; set; }

        public int LastPage { get; set; }

        public string ActiveTypeOfJob { get; set; }

        public string SelectedNationality { get; set; }

        public string SelectedGender { get; set; }
    }
}