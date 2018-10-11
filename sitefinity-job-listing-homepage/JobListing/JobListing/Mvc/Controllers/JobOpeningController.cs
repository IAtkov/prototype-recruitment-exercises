using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using Common.Constants;
using Common.Controllers;
using Common.Services.Interfaces;
using JobListing.Constants;
using JobListing.Mvc.Models;
using JobListing.Resources;
using Telerik.OpenAccess;
using Telerik.Sitefinity.ContentLocations;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using Telerik.Sitefinity.Frontend.Mvc.Models;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Mvc.ActionFilters;

namespace JobListing.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "JobOpeningsWidget", Title = "Job openings", SectionName = "Telerik.Sitefinity.DynamicTypes.Model.JobOpenings", CssClass = "sfMvcIcn")]
    [Localization(typeof(JobListingResource))]
    public class JobOpeningController : BaseController, IDynamicContentWidget, IContentLocatableView
    {
        private JobOpeningModel model;
        private readonly IDynamicContentService dynamicContent;
        private readonly ITaxonomiesService taxonomiesService;

        public JobOpeningController(IDynamicContentService dynamicContent, ITaxonomiesService taxonomiesService)
        {
            this.dynamicContent = dynamicContent;
            this.taxonomiesService = taxonomiesService;
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public JobOpeningModel Model
        {
            get
            {
                if (model == null)
                {
                    model = new JobOpeningModel(dynamicContent, taxonomiesService);
                }

                return model;
            }
        }

        public bool? DisableCanonicalUrlMetaTag { get; set; }

        public ActionResult Index(string typeOfJobSelected = CommonConstants.All, string nationalityFilter = "", string genderFilter = "", int dateFilter = -1)
        {
            if (typeOfJobSelected == null || typeOfJobSelected == "")
            {
                typeOfJobSelected = CommonConstants.All;
            }

            Model.TypeOfJobFilter = typeOfJobSelected;
            Model.DateFilter = dateFilter;
            Model.NationalityFilter = nationalityFilter;
            Model.GenderFilter = genderFilter;
            var jobOpenings = Model.CreateListViewModel(null, 1);
            var viewModel = CreateListViewModel(jobOpenings);
            Model.ItemsPerPage = Model.ItemsPerPage.HasValue ? Model.ItemsPerPage.Value : 10;
            viewModel.LastPage = (Model.ItemsCount + Model.ItemsPerPage.Value - 1) / Model.ItemsPerPage.Value;
            viewModel.ActiveTypeOfJob = typeOfJobSelected;
            viewModel.SelectedGender = genderFilter;
            viewModel.SelectedNationality = nationalityFilter;

            return View(GetListTemplateName("List.JobOpenings"), viewModel);
        }

        [StandaloneResponseFilter]
        [HttpGet]
        public PartialViewResult LoadMoreJobs(string typeOfJobSelected = "", string nationalityFilter = "", string genderFilter = "", int dateFilter = -1, int page = 1)
        {
            Model.TypeOfJobFilter = typeOfJobSelected;
            Model.DateFilter = dateFilter;
            Model.NationalityFilter = nationalityFilter;
            Model.GenderFilter = genderFilter;
            var jobOpenings = Model.CreateListViewModel(null, page);
            var viewModel = CreateJobOpeningViewModel(jobOpenings.Items);

            return PartialView("_JobOpening", viewModel);
        }

        private List<JobOpeningViewModel> CreateJobOpeningViewModel(IEnumerable<ItemViewModel> jobOpenings)
        {
            var result = new List<JobOpeningViewModel>();
            foreach (var jobOpeningItem in jobOpenings)
            {
                var jobOpening = new JobOpeningViewModel();
                jobOpening.Title = jobOpeningItem.Fields.Title;
                jobOpening.Description = jobOpeningItem.Fields.Description;
                jobOpening.Salary = jobOpeningItem.Fields.Salary;
                jobOpening.Nationality = GetClassificationValue(jobOpeningItem.Fields.countries);
                jobOpening.JobType = GetClassificationValue(jobOpeningItem.Fields.jobtypes);
                jobOpening.PostingDate = jobOpeningItem.Fields.DateCreated;
                jobOpening.LastDate = jobOpeningItem.Fields.LastDate;
                jobOpening.Gender = jobOpeningItem.Fields.Gender.Text;

                result.Add(jobOpening);
            }

            return result;
        }

        private ListJobOpeningsViewModel CreateListViewModel(ContentListViewModel jobOpenings)
        {
            var viewModel = new ListJobOpeningsViewModel();
            viewModel.JobOpenings = CreateJobOpeningViewModel(jobOpenings.Items);
            viewModel.TypeOfJobs = taxonomiesService.GetTitlesFromFlatTaxonomy(TaxonomyConstants.JobTypes);
            viewModel.ItemsPerPage = Model.ItemsPerPage.HasValue ? Model.ItemsPerPage.Value : 10;
            viewModel.Nationalities = taxonomiesService.GetTitlesFromFlatTaxonomy(TaxonomyConstants.Countries).Select(t => new SelectViewModel { Title = t }).ToList();
            viewModel.Genders.Add(new SelectViewModel() { Title = "All", Value = CommonConstants.All, IsSelected = false });
            viewModel.Genders.Add(new SelectViewModel() { Title = "Male", Value = "2", IsSelected = false });
            viewModel.Genders.Add(new SelectViewModel() { Title = "Female", Value = "1", IsSelected = false });
            return viewModel;
        }

        private string GetClassificationValue(TrackedList<Guid> ids)
        {
            foreach (var id in ids)
            {
                return taxonomiesService.GetTaxonTitleById(id);
            }

            return "";
        }

        public IEnumerable<IContentLocationInfo> GetLocations()
        {
            return Model.GetLocations();
        }
    }
}