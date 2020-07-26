using MediatR;
using MediatRInPractice.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRInPractice.Core.Features.User
{
    public class UpdateUserHandler : IRequestHandler<UpdateUser, int>
    {
        private readonly IApplicationDbContext _context;
        public UpdateUserHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.Id);
            if (user == null)
            {
                throw new Exception("Could not find user");
            }
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.UserName = request.UserName;
            user.Email = request.Email;
            var success = await _context.SaveChangesAsync() > 0;
            if (success)
            {
                return 1;
            }
            throw new Exception("some problem");

        }
    }
}
