namespace Notes.Persistence;

public record NoteDto(
    Guid Id, 
    string Header, 
    string Body, 
    string Author, 
    DateTimeOffset Timestamp, 
    List<string> Tags
);
