using AutoMapper;
using CentroComputo2.Data.DataContext;
using Ein.DTOS;
using EIN.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CentroComputo2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneracionesController : ControllerBase
    {

        private readonly BaseContext _context;
        private readonly IMapper _mapper;

        public GeneracionesController(BaseContext conext, IMapper mapper)
        {
            _context = conext;
            _mapper= mapper;
        }



        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var generaciones = _context.Generaciones
                .Where(x=> x.EstaActivo==true)
                .Select(x => _mapper.Map<GeneracionGetDTO>(x))
                .ToList();

                if (generaciones == null || generaciones.Count == 0)
                    return NoContent();


                return Ok(generaciones);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


         

        }
        [HttpPost]
        public IActionResult Post([FromBody] GeneracionSetDTO newObj)
        {

            try
            {
                if (ModelState.IsValid)
                    return BadRequest();

                var obj = _mapper.Map<GeneracionEntity>(newObj);

                _context.Generaciones.Add(obj);
                _context.SaveChanges();
                return CreatedAtAction(nameof(Get), newObj);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }




           
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                var generacion = _context.Generaciones.Find(id);

                if (generacion == null)
                    return NotFound();

                //_context.Generaciones.Remove(generacion);
                generacion.EstaActivo = false;
                _context.Generaciones.Update(generacion);
                _context.SaveChanges();

                return Ok("Generacion eliminada correctamente");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


            
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] GeneracionEntity updateObj)
        {
            return Ok("Generacion actualizada correctamente");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] GeneracionSetDTO updateObj)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            var generacion = _context.Generaciones.Where(x=> x.Id==id && x.EstaActivo) .FirstOrDefault();

            if (generacion==null)
                return NotFound();

            generacion.Nombre= updateObj.Nombre;
           

            _context.Generaciones.Update(generacion);
            _context.SaveChanges();

            return Ok("Generacion actualizada parcialmente correctamente");
        }


    }

}

