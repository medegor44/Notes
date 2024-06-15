
using System.Collections.Concurrent;

namespace Notes.Persistence;

public class InMemoryNotesRepository : INotesRepository
{
    private readonly ConcurrentDictionary<Guid, NoteDto> _store = new();

    public Task<Guid> CreateAsync(NoteDto note, CancellationToken cancellationToken)
    {
        var id = Guid.NewGuid();
        _store.TryAdd(id, note with { Id = id });

        return Task.FromResult(id);
    }

    public Task<NoteDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        if (_store.TryGetValue(id, out var note))
            return Task.FromResult<NoteDto?>(note);
        return Task.FromResult<NoteDto?>(null);
    }
}
