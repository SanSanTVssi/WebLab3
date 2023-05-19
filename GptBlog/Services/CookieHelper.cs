namespace Backend.Services;

public static class CookieHelper
{
    public static void CreateCookie<T>(string name, T value, int expirationDays, HttpResponse response)
    {
        string cookieName = name;
        string cookieValue = Newtonsoft.Json.JsonConvert.SerializeObject(value);

        var cookieOptions = new CookieOptions
        {
            Expires = DateTime.Now.AddDays(expirationDays),
            Secure = true,
            HttpOnly = true
        };

        response.Cookies.Append(cookieName, cookieValue, cookieOptions);
    }

    public static void DeleteCookie(string name, HttpResponse response)
    {
        response.Cookies.Delete(name);
    }

    public static T DeserializeCookie<T>(string cookieString)
    {
        var cookieCollection = cookieString.Split(';');

        var properties = typeof(T).GetProperties()
            .ToDictionary(p => p.Name, p => p);

        var instance = Activator.CreateInstance<T>();

        foreach (var cookie in cookieCollection)
        {
            var cookiePair = cookie.Split('=');
            var key = cookiePair[0].Trim();
            var value = cookiePair[1].Trim();

            if (!properties.ContainsKey(key))
            {
                continue;
            }
            var property = properties[key];

            if (property.PropertyType == typeof(string))
            {
                property.SetValue(instance, value);
            }
            else
            {
                var convertedValue = Convert.ChangeType(value, property.PropertyType);
                property.SetValue(instance, convertedValue);
            }
        }

        return instance;
    }

    public static T DeserializeJsonCookie<T>(string cookieString) => Newtonsoft.Json.JsonConvert.DeserializeObject<T>(cookieString);

}