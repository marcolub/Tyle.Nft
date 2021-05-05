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

}
