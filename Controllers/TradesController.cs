namespace WebTrade.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("[controller]")]
public class TradesController : ControllerBase
{
    private List<string> _data = new()
    {
        "This is just a test",
        "Azure App with GitHub Actions"
    };

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(string.Join("\n", _data));
    }

    [HttpGet("{idx}")]
    public IActionResult GetById(int idx)
    {
        if (idx < 0 || idx >= _data.Count)
            return NotFound();

        return Ok(_data[idx]);
    }
}
