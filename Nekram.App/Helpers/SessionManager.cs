/*
*!* Class Name: SessionManager
*!* Calls: None
*!* Description:
   This is a session manager class that deals with all session related objects

*!* Functions:
    Class contains generic methods to write and read to/from session objects

*!* Created By: Nkambwe Mark
*!* Creation Date:2020-01-04 07:45:00 00:000 AM
*/

using System;
using System.Web;

namespace Nekram.App.Helpers {

    public class SessionManager {

        /// <summary>
        /// Get session object by key
        /// </summary>
        /// <typeparam name="T">Session Object Type</typeparam>
        /// <param name="key">Session Object Key</param>
        /// <returns>
        /// Session object of type T
        /// </returns>
        public static T Get<T>(SessionKeys key) {
            var skey = Enum.GetName(typeof(SessionKeys), key);

            if (!Exits(skey)) {
                return default(T);
            }

            return (T)HttpContext.Current.Session[skey];

        }

        /// <summary>
        /// Get session object with key <paramref name="key"/> and default type <paramref name="defaultValue"/>
        /// </summary>
        /// <typeparam name="T">Session object type</typeparam>
        /// <param name="key">Session object key</param>
        /// <param name="defaultValue">Session object default value</param>
        /// <returns></returns>
        public static T Get<T>(SessionKeys key, T defaultValue) {
            var skey = Enum.GetName(typeof(SessionKeys), key);
            if (!Exits(skey)) {
                HttpContext.Current.Session[skey] = defaultValue;
            }

            return (T)HttpContext.Current.Session[skey];
        }

        /// <summary>
        /// Save object to session
        /// </summary>
        /// <typeparam name="T">Type of object to save to session</typeparam>
        /// <param name="key">Key of object to save to session</param>
        /// <param name="entity">Object to save to session</param>
        public static void Set<T>(SessionKeys key, T entity) {
            var skey = Enum.GetName(typeof(SessionKeys), key);
            HttpContext.Current.Session.Add(skey, entity);
        }

        /// <summary>
        /// Remove object from session with key <paramref name="key"/>
        /// </summary>
        /// <param name="key">Key of object to remove from session</param>
        public static void Remove(SessionKeys key) {
            var skey = Enum.GetName(typeof(SessionKeys), key);
            if (Exits(skey))
                HttpContext.Current.Session.Remove(skey);

        }

        /// <summary>
        /// Clear current session
        /// </summary>
        public static void Clear() {
            HttpContext.Current.Session.Abandon();
        }

        /// <summary>
        /// Check if session object is already set
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected static bool Exits(string key) {
            var exists = false;
            dynamic sessionObject = HttpContext.Current.Session[key];

            if (sessionObject != null)
                exists = true;

            return exists;
        }

        /// <summary>
        /// Get Seesion state data
        /// </summary>
        /// <param name="key">Key of session object to retrieve</param>
        /// <returns></returns>
        public static object Get(SessionKeys key) {
            var skey = Enum.GetName(typeof(SessionKeys), key);
            return HttpContext.Current.Session[skey];
        }

        /// <summary>
        /// Set Session data
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object Set(SessionKeys key, object value) {
            var skey = Enum.GetName(typeof(SessionKeys), key);
            return HttpContext.Current.Session[skey] = value;
        }
    }
}