namespace DTOModels {
    public class ApplicationUserDTO {
        public string Id { get; set; }
        public string Email { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? RegistrationDate { get; set; }
    }
}
