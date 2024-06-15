namespace Notes.Persistence;

public interface INotesRepository
{
    Task<NoteDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Guid> CreateAsync(NoteDto note, CancellationToken cancellationToken);
}
