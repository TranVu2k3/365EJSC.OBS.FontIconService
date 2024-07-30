using MediatR;
using obsCommon.configFontIcon.queryContract.DependencyInjection.Options;
using obsCommon.configFontIcon.queryContract.Shared;
using obsCommon.configFontIcon.queryDomain.Abstractions.Repositories;
using obsCommon.configFontIcon.queryDomain.Entities;

namespace UserCases
{
    public class GetFontIconByIdQuery : IRequest<Result<FontIcon>>
    {
        public string Id { get; set; }
    }

    public class GetFontIconByIdQueryHandler : IRequestHandler<GetFontIconByIdQuery, Result<FontIcon>>
    {
        public readonly IFontIconRepository fontIconRepository;
        public GetFontIconByIdQueryHandler (IFontIconRepository fontIconRepository)
        {
            this.fontIconRepository = fontIconRepository;
        }
        public async Task<Result<FontIcon>> Handle(GetFontIconByIdQuery request, CancellationToken cancellationToken)
        {
            var findOption = new FindOption
            {
                AllowNullReturn = false,
                IsTracking = false,
            };
            var fontIcon = await fontIconRepository.FindByIdAsync(request.Id, findOption, cancellationToken);
            return fontIcon!;
        }
    }


}
