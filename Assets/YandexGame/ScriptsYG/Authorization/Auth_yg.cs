using System.Runtime.InteropServices;
using UnityEngine;

namespace YG
{
    public partial class YandexGame
    {
        private static string _playerName = "unauthorized";
        private static string _playerId;
        private static string _playerPhoto;
        private static string _photoSize;

        public static string playerName
        {
            get => _playerName;
            set => _playerName = value;
        }
        public static string playerId { get => _playerId; }
        public static string playerPhoto
        {
            get => _playerPhoto;
            set => _playerPhoto = value;
        }
        public static string photoSize
        {
            get => _photoSize;
            set => _photoSize = value;
        }

        JsonAuth jsonAuth = new JsonAuth();

#if PLATFORM_WEBGL
        [DllImport("__Internal")]
        private static extern string InitPlayer_js();
#endif

        [InitYG]
        public static void InitializationGame()
        {
            _photoSize = Instance.infoYG.GetPlayerPhotoSize();
#if !UNITY_EDITOR && PLATFORM_WEBGL
            Debug.Log("Init Auth inGame");
            string playerData = InitPlayer_js();
            Instance.SetInitializationSDK(playerData);
#elif UNITY_EDITOR 
            InitPlayerForEditor();
#endif
        }

#if UNITY_EDITOR
        private static void InitPlayerForEditor()
        {
            string auth = "resolved";
            string name = Instance.infoYG.playerInfoSimulation.name;

            if (!Instance.infoYG.playerInfoSimulation.authorized)
            {
                auth = "rejected";
                name = "unauthorized";
            }
            else
            {
                if (!Instance.infoYG.scopes)
                    name = "anonymous";
            }

            JsonAuth playerDataSimulation = new JsonAuth()
            {
                playerAuth = auth,
                playerName = name,
                playerId = Instance.infoYG.playerInfoSimulation.uniqueID,
                playerPhoto = Instance.infoYG.playerInfoSimulation.photo
            };

            string json = JsonUtility.ToJson(playerDataSimulation);
            Instance.SetInitializationSDK(json);
        }
#endif
      
#if PLATFORM_WEBGL
        [DllImport("__Internal")]
        public static extern void RequestAuth_js(bool sendback);
#endif
        public static void RequestAuth(bool sendback = true)
        {
#if !UNITY_EDITOR && PLATFORM_WEBGL
            RequestAuth_js(sendback);
#elif UNITY_EDITOR 
            InitPlayerForEditor();
#endif
        }

        public void _RequestAuth() => RequestAuth(true);


        public void SetInitializationSDK(string data)
        {
            if (data == "noData" || data == "" || data == null)
            {
                _playerName = "unauthorized";
                _playerId = null;
                playerPhoto = null;
                RejectedAuthorization.Invoke();
                Debug.LogError("Failed init player data");
                GetDataInvoke();
                return;
            }

            jsonAuth = JsonUtility.FromJson<JsonAuth>(data);

            if (jsonAuth.playerAuth.ToString() == "resolved")
            {
                ResolvedAuthorization.Invoke();
                _auth = true;
            }
            else if (jsonAuth.playerAuth.ToString() == "rejected")
            {
                RejectedAuthorization.Invoke();
                _auth = false;
            }

            _playerName = jsonAuth.playerName.ToString();
            _playerId = jsonAuth.playerId.ToString();
            _playerPhoto = jsonAuth.playerPhoto.ToString();

            Message("Authorization - " + _auth);
            GetDataInvoke();
        }

#if PLATFORM_WEBGL
        [DllImport("__Internal")]
        private static extern void OpenAuthDialog();
#endif

        public static void AuthDialog()
        {
            if (auth)
                Message("Open Auth Dialog");
            else
                Message("SDK Яндекс Игр предлагает войти в аккаунт только тем пользователям, которые еще не вошли.");

#if !UNITY_EDITOR && PLATFORM_WEBGL
            OpenAuthDialog();
#endif
        }
        public void _OpenAuthDialog() => AuthDialog();


        public class JsonAuth
        {
            public string playerAuth;
            public string playerName;
            public string playerId;
            public string playerPhoto;
        }
    }
}
