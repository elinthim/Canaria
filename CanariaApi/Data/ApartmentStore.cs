using CanariaApi.Models.DTO;

namespace CanariaApi.Data
{
    public static class ApartmentStore //för att kunna kalla direkt på min apartment
    {
        public static List<ApartmentDto> apartmentList = new List<ApartmentDto>
        {
        new ApartmentDto{ApartmentId=1, Name="Beach bungalow"}, //aparmtent DTO kan man kalla på trots att den inte ligger i databasen
    new ApartmentDto{ApartmentId=1, Name="Mountain bungalow"}
    };
    }
}
