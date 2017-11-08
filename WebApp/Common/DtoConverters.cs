using DataAccess.Entities;

namespace WebApp.Common
{
    public class DtoConverter
    {
        public static Product ProductDtoToModel(ProductDto dto)
        {
            return new Product()
            {
                Id = dto.Id,
                Name = dto.Name,
                Code = dto.Code
            };
        }

        public static ProductDto ProductModelToDto(Product model)
        {
            return new ProductDto()
            {
                Id = model.Id,
                Name = model.Name,
                Code = model.Code
            };
        }

        public static Provisioner ProvisionerDtoToModel(ProvisionerDto dto)
        {
            return new Provisioner()
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }

        public static ProvisionerDto ProvisionerModelToDto(Provisioner model)
        {
            return new ProvisionerDto()
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public static SupplyDto SupplyModelToDto(Supply supply)
        {
            return new SupplyDto()
            {
                Id = supply.Id,
                Product = new ProductDto()
                {
                    Id = supply.Product.Id,
                    Name = supply.Product.Name,
                    Code = supply.Product.Code,
                },
                Provisioner = new ProvisionerDto()
                {
                    Id = supply.Provisioner.Id,
                    Name = supply.Provisioner.Name,
                },
                TimeStamp = supply.TimeStamp
            };
        }

        public static Supply SupplyDtoToModel(SupplyDto dto)
        {
            return new Supply()
            {
                Id = dto.Id,
                Product = ProductDtoToModel(dto.Product),
                Provisioner = ProvisionerDtoToModel(dto.Provisioner),
                TimeStamp = dto.TimeStamp
            };
        }
    }
}