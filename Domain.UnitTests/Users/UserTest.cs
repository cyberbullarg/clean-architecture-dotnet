using Domain.Users;
using FluentAssertions;

namespace Domain.UnitTests.Users
{
    public class UserTest
    {
        [Fact]
        public void Create_Should_ReturnUser_WhenNameIsValaid()
        {
            // Arrange
            Name name = new("Bill Gates");

            // Act
            User user = User.Create(name);

            // Assert
            user.Should().NotBeNull();
        }

        [Fact]
        public void Create_Should_RaiseDomainEvent_WhenNameIsValid()
        {
            // Arrange
            Name name = new("Bill Gates");

            // Act
            User user = User.Create(name);

            // Assert
            user.DomainEvents.Should().ContainSingle().Which.Should().BeOfType<UserCreatedDomainEvent>();
        }
    }
}
