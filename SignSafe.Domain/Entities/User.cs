using Microsoft.AspNet.Identity;
using SignSafe.Domain.Dtos.Users;
using SignSafe.Domain.Enums.Users;
using SignSafe.Domain.Extensions;
using System.Text;

namespace SignSafe.Domain.Entities
{
    public class User : Base
    {
        public User(InsertUserDto insertUserDto)
        {
            Name = insertUserDto.Name;
            Email = insertUserDto.Email;
            Password = insertUserDto.Password;
            PhoneNumber = insertUserDto.PhoneNumber;
            BirthDate = insertUserDto.BirthDate;
        }

        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string? PhoneNumber { get; protected set; }
        public DateTime BirthDate { get; protected set; }
        public string Roles { get; protected set; } = UserRoles.Standard.GetDescription();
        public void UpdateUser(UserDto dto)
        {
            Name = dto.Name;
            Email = dto.Email;
            PhoneNumber = dto.PhoneNumber;
            BirthDate = dto.BirthDate;
        }

        public void UpdateRoles(List<UserRoles> roles)
        {
            var roleList = new StringBuilder();
            roles
                .Distinct()
                .ToList()
                .ForEach(x => roleList.Append($"{x.GetDescription()}, "));

            roleList.Remove(roleList.Length - 2, 1);

            Roles = roleList.ToString();
        }

        public void EncryptUserPassword()
        {
            var hasher = new PasswordHasher();
            Password = hasher.HashPassword(Password);
        }

        public PasswordVerificationResult VerifyUserPassword(string providedPassword)
        {
            var hasher = new PasswordHasher();
            return hasher.VerifyHashedPassword(Password, providedPassword);
        }
    }
}
