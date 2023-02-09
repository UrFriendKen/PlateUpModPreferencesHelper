using Kitchen;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;

namespace KitchenModPreferencesHelper
{
    public enum OptionStyle
    {
        Text,
        Pips
    }

    public class Preference<T>
    {
        public readonly string MOD_GUID;
        public readonly string ID;
        public readonly string TITLE;
        public readonly string INFO;

        private readonly dynamic _kLPreference;
        private readonly Option<T> _kitchenOption;

        private Dictionary<T, string> _optionDict;

        public T Value
        {
            get
            {
                if (typeof(T) == typeof(bool))
                {
                    return (T)Convert.ChangeType(PreferenceUtils.Get<KitchenLib.BoolPreference>(MOD_GUID, ID).Value, typeof(T));
                }
                else if (typeof(T) == typeof(float))
                {
                    return (T)Convert.ChangeType(PreferenceUtils.Get<KitchenLib.FloatPreference>(MOD_GUID, ID).Value, typeof(T));
                }
                else if (typeof(T) == typeof(int))
                {
                    return (T)Convert.ChangeType(PreferenceUtils.Get<KitchenLib.IntPreference>(MOD_GUID, ID).Value, typeof(T));
                }
                else
                {
                    return (T)Convert.ChangeType(PreferenceUtils.Get<KitchenLib.StringPreference>(MOD_GUID, ID).Value, typeof(T));
                }
            }
            set
            {
                if (typeof(T) == typeof(bool))
                {
                    PreferenceUtils.Get<KitchenLib.BoolPreference>(MOD_GUID, ID).Value = (bool)Convert.ChangeType(value, typeof(T));
                }
                else if (typeof(T) == typeof(float))
                {
                    PreferenceUtils.Get<KitchenLib.FloatPreference>(MOD_GUID, ID).Value = (float)Convert.ChangeType(value, typeof(T));
                }
                else if (typeof(T) == typeof(int))
                {
                    PreferenceUtils.Get<KitchenLib.IntPreference>(MOD_GUID, ID).Value = (int)Convert.ChangeType(value, typeof(T));
                }
                else
                {
                    PreferenceUtils.Get<KitchenLib.StringPreference>(MOD_GUID, ID).Value = (string)Convert.ChangeType(value, typeof(T));
                }
            }
        }

        public Preference(string modGUID, string preferenceID, string displayString = "", string infoText = null)
        {
            MOD_GUID = modGUID;
            ID = preferenceID;
            TITLE = displayString;
            INFO = infoText;

            if (typeof(T) == typeof(bool))
            {
                _kLPreference = PreferenceUtils.Register<KitchenLib.BoolPreference>(modGUID, preferenceID, title);
            }
            else if (typeof(T) == typeof(float))
            {
                _kLPreference = PreferenceUtils.Register<KitchenLib.FloatPreference>(modGUID, preferenceID, title);
            }
            else if (typeof(T) == typeof(int))
            {
                _kLPreference = PreferenceUtils.Register<KitchenLib.IntPreference>(modGUID, preferenceID, title);
            }
            else if (typeof(T) == typeof(string))
            {
                _kLPreference = PreferenceUtils.Register<KitchenLib.StringPreference>(modGUID, preferenceID, title);
            }
            else
            {
                throw new ArgumentException("Type specified is not a supported type!", "T");
            }

            _optionDict = new Dictionary<T, string>();
        }

        public void Add(OptionStyle optionStyle)
        {
            
        }
    }
}
