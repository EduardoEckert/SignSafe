using MediatR;
using SignSafe.Data.UoW;

namespace SignSafe.Application.Users.Commands.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.Get(request.UserId);
            if (user is null)
                return await Task.FromResult(Unit.Value);

            user.UpdateUser(request.UserDto);
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.Commit();

            return await Task.FromResult(Unit.Value);
        }
    }
}
