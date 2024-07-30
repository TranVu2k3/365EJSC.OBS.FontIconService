using MediatR;
using obsCommon.configFontIcon.commandContract.Shared;
using obsCommon.configFontIcon.commandDomain.Abstractions.Repositories;
using obsCommon.configFontIcon.commandDomain.Entities;

namespace UserCases
{
    public record class CreateFontIconCommand : IRequest<Result<FontIcon>>
    {
        public string Id { get; set; }
        public string Description { get; set; }

        public string Type { get; set; }

        public string? Version { get; set; }

        public bool IsActived { get; set; }
    }

    public class CreateFontIconCommandHandler : IRequestHandler<CreateFontIconCommand, Result<FontIcon>>
    {
        private readonly IFontIconRepository fontIconRepository;

        public CreateFontIconCommandHandler(IFontIconRepository fontIconRepository)
        {
            this.fontIconRepository = fontIconRepository;
        }
        public async Task<Result<FontIcon>> Handle(CreateFontIconCommand request, CancellationToken cancellationToken)
        {
            var fontIcon = new FontIcon
            {
                Id = request.Id!,
                Description = request.Description,
                Type = request.Type,
                Version = request.Version,
                IsActived = request.IsActived
            };

            using var transaction = await fontIconRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                fontIconRepository.Add(fontIcon);
                await fontIconRepository.SaveChangesAsync(cancellationToken);
                transaction.Commit();
                return fontIcon;
            }
            catch (Exception ex) 
            { 
                transaction.Rollback();
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
        }
    }
}
