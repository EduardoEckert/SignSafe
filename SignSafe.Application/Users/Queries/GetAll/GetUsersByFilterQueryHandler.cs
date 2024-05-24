﻿using MediatR;
using SignSafe.Data.UoW;
using SignSafe.Domain.Contracts.Api;
using SignSafe.Domain.Dtos.Users;

namespace SignSafe.Application.Users.Queries.GetAll
{
    public class GetUsersByFilterQueryHandler : IRequestHandler<GetUsersByFilterQuery, PaginatedResult<List<UserDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUsersByFilterQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<PaginatedResult<List<UserDto>>> Handle(GetUsersByFilterQuery request, CancellationToken cancellationToken)
        {
            var filter = BuildFilter(request);

            var result = await _unitOfWork.UserRepository.GetByFilter(filter, request.Pagination);

            var data = result.Data.Select(user => new UserDto(user)).ToList();

            return new PaginatedResult<List<UserDto>>(data, request.Pagination.Page, request.Pagination.Size, result.TotalItems);
        }

        private UsersFilterDto BuildFilter(GetUsersByFilterQuery request)
        {
            return new UsersFilterDto
            {
                Name = request.Name,
                Email = request.Email,
            };
        }
    }
}
