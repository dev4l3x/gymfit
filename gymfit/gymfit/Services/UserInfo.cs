using System;
using System.Collections.Generic;
using System.Text;

namespace GymFit.Services
{
    using System.Runtime.CompilerServices;

    public interface IUserInfo
    {
        string Username { get; set; }
        string Token { get; set; }
        DateTime TokenCaducity { get; set; }
        int ActiveRoutine { get; set; }
    }

    public class UserInfo : IUserInfo
    {
        private ISettingsStore _settingsStore;
        public string Username
        {
            get => GetSetting<string>();
            set => SetSetting(value);
        }

        public string Token
        {
            get => GetSetting<string>();
            set => SetSetting(value);
        }

        public DateTime TokenCaducity
        {
            get => GetSetting<DateTime>();
            set => SetSetting(value);
        }

        public int ActiveRoutine
        {
            get => GetSetting<int>();
            set => SetSetting(value);
        }

        public UserInfo(ISettingsStore settingsStore)
        {
            _settingsStore = settingsStore;
        }

        private void SetSetting<TValue>(TValue value, [CallerMemberName] string settingName = "")
        {
            _settingsStore.SetAsync(settingName, value);
        }

        private TValue GetSetting<TValue>([CallerMemberName] string settingName = "")
        {
            return  _settingsStore.GetAsync<TValue>(settingName);
        }

    }
}
