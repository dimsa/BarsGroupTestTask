﻿using System;

namespace DataAccess.Entities
{
    public class Product : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Guid Code { get; set; }
    }

    public class Provisioner : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }

    public class Supply : IEntity
    {
        public virtual int Id { get; set; }
        public virtual int ProductId { get; set; }
        public virtual int ProvisionerId { get; set; }
        public virtual DateTime TimeStamp { get; set; }
    }
}
