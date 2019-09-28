using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Card_Type2 : NetworkBehaviour
{
    //public GameObject[] _gCard;
    public GameObject _gCard_C_2;
    public GameObject _gCard_C_3;
    public GameObject _gCard_C_4;
    public GameObject _gCard_A2_1;
    public GameObject _gCard_A2_1_Btn;
    public GameObject _gCard_A2_1_Text;
    public GameObject _gCard_A2_2;
    public GameObject _gCard_A2_2_Btn;
    public GameObject _gCard_A2_2_Text;
    public GameObject _gCard_A2_3;
    public GameObject _gCard_A3_1;
    public GameObject _gCard_A3_1_Btn;
    public GameObject _gCard_A3_1_Text;
    public GameObject _gCard_A3_2;
    public GameObject _gCard_A3_2_Btn;
    public GameObject _gCard_A3_2_Text;
    public GameObject _gCard_A3_3;
    public GameObject _gCard_A4_1;
    public GameObject _gCard_A4_1_Btn;
    public GameObject _gCard_A4_1_Text;
    public GameObject _gCard_A4_2;
    public GameObject _gCard_A4_2_Btn;
    public GameObject _gCard_A4_2_Text;
    public GameObject _gCard_A4_3;
    public GameObject _gCard_B2_1;
    public GameObject _gCard_B2_1_Btn1;
    public GameObject _gCard_B2_1_Btn2;
    public GameObject _gCard_B2_1_Btn3;
    public GameObject _gCard_B2_1_Btn4;
    public GameObject _gCard_B2_2;
    //public GameObject _gDice_Sum;
    [SyncVar]
    public bool _bCard_C_2;
    [SyncVar]
    public bool _bCard_C_3;
    [SyncVar]
    public bool _bCard_C_4;
    [SyncVar]
    public bool _bCard_A2_1;
    [SyncVar]
    public bool _bCard_A2_1_Btn;
    [SyncVar]
    public bool _bCard_A2_1_Text;
    [SyncVar]
    public bool _bCard_A2_2;
    [SyncVar]
    public bool _bCard_A2_2_Btn;
    [SyncVar]
    public bool _bCard_A2_2_Text;
    [SyncVar]
    public bool _bCard_A2_3;
    [SyncVar]
    public bool _bCard_A3_1;
    [SyncVar]
    public bool _bCard_A3_1_Btn;
    [SyncVar]
    public bool _bCard_A3_1_Text;
    [SyncVar]
    public bool _bCard_A3_2;
    [SyncVar]
    public bool _bCard_A3_2_Btn;
    [SyncVar]
    public bool _bCard_A3_2_Text;
    [SyncVar]
    public bool _bCard_A3_3;
    [SyncVar]
    public bool _bCard_A4_1;
    [SyncVar]
    public bool _bCard_A4_1_Btn;
    [SyncVar]
    public bool _bCard_A4_1_Text;
    [SyncVar]
    public bool _bCard_A4_2;
    [SyncVar]
    public bool _bCard_A4_2_Btn;
    [SyncVar]
    public bool _bCard_A4_2_Text;
    [SyncVar]
    public bool _bCard_A4_3;
    [SyncVar]
    public bool _bCard_B2_1;
    [SyncVar]
    public bool _bCard_B2_1_Btn1;
    [SyncVar]
    public bool _bCard_B2_1_Btn2;
    [SyncVar]
    public bool _bCard_B2_1_Btn3;
    [SyncVar]
    public bool _bCard_B2_1_Btn4;
    [SyncVar]
    public bool _bCard_B2_2;


    void Start()
    {
        
        _bCard_C_2 = false;
        _bCard_C_3 = false;
        _bCard_C_4 = false;
        _bCard_A2_1 = false;
        _bCard_A2_1_Btn = false;
        _bCard_A2_1_Text = false;
        _bCard_A2_2 = false;
        _bCard_A2_2_Btn = false;
        _bCard_A2_2_Text = false;
        _bCard_A2_3 = false;
        _bCard_A3_1 = false;
        _bCard_A3_1_Btn = false;
        _bCard_A3_1_Text = false;
        _bCard_A3_2 = false;
        _bCard_A3_2_Btn = false;
        _bCard_A3_2_Text = false;
        _bCard_A3_3 = false;
        _bCard_A4_1 = false;
        _bCard_A4_1_Btn = false;
        _bCard_A4_1_Text = false;
        _bCard_A4_2 = false;
        _bCard_A4_2_Btn = false;
        _bCard_A4_2_Text = false;
        _bCard_A4_3 = false;
        _bCard_B2_1 = false;
        _bCard_B2_1_Btn1 = false;
        _bCard_B2_1_Btn2 = false;
        _bCard_B2_1_Btn3 = false;
        _bCard_B2_1_Btn4 = false;
        _bCard_B2_2 = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        _gCard_C_2.SetActive(_bCard_C_2);
        _gCard_C_3.SetActive(_bCard_C_3);
        _gCard_C_4.SetActive(_bCard_C_4);
        _gCard_A2_1.SetActive(_bCard_A2_1);
        _gCard_A2_1_Btn.SetActive(_bCard_A2_1_Btn);
        _gCard_A2_1_Text.SetActive(_bCard_A2_1_Text);
        _gCard_A2_2.SetActive(_bCard_A2_2);
        _gCard_A2_2_Btn.SetActive(_bCard_A2_2_Btn);
        _gCard_A2_2_Text.SetActive(_bCard_A2_2_Text);
        _gCard_A2_3.SetActive(_bCard_A2_3);
        _gCard_A3_1.SetActive(_bCard_A3_1);
        _gCard_A3_1_Btn.SetActive(_bCard_A3_1_Btn);
        _gCard_A3_1_Text.SetActive(_bCard_A3_1_Text);
        _gCard_A3_2.SetActive(_bCard_A3_2);
        _gCard_A3_2_Btn.SetActive(_bCard_A3_2_Btn);
        _gCard_A3_2_Text.SetActive(_bCard_A3_2_Text);
        _gCard_A3_3.SetActive(_bCard_A3_3);
        _gCard_A4_1.SetActive(_bCard_A4_1);
        _gCard_A4_1_Btn.SetActive(_bCard_A4_1_Btn);
        _gCard_A4_1_Text.SetActive(_bCard_A4_1_Text);
        _gCard_A4_2.SetActive(_bCard_A4_2);
        _gCard_A4_2_Btn.SetActive(_bCard_A4_2_Btn);
        _gCard_A4_2_Text.SetActive(_bCard_A4_2_Text);
        _gCard_A4_3.SetActive(_bCard_A4_3);
        _gCard_B2_1.SetActive(_bCard_B2_1);
        _gCard_B2_1_Btn1.SetActive(_bCard_B2_1_Btn1);
        _gCard_B2_1_Btn2.SetActive(_bCard_B2_1_Btn2);
        _gCard_B2_1_Btn3.SetActive(_bCard_B2_1_Btn3);
        _gCard_B2_1_Btn4.SetActive(_bCard_B2_1_Btn4);
        _gCard_B2_2.SetActive(_bCard_B2_2);
    }
}
