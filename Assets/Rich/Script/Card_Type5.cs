using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Card_Type5 : NetworkBehaviour
{
    //public GameObject[] _gCard;
   
    
    public GameObject _gCard_A5_2;
    public GameObject _gCard_A5_2_Btn;
    public GameObject _gCard_A5_2_Text;
    public GameObject _gCard_A5_3;
    public GameObject _gCard_A6_2;
    public GameObject _gCard_A6_2_Btn;
    public GameObject _gCard_A6_2_Text;
    public GameObject _gCard_A6_3;
    public GameObject _gCard_A7_2;
    public GameObject _gCard_A7_2_Btn;
    public GameObject _gCard_A7_2_Text;
    public GameObject _gCard_A7_3;
    public GameObject _gCard_A8_2;
    public GameObject _gCard_A8_2_Btn;
    public GameObject _gCard_A8_2_Text;
    public GameObject _gCard_A8_3;
    public GameObject _gCard_A9_2;
    public GameObject _gCard_A9_2_Btn;
    public GameObject _gCard_A9_2_Text;
    public GameObject _gCard_A9_3;
    public GameObject _gCard_A10_2;
    public GameObject _gCard_A10_2_Btn;
    public GameObject _gCard_A10_2_Text;
    public GameObject _gCard_A10_3;
    public GameObject _gCard_A11_2;
    public GameObject _gCard_A11_2_Btn;
    public GameObject _gCard_A11_2_Text;
    public GameObject _gCard_A11_3;
    public GameObject _gCard_A12_2;
    public GameObject _gCard_A12_2_Btn;
    public GameObject _gCard_A12_2_Text;
    public GameObject _gCard_A12_3;

    //public GameObject _gDice_Sum;


    [SyncVar]
    public bool _bCard_A5_2;
    [SyncVar]
    public bool _bCard_A5_2_Btn;
    [SyncVar]
    public bool _bCard_A5_2_Text;
    [SyncVar]
    public bool _bCard_A5_3;
    
    [SyncVar]
    public bool _bCard_A6_2;
    [SyncVar]
    public bool _bCard_A6_2_Btn;
    [SyncVar]
    public bool _bCard_A6_2_Text;
    [SyncVar]
    public bool _bCard_A6_3;
    
    [SyncVar]
    public bool _bCard_A7_2;
    [SyncVar]
    public bool _bCard_A7_2_Btn;
    [SyncVar]
    public bool _bCard_A7_2_Text;
    [SyncVar]
    public bool _bCard_A7_3;

    [SyncVar]
    public bool _bCard_A8_2;
    [SyncVar]
    public bool _bCard_A8_2_Btn;
    [SyncVar]
    public bool _bCard_A8_2_Text;
    [SyncVar]
    public bool _bCard_A8_3;

    [SyncVar]
    public bool _bCard_A9_2;
    [SyncVar]
    public bool _bCard_A9_2_Btn;
    [SyncVar]
    public bool _bCard_A9_2_Text;
    [SyncVar]
    public bool _bCard_A9_3;

    [SyncVar]
    public bool _bCard_A10_2;
    [SyncVar]
    public bool _bCard_A10_2_Btn;
    [SyncVar]
    public bool _bCard_A10_2_Text;
    [SyncVar]
    public bool _bCard_A10_3;

    [SyncVar]
    public bool _bCard_A11_2;
    [SyncVar]
    public bool _bCard_A11_2_Btn;
    [SyncVar]
    public bool _bCard_A11_2_Text;
    [SyncVar]
    public bool _bCard_A11_3;

    [SyncVar]
    public bool _bCard_A12_2;
    [SyncVar]
    public bool _bCard_A12_2_Btn;
    [SyncVar]
    public bool _bCard_A12_3;



    void Start()
    {

       
        
        _bCard_A5_2 = false;
        _bCard_A5_2_Btn = false;
        _bCard_A5_2_Text = false;
        _bCard_A5_3 = false;
        
        _bCard_A6_2 = false;
        _bCard_A6_2_Btn = false;
        _bCard_A6_2_Text = false;
        _bCard_A6_3 = false;
        
        _bCard_A7_2 = false;
        _bCard_A7_2_Btn = false;
        _bCard_A7_2_Text = false;
        _bCard_A7_3 = false;

        _bCard_A8_2 = false;
        _bCard_A8_2_Btn = false;
        _bCard_A8_2_Text = false;
        _bCard_A8_3 = false;

        _bCard_A9_2 = false;
        _bCard_A9_2_Btn = false;
        _bCard_A9_2_Text = false;
        _bCard_A9_3 = false;

        _bCard_A10_2 = false;
        _bCard_A10_2_Btn = false;
        _bCard_A10_2_Text = false;
        _bCard_A10_3 = false;

        _bCard_A11_2 = false;
        _bCard_A11_2_Btn = false;
        _bCard_A11_2_Text = false;
        _bCard_A11_3 = false;

        _bCard_A12_2 = false;
        _bCard_A12_2_Btn = false;
        _bCard_A12_3 = false;


    }

    // Update is called once per frame
    void Update()
    {

       
      
        _gCard_A5_2.SetActive(_bCard_A5_2);
        _gCard_A5_2_Btn.SetActive(_bCard_A5_2_Btn);
        _gCard_A5_2_Text.SetActive(_bCard_A5_2_Text);
        _gCard_A5_3.SetActive(_bCard_A5_3);
        
        _gCard_A6_2.SetActive(_bCard_A6_2);
        _gCard_A6_2_Btn.SetActive(_bCard_A6_2_Btn);
        _gCard_A6_2_Text.SetActive(_bCard_A6_2_Text);
        _gCard_A6_3.SetActive(_bCard_A6_3);
        
        _gCard_A7_2.SetActive(_bCard_A7_2);
        _gCard_A7_2_Btn.SetActive(_bCard_A7_2_Btn);
        _gCard_A7_2_Text.SetActive(_bCard_A7_2_Text);
        _gCard_A7_3.SetActive(_bCard_A7_3);

        _gCard_A8_2.SetActive(_bCard_A8_2);
        _gCard_A8_2_Btn.SetActive(_bCard_A8_2_Btn);
        _gCard_A8_2_Text.SetActive(_bCard_A8_2_Text);
        _gCard_A8_3.SetActive(_bCard_A8_3);

        _gCard_A9_2.SetActive(_bCard_A9_2);
        _gCard_A9_2_Btn.SetActive(_bCard_A9_2_Btn);
        _gCard_A9_2_Text.SetActive(_bCard_A9_2_Text);
        _gCard_A9_3.SetActive(_bCard_A9_3);

        _gCard_A10_2.SetActive(_bCard_A10_2);
        _gCard_A10_2_Btn.SetActive(_bCard_A10_2_Btn);
        _gCard_A10_2_Text.SetActive(_bCard_A10_2_Text);
        _gCard_A10_3.SetActive(_bCard_A10_3);

        _gCard_A11_2.SetActive(_bCard_A11_2);
        _gCard_A11_2_Btn.SetActive(_bCard_A11_2_Btn);
        _gCard_A11_2_Text.SetActive(_bCard_A11_2_Text);
        _gCard_A11_3.SetActive(_bCard_A11_3);

        _gCard_A12_2.SetActive(_bCard_A12_2);
        _gCard_A12_2_Btn.SetActive(_bCard_A12_2_Btn);
        _gCard_A12_3.SetActive(_bCard_A12_3);

    }
}
