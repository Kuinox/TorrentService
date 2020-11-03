using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CK.DB.Actor;
using CK.DB.User.UserPassword;
using CK.SqlServer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TorrentService
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class SignupController : ControllerBase
    {
        readonly ISqlTransactionCallContext _ctx;
        readonly UserPasswordTable _userPasswordTable;
        readonly UserTable _userTable;

        public SignupController( ISqlTransactionCallContext sqlTransactionCallContext, UserPasswordTable userPasswordTable, UserTable userTable )
        {
            _ctx = sqlTransactionCallContext;
            _userPasswordTable = userPasswordTable;
            _userTable = userTable;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task Post( string username, string password )
        {
            int userId = await _userTable.CreateUserAsync( _ctx, 1, username );
            await _userPasswordTable.CreateOrUpdatePasswordUserAsync( _ctx, 1, userId, password );
        }
    }
}
