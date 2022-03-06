using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;


namespace TodoApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly TodoContext _context;

        public AccountController(TodoContext context)
        {
            _context = context;

            if(_context.Accounts.Count() == 0)
            {
                _context.Accounts.Add(new Account { username = "SampleUser", password = "blah" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Account>> GetAll()
        {
            return _context.Accounts.ToList();
        }


        [HttpGet("{id}")]
        public ActionResult<Account> Get(int id)
        {
            var account = _context.Accounts.Find(id);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }

        [HttpPost]
        public IActionResult Create(Account account)
        {
            List<Account> existingAccounts = _context.Accounts.ToList();
            foreach(Account acc in existingAccounts)
            {
                if(acc.username == account.username)
                {
                    return Conflict("Please choose a different username");
                }
            }

            return CreatedAtAction(nameof(Create), new { id = account.AccountId }, account);
        }



    }
}
