using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationVersionComparator
{
    public class VersionViewModel
    {

        [RegularExpression(@"^(0|[1-9]\d*)(\.(0|[1-9]\d*)){0,2}$")]
        [Required(ErrorMessage = "Not a valid version format. Use the format MajorNumber.MinorNumber.PatchNumber")]
        public string Version { get; set; }
        public IEnumerable<Software> NewerApplications { get; set; }

    }

}
