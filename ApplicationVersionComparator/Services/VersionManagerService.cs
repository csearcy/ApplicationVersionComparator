using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationVersionComparator.Services
{
    public interface IVersionManagerService
    {
        IEnumerable<Software> GetAllSoftwareGreaterThanVersion(string version);
    }

    public class VersionManagerService : IVersionManagerService
    {
        public IEnumerable<Software> GetAllSoftwareGreaterThanVersion(string version)
        {
            if (string.IsNullOrEmpty(version))
            {
                return null;
            }

            version += !version.Contains(".") ? ".0" : string.Empty;

            IEnumerable<Software> applications;

            try
            {
                applications = SoftwareManager.GetAllSoftware().Where(a => Version.Parse(a.Version.TrimEnd('.')).CompareTo(Version.Parse(version.TrimEnd('.'))) > 0);
            }
            catch (Exception exception)
            {

                throw new ArgumentException("Unable to convert given version into valid version format.", exception);
            }

            return applications;
        }
    }
}
