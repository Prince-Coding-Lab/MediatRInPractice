using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediatRInPractice.Core.Features.User
{
    public class UpdateUser: IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
    }
}
