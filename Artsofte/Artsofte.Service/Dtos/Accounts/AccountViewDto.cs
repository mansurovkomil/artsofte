using Artsofte.Domain.Entities;

namespace Artsofte.Service.Dtos.Accounts
{
    public class AccountViewDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = String.Empty;

        public string LastName { get; set; } = String.Empty;

        public int Age { get; set; }

        public int Department { get; set; }

        public string Language { get; set; } = String.Empty;

        public static implicit operator AccountViewDto(Human human)
        {
            return new AccountViewDto()
            {
                Id = human.Id,
                FirstName = human.FirstName,
                LastName = human.LastName,
                Age = human.Age,
                Department = human.Department,
                Language = human.Language
            };
        }
    }
}
