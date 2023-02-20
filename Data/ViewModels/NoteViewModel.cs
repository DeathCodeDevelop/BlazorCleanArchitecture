namespace Data.ViewModels;

public class NoteViewModel
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public string Details { get; set; }
	public DateTime CreationDate { get; set; }
	public DateTime? EditDate { get; set; }
}
