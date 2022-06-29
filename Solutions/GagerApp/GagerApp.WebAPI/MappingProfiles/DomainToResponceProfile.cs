using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GagerApp.Model.DTO;
using GagerApp.Model.Entities;
using GagerApp.WebAPI.Models;

namespace GagerApp.WebAPI.MappingProfiles
{
    public class DomainToResponceProfile : Profile
    {
        public DomainToResponceProfile()
        {
            CreateMap<ZayavkaZamer, OrderDTO>()
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.IdZayavka))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => new DateTime(src.TimeStartZamer.Ticks)))
                .ForMember(dest => dest.FinishTime, opt => opt.MapFrom(src => new DateTime(src.TimeStopZamer.Ticks)))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(
                    (src, dest) =>
                    {
                        return (OrderStatus)src.IdStatusZamer;
                    }
                )
                )
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Id.Burg + ", " + src.Id.Ulica + ", " + src.Id.NumberDom + ", " + src.Id.NumberKvartira))
                .ForMember(dest => dest.ChangeNotificationSuspended, opt => opt.Ignore());

            CreateMap<UserProfile, UserDTO>()
               .ForMember(dto => dto.Name, opt => opt.MapFrom(profile => profile.IdProfileWorkerNavigation.Name))
               .ForMember(dto => dto.SurName, opt => opt.MapFrom(profile => profile.IdProfileWorkerNavigation.Surname))
               .ForMember(dto => dto.Paternum, opt => opt.MapFrom(profile => profile.IdProfileWorkerNavigation.Paternum));
            
            CreateMap<CustomerDirectory, ClientDTO>()
                .ForMember(dto => dto.NameClient, opt => opt.MapFrom(profile => profile.NameClient))
                .ForMember(dto => dto.SurnameClient, opt => opt.MapFrom(profile => profile.SurnameClient))
                .ForMember(dto => dto.PaternumClient, opt => opt.MapFrom(profile => profile.PaternumClient));

            CreateMap<CatalogAdress, AdressDTO>()
                .ForMember(dest => dest.IdAdress, opt => opt.MapFrom(src => src.IdAdress))
                .ForMember(dest => dest.Burg, opt => opt.MapFrom(src => src.Burg))
                .ForMember(dest => dest.Ulica, opt => opt.MapFrom(src => src.Ulica))
                .ForMember(dest => dest.NumberDom, opt => opt.MapFrom(src => src.NumberDom))
                .ForMember(dest => dest.NumberKvartira, opt => opt.MapFrom(src => src.NumberKvartira))
                ;

            CreateMap<CatalogVidConstruct, VidConstructDTO>()
                .ForMember(dto => dto.IdConstruct, opt => opt.MapFrom(src => src.IdConstruct))
                .ForMember(dto => dto.NameConstruct, opt => opt.MapFrom(src => src.NameConstruct));

            CreateMap<ZayavkaZamer, FullOrderDTO>()
               .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.IdZayavka))
               .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.DateZamer))
               .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => new DateTime(src.TimeStartZamer.Ticks)))
               .ForMember(dest => dest.FinishTime, opt => opt.MapFrom(src => new DateTime(src.TimeStopZamer.Ticks)))
               .ForMember(dest => dest.FinishTime, opt => opt.Ignore())
               .ForMember(dest => dest.Status, opt => opt.MapFrom(
                   (src, dest) =>
                   {
                       return (OrderStatus)src.IdStatusZamer;
                   }
               )
               )
               .ForMember(dest => dest.Adress, opt => opt.MapFrom(src => src.Id))
               .ForMember(dto => dto.Client, opt => opt.MapFrom(profile => profile.IdPartnerNavigation.IdCustomerDirectoryNavigation))
               .ForMember(dto => dto.Notes, opt => opt.MapFrom(profile => profile.Notice))
               .ForMember(dto => dto.TelefonNumber, opt => opt.MapFrom(profile => profile.IdPartnerNavigation.CatalogTelNumber.Select(y=> y.NumberTel).ToList()))
               .ForMember(dest => dest.Rooms, opt => opt.MapFrom(profile => profile.Id.CatalogRoom));

            CreateMap<CatalogRoom, RoomDTO>()
               .ForMember(dto => dto.IdRoom, opt => opt.MapFrom(src => src.IdRoom))
               .ForMember(dto => dto.NameRoom, opt => opt.MapFrom(src => src.NameRoom));

            CreateMap<CatalogRoom, FullRoomDTO>()
              .ForMember(dto => dto.IdRoom, opt => opt.MapFrom(src => src.IdRoom))
              .ForMember(dto => dto.NameRoom, opt => opt.MapFrom(src => src.NameRoom))
              .ForMember(dto => dto.Blueprint, opt => opt.MapFrom(src => src.Blueprint))
              .ForMember(dto => dto.VidConstruct, opt => opt.MapFrom(src => src.IdConstructNavigation))
              .ForMember(dto => dto.DopUsluga, opt => opt.MapFrom(src => src.PositionSmeta));
              
             CreateMap<PositionSmeta, DopUslugaDTO>()
              .ForMember(dto => dto.ID, opt => opt.MapFrom(src => src.IdPositionSmeta))
              .ForMember(dto => dto.Name, opt => opt.MapFrom(src => src.IdCatalogNavigation.NameMatUsl))
              .ForMember(dto => dto.Col, opt => opt.MapFrom(src => src.Col))
              .ForMember(dto => dto.Type, opt => opt.MapFrom(src => src.IdCatalogNavigation.IdTypeMatUslNavigation.Name))
              .ForMember(dto => dto.Unit, opt => opt.MapFrom(src => src.IdCatalogNavigation.IdUnitsNavigation.Name));
        }
    }
}
