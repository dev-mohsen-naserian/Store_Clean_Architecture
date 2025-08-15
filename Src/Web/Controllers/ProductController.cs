using Application.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Common;

namespace Web.Controllers;
public class ProductController : BaseApiController
{
    public async Task<IActionResult>Get()
    {
        return Ok();
    }
}
