namespace Application.Notes.Queries.Models;

public class NoteDTO
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public string Details { get; set; }
	public DateTime CreationDate { get; set; }
	public DateTime? EditDate { get; set; }
}

