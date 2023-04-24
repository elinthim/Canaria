namespace CanariaApi.Models
{
    public class Apartment
    {
        public int ApartmentId { get; set; }
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; } //huvudklassen innehåller allt som ska vara i aprtment DTO aparmtent blir en förkortad version av apartment
    }
}
