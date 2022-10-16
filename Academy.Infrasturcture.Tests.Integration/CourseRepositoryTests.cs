using Academy.Domain.Tests.Builders;
using Academy.Infrastructure;
using Academy.Infrastructure.Tests.Integration;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Academy.Infrasturcture.Tests.Integration
{
    public class CourseRepositoryTests : IClassFixture<RealDatabaseFixture>
    {
        private readonly CourseRepository _repository;
        private readonly CourseTestBuilder _courseBuilder;

        public CourseRepositoryTests(RealDatabaseFixture databaseFixture)
        {
            _courseBuilder = new CourseTestBuilder();
            _repository = new CourseRepository(databaseFixture.Context);
        }


        [Fact]
        public void Should_ReturnAllCourses()
        {
            //act
            var courses = _repository.GetAll();

            //assert
            courses.Should().HaveCountGreaterOrEqualTo(3);

        }


        [Fact]
        public void Should_CreateCourse()
        {
            //arrange
            var expected = _courseBuilder.Build();

            //act
            var courseId = _repository.Create(expected);

            //assert
            courseId.Should().Be(expected.Id);

            var courses = _repository.GetAll();
            courses.Should().Contain(expected);

        }


    }
}
