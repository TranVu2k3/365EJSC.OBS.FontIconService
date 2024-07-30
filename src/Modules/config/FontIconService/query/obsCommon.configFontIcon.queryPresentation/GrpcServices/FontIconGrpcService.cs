using Grpc.Core;
using MediatR;
using obsCommon.configFontIcon.queryContract.Exceptions;
using UserCases;
using FontIconGrpc;

namespace obsCommon.configFontIcon.queryPresentation.GrpcServices
{
    public class FontIconGrpcService : FontIcon.FontIconBase
    {
        private readonly IMediator mediator;

        public FontIconGrpcService(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public override async Task<GetFontIconByIdResponse> GetFontIconById(GetFontIconByIdRequest request, ServerCallContext context)
        {
            var id = request.Id;
            var query = new GetFontIconByIdQuery
            {
                Id = id
            };
            try
            {
                var result = await mediator.Send(query);
                var value = result.Data;
                var data = new GetFontIconByIdResponse
                {
                    Description = value.Description ?? string.Empty,
                    Type = value.Type ?? string.Empty,
                    Id = value.Id,
                    Version = value.Version ?? string.Empty,
                    IsActived = value.IsActived
                };
                return data;
            }
            catch (NotFoundException e)
            {
                throw new RpcException(new Status(StatusCode.NotFound, e.Message));
            }
            catch (Exception)
            {
                throw new RpcException(new Status(StatusCode.Internal, "Internal Server Error"));
            }
        }

        public override async Task<GetAllFontIconResponse> GetAllFontIcon(GetAllFontIconRequest request, ServerCallContext context)
        {
            var query = new GetAllFontIconQuery();
            try
            {
                var result = await mediator.Send(query);
                var data = new List<GetFontIconByIdResponse>();
                foreach (var fontIcon in result.Data)
                    data.Add(new GetFontIconByIdResponse
                    {
                        Description = fontIcon.Description ?? string.Empty,
                        Type = fontIcon.Type ?? string.Empty,
                        Id = fontIcon.Id,
                        Version = fontIcon.Version ?? string.Empty,
                        IsActived = fontIcon.IsActived
                    });
                var list = new GetAllFontIconResponse();
                list.FontIcon.Add(data);
                return list;
            }
            catch (Exception)
            {
                throw new RpcException(new Status(StatusCode.Internal, "Internal Server Error"));
            }
        }
    }
}
