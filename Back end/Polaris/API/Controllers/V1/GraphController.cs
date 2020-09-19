using API.Services.GraphBusiness;
using Microsoft.AspNetCore.Mvc;
using Models.Network;
using Models.Banking;


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
            throw new System.NotImplementedException();
        }

        [HttpGet]
        [Route("expansion/{nodeId}")]
        public ActionResult ExpandSingleNode(string nodeId)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        [Route("expansion")]
        public ActionResult ExpandNodes()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        [Route("paths")]
        public ActionResult GetPaths()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        [Route("max-flow")]
        public ActionResult GetMaxFlow()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        [Route("stats")]
        public ActionResult GetStats()
        {
            return Ok(_graphService.Stats());
        }
    }
}