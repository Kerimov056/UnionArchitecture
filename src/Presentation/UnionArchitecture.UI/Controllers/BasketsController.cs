using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using UnionArchitecture.Aplication.Abstraction.Services;

namespace UnionArchitecture.UI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketsController : ControllerBase
{
    private readonly IBasketService _basketService;

    public BasketsController(IBasketService basketService)
    {
        _basketService = basketService;
    }

    [HttpPost]
    public async Task<IActionResult> AddBasket([Required][FromQuery] Guid Id)
    {

        await _basketService.AddBasketAsync(Id);
        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpGet]
    public async Task<IActionResult> GetBasketProducts()
    {
        return Ok(await _basketService.GetBasketProductsAsync());
    }

    [HttpDelete("Delete-Basket-Product")]
    public async Task<IActionResult> DeleteBasketProduct([Required][FromQuery] Guid Id)
    {
        await _basketService.DeleteBasketAsync(Id);          //Isdiyir aaa Roter'i duzelt
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBasketItemProduct([Required][FromQuery] Guid Id)
    {
        await _basketService.DeleteBasketItemAsync(Id);
        return Ok();
    }

    [Route("{Id}")]
    [HttpGet]
    public async Task<IActionResult> GetBasketItemCount([FromRoute][Required] Guid Id)  //bir productdan nece ded oldugun gosterir.
    {
        return Ok(await _basketService.GetItemBasketCount(Id));
    }

    [HttpGet("Get-Basket-Count")]
    public async Task<IActionResult> GetBasketCount()  //baskete nece cur ferqli product oldugunu gosterir.
    {
        var basketCount = await _basketService.GetBasketCountAsync();
        return Ok(basketCount); 
    }
}

//asdasdasd