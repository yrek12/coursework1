using System.Collections.Generic;
using AutoMapper;
using BLL.DTO;
using DAL.Models;
using DAL.Repository;

namespace BLL.Logic
{
    internal class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _userMapper;

        private readonly IMapper _userUpdateMapper;

        public UserService(IUnitOfWork unitOfWork)
        {
            _userMapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()
            .ForMember(x => x.Role, y => y.MapFrom(c => c.Role))
            .ForMember(x => x.Resume, y => y.MapFrom(c => c.Resume))).CreateMapper();

            _userUpdateMapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>()
            .ForMember(x => x.Role, y => y.MapFrom(c => c.Role))
            .ForMember(x => x.Resume, y => y.MapFrom(c => c.Resume))).CreateMapper();

            _unitOfWork = unitOfWork;
        }

        public void AddUser(UserDTO userDto)
        {
            _unitOfWork.Users.Create(new User { Name = userDto.Name, Login = userDto.Login, Pass = userDto.Pass, RoleId = userDto.RoleId });
            _unitOfWork.Save();
        }

        public UserDTO GetUserByID(int id)
        {
            return _userMapper.Map<User, UserDTO>(_unitOfWork.Users.GetOne(x => (x.UserId == id)));
        }

        public ICollection<UserDTO> GetUsers()
        {
            return _userMapper.Map<IEnumerable<User>, List<UserDTO>>(_unitOfWork.Users.Get());
        }

        public void RemoveUserByID(int id)
        {
            _unitOfWork.Users.Remove(_unitOfWork.Users.FindById(id));
            _unitOfWork.Save();
        }

        public void Updateuser(int id, UserDTO userDto)
        {
            var userForUpdate = GetUserByID(id);

            if (userForUpdate != null)
            {
                _unitOfWork.Users.Update(_userUpdateMapper.Map<UserDTO, User>(userDto));
            }
        }
    }
}
