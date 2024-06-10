namespace WebApi;

public class NoteDto
{
    public string Header { get; set; }
    public string Body { get; set; }
    public DateTimeOffset Timestamp { get; set; }
    public List<string> Tags { get; set; }
    public string Author { get; set; }
    public Guid? Id { get; set; }
}
