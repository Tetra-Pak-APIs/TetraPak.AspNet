﻿using System.Threading.Tasks;

namespace TetraPak.AspNet.Api.Auth.Development
{
    public class MockedSidecarAuthorityHandler : MockedSidecarHandler
    {
        protected override Task<bool> OnHandle()
        {
            // todo handle authority requests
            return Task.FromResult(false);
        }
    }
}