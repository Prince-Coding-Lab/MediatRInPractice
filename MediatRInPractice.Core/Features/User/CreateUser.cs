using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediatRInPractice.Core.Features.User
{
    public class CreateUser: IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}
