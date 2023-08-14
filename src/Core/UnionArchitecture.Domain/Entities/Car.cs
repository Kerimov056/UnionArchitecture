using UnionArchitecture.Domain.Entities.Common;

namespace UnionArchitecture.Domain.Entities;

public class Car:BaseEntity
{
    public string Marka { get; set; }
    public string Model { get; set; }
}
