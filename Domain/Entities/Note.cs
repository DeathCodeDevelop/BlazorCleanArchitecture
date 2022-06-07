using Domain.Contracts;

namespace Domain.Entities;

public class Note : Entity
{
	public Guid UserId { get; set; }
	public string Title { get; set; }
	public string Details { get; set; }
	public DateTime CreationDate { get; set; }
	public DateTime? EditDate { get; set; }
}


