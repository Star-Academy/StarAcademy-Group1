using API.Services.Importer;
using API.Services.Utils;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using Models.Banking;

namespace API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class ImporterController : ControllerBase
    {
        IImporterService<BankAccount> _bankAccountService;
        IImporterService<Transaction> _transactionService;

        public ImporterController(
            IImporterService<BankAccount> bankAccountService,
            IImporterService<Transaction> transactionService
        )
        {
            _bankAccountService = bankAccountService;
            _transactionService = transactionService;
        }

        [HttpPost]
        [Route("account/{indexName}")]
        public async Task<ActionResult> ImportAccountAsync(string indexName)
        {
            string text;
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                text = await reader.ReadToEndAsync();
            }
            _bankAccountService.Import(text, new CsvStringParser<BankAccount>(), indexName);
            return Ok();
        }

        [HttpPost]
        [Route("transaction/{indexName}")]
        public async Task<ActionResult> ImportTransactionAsync(string indexName)
        {
            string text;
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                text = await reader.ReadToEndAsync();
            }
            _transactionService.Import(text, new CsvStringParser<Transaction>(), indexName);
            return Ok();
        }
    }
}