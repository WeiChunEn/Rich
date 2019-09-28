using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;

namespace Prototype.NetworkLobby
{
    //Main menu, mainly only a bunch of callback called by the UI (setup throught the Inspector)
    public class LobbyMainMenu : MonoBehaviour 
    {
        public LobbyManager lobbyManager;

        public RectTransform lobbyServerList;
        public RectTransform lobbyPanel;

        public InputField Name_Input;
        public InputField ipInput;
        public InputField matchNameInput;
        public GameObject _gGame_Name;
        public GameObject _gMenu_Name;
        public GameObject _gSer_Name;
        public GameObject _gOpen_Room;
        public GameObject _gWarning_PlayName;
        public GameObject _gWarning_RoomName;
        public GameObject _gRoom_Panel;
        public GameObject _gRoom_Game_Name;
        public string _sRoom_Name;

        public GameObject _gDefense_Panel;
        
       
        void Start()
        {
            _gRoom_Panel.SetActive(false);
            _gGame_Name.SetActive(false);
            _gRoom_Game_Name.SetActive(false);
            _gDefense_Panel.SetActive(false);
        }
        public void OnEnable()
        {
            lobbyManager.topPanel.ToggleVisibility(true);

            ipInput.onEndEdit.RemoveAllListeners();
            ipInput.onEndEdit.AddListener(onEndEditIP);

            matchNameInput.onEndEdit.RemoveAllListeners();
            matchNameInput.onEndEdit.AddListener(onEndEditGameName);
        }

        public void OnClickHost()
        {
            lobbyManager.StartHost();
        }

        public void OnClickJoin()
        {
            lobbyManager.ChangeTo(lobbyPanel);

            lobbyManager.networkAddress = ipInput.text;
            lobbyManager.StartClient();

            lobbyManager.backDelegate = lobbyManager.StopClientClbk;
            lobbyManager.DisplayIsConnecting();

            lobbyManager.SetServerInfo("Connecting...", lobbyManager.networkAddress);
            _gGame_Name.SetActive(true);
            _gMenu_Name.SetActive(false);
            _gSer_Name.SetActive(true);
            _gRoom_Panel.SetActive(true);
            _gRoom_Game_Name.SetActive(true);

        }

        public void OnClickDedicated()
        {
            lobbyManager.ChangeTo(null);
            lobbyManager.StartServer();

            lobbyManager.backDelegate = lobbyManager.StopServerClbk;

            lobbyManager.SetServerInfo("Dedicated Server", lobbyManager.networkAddress);
        }
        public void Defense_Panel_Off()
        {
            _gDefense_Panel.SetActive(false);
        }
        public void OnClickCreateMatchmakingGame()
        {
            _gDefense_Panel.SetActive(true);
            Invoke("Defense_Panel_Off", 2.0f);
            _sRoom_Name = "";
            MatchCollection matches = Regex.Matches(matchNameInput.text, @"[^\W_]+", RegexOptions.IgnoreCase);
            foreach (Match match in matches)
            {
                _sRoom_Name += match.Value;
            }
            if (_sRoom_Name != "")
            {
                //_tName.text = Name_Input.text;
                lobbyManager.StartMatchMaker();
                lobbyManager.matchMaker.CreateMatch(
                    _sRoom_Name,
                    (uint)lobbyManager.maxPlayers,
                    true,
                    "", "", "", 0, 0,
                    lobbyManager.OnMatchCreate);

                lobbyManager.backDelegate = lobbyManager.StopHost;
                lobbyManager._isMatchmaking = true;
                lobbyManager.DisplayIsConnecting();
                GameObject.Find("123").GetComponent<RectTransform>().position = new Vector3(0, -1000, 0);
                _gGame_Name.SetActive(false);
                _gMenu_Name.SetActive(false);
                _gSer_Name.GetComponent<Text>().text = _sRoom_Name;
                _gSer_Name.SetActive(true);
                _gOpen_Room.SetActive(false);
                _gRoom_Panel.SetActive(true);
                _gRoom_Game_Name.SetActive(true);
                lobbyManager.SetServerInfo("Matchmaker Host", lobbyManager.matchHost);
            }
            else
            {
                _gWarning_RoomName.SetActive(true);
                Invoke("Close_Warning", 3.0f);
            }
           
        }
        public void Close_Warning()
        {
            _gWarning_RoomName.SetActive(false);
            _gWarning_PlayName.SetActive(false);
        }
        public void OnClickOpenServerList()
        {
            if (Name_Input.text != "")
            {
                lobbyManager.StartMatchMaker();
                lobbyManager.backDelegate = lobbyManager.SimpleBackClbk;
                lobbyManager.ChangeTo(lobbyServerList);
                GameObject.Find("123").GetComponent<RectTransform>().position = new Vector3(0, -1000, 0);
                _gGame_Name.SetActive(true);
                _gMenu_Name.SetActive(false);
                _gSer_Name.SetActive(true);
                

                _gSer_Name.GetComponent<Text>().text = "";
            }
            else
            {
                _gWarning_PlayName.SetActive(true);
                Invoke("Close_Warning", 3.0f);
            }
        }
        public void Click_Open_Room()
        {
            if (Name_Input.text != "")
            {
                _gOpen_Room.SetActive(true);
            }
            else
            {
                _gWarning_PlayName.SetActive(true);
                Invoke("Close_Warning",3.0f);
            }
            
        }
        void onEndEditIP(string text)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                OnClickJoin();
            }
        }

        void onEndEditGameName(string text)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                OnClickCreateMatchmakingGame();
            }
        }

    }
}
