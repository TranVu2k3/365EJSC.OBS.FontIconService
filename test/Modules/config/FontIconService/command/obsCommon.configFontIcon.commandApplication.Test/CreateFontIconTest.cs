using Moq;
using System.Data;

namespace obsCommon.configFontIcon.commandApplication.Test
{
    public class CreateFontIconTest
    {
        private readonly Mock<IFontIconRepository> fontIconRepositoryMock;
        private readonly CreateFontIconCommandHandler handler;

        public CreateFontIconTest()
        {
            fontIconRepositoryMock = new Mock<IFontIconRepository>();
            handler = new CreateFontIconCommandHandler(fontIconRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreateFontIcon_WhenRequestIsValid()
        {
            var command = new CreateFontIconCommand
            {
                Description = "FontIcon Description",
                Type = "FontIcon Type",
                Version = "FontIcon Version",
                IsActived = true
            };
            var fontIcon = new Entities.FontIcon
            {
                Description = command.Description,
                Type = command.Type,
                Version = command.Version,
                IsActived = command.IsActived
            };
            fontIconRepositoryMock.Setup(repo => repo.BeginTransactionAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(Mock.Of<IDbTransaction>());
            fontIconRepositoryMock.Setup(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var result = await handler.Handle(command, CancellationToken.None);

            fontIconRepositoryMock.Verify(repo => repo.Add(It.IsAny<Entities.FontIcon>()), Times.Once);
            fontIconRepositoryMock.Verify(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
            Assert.Equal(fontIcon.Description, result.Data.Description);
            Assert.Equal(fontIcon.Type, result.Data.Type);
            Assert.Equal(fontIcon.Version, result.Data.Version);
            Assert.Equal(fontIcon.IsActived, result.Data.IsActived);
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenTransactionFails()
        {
            var command = new CreateFontIconCommand
            {
                Description = "FontIcon Description",
                Type = "FontIcon Type",
                Version = "FontIcon Version",
                IsActived = true
            };
            fontIconRepositoryMock.Setup(repo => repo.BeginTransactionAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(Mock.Of<IDbTransaction>());
            fontIconRepositoryMock.Setup(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception());

            await Assert.ThrowsAsync<Exception>(() => handler.Handle(command, CancellationToken.None));
            fontIconRepositoryMock.Verify(repo => repo.Add(It.IsAny<Entities.FontIcon>()), Times.Once);
            fontIconRepositoryMock.Verify(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public void Handle_ShouldThrowValidationExceptionForInvalidDescription()
        {
            var command = new CreateFontIconCommand
            {
                Description = null,
                Type = "FontIcon Type",
                Version = "FontIcon Version",
                IsActived = true
            };
        }

        [Fact]
        public void Handle_ShouldThrowValidationExceptionForInvalidType()
        {
            var command = new CreateFontIconCommand
            {
                Description = "FontIcon Description",
                Type = null,
                Version = "FontIcon Version",
                IsActived = true
            };
        }


        [Fact]
        public void Handle_ShouldThrowValidationExceptionForInvalidIsActived()
        {
            var command = new CreateFontIconCommand
            {
                Description = "FontIcon Description",
                Type = "FontIcon Type",
                Version = "FontIcon Version",
                IsActived = false
            };
        }

        [Fact]
        public async Task Handle_ShouldThrowValidationExceptionWhenFontIconRepositoryThrows()
        {
            var command = new CreateFontIconCommand
            {
                Description = "FontIcon Description",
                Type = "FontIconType",
                Version = "FontIcon Version",
                IsActived = true
            };
            var fontIcon = new Entities.FontIcon
            {
                Description = command.Description,
                Type = command.Type,
                Version = command.Version,
                IsActived = command.IsActived
            };
            fontIconRepositoryMock.Setup(repo => repo.BeginTransactionAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(Mock.Of<IDbTransaction>());
            fontIconRepositoryMock.Setup(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new DomainValidationException("FontIcon repository exception"));

            await Assert.ThrowsAsync<DomainValidationException>(() => handler.Handle(command, CancellationToken.None));
        }
    }
}
