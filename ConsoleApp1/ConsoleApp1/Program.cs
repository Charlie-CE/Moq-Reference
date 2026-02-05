using Moq;

namespace ConsoleApp1;

public class Program
{
    static void Main(string[] args)
    {
    }

    public class User
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

    public interface IUserService
    {
        User GetUser(string email, string  password);
    }

    public class UserService : IUserService
    {
        User IUserService.GetUser(string email, string password)
        {
            return new User();
        }
    }

    public class LoginService
    {
        private readonly IUserService _userService;

        public LoginService(IUserService service)
        {
            _userService = service;
        }

        public bool Login(string email, string password)
        {
            var user = _userService.GetUser(email, password);

            return user != null;
        }
    }

    public interface IUserInfo
    {
        string UserName { get; set; }
        int Age { get; set; }

        string GetUserData();
    }

    public interface IVerifyService
    {
        void Process(int value);
    }

    public class VerifyServiceClient
    {
        private readonly IVerifyService _service;

        public VerifyServiceClient(IVerifyService service)
        {
            _service = service;
        }

        public void Execute(int[] values)
        {
            foreach (var value in values)
            {
                _service.Process(value);
            }
        }
    }
}
