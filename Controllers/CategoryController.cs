using Microsoft.AspNetCore.Mvc;
using ajay_chouhan.Model;
using ajay_chouhan.Data;

namespace ajay_chouhan
{
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ajay_chouhanContext _context;

        public CategoryController(ajay_chouhanContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Category model)
        {
            _context.Category.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var entityData = _context.Category;
            return Ok(entityData);
        }

        [HttpGet]
        [Route("{entityId:int}")]
        public IActionResult GetById([FromRoute] int entityId)
        {
            var entityData = _context.Category.FirstOrDefault(entity => entity.Id == entityId);
            return Ok(entityData);
        }

        [HttpDelete]
        [Route("{entityId:int}")]
        public IActionResult DeleteById([FromRoute] int entityId)
        {
            var entityData = _context.Category.FirstOrDefault(entity => entity.Id == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Category.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        [HttpPut]
        [Route("{entityId:int}")]
        public IActionResult UpdateById(int entityId, [FromBody] Category updatedEntity)
        {
            if (entityId != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            var entityData = _context.Category.FirstOrDefault(entity => entity.Id == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            var propertiesToUpdate = typeof(Category).GetProperties().Where(property => property.Name != "Id").ToList();
            foreach (var property in propertiesToUpdate)
            {
                property.SetValue(entityData, property.GetValue(updatedEntity));
            }

            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}