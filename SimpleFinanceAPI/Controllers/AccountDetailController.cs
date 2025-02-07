using Microsoft.AspNetCore.Mvc;
using SimpleFinanceAPI.Data;
using SimpleFinanceAPI.Interfaces;
using SimpleFinanceAPI.Models;

namespace SimpleFinanceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountDetailController : Controller
    {
        private readonly IAccountDetailRepository _accountDetailRepository;
        private readonly DataContext _context;

        public AccountDetailController(IAccountDetailRepository accountDetailRepository, DataContext dataContext)
        {
            _accountDetailRepository = accountDetailRepository;
            _context = dataContext;
        }

        /*
         * Get All Account Details in the Database
         * api/AccountDetail
         */
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AccountDetail>))]
        public async Task<IActionResult> GetAllAccountDetails()
        {
            var accountDetails = await _accountDetailRepository.GetAllAccountDetails();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(accountDetails);
        }

        /*
         * Get All Account Details associated to a Account Header
         * api/AccountDetail/{accountHeaderId}
         */
        [HttpGet("{accountHeaderId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AccountDetail>))]
        public async Task<IActionResult> GetAccountDetails(Guid accountHeaderId)
        {
            var accountDetails = await _accountDetailRepository.GetAccountDetailsByHeaderId(accountHeaderId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(accountDetails);
        }

        /*
         * Get An Account Detail by Detail Id
         * api/AccountDetail/{accountDetailId}
         */
        [HttpGet("{accountDetailId}")]
        [ProducesResponseType(200, Type = typeof(AccountDetail))]
        public async Task<IActionResult> GetAccountDetail(Guid accountDetailId)
        {
            var accountDetail = await _accountDetailRepository.GetAccountDetail(accountDetailId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(accountDetail);
        }

        /*
         * Create an Account Detail
         * api/AccountDetail
         */
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(AccountDetail))]
        public async Task<IActionResult> CreateAccountDetail (AccountDetail accountDetail)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _accountDetailRepository.CreateAccountDetail(accountDetail);
            return Ok();
        }

        /*
         * Delete an Account Detail By Id
         * api/AccountDetail/{accountDetailId}
         */
        [HttpDelete("{accountDetailId}")]
        [ProducesResponseType(200, Type = typeof(AccountDetail))]
        public async Task<IActionResult> DeleteAccountDetail(Guid accountDetailId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var accountDetail = await _accountDetailRepository.DeleteAccountDetail(accountDetailId);
            return Ok(accountDetail);
        }

        /*
         * Update an Account Detail
         * api/AccountDetail
         */
        [HttpPut("{accountDetailId}")]
        [ProducesResponseType(200, Type = typeof(AccountDetail))]
        public async Task<IActionResult> UpdateAccountDetail(AccountDetail existingAccountDetail)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var accountDetail =  await _accountDetailRepository.UpdateAccountDetail(existingAccountDetail);
            return Ok(accountDetail);
        }
    }
}
