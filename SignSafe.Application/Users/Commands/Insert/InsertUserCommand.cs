﻿using MediatR;
using SignSafe.Domain.Dtos.Users;

namespace SignSafe.Application.Users.Commands.Insert
{
    public class InsertUserCommand : IRequest
    {
        public required UserDto UserDto { get; set; }
    }
}
