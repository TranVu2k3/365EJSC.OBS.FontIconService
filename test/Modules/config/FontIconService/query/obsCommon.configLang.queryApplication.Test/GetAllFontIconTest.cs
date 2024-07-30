using Moq;

namespace obsCommon.configFontIcon.queryApplication.Test
{
    public class GetAllFontIconTest
    {
        private readonly Mock<IFontIconRepository> fontIconRepositoryMock;
        private readonly GetAllFontIconQueryHandler handler;

        public GetAllFontIconTest()
        {
            fontIconRepositoryMock = new Mock<IFontIconRepository>();
            handler = new GetAllFontIconQueryHandler(fontIconRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnAllSamples()
        {
            var samples = new List<Entities.FontIcon>
            {
                new() { Id = "1",  Description = "Description 1", Type ="Type 1", Version = "1", IsActived = true},
                new() { Id = "2",  Description = "Description 2", Type ="Type 2", Version = "2", IsActived = true }
            };
            fontIconRepositoryMock
                .Setup(repo => repo.FindAll(false, null, It.IsAny<Expression<Func<Entities.FontIcon, object>>[]>()))
                .Returns(samples.AsQueryable());

            var result = await handler.Handle(new GetAllFontIconQuery(), CancellationToken.None);

            Assert.Equal(StatusCode.Ok, result.StatusCode);
            Assert.Equal(samples, result.Data);
        }

        [Fact]
        public async Task Handle_ShouldReturnEmptyList_WhenNoSamplesFound()
        {
            fontIconRepositoryMock
                .Setup(repo => repo.FindAll(false, null, It.IsAny<Expression<Func<Entities.FontIcon, object>>[]>()))
                .Returns(new List<Entities.FontIcon>().AsQueryable());

            var result = await handler.Handle(new GetAllFontIconQuery(), CancellationToken.None);

            Assert.Equal(StatusCode.Ok, result.StatusCode);
            Assert.Empty(result.Data);
        }
    }
}