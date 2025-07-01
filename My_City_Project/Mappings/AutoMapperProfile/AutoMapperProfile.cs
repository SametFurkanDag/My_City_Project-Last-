using AutoMapper;
using My_City_Project.Dtos;
using My_City_Project.Dtos.CartDtos;
using My_City_Project.Dtos.CartItemDtos;
using My_City_Project.Dtos.OrderDtos;
using My_City_Project.Dtos.OrderItemDtos;
using My_City_Project.Dtos.PlacesDtos;
using My_City_Project.Dtos.ProductDtos;
using My_City_Project.Dtos.ReportDtos;
using My_City_Project.Dtos.ResellerDtos;
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
            CreateMap<Product, ResultProductDto>()
            .ForMember(dest => dest.VendorName, opt => opt.MapFrom(src => src.vendor != null ? src.vendor.VendorName : null));
            CreateMap<GetByIdProductDto, Product>().ReverseMap();
            
            CreateMap<CreateCartItemDto, CartItem>().ReverseMap();
            CreateMap<UpdateCartItemDto, CartItem>().ReverseMap(); 
            CreateMap<CartItem, ResultCartItemDto>()
    .ForMember(dest => dest.CartItemId, opt => opt.MapFrom(src => src.Id));

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

            CreateMap<CreateOrderDto, Order>().ReverseMap();
            CreateMap<UpdateOrderDto, Order>().ReverseMap();
            CreateMap<ResultOrderDto, Order>().ReverseMap();
            CreateMap<GetByIdOrderDto, Order>().ReverseMap();

            CreateMap<CreateOrderItemDto, OrderItem>().ReverseMap();
            CreateMap<UpdateOrderItemDto, OrderItem>().ReverseMap();
            CreateMap<ResultOrderItemDto, OrderItem>().ReverseMap();
            CreateMap<GetByIdOrderItemDto, OrderItem>().ReverseMap();

            CreateMap<CreateResellerDto, Reseller>().ReverseMap();
            CreateMap<UpdateResellerDto, Reseller>().ReverseMap();
            CreateMap<ResultResellerDto, Reseller>().ReverseMap();
            CreateMap<GetByIdResellerDto, Reseller>().ReverseMap();
            
            CreateMap<CreateReportDto, Report>().ReverseMap();
            CreateMap<UpdateReportDto, Report>().ReverseMap();
            CreateMap<ResultReportDto, Report>().ReverseMap();
            CreateMap<GetByIdReportDto, Report>().ReverseMap();
        }
    }
}
