using SignSafe.Domain.Dtos.Users;

namespace SignSafe.Domain.Entities
{
    public class User : Base
    {
        public User() { }
        public User(UserDto userDto)
        {
            Name = userDto.Name;
            Email = userDto.Email;
            PhoneNumber = userDto.PhoneNumber;
            BirthDate = userDto.BirthDate;
        }

        public string? Name { get; protected set; }
        public string? Email { get; protected set; }
        public string? PhoneNumber { get; protected set; }
        public DateTime BirthDate { get; protected set; }
        public void UpdateUser(UserDto dto)
        {
            Name = dto.Name;
            Email = dto.Email;
            PhoneNumber = dto.PhoneNumber;
            BirthDate = dto.BirthDate;
        }
    }
}
