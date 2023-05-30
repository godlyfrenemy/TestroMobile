using Xamarin.Essentials;

namespace Testro.Models
{
    public class User
    {
        public readonly static long UNKNOWN_ID = -1;

        private static long _userId = -1;
        public static long UserId
        {
            get => _userId;
            set
            {
                _userId = value;
                Preferences.Set("USER_ID", value);
            }
        }
        private static long _userDataId = -1;
        public static long UserDataId
        {
            get => _userDataId;
            set
            {
                _userDataId = value;
                Preferences.Set("USER_DATA_ID", value);
            }
        }
    }
}
