using MediatR;
using obsCommon.configFontIcon.commandContract.DependencyInjection.Options;
using obsCommon.configFontIcon.commandContract.Shared;
using obsCommon.configFontIcon.commandDomain.Abstractions.Repositories;

namespace UserCases
{
    public record class UpdateFontIconCommand : IRequest<Result>
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string? Version { get; set; }
        public bool IsActived { get; set; }
    }
    public class UpdateFontIconCommandHandler : IRequestHandler<UpdateFontIconCommand, Result>
    {
        public readonly IFontIconRepository fontIconRepository;
        public UpdateFontIconCommandHandler(IFontIconRepository fontIconRepository)
        {
            this.fontIconRepository = fontIconRepository;
        }
        public async Task<Result> Handle(UpdateFontIconCommand request, CancellationToken cancellationToken)
        {
            using var transaction = await fontIconRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                var findOption = new FindOption
                {
                    AllowNullReturn = false,
                    IsTracking = true,
                };
                var fontIcon = await fontIconRepository.FindByIdAsync(request.Id, findOption, cancellationToken);
                fontIcon!.Update(request.Description, request.Type, request.Version, request.IsActived);
                fontIconRepository.Update(fontIcon);
                await fontIconRepository.SaveChangesAsync(cancellationToken);
                transaction.Commit();
                return Result.Ok();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
