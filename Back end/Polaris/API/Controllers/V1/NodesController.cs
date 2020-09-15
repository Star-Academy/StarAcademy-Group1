using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using API.Services.NodeBusiness;
using Models.Network;
using Elastic.Exceptions;
using Models.Response;
using Models.Banking;

namespace API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class NodesController : ControllerBase
    {
        private readonly INodeService<BankAccount, string> _nodeService;

        public NodesController(INodeService<BankAccount, string> nodeService)
        {
            _nodeService = nodeService;
        }

        [HttpGet]
        [Route("typing")]
        public IActionResult GetTyping()
        {
            return Ok("Some fields");
        }

        [HttpGet]
        [Route("{nodeId}")]
        public IActionResult GetNodeById(string nodeId)
        {
            Node<BankAccount, string> node;
            try
            {
                node = _nodeService.GetNodeById(nodeId);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound($"NodeNotFound: {e.Message}");
            }
            return Ok(node);
        }

        [HttpDelete]
        [Route("{nodeId}")]
        public IActionResult DeleteNodeById(string nodeId)
        {
            try
            {
                _nodeService.DeleteNodeById(nodeId);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound($"NodeNotFound: {e.Message}");
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult GetNodesByFilter(/*string[] filter = null, [FromQuery] Pagination pagination = null*/)
        {
            return Ok(_nodeService.GetNodesByFilter(new string[]{}, null));
        }

        [HttpPost]
        public IActionResult AddNewNode([FromBody] Node<BankAccount, string> node)
        {
            _nodeService.InsertNode(node);
            Console.WriteLine(ControllerContext.ActionDescriptor.AttributeRouteInfo.Name);
            return Created($"api/v1/nodes/{node.Id}", node);
        }

        [HttpPut]
        public IActionResult UpdateExistingNode([FromBody] Node<BankAccount, string> newNode)
        {
            try
            {
                _nodeService.UpdateNode(newNode);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound($"NodeNotFound: {e.Message}");
            }
            return Ok();
        }
    }
}