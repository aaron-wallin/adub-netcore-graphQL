using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using NetCoreGraphQL.Api.Models;

namespace NetCoreGraphQL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphController : ControllerBase
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _documentExecutor;

        public GraphController(ISchema schema, IDocumentExecuter documentExecutor)
        {
            _schema = schema;
            _documentExecutor = documentExecutor;
        }

        [HttpGet]
        public async Task<IActionResult> Get(GraphQLQuery query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            var inputs = query.Variables.ToInputs();
            var executeOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = inputs
            };

            var result = await _documentExecutor.ExecuteAsync(executeOptions).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            var inputs = query.Variables.ToInputs();
            var executeOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = inputs
            };

            var result = await _documentExecutor.ExecuteAsync(executeOptions).ConfigureAwait(false);

            if(result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}