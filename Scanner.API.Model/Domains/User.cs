namespace Scanner.API.Model.Domains {
    public class User {
        public int Id { get; set; }
        public string EmployeeId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public bool? IsUser { get; set; }
    }
}
