namespace geradoc_v2.Authentication {
    public class AuthenticationRequest {

        public AuthenticationRequest(string email, string password){
            Email = email;
            Password = password;
        }
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
    
}
