using CanariaApi.Data;
using CanariaApi.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace CanariaApi.Controllers
{
    [Route("api/CanariaApi")] // [Route("api/[controller]")]
    [ApiController]
    public class CanariaApiController : Controller
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ApartmentDto>> GetApartment()
        {
            return Ok(ApartmentStore.apartmentList);
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)] //200
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //400
        [ProducesResponseType(StatusCodes.Status404NotFound)] //404
        public ActionResult<ApartmentDto> GetApartment(int id)
        {
            if (id == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest); //BadRequest(); //samma som felmeddelande kod 400
            }
            var apartment = ApartmentStore.apartmentList.FirstOrDefault(ap => ap.ApartmentId == id);
            if (apartment == null)
            {
                return BadRequest(apartment); //NotFound(); // samma som felmeddelande 404
            }
            return Ok(apartment);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)] //200
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //400
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ApartmentDto> CreateApartment([FromBody] ApartmentDto apartmentDto) //inte Iaction utan action för vi ska skapa 
        {
            if (apartmentDto==null)
            {
                return BadRequest(apartmentDto);
            }
            if (apartmentDto.ApartmentId > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            apartmentDto.ApartmentId = ApartmentStore.apartmentList.OrderByDescending(ap => ap.ApartmentId).FirstOrDefault().ApartmentId;
            ApartmentStore.apartmentList.Add(apartmentDto);
            return Ok(apartmentDto);
        }



    }
}


//return new List<Apartment>
//            {
//               new Apartment{ApartmentId=1, Name="Beach bungalow"},
//               new Apartment{ApartmentId=2, Name="Mountain bungalow"},
//           };