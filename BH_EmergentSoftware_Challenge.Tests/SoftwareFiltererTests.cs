using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BH_EmergentSoftware_Challenge.Tests
{
    [TestClass]
    public class SoftwareFiltererTests
    {
        /// <summary>
        /// Test that several spellings of 1.9 and approximate all return all possible variations of 2.0.0.
        /// </summary>
        [TestMethod]
        public void EqualityTest()
        {
            List<string> acceptableLessThanTwoValues = new List<string> { "1", "1.9", "1.9.9", "1.", "1.9.", "1.9.9." };
            IEnumerable<Software> testSoftwares = new List<Software>()
            {
                new Software()
                {
                    Name = "Major",
                    Version = "2"
                },
                new Software()
                {
                    Name = "Minor",
                    Version = "2.0"
                },
                new Software()
                {
                    Name = "Patch",
                    Version = "2.0.0"
                }
            };

            SoftwareFilterer softwareFilterer = new SoftwareFilterer();

            foreach (var value in acceptableLessThanTwoValues)
            {
                Assert.AreEqual(testSoftwares.Count(), softwareFilterer.FilterSoftwareByGreaterVersion(testSoftwares, value).Count());
            }
        }

        /// <summary>
        /// Test that a patch is assessed as being greater than a major version.
        /// </summary>
        [TestMethod]
        public void MajorVersionToPatchTest()
        {
            IEnumerable<Software> testSoftwares = new List<Software>()
            {
                new Software()
                {
                    Name = "Patch",
                    Version = "2.0.1"
                }
            };

            SoftwareFilterer softwareFilterer = new SoftwareFilterer();
            Assert.AreEqual(testSoftwares.Count(), softwareFilterer.FilterSoftwareByGreaterVersion(testSoftwares, "2").Count());
        }

        /// <summary>
        /// Test that a minor version is assessed as being greater than a major version.
        /// </summary>
        [TestMethod]
        public void MajorVersionToMinorVersionTest()
        {
            IEnumerable<Software> testSoftwares = new List<Software>()
            {
                new Software()
                {
                    Name = "Minor v1",
                    Version = "2.1.0"
                },
                new Software()
                {
                    Name = "Minor v2",
                    Version = "2.1"
                }
            };

            SoftwareFilterer softwareFilterer = new SoftwareFilterer();
            Assert.AreEqual(testSoftwares.Count(), softwareFilterer.FilterSoftwareByGreaterVersion(testSoftwares, "2").Count());
        }

        /// <summary>
        /// Test that a minor version is assessed as being greater than a major version.
        /// </summary>
        [TestMethod]
        public void MinorVersionToPatchTest()
        {
            IEnumerable<Software> testSoftwares = new List<Software>()
            {
                new Software()
                {
                    Name = "Minor v1",
                    Version = "2.1.0"
                },
                new Software()
                {
                    Name = "Minor v2",
                    Version = "2.1"
                }
            };

            SoftwareFilterer softwareFilterer = new SoftwareFilterer();
            Assert.AreEqual(testSoftwares.Count(), softwareFilterer.FilterSoftwareByGreaterVersion(testSoftwares, "2.0.1").Count());
        }
    }
}

