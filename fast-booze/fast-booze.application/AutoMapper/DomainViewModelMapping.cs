using AutoMapper;
using fast_booze.application.ViewModel;
using fast_booze.Entities;

namespace fast_booze.application.AutoMapper
{
    public sealed class DomainViewModelMapping : Profile
    {
        public DomainViewModelMapping() 
        {
            CreateMap<Beverage, BeverageViewModel>();
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<ItemOrder, ItemOrderViewModel>();
            CreateMap<LiquorStore, LiquorStoreViewModel>();
            CreateMap<Order, OrderViewModel>()
                .ForMember(_ => _.Items, opt=> opt
                .MapFrom(src => src.Items));
            CreateMap<Stock, StockViewModel>()
                .ForMember(_ => _.Beverages, opt => opt
            .MapFrom(src=> src.Beverages));
        }
    }
}