using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR; 
using Occon.Server.Api.DbStorage;
using Occon.Server.Api.HubConfig;
using Occon.Server.Api.DbStorage;
using System.Threading;

namespace Occon.Server.Api.Controllers
{   
    /*https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-3.0*/
    [Route("api/[OcconControl]")]
    [ApiController]
    public class TimerManager
    {
        private AutoResetEvent _autoReset;
        private Action _action;
        private readonly Timer _timer;

        public DateTime TimerStarted { get; }

        public TimerManager(Action action)
        {
            _action = action;
            _autoReset = new AutoResetEvent(false);
            _timer = new Timer(Execute, _autoReset, 1000, 1000);
            TimerStarted = DateTime.Now;
        }

        public void Execute(object stateInfo)
        {
            _action();
        }
    }
    public class OcconControl : ControllerBase
    {
        private IHubContext<OcconHub> _hub;

        public OcconControl(IHubContext<OcconHub> hub)
        {
            _hub = hub;
        }
        public IActionResult Get()
        {
            var timerManager = new TimerManager(() => _hub.Clients.All.SendAsync("TransferData", DbManager.GetData(false)));
            return Ok(DbManager.GetData(false));
        }


    }
}