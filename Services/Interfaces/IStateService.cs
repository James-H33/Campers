using Campers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campers.Services.Interfaces
{
    interface IStateService
    {
        public Task <ApplicationState> GetState();
        public Task UpdateState();
        public Task UpdateState(string key, dynamic value);
        public void WatchStateChange(Action<ApplicationState> callback);
    }
}
