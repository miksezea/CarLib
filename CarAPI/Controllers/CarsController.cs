using Microsoft.AspNetCore.Mvc;
using CarAPI.Repositories;
using CarLib;

namespace CarAPI.Controllers
{
    [Route("api/[controller]")]
    //URI: api/cars
    [ApiController]
    public class CarsController : ControllerBase
    {
        private CarsRepository _repository;

        public CarsController(CarsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<CarsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            List<Car> list = _repository.GetAll();
            if (list.Count < 1)
            {
                return NoContent();
            }
            return Ok(list);
        }

        // GET api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{Id}")]
        public ActionResult<Car> Get(int Id)
        {
            try
            {
                return Ok(_repository.GetById(Id));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/<CarsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Car> Post([FromBody] Car newCar)
        {
            try
            {
                Car createdCar = _repository.Add(newCar);
                return Created($"api/cars/{createdCar.Id}", createdCar);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{Id}")]
        public ActionResult<Car> Put(int Id, [FromBody] Car car)
        {
            try
            {
                Car? updatedCar = _repository.Update(Id, car);
                return Ok(updatedCar);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{Id}")]
        public ActionResult<Car> Delete(int Id)
        {
            try
            {
                Car deletedCar = _repository.Delete(Id);
                return Ok(deletedCar);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
