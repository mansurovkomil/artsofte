using Artsofte.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Artsofte.Service.Dtos.Floor
{
    public class FloorUpdateDto
    {
        [Required(ErrorMessage = "Enter a name!")]
        public int Departmen { get; set; }
        public static implicit operator Department(FloorUpdateDto department)
        {
            return new Department()
            {
                FloorNumber = department.Departmen
            };
        }
    }
}
