using MediatR;
using MediatRInPractice.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatRInPractice.Core.Entities;

namespace MediatRInPractice.Core.Features.User
{
    public class CreateUserHandler : IRequestHandler<CreateUser, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateUserHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            var user = new MediatRInPractice.Core.Entities.User();
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.UserName = request.UserName;
            user.Password = request.Password;
            user.Email = request.Email;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }
    }
}
