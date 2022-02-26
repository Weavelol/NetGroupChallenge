using AutoMapper;
using Core.Models;
using DTOModels;

namespace NetGroupChallengeBlazor.Server.AutoMapperProfiles {
    public class AutoMapperProfile : Profile {
        public AutoMapperProfile() {
            CreateMap<StorageCreateDTO, Storage>();
            CreateMap<Storage, StorageDTO>();

            CreateMap<ImageDTO, ItemImage>().ReverseMap();

            CreateMap<ItemCreateDTO, Item>();
            CreateMap<Item, ItemDTO>();

            CreateMap<ApplicationUser, ApplicationUserDTO>();
            CreateMap<Statistics, StatisticsDTO>();
        }
    }
}
