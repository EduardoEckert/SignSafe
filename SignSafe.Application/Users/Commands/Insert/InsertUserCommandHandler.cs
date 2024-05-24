using MediatR;
using SignSafe.Data.UoW;
using SignSafe.Domain.Entities;

namespace SignSafe.Application.Users.Commands.Insert
{
    public class InsertUserCommandHandler : IRequestHandler<InsertUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public InsertUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.UserDto);
            try
            {
                await _unitOfWork.UserRepository.Insert(user);
                await _unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw;
            }

            return;
        }
    }
}
