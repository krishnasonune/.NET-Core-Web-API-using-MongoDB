using Crud_with_mongodb.Models;
using Microsoft.AspNetCore.Mvc;
using Namespace;
namespace values.Controllers;
[ApiController]
[Route("api/[controller]/[action]")]
public class Values : Controller
{
    UserDAL userDAL;

    public Values(UserDAL userDAL)
    {
        this.userDAL = userDAL;
    }

    [HttpGet]
    public async Task<IActionResult> Get_All_Users()
    {
        var result = await userDAL.Get_All_Records();
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Get_A_Single_Record(string Id){
        var result = await userDAL.Get_A_Single_Record(Id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Insert_Record(Users obj){
        var result = await userDAL.Insert_Record(obj);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update_Record(Users obj){
        var result = await userDAL.Update_Record(obj);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete_Record(string Id){
        var result = await userDAL.Delete_Record(Id);
        return Ok(result);
    }
}