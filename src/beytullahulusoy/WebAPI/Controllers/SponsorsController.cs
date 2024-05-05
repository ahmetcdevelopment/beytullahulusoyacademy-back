using Application.Features.Sponsors.Commands.Create;
using Application.Features.Sponsors.Commands.Delete;
using Application.Features.Sponsors.Commands.Update;
using Application.Features.Sponsors.Queries.GetById;
using Application.Features.Sponsors.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SponsorsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSponsorCommand createSponsorCommand)
    {
        CreatedSponsorResponse response = await Mediator.Send(createSponsorCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSponsorCommand updateSponsorCommand)
    {
        UpdatedSponsorResponse response = await Mediator.Send(updateSponsorCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedSponsorResponse response = await Mediator.Send(new DeleteSponsorCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdSponsorResponse response = await Mediator.Send(new GetByIdSponsorQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSponsorQuery getListSponsorQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListSponsorListItemDto> response = await Mediator.Send(getListSponsorQuery);
        return Ok(response);
    }
}