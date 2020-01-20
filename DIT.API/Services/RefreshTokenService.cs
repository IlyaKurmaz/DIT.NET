using DIT.Domain;
using DIT.Domain.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIT.API.Services
{
    public class RefreshTokenService: IRefreshTokenService
    {
        private readonly DitContext _context;

        public RefreshTokenService(DitContext context)
        {
            _context = context;
        }

        public async Task<RefreshToken> getRefreshToken(string refreshToken)
        {
            return await _context.RefreshTokens.SingleOrDefaultAsync(r => r.Token == refreshToken);
        }
    }
}
