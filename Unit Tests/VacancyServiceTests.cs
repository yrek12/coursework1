using System;
using System.Collections.Generic;
using BLL.DTO;
using BLL.Logic;
using DAL;
using DAL.Models;
using DAL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Unit_Tests
{
    [TestClass]
    public class VacancyServiceTests
    {
        private IVacansyService _vacancyService;

        private Mock<UnitOfWork> _unitOfWork;

        private Mock<IGenericRepository<Vacansy>> _vacansyRepository;

        private List<Vacansy> vacancies;

        [TestInitialize]
        public void Initialize()
        {
            var resumeRepository = new Mock<IGenericRepository<Resume>>();
            var roleRepository = new Mock<IGenericRepository<Role>>();
            var userRepository = new Mock<IGenericRepository<User>>();
            _vacansyRepository = new Mock<IGenericRepository<Vacansy>>();
            var context = new Mock<Context>();

            _unitOfWork = new Mock<UnitOfWork>(context.Object, roleRepository.Object, userRepository.Object, resumeRepository.Object, _vacansyRepository.Object);

            _vacancyService = new VacansyService(_unitOfWork.Object);
        }

        [TestMethod]
        public void GetVacancies_ReturnsCorrectNumberOfResumes()
        {
            //Arrange
            vacancies = new List<Vacansy>
            {
                new Vacansy(){VacansyTitle ="First"},
                 new Vacansy(){VacansyTitle ="Second"},
                  new Vacansy(){VacansyTitle ="Third"},

            };

            _vacansyRepository.Setup(x => x.Get()).Returns(vacancies);

            //Act
            var result = _vacancyService.GetVacancies();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void AddVacansy_CalledCreateMethod()
        {
            //Arrange
            _vacansyRepository.Setup(x => x.Create(It.IsAny<Vacansy>()));

            //Act
            _vacancyService.AddVacansy(new VacansyDTO());

            //Assert
            _vacansyRepository.Verify(x => x.Create(It.IsAny<Vacansy>()), Times.Once);
        }

        [TestMethod]
        public void UpdateVacansy_CalledUpdateMethod()
        {
            //Arrange
            _vacansyRepository.Setup(x => x.GetOne(It.IsAny<Func<Vacansy, bool>>()))
                .Returns(new Vacansy() { });

            _vacansyRepository.Setup(x => x.Update(It.IsAny<Vacansy>()));

            //Act
            _vacancyService.UpdateVacansy(1, new VacansyDTO());

            //Assert
            _vacansyRepository.Verify(x => x.Update(It.IsAny<Vacansy>()), Times.Once);
        }

        [TestMethod]
        public void GetVacansyByID_ReturnsCorrectVacansy()
        {
            //Arrange
            var expectedVacansy = new Vacansy() { VacansyId = 1, VacansyTitle = "Title" };
            _vacansyRepository.Setup(x => x.GetOne(It.IsAny<Func<Vacansy, bool>>()))
               .Returns(expectedVacansy);

            //Act
            var result = _vacancyService.GetVacansyByID(1);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedVacansy.VacansyId, result.VacansyId);
            Assert.AreEqual(expectedVacansy.VacansyTitle, result.VacansyTitle);
        }

        [TestMethod]
        public void RemoveVacansyByID_CallsRemove()
        {
            //Arrange
            var expectedService = new Vacansy() { VacansyId = 1, VacansyTitle = "Title" };
            _vacansyRepository.Setup(x => x.Remove(expectedService));

            //Act
            _vacancyService.RemoveVacansyByID(1);

            //Assert
            _vacansyRepository.Verify(x => x.Remove(It.IsAny<Vacansy>()), Times.Once);
        }
    }
}
