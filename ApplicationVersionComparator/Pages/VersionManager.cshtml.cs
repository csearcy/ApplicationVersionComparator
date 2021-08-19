using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApplicationVersionComparator.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApplicationVersionComparator.Pages
{
    public class VersionCompareModel : PageModel
    {
        private readonly IVersionManagerService _versionManagerService;

        public VersionCompareModel(IVersionManagerService versionManagerService)
        {
            _versionManagerService = versionManagerService;
        }


        [BindProperty]
        [RegularExpression(@"^(0|[1-9]\d*)(\.(0|[1-9]\d*)){0,2}$", ErrorMessage = "Not a valid version format. Use the format MajorNumber.MinorNumber.PatchNumber with no leading 0s")]
        public string Version { get; set; }
        public IEnumerable<Software> NewerApplications { get; set; }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            NewerApplications = _versionManagerService.GetAllSoftwareGreaterThanVersion(Version);
        }
    }
}
