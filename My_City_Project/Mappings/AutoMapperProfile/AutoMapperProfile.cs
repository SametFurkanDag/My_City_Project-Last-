using AutoMapper;
using My_City_Project.Dtos;
using My_City_Project.Dtos.CartDtos;
using My_City_Project.Dtos.CartItemDtos;
using My_City_Project.Dtos.PlacesDtos;
using My_City_Project.Dtos.ProductDtos;
using My_City_Project.Dtos.VendorDto;
using My_City_Project.Dtos.VendorDtos;
using My_City_Project.Model.Entities;


namespace My_City_Project.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateProductDto, Product>().ReverseMap();
            CreateMap<UpdateProductDto, Product>().ReverseMap();
            CreateMap<ResultProductDto, Product>().ReverseMap();
            CreateMap<GetByIdProductDto, Product>().ReverseMap();

            CreateMap<CreateCartItemDto, CartItem>().ReverseMap();
            CreateMap<UpdateCartItemDto, CartItem>().ReverseMap();
            CreateMap<ResultCartItemDto, CartItem>().ReverseMap();
            CreateMap<GetByIdCartItemDto, CartItem>().ReverseMap();

            CreateMap<CreatePlaceDto, Places>().ReverseMap();
            CreateMap<UpdatePlaceDto, Places>().ReverseMap();
            CreateMap<ResultPlaceDto, Places>().ReverseMap();
            CreateMap<GetByIdPlaceDto, Places>().ReverseMap();

            CreateMap<CreateCartDto, Cart>().ReverseMap();
            CreateMap<UpdateCartDto, Cart>().ReverseMap();
            CreateMap<ResultCartDto, Cart>().ReverseMap();
            CreateMap<GetByIdCartDto, Cart>().ReverseMap();
            
            CreateMap<CreateVendorDto, Vendor>().ReverseMap();
            CreateMap<UpdateVendorDto, Vendor>().ReverseMap();
            CreateMap<ResultVendorDto, Vendor>().ReverseMap();
            CreateMap<GetByIdVendorDto, Vendor>().ReverseMap();









        }
    }
}
