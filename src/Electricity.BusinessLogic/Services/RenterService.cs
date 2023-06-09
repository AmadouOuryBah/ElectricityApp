﻿
using AutoMapper;
using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services.Interface;
using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;

namespace Electricity.BusinessLogic.Services
{
    public class RenterService : IRenter
    {
        public readonly IGenericRepository<Renter> _repository;
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;

        public RenterService(IGenericRepository<Renter> repository,
           IMapper mapper,
           IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<RenterDto> AddAsync(RenterRequest renter)
        {
            var renterMapped = _mapper.Map<Renter>(renter);

            _repository.Add(renterMapped);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<RenterDto>(renterMapped);
        }

        public async Task<string> DeleteAsync(int id)
        {
           var renter = await _repository.GetByIdAsync(id);

            _repository.Delete(renter);
            _unitOfWork.SaveChangesAsync();

            return "deleted";

        }

        public async Task<List<RenterDto>> GetAllAsync()
        {
           var renters =  await _repository.GetAllAsync();

            return _mapper.Map<List<RenterDto>>(renters);
        }

        public async Task<RenterDto> UpdateAsync(RenterDto renter)
        {
            var renterFound = await _repository.GetByIdAsync(renter.Id);

            renterFound.Name = renter.Name;
           
            _repository.Update(renterFound);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<RenterDto>(renterFound);
        }


        public  async Task<RenterDto> GetById(int id)
        {
            var renter = await _repository.GetByIdAsync(id);

            return _mapper.Map<RenterDto>(renter);

        }
    }
}
