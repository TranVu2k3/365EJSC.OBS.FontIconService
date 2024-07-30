using MediatR;
using obsCommon.configFontIcon.queryContract.Shared;
using obsCommon.configFontIcon.queryDomain.Abstractions.Repositories;
using obsCommon.configFontIcon.queryDomain.Entities;

namespace UserCases
{
    public class GetAllFontIconQuery : IRequest<Result<List<FontIcon>>>
    {
    }

    public class GetAllFontIconQueryHandler : IRequestHandler<GetAllFontIconQuery, Result<List<FontIcon>>>
    {
        public readonly IFontIconRepository fontIconRepository;
        public GetAllFontIconQueryHandler(IFontIconRepository fontIconRepository)
        {
            this.fontIconRepository = fontIconRepository;
        }
        public async Task<Result<List<FontIcon>>> Handle(GetAllFontIconQuery request, CancellationToken cancellationToken)
        {
            var fontIcons = fontIconRepository.FindAll().ToList();
            return await Task.FromResult(fontIcons);
        }
    }
}
