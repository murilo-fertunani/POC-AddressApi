using AddressApi.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AddressApi
{
    public static class AddressControllerExtension
    {
        public static void UseAddressController(this WebApplication app)
        {
            app.MapGet("address/{postalCode}", async ([FromServices] IAddressBLL bll, [FromRoute] string postalCode) =>
                await bll.GetAddressAsync(postalCode));
        }
    }
}