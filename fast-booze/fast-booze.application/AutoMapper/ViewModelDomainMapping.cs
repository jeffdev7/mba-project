using AutoMapper;
using fast_booze.application.ViewModel;
using fast_booze.Entities;

namespace fast_booze.application.AutoMapper
{
    public sealed class ViewModelDomainMapping : Profile
    {
        public ViewModelDomainMapping() 
        {
            CreateMap<BeverageViewModel, Beverage>();
            CreateMap<CustomerViewModel, Customer>();
            CreateMap<CustomerViewModel, Customer>();
            CreateMap<LiquorStoreViewModel, LiquorStore>();
            CreateMap<OrderViewModel, Order>()
                .ForMember(_ => _.Items, opt=> opt
                .MapFrom(src => src.Items));
            CreateMap<StockViewModel, Stock>()
                .ForMember(_ => _.Beverages, opt => opt
            .MapFrom(src=> src.Beverages));
        }
    }
}