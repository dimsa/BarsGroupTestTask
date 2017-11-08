using System;

/*
 Не хотелось городить параллельную иерархию Dto'шек, но из-за того, что нужно SupplyDto, 
 не хочется оставлять остальные сущности без Dto и лучше сделать всё в одном стиле.
 Но в целом это было бы полезно для проекта, если например Модель бы стала изменяться и 
 было бы необходимо сохранить совместимость с потребителями данных
*/

namespace WebApp.Common
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid Code { get; set; }
    }

    public class ProvisionerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class SupplyDto
        {
            public int Id { get; set; }
            public ProductDto Product { get; set; }
            public ProvisionerDto Provisioner { get; set; }
            public DateTime TimeStamp { get; set; }
        }
}