/*Class Name : StateHelper
 *Description: Helper class that helps in accessing HttpApplicationState class
 */
using System;
using System.Collections.Generic;
using System.Web;

namespace Nekram.App.Helpers {
    public class StateHelper {

        /// <summary>
        /// Get Application State object
        /// </summary>
        /// <param name="key">Key for the Application state to retrieve</param>
        /// <param name="defaultValue">Optional value to be passed as object in case state object does not exist.</param>
        /// <returns>
        /// Application State object or the default if object does not exist
        /// </returns>
        public static object Get(StateKeys key, object defaultValue = null) {
            var skey = Enum.GetName(typeof(StateKeys), key);

            if (HttpContext.Current.Application[skey] == null && defaultValue != null)
                HttpContext.Current.Application[skey] = defaultValue;

            return HttpContext.Current.Application[skey];
        }

        /// <summary>
        /// Set Application State object
        /// </summary>
        /// <param name="key">Key to assign the Application state</param>
        /// <param name="value">Value assigned to application state</param>
        /// <returns>
        /// Application State object with the set value
        /// </returns>
        public static object Set(StateKeys key, object value) {
            return HttpContext.Current.Application[Enum.GetName(typeof(StateKeys),
                key)] = value;
        }

        /// <summary>
        /// Get multiple application state values
        /// </summary>
        /// <param name="keys">list of keys for application sate values to be retrieved</param>
        /// <returns>
        /// Collection of key/value pairs of application state values
        /// </returns>
        public static IDictionary<StateKeys, object> GetMultiple(params StateKeys[] keys) {
            var results = new Dictionary<StateKeys, object>();
            var state = HttpContext.Current.Application;
            state.Lock();

            foreach (var key in keys) {
                var skey = Enum.GetName(typeof(StateKeys), key);
                results.Add(key, state[skey]);
            }

            state.UnLock();
            return results;
        }

        /// <summary>
        /// Set multiple application sate values
        /// </summary>
        /// <param name="data">Application state data</param>
        public static void SetMultiple(IDictionary<StateKeys, object> data) {
            var state = HttpContext.Current.Application;
            state.Lock();
            foreach (var key in data.Keys) {
                var skey = Enum.GetName(typeof(StateKeys), key);
                state[skey] = data[key];
            }
            state.UnLock();
        }
    }
}