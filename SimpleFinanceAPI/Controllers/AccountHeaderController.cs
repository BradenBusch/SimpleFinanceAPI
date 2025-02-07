using Microsoft.AspNetCore.Mvc;
using SimpleFinanceAPI.Data;
using SimpleFinanceAPI.Interfaces;
using SimpleFinanceAPI.Models;
using SimpleFinanceAPI.Repository;

namespace SimpleFinanceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountHeaderController : Controller
    {
        private readonly IAccountHeaderRepository _accountHeaderRepository;
        private readonly DataContext _context;

        public AccountHeaderController(IAccountHeaderRepository accountHeaderRepository, DataContext context)
        {
            _accountHeaderRepository = accountHeaderRepository;
            _context = context;
        }

        /*
         * Get All Account Headers in the Database
         * api/AccountHeader
         */
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AccountHeader>))]
        public async Task<IActionResult> GetAccountHeaders()
        {
            var accountHeaders = await _accountHeaderRepository.GetAccountHeaders();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(accountHeaders);
        }

        /*
         * Get All Account Headers tied to a UserId
         * api/AccountHeader/{UserId}
         */
        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AccountHeader>))]
        public async Task<IActionResult> GetAccountHeadersByUserId(Guid userId)
        {
            var accountHeaders = await _accountHeaderRepository.GetAccountHeadersByUserId(userId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(accountHeaders);
        }

        /*
         * Get AccountHeader By Id
         * api/AccountHeader/{AccountId}
         */
        [HttpGet("{accountId}")]
        [ProducesResponseType(200, Type = typeof(AccountHeader))]
        public async Task<IActionResult> GetAccountHeaderByAccountId(Guid accountId)
        {
            var accountHeader = await _accountHeaderRepository.GetAccountHeaderByAccountId(accountId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(accountHeader);
        }

        /*
         * Create an Account Header
         * api/AccountHeader
         */
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(AccountHeader))]
        public async Task<IActionResult> CreateAccountHeader(AccountHeader accountHeader)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var createdAccountHeader = await _accountHeaderRepository.CreateAccountHeader(accountHeader);
            return Ok(createdAccountHeader);
        }

        /*
         * Delete an Account Header By Id
         * api/AccountHeader
         */
        //api/AccountHeader/{accountHeaderId}
        [HttpDelete("{accountDetailId}")]
        [ProducesResponseType(200, Type = typeof(AccountHeader))]
        public async Task<IActionResult> DeleteAccountHeader(Guid accountHeaderId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var deletedAccountHeader = await _accountHeaderRepository.DeleteAccountHeader(accountHeaderId);
            return Ok(deletedAccountHeader);
        }

        /*
         * Update an Account Header
         * api/AccountHeader
         */
        [HttpPut("{accountDetailId}")]
        [ProducesResponseType(200, Type = typeof(AccountHeader))]
        public async Task<IActionResult> UpdateAccountHeader(AccountHeader existingAccountHeader)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var accountHeader = await _accountHeaderRepository.UpdateAccountHeader(existingAccountHeader);
            return Ok(accountHeader);
        }
    }
}
