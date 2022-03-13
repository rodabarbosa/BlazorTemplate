namespace Sirb.Template.Shared.ViewModels
{
    public class PermissionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }
        public bool Delete { get; set; }
        public bool Read { get; set; }
        public bool Write { get; set; }
        public bool Update { get; set; }

    }
}