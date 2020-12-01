using Campers.Models;
using Campers.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Campers.Services
{
    public class StateService : IStateService
    {
        private ApplicationState state = new ApplicationState();

        public Action<ApplicationState> OnChange;

        public async Task<ApplicationState> GetState()
        {
            return await Task.FromResult(state);
        }

        public void WatchStateChange(Action<ApplicationState> callback)
        {
            OnChange += callback;
        }

        public async Task UpdateState()
        {
            await Task.Run(() => OnChange?.Invoke(state));
        }

        public async Task UpdateState(string key, dynamic value)
        {
            Type targetType = typeof(ApplicationState);
            PropertyInfo property = targetType.GetProperty(key);
            property.SetValue(this, value, null);

            await Task.Run(() => OnChange?.Invoke(state));
        }
    }
}
