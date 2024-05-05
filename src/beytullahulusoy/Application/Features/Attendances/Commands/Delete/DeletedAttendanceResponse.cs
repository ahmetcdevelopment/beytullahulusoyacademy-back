using NArchitecture.Core.Application.Responses;

namespace Application.Features.Attendances.Commands.Delete;

public class DeletedAttendanceResponse : IResponse
{
    public int Id { get; set; }
}