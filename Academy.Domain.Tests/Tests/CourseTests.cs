using System;
using Xunit;

namespace Academy.Domain.Tests.Tests
{
    public class CourseTests
    {
        [Fact]
        public void Constructor_ShouldConstructCourseProperly()
        {
            const int id = 1;
            const string name = "tdd & bdd";
            const bool isOnline = true;
            const double tuition = 600;
            const string instructor = "hossein";

            var course = new Course( id , name , isOnline , tuition , instructor);

            Assert.Equal(id, course.Id);
            Assert.Equal(name, course.Name);
            Assert.Equal(isOnline, course.IsOnline);
            Assert.Equal(tuition, course.Tuition);
            Assert.Equal(instructor, course.Instructor);
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenNameIsNotProvided()
        {
            const int id = 1;
            const string name = "";
            const bool isOnline = true;
            const double tuition = 240;
            const string instructor = "hossein";

            void course() => new Course(id, name, isOnline, tuition, instructor);

            Assert.Throws<Exception>(course);
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenTuitionIsNotProvided()
        {
            const int id = 1;
            const string name = "tdd & bdd";
            const bool isOnline = true;
            const double tuition = 0;
            const string instructor = "hossein";

            void course() => new Course(id, name, isOnline, tuition, instructor);

            Assert.Throws<Exception>(course);
        }
    }

}
