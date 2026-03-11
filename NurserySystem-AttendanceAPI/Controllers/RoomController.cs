using Microsoft.AspNetCore.Mvc;
using NurserySystem_AttendanceAPI.DTOs;
using NurserySystem_AttendanceAPI.Model;
using NurserySystem_AttendanceAPI.UnitOfWork;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NurserySystem_AttendanceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public RoomController(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
            
        }
        // GET: api/<RoomController>
        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _uow.RoomDetails.GetAllAsync();
            if(rooms == null)
            {
                return NotFound("Rooms Not Found");
            }

            return Ok(rooms);
            
        }

        // GET api/<RoomController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomsByID(int id)
        {
            var room = await _uow.RoomDetails.GetByIdAsync(id);
            if(room == null)
            {
                return NotFound("Room is not found");
            }

            return Ok(room);
             
        }

        // POST api/<RoomController>
        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] RoomDTO rdto)
        {
            var room = new RoomDetails
            {
                RoomCode = rdto.RoomCode,
                IsActive = true
            };

            await _uow.RoomDetails.AddAsync(room);
            await _uow.RoomDetails.SaveAsync();
            return CreatedAtAction(nameof(GetRoomsByID), new { id = room.Id }, room);

        }

        // PUT api/<RoomController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] RoomDTO rdto)
        {
            var room = await _uow.RoomDetails.GetByIdAsync(id);
            if(room == null)
            {
                return NotFound("Room Not Found");
            }
            else
            {
                room.RoomCode = rdto.RoomCode;
                room.IsActive = rdto.IsActive;

                _uow.RoomDetails.Update(room);
                await _uow.RoomDetails.SaveAsync();

                return NoContent();
            }
        }

        // DELETE api/<RoomController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _uow.RoomDetails.GetByIdAsync(id);

            if (room == null)
            {
                return NotFound("Room Not Found");
            }
            else
            {
                _uow.RoomDetails.Delete(room);
                await _uow.RoomDetails.SaveAsync();
                return NoContent();
            }
        }
    }
}
