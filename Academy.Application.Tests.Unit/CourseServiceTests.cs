using Academy.Domain;
using Academy.Domain.Exceptions;
using Academy.Domain.Tests.Builders;
using Faker;
using FluentAssertions;
using NSubstitute;
using System;
using Tynamix.ObjectFiller;
using Xunit;

namespace Academy.Application.Tests.Unit
{
    public class CourseServiceTests
    {

        private readonly CourseTestBuilder _courseTestBuilder;
        private readonly CourseService _courseService;
        private readonly ICourseRepository _courseRepository;

        public CourseServiceTests()
        {
            _courseTestBuilder = new CourseTestBuilder();
            _courseRepository = Substitute.For<ICourseRepository>();
            _courseService = new CourseService(_courseRepository);
        }

        [Fact]
        public void Should_CreateANewCourse()
        {
            //arrange
            var command = SomeCreateCourse();

            //act
            _courseService.Create(command);

            //assert
            _courseRepository.ReceivedWithAnyArgs().Create(default);

        }

        private static CreateCourse SomeCreateCourse()
        {
            //return new CreateCourse()
            // {
            //     Id = 30,
            //     IsOnline = true,
            //     Name = "C#",
            //     Instructor = Name.FullName(), => Faker.Net
            //     Tuition = 300
            // };

            var filler = new Filler<CreateCourse>();
            filler.Setup().OnProperty(x => x.Tuition).Use(780);
            return filler.Create();
        }

        [Fact]
        public void Should_CreateANewCourseAndReturnId()
        {
            //arrange
            var command = SomeCreateCourse();

            //act
            var actual = _courseService.Create(command);

            //assert
            actual.Should().Be(command.Id);

        }

        [Fact]
        public void Should_ThrowException_WhenAddingCourseIsDuplicated()
        {
            //arrange
            var command = SomeCreateCourse();
            var course = _courseTestBuilder.Build();
            _courseRepository.GetBy(Arg.Any<string>()).Returns(course);

            //act
            Action actual = () => _courseService.Create(command);

            //assert
            actual.Should().Throw<DuplicatedCourseNameException>();

        }

    }
}