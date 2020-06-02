using DAL.Dependencies;
using DAL.Models;
using DAL.Repository;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartDB
{
    class Program
    {
        static void Main(string[] args)
        {

            var kernel = new StandardKernel(new DataAccessModule());

            var data = kernel.Get<IUnitOfWork>();

            data.Roles.Create(new Role { RoleName = "Admin" });
            data.Roles.Create(new Role { RoleName = "Employee" });
            data.Roles.Create(new Role { RoleName = "Employer" });
            data.Save();

            var vacansy = new Vacansy { VacansyTitle = "Middle .Net developer", VacansyInfo = "Looking for middle .net developer", VacansyPosition = "Middle", VacansySalary = 2100, Resumes = new List<Resume>() };
            var resume = new Resume { ResumeTitile = ".Net developer", Position = "Middle", ResumeId = 1, Info = "Looking for a good job", PreferablySalary = 2000, Vacancies = new List<Vacansy>() };
            resume.Vacancies.Add(vacansy);
            vacansy.Resumes.Add(resume);
            data.Save();

            data.Users.Create(new User { Login = "Admin", Pass = "Admin", RoleId = 1 });
            var employee = new User { UserId = 2, Login = "Employee", Pass = "Employee", RoleId = 2, Name = "UserName", Surname = "UserSurname", Patronymic = "UserPatronymic", Resume = resume, ResumeId = resume.ResumeId };
            data.Users.Create(employee);
            data.Users.Create(new User { Login = "Employer", Pass = "Employer", RoleId = 3 });

            data.Resumes.Create(resume);
            data.Vacansies.Create(vacansy);
            data.Save();

            var list = data.Resumes.Get().ToList();
            var list1 = data.Vacansies.Get().ToList();
            var list2 = data.Users.Get().ToList();
        }
    }
}
