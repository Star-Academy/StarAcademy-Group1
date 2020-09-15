using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using API.Services.Node;
using Models.GraphStructure;
using Elastic.Exceptions;
using Models.ResponsePagination;

namespace API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class NodesController : ControllerBase
    {
        private readonly INodeService<string> _nodeService;

        public NodesController(INodeService<string> nodeService)
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
            Node<string> node;
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

        [HttpGet("nodes")]
        public IActionResult GetNodesByFilter(string[] filter = null, [FromQuery] Pagination pagination = null)
        {
            return Ok(_nodeService.GetNodesByFilter(filter, pagination));
        }

        [HttpPost]
        public IActionResult AddNewNode([FromBody] Node<string> node)
        {
            _nodeService.InsertNode(node);
            Console.WriteLine(ControllerContext.ActionDescriptor.AttributeRouteInfo.Name);
            return Created($"api/v1/nodes/{node.Id}", node);
        }

        [HttpPut]
        public IActionResult UpdateExistingNode([FromBody] Node<string> newNode)
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