using Microsoft.AspNetCore.Mvc;
using ajaychouhan1.Model;
using ajaychouhan1.Data;
using ajaychouhan1.Filter;

namespace ajaychouhan1
{
    [Route("api/[controller]")]
    public class DemoProductController : ControllerBase
    {
        private readonly ajaychouhan1Context _context;

        public DemoProductController(ajaychouhan1Context context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] DemoProduct model)
        {
            _context.DemoProduct.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string filters)
        {
            var filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            var query = _context.Country.AsQueryable();
            var result = FilterService<DemoProduct>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        [HttpGet]
        [Route("{entityId:Guid}")]
        public IActionResult GetById([FromRoute] Guid entityId)
        {
            var entityData = _context.DemoProduct.FirstOrDefault(entity => entity.Id == entityId);
            return Ok(entityData);
        }

        [HttpDelete]
        [Route("{entityId:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid entityId)
        {
            var entityData = _context.DemoProduct.FirstOrDefault(entity => entity.Id == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.DemoProduct.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        [HttpPut]
        [Route("{entityId:Guid}")]
        public IActionResult UpdateById(Guid entityId, [FromBody] DemoProduct updatedEntity)
        {
            if (entityId != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            var entityData = _context.DemoProduct.FirstOrDefault(entity => entity.Id == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            var propertiesToUpdate = typeof(DemoProduct).GetProperties().Where(property => property.Name != "Id").ToList();
            foreach (var property in propertiesToUpdate)
            {
                property.SetValue(entityData, property.GetValue(updatedEntity));
            }

            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}