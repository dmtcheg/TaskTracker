using System;
using System.Collections.Generic;
using TaskTracker.Core;
using NUnit.Framework;
using TaskTracker.Core.Models;

namespace Tests
{
    public class CoreTests
    {
        private List<Project> _projects = new List<Project>()
        {
            new Project()
            {
                Id = 1, Name = "p1", Priority = 3, StartDate = new DateTime(2020, 1, 1),
                CompletionDate = new DateTime(2021, 11, 1)
            },
            new Project()
            {
                Id = 2, Name = "p2", Priority = 1, StartDate = new DateTime(2018, 2, 1),
                CompletionDate = new DateTime(2022, 5, 1)
            },
            new Project()
            {
                Id = 3, Name = "p3", Priority = 7, StartDate = new DateTime(2021, 4, 1),
                CompletionDate = new DateTime(2021, 8, 1)
            }
        };

        [Test]
        public void DateFilterTest()
        {
            Assert.AreEqual(new List<Project>() {_projects[1]},
                ProjectService.DateFilter(_projects, "before", new DateTime(2019, 2, 1)));
        }

        [Test]
        public void PriorityFilterTest()
        {
            Assert.AreEqual(new List<Project>() {_projects[2]},
                ProjectService.PriorityFilter(_projects, "not less", 5));
        }

        [Test]
        public void SortTest()
        {
            Assert.AreEqual(new List<Project>() {_projects[1], _projects[0], _projects[2]},
                ProjectService.Sort(_projects));
        }
    }
}