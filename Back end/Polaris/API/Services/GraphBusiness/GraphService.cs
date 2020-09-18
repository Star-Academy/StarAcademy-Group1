using System.Collections.Generic;
using System.Linq;

using API.Services.EdgeBusiness;
using Elastic.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Models.Banking;
using Models.Network;
using API.Services.NodeBusiness;
using Elastic.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Models.Banking;
using Models.Network;
using System;

namespace API.Services.GraphBusiness
{
    public class GraphService : IGraphService
    {
        private readonly IEdgeService<Transaction, string, string> _edgeService;
        private readonly INodeService<BankAccount, string> _nodeService;

        public GraphService(INodeService<BankAccount, string> nodeService, IEdgeService<Transaction, string, string> edgeService)
        {
            _nodeService = nodeService;
            _edgeService = edgeService;
        }

        public Dictionary<string, string> Stats()
        {
            var stats = new Dictionary<string, string>();
            stats.Add("nodesCount", _nodeService.GetNodesByFilter(null, null).Count().ToString());
            stats.Add("edgesCount", _edgeService.GetEdgesByFilter(null, null).Count().ToString());
            return stats;
        }
    }
}