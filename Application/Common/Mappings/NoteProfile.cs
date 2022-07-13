using Application.Notes.Queries.GetAll;
using Application.Notes.Queries.GetNoteDetails;
using Application.Notes.Queries.Models;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mappings
{
	public class NoteProfile : Profile
	{
		public NoteProfile()
		{
			CreateMap<Note, NoteDTO>()
                .ForMember(response => response.Id,
                    opt => opt.MapFrom(note => note.Id))
                .ForMember(response => response.Title,
                    opt => opt.MapFrom(note => note.Title))
                .ForMember(response => response.Details,
                    opt => opt.MapFrom(note => note.Details))
                .ForMember(response => response.CreationDate,
                    opt => opt.MapFrom(note => note.CreationDate))
                .ForMember(response => response.EditDate,
                    opt => opt.MapFrom(note => note.EditDate));

			CreateMap<Note, NoteDTO>()
				.ForMember(response => response.Id,
					opt => opt.MapFrom(note => note.Id))
				.ForMember(response => response.Title,
					opt => opt.MapFrom(note => note.Title))
				.ForMember(response => response.Details,
					opt => opt.MapFrom(note => note.Details))
				.ForMember(response => response.CreationDate,
					opt => opt.MapFrom(note => note.CreationDate))
				.ForMember(response => response.EditDate,
					opt => opt.MapFrom(note => note.EditDate));
		}
	}
}
