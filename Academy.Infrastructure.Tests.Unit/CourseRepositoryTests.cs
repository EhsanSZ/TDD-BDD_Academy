using Academy.Domain.Tests.Builders;
using FluentAssertions;
using Xunit;

namespace Academy.Infrastructure.Tests.Unit
{
    public class CourseRepositoryTests
    {
        private readonly CourseRepository _courseRepository;
        private readonly CourseTestBuilder _courseTestBuilder;

        public CourseRepositoryTests()
        {
            _courseRepository = new CourseRepository();
            _courseTestBuilder = new CourseTestBuilder();
        }

        [Fact]
        public void Should_AddNewCourseToCourseList()
        {
            //arrange
            var course = _courseTestBuilder.Build();

            //act
            _courseRepository.Create(course);

            //assert
            _courseRepository.Courses.Should().Contain(course);
        }

        [Fact]
        public void Should_ReturnListOfCourse()
        {
            //act
            var courses = _courseRepository.GetAll();

            //assert
            _courseRepository.Courses.Should().HaveCountGreaterOrEqualTo(0);

        }

        [Fact]
        public void Should_ReturnCourseByID()
        {
            //arrange
            const int id = 73;
            var expectedCourse = _courseTestBuilder.WithId(id).Build();
            _courseRepository.Create(expectedCourse);

            //act
            var actual = _courseRepository.GetBy(id);

            //assert
            actual.Should().Be(expectedCourse);
        }

        [Fact]
        public void Should_ReturnNull_WhenIdNotExist()
        {
            //arrange
            const int id = 57;

            //act
            var actual = _courseRepository.GetBy(id);

            //assert
            actual.Should().BeNull();
        }

        [Fact]
        public void Should_DeleteCourseFromStore()
        {
            //arrange
            const int id = 22;
            var course = _courseTestBuilder.WithId(id).Build();
            _courseRepository.Create(course);

            //act
            _courseRepository.Delete(id);

            //assert
            _courseRepository.Courses.Should().NotContain(course);

            //البته بهتر بود خروجی بولین بگیری و چک کنی
        }
    }

}
