using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tyle.Nft;
using Tyle.Nft.Api;

namespace GrpcService1
{
    [ApiController]
    [Route("api/[controller]")]
    public class Token1Controller : TokenController
    {
        public Token1Controller():base("YOUR DB HOST")
        {

        }

    }

    //public class Token1Controller : ControllerBase
    //{

    //    [HttpGet]
    //    [Route("{address}/{id}")]
    //    public IActionResult Get(string address, UInt64 id)
    //    {
    //        var Tyle = new Client();
    //        Tyle.DbConnect("135.181.35.207");

    //        dynamic token = Tyle.db.GetToken(address, id);

    //        if (token.o == null)
    //            return NotFound();
    //        return Ok(token);
    //    }
    //}

}