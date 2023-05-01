using Artsofte.Domain.Common;

namespace Artsofte.Domain.Entities
{
    public class Human : Auditable
    {
        public string FirstName { get; set; } = String.Empty;

        public string LastName { get; set; } = String.Empty;

        public int Age { get; set; }

        public int Department { get; set; }

        public string Language { get; set; } = String.Empty;
    }
}
