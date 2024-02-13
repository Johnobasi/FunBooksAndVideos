using AutoMapper;
using FunBooksAndVideos.Domain.Dtos;
using FunBooksAndVideos.Domain.Entities;
using FunBooksAndVideos.Domain.Models;

namespace FunBooksAndVideos.Domain.Mapping
{
    public  class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PurchaseOrderRequetDto, PurchaseOrder>().ReverseMap();
            CreateMap<ItemLine, ItemLineDto>().ReverseMap();
            CreateMap<Entities.Customer, UpdateCustomerDto>().ReverseMap();
        }
    }
}
