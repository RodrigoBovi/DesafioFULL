using DesafioFull.Application.ViewModels.User;
using DesafioFull.CrossCutting.Security;
using DesafioFull.Domain.Entities;
using DesafioFull.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFull.Application.Services
{
    public class UserService
    {
        private readonly IRepositoryBase<User, int> _userRepository;
        private readonly IConfiguration _config;

        public UserService(
            IRepositoryBase<User, int> userRepository,
            IConfiguration config
            )
        {
            _userRepository = userRepository;
            _config = config;
        }

        public async Task<UserResponseViewModel> Authenticate(UserViewModel userViewModel)
        {
            try
            {
                UserResponseViewModel userResponse = new UserResponseViewModel();

                IEnumerable<User> users = await _userRepository.GetAllByConditionAsync(w => w.Email == userViewModel.Email);
                User user = users.FirstOrDefault(w => w.Password == Cryptography.HashWithDatabaseValue(userViewModel.Password, w.Password));

                if (user == null) 
                {
                    userResponse.Error = "Usuário não encontrado!";
                }
                else
                {
                    userResponse.User = new UserResponse
                    {
                        UserId = user.UserId,
                        Username = user.Username,
                        JwtToken = JwtSecurity.CreateToken(_config, user.UserId)
                    };
                }

                return userResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
