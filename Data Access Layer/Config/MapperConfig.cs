using AutoMapper;
using DataAccess.DTO;
using DataAccess.Models;

namespace DataAccess.Config
{
    public class MapperConfig
    {
        public static Mapper InititalizeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductRequest>();
                cfg.CreateMap<ProductRequest, Product>().ForMember(dest => dest.ProductId, opt => opt.Ignore());
                cfg.CreateMap<Category, CategoryRequest>();
                cfg.CreateMap<CategoryRequest, Category>().ForMember(dest => dest.CategoryId, opt => opt.Ignore());
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
