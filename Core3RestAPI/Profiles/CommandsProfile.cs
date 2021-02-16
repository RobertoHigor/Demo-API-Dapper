using AutoMapper;
using Core3RestAPI.Dtos;
using Core3RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Classe para mapear uma entidade a um DTO
namespace Core3RestAPI.Profiles
{
    public class CommandsProfile : Profile
    {      
        public CommandsProfile()
        {
            // source -> target
            CreateMap<Command, CommandReadDTO>();
            CreateMap<CommandCreateDTO, Command>();
            CreateMap<CommandUpdateDTO, Command>();
        }

        public override string ProfileName => "DomainToViewModelMappings";

        // How it was done in 4.x - as of 5.0 this is obsolete:
        // public class OrganizationProfile : Profile
        // {
        //     protected override void Configure()
        //     {
        //         CreateMap<Foo, FooDto>();
        //     }
        // }
    }
}
