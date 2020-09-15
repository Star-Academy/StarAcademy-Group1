using Microsoft.AspNetCore.Mvc;

using API.Services.Importer;
using API.Services.Utils;
using Models.Banking;

namespace API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
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
        public ActionResult ImportAccount(string indexName, [FromBody] string text)
        {
            _bankAccountService.Import(text, new CsvStringParser<BankAccount>(), indexName);
            return Ok();
        }

        [HttpPost]
        [Route("transaction/{indexName}")]
        public ActionResult ImportTransaction(string indexName, [FromBody] string text)
        {
            _transactionService.Import(text, new CsvStringParser<Transaction>(), indexName);
            return Ok();
        }
    }
}