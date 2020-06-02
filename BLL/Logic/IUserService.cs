using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Logic
{
    public interface IUserService
    {
        ICollection<UserDTO> GetUsers();

        UserDTO GetUserByID(int id);

        void AddUser(UserDTO userDto);

        void RemoveUserByID(int id);

        void Updateuser(int id, UserDTO userDto);
    }
}
