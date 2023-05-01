using Artsofte.Domain.Entities;

namespace Artsofte.Service.Dtos.Floor
{
    public class FloorViewDto
    {
        public int Departmen { get; set; }

        public static implicit operator FloorViewDto(Department department)
        {
            return new FloorViewDto()
            {
                Departmen = department.FloorNumber
            };
        }
    }
}
