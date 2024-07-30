using Moq;
using System.Data;

namespace obsCommon.configFontIcon.commandApplication.Test
{
    public class UpdateFontIconTest
    {
        private readonly Mock<IFontIconRepository> fontIconRepositoryMock;
        private readonly UpdateFontIconCommandHandler handler;

        public UpdateFontIconTest()
        {
            fontIconRepositoryMock = new Mock<IFontIconRepository>();
            handler = new UpdateFontIconCommandHandler(fontIconRepositoryMock.Object);
        }


        [Fact]
        public async Task Handle_ShouldUpdateSample_WhenRequestIsValid()
        {
            var command = new UpdateFontIconCommand
            {
                Id = "a",
                Description = "Updated Description",
                Type = "Updated Type",
                Version = "Updated Version",
                IsActived = true
            };
            var fontIcon = new Entities.FontIcon
            {
                Id = "a",
                Description = "Old Description",
                Type = "Old Type",
                Version = "Old Version",
                IsActived = true
            };
            fontIconRepositoryMock
                .Setup(repo => repo.FindByIdAsync(command.Id, It.IsAny<FindOption>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(fontIcon);
            fontIconRepositoryMock.Setup(repo => repo.BeginTransactionAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(Mock.Of<IDbTransaction>());
            fontIconRepositoryMock.Setup(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            var result = await handler.Handle(command, CancellationToken.None);

            fontIconRepositoryMock.Verify(repo => repo.Update(It.IsAny<Entities.FontIcon>()), Times.Once);
            fontIconRepositoryMock.Verify(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
            Assert.Equal(StatusCode.Ok, result.StatusCode);
            Assert.Equal(command.Description, fontIcon.Description);
            Assert.Equal(command.Type, fontIcon.Type);
            Assert.Equal(command.Version, fontIcon.Version);
            Assert.Equal(command.IsActived, fontIcon.IsActived);
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenTransactionFails()
        {
            var command = new UpdateFontIconCommand
            {
                Id = "a",
                Description = "Updated Description",
                Type = "Updated Type",
                Version = "Updated Version",
                IsActived = true
            };
            var sample = new Entities.FontIcon
            {
                Id = "a",
                Description = "Old Description",
                Type = "Old Type",
                Version = "Old Version",
                IsActived = true
            };
            fontIconRepositoryMock
                .Setup(repo => repo.FindByIdAsync(command.Id, It.IsAny<FindOption>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(sample);
            var dbTransactionMock = new Mock<IDbTransaction>();
            fontIconRepositoryMock.Setup(repo => repo.BeginTransactionAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(dbTransactionMock.Object);
            fontIconRepositoryMock.Setup(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception());

            await Assert.ThrowsAsync<Exception>(() => handler.Handle(command, CancellationToken.None));
            fontIconRepositoryMock.Verify(repo => repo.Update(It.IsAny<Entities.FontIcon>()), Times.Once);
            fontIconRepositoryMock.Verify(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
