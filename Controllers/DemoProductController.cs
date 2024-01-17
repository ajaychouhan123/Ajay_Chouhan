using Microsoft.AspNetCore.Mvc;
using ajay_chouhan.Model;
using ajay_chouhan.Data;

namespace ajay_chouhan
{
    [Route("api/[controller]")]
    public class DemoProductController : ControllerBase
    {
        private readonly ajay_chouhanContext _context;

        public DemoProductController(ajay_chouhanContext context)
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
        public IActionResult Get()
        {
            var entityData = _context.DemoProduct;
            return Ok(entityData);
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