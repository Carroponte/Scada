using Microsoft.AspNetCore.Mvc;

namespace CarroponteAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class CarroponteController : ControllerBase
{
    [HttpGet(Name = "GetCarroponteState")]
    public string GetState() => CarroponteInterface
        .GetStatus()
        .ToString()!;
    
    [HttpPost(Name = nameof(PostAvanti))]
    public void PostAvanti() => CarroponteInterface.ToggleAvanti();
    
    [HttpPost(Name = nameof(PostIndietro))]
    public void PostIndietro() => CarroponteInterface.ToggleIndietro();
    
    [HttpPost(Name = nameof(PostSinistra))]
    public void PostSinistra() => CarroponteInterface.ToggleSinistra();
    
    [HttpPost(Name = nameof(PostDestra))]
    public void PostDestra() => CarroponteInterface.ToggleDestra();
    
    [HttpPost(Name = nameof(PostSale))]
    public void PostSale() => CarroponteInterface.ToggleSale();
    
    [HttpPost(Name = nameof(PostScende))]
    public void PostScende() => CarroponteInterface.ToggleScende();
}