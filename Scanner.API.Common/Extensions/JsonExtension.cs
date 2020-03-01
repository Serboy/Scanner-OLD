using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Scanner.API.Common.Extensions {
    public static class JsonExtension {
        public static T GetJobjectValue<T>(this JObject jObject, string key) {
            var obj = jObject[key];
            if (obj == null)
                return default(T);

            return obj.ToObject<T>();
        }

        public static T GetJobjectValue<T>(this JToken jToken, string key) {
            var obj = jToken[key];
            if (obj == null)
                return default(T);

            return obj.ToObject<T>();
        }

        public static JToken Rename(this JToken json, Dictionary<string, string> map) {
            return Rename(json, name => map.ContainsKey(name) ? map[name] : name);
        }

        public static JToken Rename(this JToken json, Func<string, string> map) {
            var prop = json as JProperty;
            if (prop != null) {
                return new JProperty(map(prop.Name), Rename(prop.Value, map));
            }

            var arr = json as JArray;
            if (arr != null) {
                var cont = arr.Select(el => Rename(el, map));
                return new JArray(cont);
            }

            var o = json as JObject;
            if (o != null) {
                var cont = o.Properties().Select(el => Rename(el, map));
                return new JObject(cont);
            }

            return json;
        }

        public static JToken GetFirstFromJarray(this string jsonStr) {
            JToken jArray;

            if (!IsValidateJson(jsonStr, out jArray))
                return null;

            if (jArray is JArray && jArray.HasValues)
                return jArray.FirstOrDefault();

            return null;
        }

        public static JToken GetFirstFromJarray(this JToken jToken) {
            if (jToken is JArray && jToken.HasValues)
                return jToken.FirstOrDefault();

            return null;
        }

        public static JToken ValidateJson(this string s) {
            try {
                var jToken = JToken.Parse(s);
                return jToken;
            } catch {
                return null;
            }
        }

        public static bool IsValidateJson(string s, out JToken jToken) {
            try {
                jToken = JToken.Parse(s);
                return true;
            } catch {
                jToken = null;
                return false;
            }
        }

        public static IDictionary<string, object> ToDictionary(this JObject jObj) {
            if (jObj == null)
                return null;

            var result = jObj.ToObject<Dictionary<string, object>>();

            var keys = (from r in result
                        let key = r.Key
                        let value = r.Value
                        where value.GetType() == typeof(JObject)
                        select key).ToList();

            keys.ForEach(key => result[key] = ToDictionary(result[key] as JObject));

            return result;
        }
    }
}
