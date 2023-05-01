using Artsofte.DataAccess.Interfaces.Common;
using Artsofte.Domain.Entities;
using Artsofte.Service.Common.Exceptions;
using Artsofte.Service.Dtos.Floor;
using Artsofte.Service.Interfaces.Departments;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Artsofte.Service.Services.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._repository = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<bool> AddDepartmentAsync(FloorCreateDto floorCreateDto)
        {
            var newAccount = (Department)floorCreateDto;

            _repository.Departaments.Add(newAccount);
            var dbResult = await _repository.SaveChangesAsync();
            return dbResult > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var temp = await _repository.Departaments.FindByIdAsync(id);
            if (temp is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "Department not found");
            _repository.Departaments.Delete(id);
            var result = await _repository.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<FloorViewDto>> GetAllAsync()
        {
            var query = _repository.Departaments.GetAll().Select(x => _mapper.Map<FloorViewDto>(x));
            return await query.ToListAsync();
        }

        public async Task<FloorViewDto> GetByIdAsync(int id)
        {
            var temp = await _repository.Departaments.FindByIdAsync(id);
            if (temp is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "Department is not Found");
            var res = (FloorViewDto)temp;
            return res;
        }

        public async Task<bool> UpdateAsync(int id, FloorUpdateDto floorUpdateDto)
        {
            var temp = await _repository.Departaments.FindByIdAsync(id);
            if (temp is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "Departament is not found");
            else
            {
                _repository.Departaments.TrackingDeteched(temp);
                if (floorUpdateDto != null)
                {
                    if (floorUpdateDto.Departmen > 0) temp.FloorNumber = floorUpdateDto.Departmen;
                }
                _repository.Departaments.Update(id, temp);

                var result = await _repository.SaveChangesAsync();
                return result > 0;
            }
        }
    }
}
