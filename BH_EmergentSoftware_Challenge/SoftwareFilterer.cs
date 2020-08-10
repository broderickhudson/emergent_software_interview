using System;
using System.Collections.Generic;

namespace BH_EmergentSoftware_Challenge
{
    //I put this functionality in its own class to make testing easier and to make it clear where this functionality was.
    public class SoftwareFilterer
    {
        /// <summary>
        /// Returns all of the software that has a version greater than the given filter string.
        /// </summary>
        /// <param name="givenSoftware">The given list of software. I understand that I could just use SoftwareManager for this every time, but maybe in the future that wouldn't be the case.</param>
        /// <param name="filterString">The string that will be used to filter the software.</param>
        /// <returns></returns>
        public IEnumerable<Software> FilterSoftwareByGreaterVersion(IEnumerable<Software> givenSoftware, string filterString)
        {
            //Algorithm:    Use the Version class, and compare with that.
            //              I figured that I shouldn't reinvent the wheel with this. I hope that was a safe assumption.

            //First, make sure that filterString has a value. If it doesn't, just return everything.
            if (string.IsNullOrEmpty(filterString))
                return givenSoftware;

            List<Software> matchingSoftware = new List<Software>();

            Version filterVersion = InitializeVersionFromString(filterString);

            //Iterate through the list of software
            foreach (Software software in givenSoftware)
            {
                Version softwareVersion = InitializeVersionFromString(software.Version);

                //Compare the versions. A result of anything less than 0 means that the current software is greater than the filtered version, so we want it.
                int comparisonResult = filterVersion.CompareTo(softwareVersion);
                if (comparisonResult < 0)
                    matchingSoftware.Add(software);
            }
            return matchingSoftware;
        }

        private Version InitializeVersionFromString(string versionString)
        {
            Version version = null;

            //First, validate the version string
            //Ideally, I wouldn't be verifying the values of the data every time I loop through, but since I'm using statically defined software versions, it seems like I have to.
            //I bet there is a smarter way to do this though.
            if (versionString.StartsWith("."))
                versionString = versionString.Substring(1);

            if (versionString.EndsWith("."))
                versionString = versionString.Substring(0, versionString.Length - 1);

            //If it contains at least one dot, then it's a valid version string.
            if (versionString.Contains("."))
                version = new Version(versionString);

            //Otherwise, it must be a single number, so initialize it with string interpolation adding another zero
            else
                version = new Version($"{versionString}.0");

            return version;
        }
    }
}