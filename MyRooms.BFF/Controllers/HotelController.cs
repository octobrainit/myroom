using Microsoft.AspNetCore.Mvc;
using MyRooms.Consumer.UseCase.CreateHotel;
using MyRooms.Producer.UseCase.GetHotelDetails;
using MyRooms.Producer.UseCase.GetHotels;

namespace MyRooms.BFF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostHotel([FromServices] ICreateHotelUseCase createHotelUseCase, [FromBody] CreateHotelInput input, CancellationToken cancellationToken)
        {
            var response = await createHotelUseCase.HandleExecutionAsync(input, cancellationToken);
            
            return response.IsValid ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetHotels([FromServices] IGetHotelsUseCase getHotelsUseCase, CancellationToken cancellationToken)
        {
            var response = await getHotelsUseCase.HandleExecutionAsync(new GetHotels(), cancellationToken);
            return response.IsValid ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelDetail([FromServices] IGetHotelDetailsUseCase getHotelDetailsUseCase, int id, CancellationToken cancellationToken)
        {
            var response = await getHotelDetailsUseCase.HandleExecutionAsync(new GetHotelDetailsInput(id), cancellationToken);
            return response.IsValid ? Ok(response) : BadRequest(response);
        }

    }
}
