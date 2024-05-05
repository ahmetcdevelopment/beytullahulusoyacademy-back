using NArchitecture.Core.Application.Responses;
using Domain.Enums;
using Domain.Enums;

namespace Application.Features.Recourses.Commands.Create;

public class CreatedRecourseResponse : IResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public float SizeM { get; set; }
    public float WeightKg { get; set; }
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public RecourseStatus RecourseStatus { get; set; }
}