using Artsofte.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Artsofte.Service.Dtos.Floor
{
    public class FloorCreateDto
    {
        [Required(ErrorMessage = "Please enter the Department!")]
        public int Departmen { get; set; }
        public static implicit operator Department(FloorCreateDto department)
        {
            return new Department()
            {
                FloorNumber = department.Departmen
            };
        }
    }
}
