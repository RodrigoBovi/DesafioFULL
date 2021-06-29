namespace DesafioFull.Application.ViewModels.User
{
    public class UserResponseViewModel
    {
        public UserResponse User { get; set; }

        public string Error { get; set; }
    }

    public class UserResponse
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string JwtToken { get; set; }
    }
}
