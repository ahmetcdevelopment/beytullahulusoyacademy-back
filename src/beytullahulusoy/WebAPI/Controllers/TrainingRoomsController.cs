using Application.Features.TrainingRooms.Commands.Create;
using Application.Features.TrainingRooms.Commands.Delete;
using Application.Features.TrainingRooms.Commands.Update;
using Application.Features.TrainingRooms.Queries.GetById;
using Application.Features.TrainingRooms.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TrainingRoomsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTrainingRoomCommand createTrainingRoomCommand)
    {
        CreatedTrainingRoomResponse response = await Mediator.Send(createTrainingRoomCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTrainingRoomCommand updateTrainingRoomCommand)
    {
        UpdatedTrainingRoomResponse response = await Mediator.Send(updateTrainingRoomCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedTrainingRoomResponse response = await Mediator.Send(new DeleteTrainingRoomCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdTrainingRoomResponse response = await Mediator.Send(new GetByIdTrainingRoomQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTrainingRoomQuery getListTrainingRoomQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListTrainingRoomListItemDto> response = await Mediator.Send(getListTrainingRoomQuery);
        return Ok(response);
    }
}