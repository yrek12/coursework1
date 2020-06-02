using AutoMapper;
using BLL.DTO;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;

namespace BLL.Logic
{
    internal class VacansyService : IVacansyService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _vacansyMapper;

        private readonly IMapper _vacansyUpdateMapper;

        private readonly IMapper _resumeMapper;

        public VacansyService(IUnitOfWork unitOfWork)
        {
            _vacansyMapper = new MapperConfiguration(cfg => cfg.CreateMap<Vacansy, VacansyDTO>()).CreateMapper();

            _vacansyUpdateMapper = new MapperConfiguration(cfg => cfg.CreateMap<VacansyDTO, Vacansy>()).CreateMapper();

            _resumeMapper = new MapperConfiguration(cfg => cfg.CreateMap<ResumeDTO, Resume>()).CreateMapper();

            _unitOfWork = unitOfWork;
        }

        public void AddVacansy(VacansyDTO vacancyDto)
        {
            try
            {
                _unitOfWork.Vacansies.Create(new Vacansy
                {
                    VacansyId = vacancyDto.VacansyId,
                    VacansyInfo = vacancyDto.VacansyInfo,
                    VacansyPosition = vacancyDto.VacansyPosition,
                    VacansySalary = vacancyDto.VacansySalary,
                    VacansyTitle = vacancyDto.VacansyTitle
                });
                _unitOfWork.Save();
            }
            catch (Exception exception)
            {
                throw new Exception("Data can not be added!" + $"/n{exception.Message}");
            }
        }

        public void UpdateVacansy(int id, VacansyDTO vacancyDto)
        {
            var vacancyForUpdate = GetVacansyByID(id);

            if (vacancyForUpdate != null)
            {
                _unitOfWork.Vacansies.Update(_vacansyUpdateMapper.Map<VacansyDTO, Vacansy>(vacancyDto));
            }
        }

        public VacansyDTO GetVacansyByID(int id)
        {
            return _vacansyMapper.Map<Vacansy, VacansyDTO>(_unitOfWork.Vacansies.GetOne(x => (x.VacansyId == id)));
        }

        public ICollection<VacansyDTO> GetVacancies()
        {
            return _vacansyMapper.Map<IEnumerable<Vacansy>, List<VacansyDTO>>(_unitOfWork.Vacansies.Get());
        }

        public void RemoveVacansyByID(int id)
        {
            try
            {
                _unitOfWork.Vacansies.Remove(_unitOfWork.Vacansies.FindById(id));
                _unitOfWork.Save();
            }
            catch (Exception exception)
            {
                throw new Exception("Data can not be removed!" + $"/n{exception.Message}");

            }
        }
    }
}
