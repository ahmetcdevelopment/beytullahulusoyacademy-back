using Application.Features.Trainings.Commands.Create;
using Application.Features.Trainings.Commands.Delete;
using Application.Features.Trainings.Commands.Update;
using Application.Features.Trainings.Queries.GetById;
using Application.Features.Trainings.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TrainingsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTrainingCommand createTrainingCommand)
    {
        CreatedTrainingResponse response = await Mediator.Send(createTrainingCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTrainingCommand updateTrainingCommand)
    {
        UpdatedTrainingResponse response = await Mediator.Send(updateTrainingCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedTrainingResponse response = await Mediator.Send(new DeleteTrainingCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdTrainingResponse response = await Mediator.Send(new GetByIdTrainingQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTrainingQuery getListTrainingQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListTrainingListItemDto> response = await Mediator.Send(getListTrainingQuery);
        return Ok(response);
    }
}