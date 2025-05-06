using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{

    private readonly DataContext _dataContext;

    public UsersController(DataContext dataContext){
        _dataContext = dataContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() {
        var users = await _dataContext.Users.ToListAsync();

        return Ok(users);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<AppUser>> GetUsers(int id){
        var user = await _dataContext.Users.FindAsync(id);

        if (user == null) return NotFound();

        return Ok(user);
    }
}