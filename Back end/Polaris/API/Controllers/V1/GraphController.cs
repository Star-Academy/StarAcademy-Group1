using API.Services.GraphBusiness;
using Microsoft.AspNetCore.Mvc;
using Models.Banking;
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
            [FromQuery(Name = "node")] string[] nodeFilter,
            [FromQuery(Name = "edge")] string[] edgeFilter,
            [FromQuery(Name = "node")] Pagination nodePagination,
            [FromQuery(Name = "edge")] Pagination edgePagination,
            bool isSource = true,
            bool isTarget = true
        )
        {
            return Ok(_graphService
                .GetNodeExpansions(nodeId, isSource, isTarget,
                    nodeFilter, edgeFilter, null, null));
        }

        [HttpGet]
        [Route("expansion")]
        public ActionResult GetNodesExpansions(
            [FromQuery] string[] nodesIds,
            [FromQuery(Name = "node")] string[] nodeFilter,
            [FromQuery(Name = "edge")] string[] edgeFilter,
            [FromQuery(Name = "node")] Pagination nodePagination,
            [FromQuery(Name = "edge")] Pagination edgePagination,
            bool isSource = true,
            bool isTarget = true
        )
        {
            if((nodePagination.PageIndex == 0 && nodePagination.PageSize == 0) || (edgePagination.PageIndex == 0 && edgePagination.PageSize == 0))
                return Ok(_graphService
                .GetNodesExpansions(nodesIds, isSource, isTarget,
                    nodeFilter, edgeFilter, null, null));
            return Ok(_graphService
                .GetNodesExpansions(nodesIds, isSource, isTarget,
                    nodeFilter, edgeFilter, nodePagination, edgePagination));
        }

        [HttpGet]
        [Route("paths")]
        public ActionResult GetPaths(
            string sourceNodeId,
            string targetNodeId,
            [FromQuery(Name = "node")] string[] nodeFilter,
            [FromQuery(Name = "edge")] string[] edgeFilter,
            [FromQuery(Name = "node")] Pagination nodePagination,
            [FromQuery(Name = "edge")] Pagination edgePagination,
            int maxLength = 7
        )
        {
            return Ok(_graphService
                .GetPaths(sourceNodeId, targetNodeId, nodeFilter, edgeFilter, null, null, maxLength));
        }

        [HttpGet]
        [Route("max-flow")]
        public ActionResult GetMaxFlow(
            string sourceNodeId,
            string targetNodeId,
            [FromQuery(Name = "node")] string[] nodeFilter,
            [FromQuery(Name = "edge")] string[] edgeFilter,
            [FromQuery(Name = "node")] Pagination nodePagination,
            [FromQuery(Name = "edge")] Pagination edgePagination
        )
        {
            return Ok(_graphService
                .GetMaxFlow(sourceNodeId, targetNodeId, nodeFilter, edgeFilter, null, null));
        }

        [HttpGet]
        [Route("stats")]
        public ActionResult GetStats()
        {
            return Ok(_graphService.Stats());
        }
    }
}