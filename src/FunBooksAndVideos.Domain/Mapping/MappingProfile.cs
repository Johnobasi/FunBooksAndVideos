using AutoMapper;
using FunBooksAndVideos.Domain.Dtos;

namespace FunBooksAndVideos.Domain.Mapping
{
    public  class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PurchaseOrderRequetDto, Entities.PurchaseOrder>().ReverseMap();
            CreateMap<Entities.ItemLine, ItemLineDto>().ReverseMap();
            CreateMap<Entities.Customer, UpdateCustomerDto>().ReverseMap();
        }
    }
}
