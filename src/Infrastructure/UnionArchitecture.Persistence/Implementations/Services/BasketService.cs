using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.Basket;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Domain.Entities.Identity;
using UnionArchitecture.Persistence.Contexts;

namespace UnionArchitecture.Persistence.Implementations.Services;

public class BasketService : IBasketService
{
    private readonly IBasketReadRepository _basketRead;
    private readonly IBasketWriteRepository _basketWrite;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContext;
    private readonly UserManager<AppUser> _usManager;


    public BasketService(IBasketReadRepository basketRead,
                         IBasketWriteRepository basketWrite,
                         IMapper mapper,
                         IHttpContextAccessor httpContext,
                         UserManager<AppUser> usManager)
    {
        _basketRead = basketRead;
        _basketWrite = basketWrite;
        _mapper = mapper;
        _httpContext = httpContext;
        _usManager = usManager;
    }

    public async Task AddBasketAsync(Guid Id)
    {

        var userId = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        userId = "16a5a4f9-f783-44f2-b7cb-ca381cba6d27";
        if (userId == null) throw new NullReferenceException();

        var basket = await _basketRead.Table
                          .Include(x => x.basketProducts)
                          .FirstOrDefaultAsync(m => m.AppUserId == userId);

        if (basket == null)
        {
            basket = new Basket
            {
                AppUserId = userId
            };

            await _basketWrite.AddAsync(basket);
            await _basketWrite.SaveChangeAsync();
        }

        var basketProduct = basket.basketProducts.FirstOrDefault(Rp => Rp.CarId == Id && Rp.BasketId == basket.Id);

        if (basketProduct != null)
        {
            basketProduct.Quantity++;
        }
        else
        {
            basketProduct = new BasketProduct
            {
                BasketId = basket.Id,
                CarId = Id,
                Quantity = 1
            };
            basket.basketProducts.Add(basketProduct);
        }
        await _basketWrite.SaveChangeAsync();
    }

    public async Task DeleteBasketAsync(Guid Id)
    {       //81cb43e2-98d0-4452-c831-08db9d0906b5
        var userId = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        userId = "16a5a4f9-f783-44f2-b7cb-ca381cba6d27";
        if (userId == null) throw new NullReferenceException();

        var basket = await _basketRead.Table
                         .Include(x => x.basketProducts)
                         .FirstOrDefaultAsync(m => m.AppUserId == userId);

        if (basket == null) throw new NullReferenceException();


        _basketWrite.Remove(basket);
        await _basketWrite.SaveChangeAsync();
    }

    public async Task DeleteBasketItemAsync(Guid id)
    {
        var userId = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        userId = "16a5a4f9-f783-44f2-b7cb-ca381cba6d27";
        if (userId == null) throw new NullReferenceException();

        var basket = await _basketRead.Table
                    .Include(x => x.basketProducts)
                    .FirstOrDefaultAsync(m => m.AppUserId == userId);
        if (basket == null) throw new NullReferenceException();

        var basketProduct = basket.basketProducts.FirstOrDefault(bp => bp.CarId == id && bp.BasketId == basket.Id);

        if (basketProduct == null) throw new NullReferenceException();

        if (basketProduct.Quantity > 1)
        {
            basketProduct.Quantity--;
        }
        else
        {
            _basketWrite.Remove(basket);
        }
        await _basketWrite.SaveChangeAsync();
    }

    public async Task<int> GetBasketCountAsync()
    {
        var userId = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        userId = "16a5a4f9-f783-44f2-b7cb-ca381cba6d27";
        if (userId == null) throw new UnauthorizedAccessException();

        var basket = await _basketRead.Table
                    .Include(m => m.basketProducts)
                    .ThenInclude(m => m.Car)
                    .FirstOrDefaultAsync(m =>m.AppUserId == userId);

        var basketProduct = basket?.basketProducts;

        var uniqeProduct = basketProduct?.GroupBy(m => m.Id)
                           .Select(m => m.First())
                           .ToList();
        var uniqueProductCount = uniqeProduct?.Count() ?? 0;
        return uniqueProductCount;
    }

    public async Task<List<BasketProductListDto>> GetBasketProductsAsync()
    {
        var userId = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        userId = "16a5a4f9-f783-44f2-b7cb-ca381cba6d27";
        if (userId == null) throw new UnauthorizedAccessException();
        var basket = await _basketRead.GetAll()
                            .Include(x => x.basketProducts)
                            .ThenInclude(x => x.Car)
                            .FirstOrDefaultAsync(m => m.AppUserId == userId);
        if (basket == null) throw new NullReferenceException();

        var basketProduct = _mapper.Map<List<BasketProductListDto>>(basket.basketProducts);

        return basketProduct;
    }


    public async Task<int> GetItemBasketCount(Guid Id)
    {
        var userId = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        userId = "16a5a4f9-f783-44f2-b7cb-ca381cba6d27";
        if (userId == null) throw new UnauthorizedAccessException();
        var basket = await _basketRead.Table
                    .Include(x => x.basketProducts)
                    .FirstOrDefaultAsync(m => m.AppUserId == userId);
        if (basket == null) throw new NullReferenceException();

        var basketProduct = basket?.basketProducts.FirstOrDefault(bp => bp.CarId == Id );
        if (basketProduct is null) return 0;
        var productQuantoty = basketProduct.Quantity;
        return productQuantoty;

    }
}



//16a5a4f9-f783-44f2-b7cb-ca381cba6d27