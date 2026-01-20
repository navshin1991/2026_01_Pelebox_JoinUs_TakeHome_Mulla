using Pelebox.Domain.Entities;

namespace Pelebox.API.Models {
    public class LoginResponse {
        public LoginStatus Status { get; set; }
        public string Message { get; set; }
        public object AccessToken { get; set; }
        public User? User { get; set; }
    }

    public enum LoginStatus {
        Invalid = 0,
        Success = 1,
        Inactive = 2
    }
}
