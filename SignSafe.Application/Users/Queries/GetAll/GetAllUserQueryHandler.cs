using MediatR;
using SignSafe.Data.UoW;
using SignSafe.Domain.Entities;

namespace SignSafe.Application.Users.Queries.GetAll
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<User>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllUserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<List<User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var userList = await _unitOfWork.UserRepository.GetAll();

            return userList;
        }
    }
}
