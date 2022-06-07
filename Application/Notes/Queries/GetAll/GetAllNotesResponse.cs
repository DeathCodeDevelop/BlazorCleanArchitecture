using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Notes.Queries.GetAll;

public class GetAllNotesResponse
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public string Details { get; set; }
	public DateTime CreationDate { get; set; }
	public DateTime? EditDate { get; set; }
}

