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
        public ActionResult GetNodeExpansions(
            string nodeId,
            bool isSource = true,
            bool isTarget = true,
            [FromQuery(Name = "node")] string[] nodeFilter = null,
            [FromQuery(Name = "edge")] string[] edgeFilter = null,
            [FromQuery(Name = "node")] Pagination nodePagination = null,
            [FromQuery(Name = "edge")] Pagination edgePagination = null
        )
        {
            return Ok(_graphService
                .GetNodeExpansions(nodeId, isSource, isTarget,
                    nodeFilter, edgeFilter, nodePagination, edgePagination));
        }

        [HttpGet]
        [Route("expansion")]
        public ActionResult GetNodesExpansions(
            [FromQuery]string[] nodesIds,
            bool isSource = true,
            bool isTarget = true,
            [FromQuery(Name = "node")] string[] nodeFilter = null,
            [FromQuery(Name = "edge")] string[] edgeFilter = null,
            [FromQuery(Name = "node")] Pagination nodePagination = null,
            [FromQuery(Name = "edge")] Pagination edgePagination = null
        )
        {
            return Ok(_graphService
                .GetNodesExpansions(nodesIds, isSource, isTarget,
                    nodeFilter, edgeFilter, nodePagination, edgePagination));
        }

        [HttpGet]
        [Route("paths")]
        public ActionResult GetPaths(
            string sourceNodeId,
            string targetNodeId,
            [FromQuery(Name = "node")] string[] nodeFilter = null,
            [FromQuery(Name = "edge")] string[] edgeFilter = null,
            [FromQuery(Name = "node")] Pagination nodePagination = null,
            [FromQuery(Name = "edge")] Pagination edgePagination = null
        )
        {
            return Ok(_graphService
                .GetPaths(sourceNodeId, targetNodeId, nodeFilter, edgeFilter, nodePagination, edgePagination));
        }

        [HttpGet]
        [Route("max-flow")]
        public ActionResult GetMaxFlow(
            string sourceNodeId,
            string targetNodeId,
            [FromQuery(Name = "node")] string[] nodeFilter = null,
            [FromQuery(Name = "edge")] string[] edgeFilter = null,
            [FromQuery(Name = "node")] Pagination nodePagination = null,
            [FromQuery(Name = "edge")] Pagination edgePagination = null
        )
        {
            return Ok(_graphService
                .GetMaxFlow(sourceNodeId, targetNodeId, nodeFilter, edgeFilter, nodePagination, edgePagination));
        }

        [HttpGet]
        [Route("stats")]
        public ActionResult GetStats()
        {
            return Ok(_graphService.Stats());
        }
    }
}