﻿using Application.Notes.Commands.CreateNote;
using Application.Notes.Commands.UpdateNote;
using AutoMapper;

namespace Api.Models.Mappings
{
	public class NoteProfile : Profile
	{
		public NoteProfile()
		{
			CreateMap<CreateNoteViewModel, CreateNoteCommand>()
				.ForMember(command => command.Title,
					opt => opt.MapFrom(vm => vm.Title))
				.ForMember(command => command.Details,
					opt => opt.MapFrom(vm => vm.Details));

			CreateMap<UpdateNoteViewModel, UpdateNoteCommand>()
				.ForMember(command => command.Id,
					opt => opt.MapFrom(vm => vm.Id))
				.ForMember(command => command.Title,
					opt => opt.MapFrom(vm => vm.Title))
				.ForMember(command => command.Details,
					opt => opt.MapFrom(vm => vm.Details));
		}
	}
}
