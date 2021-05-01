using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Tyle.Nft;

using UnityEngine;

namespace GrpcService1
{
    public class CubeService : Cube.CubeBase
    {
        private readonly ILogger<CubeService> _logger;
        public CubeService(ILogger<CubeService> logger)
        {
            _logger = logger;
        }

        public override Task<RotateReply> Rotate(RotateRequest request, ServerCallContext context)
        {
            var client = new Client();
            client.DbConnect("localhost");
            var token = client.db.GetToken(request.Address, request.Tokenid).o;
            if (token.rotation.y >= 360)
                token.rotation.y = 0;
            else
                token.rotation.y += 5;
            client.db.UpdateToken(request.Address, request.Tokenid, token);

            return Task.FromResult(new RotateReply
            {
                Y = token.rotation.y
            });
        }
    }
}
