namespace NETCoreDemo.Controllers;

using NETCoreDemo.Services;
using NETCoreDemo.DTOs;
using Microsoft.AspNetCore.Mvc;

public class UserController : ApiControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service) => _service = service;

    [HttpPost("signup")]
    public async Task<IActionResult> SignUp(UserSignUpDTO request)
    {
        var user = await _service.SignUpAsync(request);
        if (user is null)
        {
            return BadRequest();
        }
        return Ok(UserSignUpResponseDTO.FromUser(user));
    }
}