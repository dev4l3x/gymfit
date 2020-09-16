namespace GymFit.Services
{
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Xamarin.Essentials;

    public interface ISettingsStore
    {

        void SetAsync<TValue>(string settingName, TValue value);
        TValue GetAsync<TValue>(string settingName);

    }

    public class SettingsStore : ISettingsStore
    {
        public void SetAsync<TValue>(string settingName, TValue value)
        {
            if (App.Current.Properties.ContainsKey(settingName))
            {
                App.Current.Properties[settingName] = value;
            }
            else
            {
                App.Current.Properties.Add(settingName, value);
            }
            App.Current.SavePropertiesAsync();
        }

        public TValue GetAsync<TValue>(string settingName)
        {
            if (!App.Current.Properties.ContainsKey(settingName))
                return default;
            return (TValue)App.Current.Properties[settingName];
        }
    }

    //public class SettingsStore : ISettingsStore
    //{

    //    private ISerializer _serializer;
    //    public SettingsStore(ISerializer serializer)
    //    {
    //        _serializer = serializer;
    //    }

    //    public async Task SetAsync<TValue>(string settingName, TValue value)
    //    {
    //        var serializedValue = _serializer.SerializeObject(value);

    //        await SecureStorage.SetAsync(settingName, serializedValue);
    //    }

    //    public async Task<TValue> GetAsync<TValue>(string settingName)
    //    {
    //        var serializedValue = await SecureStorage.GetAsync(settingName);
    //        if (serializedValue == null)
    //        {
    //            return default;
    //        }
    //        return _serializer.DeserializeObject<TValue>(serializedValue);
    //    }
    //}

    public interface ISerializer
    {
        string SerializeObject(object objectToSerialize);
        TValue DeserializeObject<TValue>(string objectToDeserialize);
    }

    public class JsonSerializer : ISerializer
    {
        public string SerializeObject(object objectToSerialize)
        {
            if (objectToSerialize is string)
            {
                return objectToSerialize as string;
            }
            return JsonConvert.SerializeObject(objectToSerialize);
        }

        public TValue DeserializeObject<TValue>(string objectToDeserialize)
        {
            if (objectToDeserialize is TValue value)
                return value;
            return JsonConvert.DeserializeObject<TValue>(objectToDeserialize);
        }

    }
}
