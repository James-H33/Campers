using Campers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campers.Services.Interfaces
{
  interface IStateService
  {
    Task <ApplicationState> GetState();
    Task UpdateState();
    Task UpdateState(string key, dynamic value);
    void WatchStateChange(Action<ApplicationState> callback);
  }
}
