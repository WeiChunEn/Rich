using UnityEngine;
using UnityEngine.UI;
using System.Collections;


namespace Prototype.NetworkLobby 
{
    public class LobbyInfoPanel : MonoBehaviour
    {
        public Text infoText;
        public Text buttonText;
        public Button singleButton;
        public Vector3 _vInput_Name_Pos;

         void Start()
        {
            _vInput_Name_Pos = new Vector3(454.4901f, 321.8519f, 0);
        }
        public void Display(string info, string buttonInfo, UnityEngine.Events.UnityAction buttonClbk)
        {
            infoText.text = info;

            buttonText.text = buttonInfo;

            singleButton.onClick.RemoveAllListeners();

            if (buttonClbk != null)
            {
                singleButton.onClick.AddListener(buttonClbk);
                
            }
            
            singleButton.onClick.AddListener(() => { gameObject.SetActive(false); GameObject.Find("123").transform.position = _vInput_Name_Pos; });

            gameObject.SetActive(true);
        }
    }
}