namespace Interns.Presentation.DTOs
{
    public class AddressDto
    {
        public int Id { get; set; }

        public int? UserId { get; set; }
        
        public string City { get; set; }

        public string County { get; set; }
        
        public string Street { get; set; }

        public int Number { get; set; }

        public int Zip { get; set; }

        //public virtual UserDto User { get; set; }
    }
}