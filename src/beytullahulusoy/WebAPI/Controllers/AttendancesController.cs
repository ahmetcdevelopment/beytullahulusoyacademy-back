using Application.Features.Attendances.Commands.Create;
using Application.Features.Attendances.Commands.Delete;
using Application.Features.Attendances.Commands.Update;
using Application.Features.Attendances.Queries.GetById;
using Application.Features.Attendances.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AttendancesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAttendanceCommand createAttendanceCommand)
    {
        CreatedAttendanceResponse response = await Mediator.Send(createAttendanceCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAttendanceCommand updateAttendanceCommand)
    {
        UpdatedAttendanceResponse response = await Mediator.Send(updateAttendanceCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedAttendanceResponse response = await Mediator.Send(new DeleteAttendanceCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdAttendanceResponse response = await Mediator.Send(new GetByIdAttendanceQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAttendanceQuery getListAttendanceQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAttendanceListItemDto> response = await Mediator.Send(getListAttendanceQuery);
        return Ok(response);
    }
}