using System.Collections.Generic;

using Models;

namespace API.Services.GraphBusiness
{
    public interface IGraphService
    {
        Dictionary<string, string> Stats();
    }
}