﻿using Academy.Domain.Tests.CollectionFixtures;
using FluentAssertions;
using Xunit;

namespace Academy.Domain.Tests.Tests
{
    [Collection("Database Collection")]
    public class SectionTests
    {
        public SectionTests(DatabaseFixture databaseFixture)
        {
        }

        [Fact]
        public void Constructor_Should_Construct_Section_Properly()
        {
            //Arrange
            const int id = 1;
            const string name = "tdd section";

            //Act
            var section = new Section(id, name);

            //Assert
            section.Id.Should().Be(id);
            section.Name.Should().Be(name);
        }
    }
}