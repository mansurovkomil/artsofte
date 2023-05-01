using Artsofte.Service.Dtos.Floor;

namespace Artsofte.Service.Interfaces.Departments
{
    public interface IDepartmentService
    {
        public Task<bool> AddDepartmentAsync(FloorCreateDto floorCreateDto);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> UpdateAsync(int id, FloorUpdateDto floorUpdateDto);
        public Task<List<FloorViewDto>> GetAllAsync();
        public Task<FloorViewDto> GetByIdAsync(int id);
    }
}
