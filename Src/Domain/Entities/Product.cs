using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Product: BaseAuditableEntity,ICommands
{
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string PictureUrl { get; set; } = string.Empty;

    // Foreign Keys
    public int ProductTypeId { get; set; }
    public int ProductBrandId { get; set; }

    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public bool IsDelete { get; set; } = false;
    public string Summery { get; set; } = string.Empty;

    // Navigation Properties
    public ProductType ProductType { get; set; }
    public ProductBrand ProductBrand { get; set; }
}
