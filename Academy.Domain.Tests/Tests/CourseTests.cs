using Academy.Domain.Exceptions;
using Academy.Domain.Tests.Builders;
using Academy.Domain.Tests.ClassFixtures;
using Academy.Domain.Tests.CollectionFixtures;
using Academy.Domain.Tests.Factories;
using FluentAssertions;
using System;
using Xunit;

namespace Academy.Domain.Tests.Tests
{
    [Collection("Database Collection")]
    public class CourseTests : IClassFixture<IdentifierFixture>
    {
        private readonly CourseTestBuilder courseTestBuilder;
        public CourseTests(DatabaseFixture databaseFixture)
        {
            courseTestBuilder = new CourseTestBuilder();
        }

        [Fact]
        public void Constructor_ShouldConstructCourseProperly()
        {
            //var guid = IdentifierFixture.Id;
            const string name = "tdd & bdd";
            const bool isOnline = true;
            const double tuition = 600;
            const string instructor = "Ehsan";

            var course = courseTestBuilder.Build();

            course.Name.Should().Be(name);
            course.IsOnline.Should().Be(isOnline);
            course.Tuition.Should().Be(tuition);
            course.Instructor.Should().Be(instructor);
            course.Sections.Should().BeEmpty();

        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenNameIsNotProvided()
        {

            Action course = () => courseTestBuilder.WithName("").Build();

            course.Should().ThrowExactly<CourseNameIsInvalidException>();

        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenTuitionIsNotProvided()
        {

            Action course = () => courseTestBuilder.WithTuition(0).Build();

            course.Should().ThrowExactly<CourseTuitionIsInvalidException>();
        }

        [Fact]
        public void AddSection_ShouldAddNewSectionToSections_WhenIdAndNamePassed()
        {
            //arrange
            var course = courseTestBuilder.Build();
            var sectionToAdd = SectionFactory.Create();

            //act
            course.AddSection(sectionToAdd);

            //assert
            course.Sections.Should().ContainEquivalentOf(sectionToAdd);
        }


        [Fact]
        public void Should_BeEqual_WhenIdIsEqual()
        {
            //arrange
            const int sameId = 1;
            var courseBuilder = new CourseTestBuilder();
            var course1 = courseBuilder.Build();
            course1.Id = sameId;
            var course2 = courseBuilder.Build();
            course2.Id = sameId;

            //act
            var actual = course1.Equals(course2);

            //assert
            actual.Should().BeTrue();
            //course1.Should().Be(course2);
        }


        [Fact]
        public void Should_NotBeEqual_WhenIdIsNotEqual()
        {
            //arrange
            var courseBuilder = new CourseTestBuilder();
            var course1 = courseBuilder.Build();
            course1.Id = 1;
            var course2 = courseBuilder.Build();
            course2.Id = 2;

            //act
            var actual = course1.Equals(course2);

            //assert
            actual.Should().BeFalse();
            //course1.Should().NotBe(course2);
        }

        [Fact]
        public void Should_NotBeEqual_WhenIsNull()
        {
            //arrange
            var courseBuilder = new CourseTestBuilder();
            var course1 = courseBuilder.Build();

            //act
            var actual = course1.Equals(null);

            //assert
            actual.Should().BeFalse();
        }


    }

}
