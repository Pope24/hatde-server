namespace server_hatde.Requests
{
    public class RegisterRequest
    {
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string? BusinessName { get; set; }
        public string? Description { get; set; }
        public string? Mst {  get; set; }
    }
}
