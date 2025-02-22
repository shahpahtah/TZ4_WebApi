using System.ComponentModel.DataAnnotations;
using WebApi.DbModel;

namespace WebApi
{
    public class User
    {
        UserDto dto;
        public User() { }
        public int Id { get => dto.Id; }
        [Required]
        [MinLength(2)]
        public string LastName { get => dto.LastName; set => dto.LastName = value; }
        [Required]
        [MinLength(2)]
        public string FirstName
        {
            get => dto.FirstName; set => dto.FirstName = value;
        }
        [EmailAddress]
        public string Email { get => dto.Email; set => dto.Email = value; }
        public DateTime DateOfBirth { get => dto.DateOfBirth; set => dto.DateOfBirth = value; }
        private User(UserDto _dto)
        {
            dto = _dto;
        }
        public static class DtoFactory
        {
            public static UserDto Create(string lastname,string firstname,string email,DateTime dateofbirth)
            {
                return new UserDto { DateOfBirth = dateofbirth, Email = email, FirstName = firstname, LastName = lastname };
            }
        }
        public static class Mapper
        {
            public static User Map(UserDto dto)
            {
                return new User(dto);
            }
            public static UserDto Map(User user)
            {
                return user.dto;
            }
        }
    }
}
