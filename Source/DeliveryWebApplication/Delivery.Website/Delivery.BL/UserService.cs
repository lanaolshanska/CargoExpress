using AutoMapper;
using Delivery.DAL.Contracts;
using Delivery.Models;
using Delivery.Models.DTO;
using Delivery.Utils.Enum;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.BL
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper) : base(userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public int Create(string userName, string password, string email, Role role)
        {
            var user = new User
            {
                Username = userName,
                Password = Encode(password),
                Email = email,
                Role = role
            };

            Create(user);
            return user.Id;
        }

        public async Task<int> CreateAsync(string userName, string password, string email, Role role)
        {
            var user = new User
            {
                Username = userName,
                Password = Encode(password),
                Email = email,
                Role = role
            };

            await _userRepository.CreateAsync(user);
            return user.Id;
        }

        public bool IsEmailExist(string email)
        {
            return _userRepository.IsEmailExist(email);
        }

        public User FindUserByEmailAndPassword(string email, string password)
        {
            return _userRepository.FindUserByEmailAndPassword(email, Encode(password));
        }

        public async Task<User> FindUserByEmailAndPasswordAsync(string email, string password)
        {
            return await _userRepository.FindUserByEmailAndPasswordAsync(email, Encode(password));
        }

        public async Task<IEnumerable<User>> GetAllAsync(string query, UserFilterByEnum? filterField, UserSortByEnum? sortBy, int? take, int? skip)
        {
            return await _userRepository.GetAllAsync(query, filterField, sortBy, take, skip);
        }

        public async Task<User> UpdateAsync(int id, UpdateUserModel item)
        {
            if (await _userRepository.IsEmailUniqueAsync(id, item.Email))
            {
                var user = _mapper.Map<UserModel, User>(item);
                user.Id = id;
                user.Password = Encode(user.Password);
                await _userRepository.UpdateAsync(user);

                return user;
            }
            else
            {
                throw new System.Exception("This email is already taken");
            }
        }

        public async Task<int> CreateAsync(AddUserModel item)
        {
            if (await _userRepository.IsEmailUniqueAsync(item.Email))
            {
                var user = _mapper.Map<UserModel, User>(item);
                user.Password = Encode(user.Password);
                await _userRepository.CreateAsync(user);
                return user.Id;
            }
            else
            {
                throw new System.Exception("User with such email already exists");
            }
        }

        private string Encode(string value)
        {
            using (var provider = System.Security.Cryptography.MD5.Create())
            {
                StringBuilder builder = new StringBuilder();

                foreach (byte b in provider.ComputeHash(Encoding.UTF8.GetBytes(value)))
                {
                    builder.Append(b.ToString("x2").ToLower());
                }

                return builder.ToString();
            }
        }
    }
}