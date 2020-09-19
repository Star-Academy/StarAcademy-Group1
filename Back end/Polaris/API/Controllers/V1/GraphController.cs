using API.Services.GraphBusiness;
using Microsoft.AspNetCore.Mvc;
using Models.Banking;
using Models;
using Models.Response;

namespace API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class GraphController : ControllerBase
    {
        private readonly IGraphService<string, BankAccount, string, Transaction> _graphService;

        public GraphController(IGraphService<string, BankAccount, string, Transaction> graphService)
        {
            _graphService = graphService;
        }

        [HttpGet]
        public ActionResult GetWholeGraph()
        {
            return Ok(_graphService.GetWholeGraph());
        }

        [HttpGet]
        [Route("expansion/{nodeId}")]
        public ActionResult ExpandSingleNode(string nodeId, bool source = false,
            bool target = false, string[] filter = null, Pagination pagination = null)
        {
            return Ok(_graphService.GetExpansion(nodeId, source, target, filter, pagination));
        }

        [HttpGet]
        [Route("expansion")]
        public ActionResult ExpandNodes()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        [Route("paths")]
        public ActionResult GetPaths(
            string sourceNodeId,
            string targetNodeId,
            string[] filter = null,
            Pagination pagination = null
        )
        {
            return Ok(_graphService.GetPaths(sourceNodeId, targetNodeId, filter, pagination));
        }

        [HttpGet]
        [Route("max-flow")]
        public ActionResult GetMaxFlow(
            string sourceNodeId,
            string targetNodeId,
            string[] filter = null,
            Pagination pagination = null
        )
        {
            return Ok(_graphService.GetMaxFlow(sourceNodeId, targetNodeId, filter, pagination));
        }

        [HttpGet]
        [Route("stats")]
        public ActionResult GetStats()
        {
            return Ok(_graphService.Stats());
        }
    }
}