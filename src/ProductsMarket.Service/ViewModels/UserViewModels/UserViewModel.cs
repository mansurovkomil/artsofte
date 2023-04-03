namespace ProductsMarket.Service.ViewModels.StudentViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; } = String.Empty;

        public string PhoneNumber { get; set; } = String.Empty;

        public DateTime CreatedAt { get; set; }
        
        public DateTime BirthDate { get; set; }
    }
}
