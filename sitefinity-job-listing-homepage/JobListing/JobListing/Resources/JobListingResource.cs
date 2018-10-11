using Telerik.Sitefinity.Localization;

namespace JobListing.Resources
{
    [ObjectInfo(typeof(JobListingResource), Title = "JobListingResource", Description = "JobListingResource")]
    public class JobListingResource : Resource
    {
        [ResourceEntry("IAmLookingFor", Value = "I'M LOOKING FOR", LastModified = "2018/10/10")]
        public string IAmLookingFor
        {
            get
            {
                return this["IAmLookingFor"];
            }
        }

        [ResourceEntry("Jobs", Value = "JOBS", LastModified = "2018/10/10")]
        public string Jobs
        {
            get
            {
                return this["Jobs"];
            }
        }

        [ResourceEntry("ShowMe", Value = "SHOW ME", LastModified = "2018/10/10")]
        public string ShowMe
        {
            get
            {
                return this["ShowMe"];
            }
        }

        [ResourceEntry("AllJobs", Value = "ALL JOBS", LastModified = "2018/10/10")]
        public string AllJobs
        {
            get
            {
                return this["AllJobs"];
            }
        }

        [ResourceEntry("FilterBy", Value = "Filter by", LastModified = "2018/10/10")]
        public string FilterBy
        {
            get
            {
                return this["FilterBy"];
            }
        }

        [ResourceEntry("LoadMore", Value = "Load more", LastModified = "2018/10/10")]
        public string LoadMore
        {
            get
            {
                return this["LoadMore"];
            }
        }


        [ResourceEntry("Today", Value = "Today", LastModified = "2018/10/10")]
        public string Today
        {
            get
            {
                return this["Today"];
            }
        }

        [ResourceEntry("Yesterday", Value = "Yesterday", LastModified = "2018/10/10")]
        public string Yesterday
        {
            get
            {
                return this["Yesterday"];
            }
        }

        [ResourceEntry("LastSevenDays", Value = "Last 7 days", LastModified = "2018/10/10")]
        public string LastSevenDays
        {
            get
            {
                return this["LastSevenDays"];
            }
        }

        [ResourceEntry("LastFourteenDays", Value = "Last 14 days", LastModified = "2018/10/10")]
        public string LastFourteenDays
        {
            get
            {
                return this["LoaLastFourteenDaysdMore"];
            }
        }

        [ResourceEntry("LastMonth", Value = "Last month", LastModified = "2018/10/10")]
        public string LastMonth
        {
            get
            {
                return this["LastMonth"];
            }
        }

        [ResourceEntry("LastSixMonth", Value = "Last six month", LastModified = "2018/10/10")]
        public string LastSixMonth
        {
            get
            {
                return this["LastSixMonth"];
            }
        }

        [ResourceEntry("LastYear", Value = "Last year", LastModified = "2018/10/10")]
        public string LastYear
        {
            get
            {
                return this["LastYear"];
            }
        }

        [ResourceEntry("Nationality", Value = "Nationality", LastModified = "2018/10/10")]
        public string Nationality
        {
            get
            {
                return this["Nationality"];
            }
        }

        [ResourceEntry("CreateEmailNotification", Value = "Create email notification", LastModified = "2018/10/10")]
        public string CreateEmailNotification
        {
            get
            {
                return this["CreateEmailNotification"];
            }
        }

        [ResourceEntry("Management", Value = "Management", LastModified = "2018/10/10")]
        public string Management
        {
            get
            {
                return this["Management"];
            }
        }

        [ResourceEntry("Salary", Value = "Salary", LastModified = "2018/10/10")]
        public string Salary
        {
            get
            {
                return this["Salary"];
            }
        }

        [ResourceEntry("LastDate", Value = "Last date", LastModified = "2018/10/10")]
        public string LastDate
        {
            get
            {
                return this["LastDate"];
            }
        }

        [ResourceEntry("ApplyAndOffer", Value = "Apply and offer", LastModified = "2018/10/10")]
        public string ApplyAndOffer
        {
            get
            {
                return this["ApplyAndOffer"];
            }
        }
    }
}