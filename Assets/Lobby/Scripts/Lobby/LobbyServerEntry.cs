using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.Networking.Types;
using System.Collections;

namespace Prototype.NetworkLobby
{
    public class LobbyServerEntry : MonoBehaviour 
    {
        public Text serverInfoText;
        public Text slotInfo;
        public Button joinButton;
        public GameObject _gMenu_Name;
        public GameObject _gRoom_Name;
        public GameObject _gSerRoom_Name;
        public GameObject _gRoom_Panel;
        public GameObject _gRoom_Game_Name;
        public GameObject _gTop_Panel;
        public GameObject _gBack_Btn;

        public GameObject _gDefense;
        public GameObject _gDefense_Panel;
        void Update()
        {
            _gDefense = GameObject.Find("Defense");
            _gTop_Panel = GameObject.Find("TopPanel");
            _gRoom_Name = GameObject.Find("童年");
            _gSerRoom_Name = GameObject.Find("Room_Name");
            _gRoom_Game_Name = _gTop_Panel.transform.Find("Room_Game_Name").gameObject;
            _gRoom_Panel = _gTop_Panel.transform.Find("Panel").gameObject;
            _gDefense_Panel = _gDefense.transform.Find("Defense_Panel").gameObject;
            _gBack_Btn = _gTop_Panel.transform.Find("BackButton").gameObject;
        }
        public void Populate(MatchInfoSnapshot match, LobbyManager lobbyManager, Color c)
		{
            serverInfoText.text = match.name;

            slotInfo.text = match.currentSize.ToString() + "/" + match.maxSize.ToString(); ;

            NetworkID networkID = match.networkId;

            joinButton.onClick.RemoveAllListeners();
            joinButton.onClick.AddListener(() => { JoinMatch(networkID, lobbyManager); });
           
            
            GetComponent<Image>().color = c;
        }

        void JoinMatch(NetworkID networkID, LobbyManager lobbyManager)
        {
            _gDefense_Panel.SetActive(true);
            _gBack_Btn.GetComponent<Button>().interactable = false;
            Invoke("Defense_Panel_Off", 2.0f);
            _gRoom_Name.SetActive(false);
            _gSerRoom_Name.SetActive(true);
            _gRoom_Panel.SetActive(true);
            _gRoom_Game_Name.SetActive(true);
            _gSerRoom_Name.GetComponent<Text>().text = serverInfoText.text;
            lobbyManager.matchMaker.JoinMatch(networkID, "", "", "", 0, 0, lobbyManager.OnMatchJoined);
			lobbyManager.backDelegate = lobbyManager.StopClientClbk;
            lobbyManager._isMatchmaking = true;
            lobbyManager.DisplayIsConnecting();
        }

        public void Defense_Panel_Off()
        {
            _gDefense_Panel.SetActive(false);
            _gBack_Btn.GetComponent<Button>().interactable = true;
        }
    }
}