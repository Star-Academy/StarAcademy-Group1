using Microsoft.AspNetCore.Mvc;

//using API.Services.Edge;
using Models.ResponsePagination;
using Models.GraphStructure;
using Elastic.Exceptions;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class EdgesController : ControllerBase
    {
        // private readonly IEdgeService<string, string> _edgeService;

        // public EdgesController(IEdgeService<string, string> edgeService)
        // {
        //     _edgeService = edgeService;
        // }

        // [HttpGet("{edgeId}")]
        // public IActionResult GetEdgeById(string edgeId)
        // {
        //     Edge<string, string> edge;
        //     try
        //     {
        //         edge = _edgeService.GetEdgeById(edgeId);
        //     }
        //     catch (EntityNotFoundException e)
        //     {
        //         return NotFound($"EdgeNotFound: {e.Message}");
        //     }
        //     return Ok(edge);
        // }

        // [HttpDelete("{edgeId}")]
        // public IActionResult DeleteEdgeById(string edgeId)
        // {
        //     try
        //     {
        //         _edgeService.DeleteEdgeById(edgeId);
        //     }
        //     catch (EntityNotFoundException e)
        //     {
        //         return NotFound($"EdgeNotFound: {e.Message}");
        //     }
        //     return Ok();
        // }

        // [HttpGet]
        // public IActionResult GetEdgesByFilter(string[] filter = null, [FromQuery] Pagination pagination = null)
        // {
        //     return Ok(_edgeService.GetEdgesByFilter(filter, pagination));
        // }

        // [HttpPost]
        // public IActionResult AddNewEdge([FromBody] Edge<string, string> edge)
        // {
        //     _edgeService.InsertEdge(edge);
        //     return Created($"api/v1/edges/{edge.Id}", edge);
        // }

        // [HttpPut]
        // public IActionResult UpdateExistingEdge([FromBody] Edge<string, string> edge)
        // {
        //     _edgeService.UpdateEdge(edge);
        //     return Ok();
        // }
    }
}