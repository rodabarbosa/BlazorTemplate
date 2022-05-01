namespace Sirb.Template.Shared.ViewModels
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Login { get; set; }
        public string? Token { get; set; }
        public DateTime ExpireDate { get; set; }
        public PermissionViewModel[]? Permissions { get; set; }
    }
}
