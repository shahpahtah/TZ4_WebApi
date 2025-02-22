using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;
using WebApi;

namespace TZ4.Data.EF
{
    public class UserModel
    {
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public static class Mapper
        {
            public static User Map(UserModel model)
            { 
                return User.Mapper.Map(User.DtoFactory.Create(model.LastName, model.FirstName, model.Email, model.DateOfBirth));
            }
            public static UserModel Map(User user)
            {
                return new UserModel { DateOfBirth = user.DateOfBirth ,Email=user.Email,FirstName=user.FirstName,LastName=user.LastName};
            }
        }
    }
}