using Microsoft.AspNetCore.Mvc;
using Notes.Persistence;

namespace WebApi;

[ApiController]
[Route("[controller]")]
public class NotesController : ControllerBase
{
    private readonly INotesRepository _repository;

    public NotesController(INotesRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(Guid))]
    public async Task<IResult> CreateNote([FromBody] NoteDto note, CancellationToken cancellationToken)
    {
        var id = await _repository.CreateAsync(
            new(Guid.Empty, note.Header, note.Body, note.Author, DateTimeOffset.UtcNow, note.Tags), 
            cancellationToken);

        return Results.Ok(id);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(NoteDto))]
    public async Task<IResult> GetNote([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var note = await _repository.GetByIdAsync(id, cancellationToken);
        if (note is null)
            return Results.NotFound();

        return Results.Ok(new NoteDto
        {
            Author = note.Author,
            Body = note.Body,
            Header = note.Header,
            Id = note.Id,
            Tags = note.Tags,
            Timestamp = note.Timestamp
        });
    }
}
