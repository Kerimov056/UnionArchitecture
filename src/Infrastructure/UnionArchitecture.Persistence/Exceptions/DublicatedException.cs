using System.Net;

namespace UnionArchitecture.Persistence.Exceptions;

public sealed class DublicatedException : Exception, IBaseException
{
    public int StatusCode { get; set; }
    public string CustomMessage { get; set; }

    public DublicatedException(string message) : base(message)
    {
        StatusCode = (int)HttpStatusCode.Conflict;
        CustomMessage = message;
    }
}










//public async Task CreateAsync(FlowerCreateDTO createDTO)
//{
//    Flowers? flowers = await _flowersReadRepository
//           .GetByIdAsyncExpression(f => f.Name.ToLower().Equals(createDTO.name));
//    if (flowers is not null) throw new DublicatedException("Dubilcated Catagory Name!");

//    Flowers newFlower = _mapper.Map<Flowers>(createDTO);
//    newFlower.ImagePath = createDTO.image;

//    await _flowersWriteRepository.AddAsync(newFlower);
//    await _flowersWriteRepository.SaveChangeAsync();
//    //692e11b0-216f-4722-3c8d-08db87e58ba6
//    FlowersDetails FDetailEntity = new()
//    {
//        Description = createDTO.FlowerDetailsCreateDTOs.Description,
//        SKU = createDTO.FlowerDetailsCreateDTOs.SKU,
//        Weight = createDTO.FlowerDetailsCreateDTOs.Weight,
//        PowerFlowers = createDTO.FlowerDetailsCreateDTOs.PowerFlowers,
//        FlowersId = newFlower.Id
//    };
//    await _flowersDetailsWriteRepository.AddAsync(FDetailEntity);

//    //Yaziriq ama Repository'e cevireceyik
//    FlowersImage flowersImage = new()
//    {
//        ImagePath = createDTO.FlowersImageDTO.ImagePath,
//        FlowersId = newFlower.Id
//    };
//    await _flowersImageWriteRepository.AddAsync(flowersImage);

//    foreach (var item in _appDbContext.Tags)
//    {
//        var flower_tag = new Flower_Tag
//        {
//            TagsId = item.Id,
//            FlowersId = newFlower.Id
//        };
//        //tag'e add elemek lazimdi burda
//        await _appDbContext.AddAsync(flower_tag);
//    }

//    await _flowersWriteRepository.SaveChangeAsync();
//}
