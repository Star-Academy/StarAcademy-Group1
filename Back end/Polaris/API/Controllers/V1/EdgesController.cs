using API.Services.EdgeBusiness;
using Elastic.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Models.Banking;
using Models.Network;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class EdgesController : ControllerBase
    {
        private readonly IEdgeService<Transaction, string, string> _edgeService;

        public EdgesController(IEdgeService<Transaction, string, string> edgeService)
        {
            _edgeService = edgeService;
        }

        [HttpGet]
        [Route("{edgeId}")]
        public IActionResult GetEdgeById(string edgeId)
        {
            Edge<Transaction, string, string> edge;
            try
            {
                edge = _edgeService.GetEdgeById(edgeId);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound($"EdgeNotFound: {e.Message}");
            }
            return Ok(edge);
        }

        [HttpDelete]
        [Route("{edgeId}")]
        public IActionResult DeleteEdgeById(string edgeId)
        {
            try
            {
                _edgeService.DeleteEdgeById(edgeId);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound($"EdgeNotFound: {e.Message}");
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult GetEdgesByFilter(/*string[] filter = null, [FromQuery] Pagination pagination = null*/)
        {
            return Ok(_edgeService.GetEdgesByFilter(new string[] { }, null));
        }

        [HttpPost]
        public IActionResult AddNewEdge([FromBody] Edge<Transaction, string, string> edge)
        {
            _edgeService.InsertEdge(edge);
            return Created($"api/v1/edges/{edge.Id}", edge);
        }

        [HttpPut]
        public IActionResult UpdateExistingEdge([FromBody] Edge<Transaction, string, string> edge)
        {
            _edgeService.UpdateEdge(edge);
            return Ok();
        }
    }
}