using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;

public class Card_Event : NetworkBehaviour
{

    //public Button A1_Btn;
    //public Button A2_Btn;
    public GameObject _gCard;
    //public bool _bCard_Finish = false;
    //[SyncVar]
    //public bool _bSwitch;
    
    [SyncVar]
    public int _iNow_Card;
    //public Button Card_Btn;
	// Use this for initialization
	void Start ()
    {
        //A1_Btn = GameObject.Find("A1_Btn").GetComponent<Button>();
        //A1_Btn.onClick.AddListener(() => CmdA_Btn_1());

    }
	
	// Update is called once per frame
	void Update ()
    {
        
            
    }

    public int Card_Type(int _iCard_Num)
    {
        switch(_iCard_Num)
        {
            case 0:
                //_bSwitch = true;
                _gCard.GetComponent<Card_Type>()._bCard_A_1 = true;
                
               
                _iNow_Card = _iCard_Num;
                //Card_Btn = GameObject.Find("A1_Btn").GetComponent<Button>();
                //Card_Btn.onClick.AddListener(delegate () {  ClickTest("AddListener test."); CmdA_Btn_1(); });
                break;
            case 1:
                _iNow_Card = _iCard_Num;
                break;
            case 2:
                _iNow_Card = _iCard_Num;
                break;
            case 3:
                _iNow_Card = _iCard_Num;
                break;
        }
        return _iNow_Card;

    }
    
    [Command]
    public void CmdA_Btn_1()
    {
        print("CCC");
        
           
           
                print("DDD");
                _gCard.GetComponent<Card_Type>()._bCard_A_1 = false;
                _gCard.GetComponent<Card_Type>()._bCard_A_2 = true ;
        //A2_Btn = GameObject.Find("A2_Btn").GetComponent<Button>();
        //A2_Btn.onClick.AddListener(() => CmdA_Btn_2());
    }
    [Command]
    public void CmdA_Btn_2()
    {
        print("EEEE");
       
            print("DDDDDD");
            _gCard.GetComponent<Card_Type>()._bCard_A_2 = false;
            _gCard.GetComponent<Card_Type>()._bCard_A_3 = true;
            StartCoroutine(Waiting());
            _gCard.GetComponent<Card_Type>()._bCard_A_3 = false;
        
        
    }
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(3);
    }
}
