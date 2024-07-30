using Moq;

namespace obsCommon.configFontIcon.queryApplication.Test
{
    public class GetFontIconByIdTest
    {
        private readonly Mock<IFontIconRepository> fontIconRepositoryMock;
        private readonly GetFontIconByIdQueryHandler handler;

        public GetFontIconByIdTest()
        {
            fontIconRepositoryMock = new Mock<IFontIconRepository>();
            handler = new GetFontIconByIdQueryHandler(fontIconRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldThrowNotFoundException_WhenSampleNotFound()
        {
            fontIconRepositoryMock.Setup(repo =>
                    repo.FindByIdAsync(It.IsAny<int>(), It.IsAny<FindOption>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Entities.FontIcon)null);
            var query = new GetFontIconByIdQuery { Id = "1" };

            await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(query, CancellationToken.None));
        }
    }
}
