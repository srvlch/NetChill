namespace NetChill.BOL
{
    public class BOL_LoginedUser
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsRevoked { get; set; }
    }
}
