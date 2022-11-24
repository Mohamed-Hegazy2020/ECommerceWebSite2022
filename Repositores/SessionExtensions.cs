using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MyECommerceWebSite2022.Repositores
{
    public static class SessionExtensions
    {
        public static T GetComplexData<T>(this ISession session, string key)
        {
            var data = session.GetString(key);
            if (data == null)
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(data);
        }

        public static void SetComplexData(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static int? GetShopingCarCount(this ISession session, string key)
        {
            var data = session.Get(key);
            if (data == null)
            {
                return 0;
            }
            return BitConverter.ToInt32(data, 0);
        }

        public static void SetShopingCarCount(this ISession session, string key, int value)
        {
            session.Set(key, BitConverter.GetBytes(value));
        }
    }
}
