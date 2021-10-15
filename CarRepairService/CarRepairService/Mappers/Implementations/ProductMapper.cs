using CarRepairService.Mappers.Interfaces;
using CarRepairService.Models;
using CarRepairService.Models.DTO;

namespace CarRepairService.Mappers.Implementations
{
    public class ProductMapper : IMapper<Product, ProductDTO>
    {
        public void Map(Product toProduct, ProductDTO fromProduct)
        {
            toProduct.Name = fromProduct.IsFieldPresent(nameof(fromProduct.Name)) ? fromProduct.Name : toProduct.Name;
            toProduct.Price = fromProduct.IsFieldPresent(nameof(fromProduct.Price)) ? fromProduct.Price : toProduct.Price;
        }
    }
}
