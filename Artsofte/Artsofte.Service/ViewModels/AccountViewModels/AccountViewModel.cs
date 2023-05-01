namespace Artsofte.Service.ViewModels.AccountViewModels
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = String.Empty;

        public string LastName { get; set; } = String.Empty;

        public int Age { get; set; }

        public int Department { get; set; }

        public string Language { get; set; } = String.Empty;
    }
}
