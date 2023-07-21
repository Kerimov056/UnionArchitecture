using UnionArchitecture.Aplication.DTOs.Catagory;

namespace UnionArchitecture.Aplication.DTOs.Flowers;

public record FlowerGetDTO(string name,
                           string image,
                           decimal price,
                           CatagoryGetDTO catagory
                           );
