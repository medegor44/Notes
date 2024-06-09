using Microsoft.AspNetCore.Mvc;

namespace WebApi;

[ApiController]
[Route("[controller]")]
public class NotesController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(Guid))]
    public Task<IResult> CreateNote([FromBody] NoteDto note)
    {
        return Task.FromResult(Results.Ok(Guid.NewGuid()));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(NoteDto))]
    public Task<IResult> GetNote([FromRoute] Guid id)
    {
        return Task.FromResult(Results.Ok(new NoteDto()));
    }
}
