using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.DbModel
{
    public class UserDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Фамилия обязательна")] // Валидация модели
        [MinLength(2, ErrorMessage = "Минимальная длина фамилии - 2 символа")] // Валидация модели
        public string LastName { get; set; }

        [Required(ErrorMessage = "Имя обязательно")] // Валидация модели
        [MinLength(2, ErrorMessage = "Минимальная длина имени - 2 символа")] // Валидация модели
        public string FirstName { get; set; }

        public DateTime DateOfBirth { get; set; } // DateOnly или DateTime

        [EmailAddress(ErrorMessage = "Неверный формат email")] // Валидация модели
        public string Email { get; set; }
    }
}