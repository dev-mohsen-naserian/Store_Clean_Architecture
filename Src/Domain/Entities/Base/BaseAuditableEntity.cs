using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base;

public class BaseAuditableEntity:BaseEntity
{
    public DateTime Created { get; set; } = DateTime.Now;
    public Nullable<int> CreatedBy { get; set; }
    public Nullable<DateTime> LastModified { get; set; }
    public Nullable<int> LastModifiedBy { get; set; }
}
