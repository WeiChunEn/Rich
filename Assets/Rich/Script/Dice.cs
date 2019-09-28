using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Dice : NetworkBehaviour
{
    public GameObject _gDice_1_1;
    public GameObject _gDice_1_2;
    public GameObject _gDice_1_3;
    public GameObject _gDice_1_4;
    public GameObject _gDice_1_5;
    public GameObject _gDice_1_6;
    public GameObject _gDice_2_1;
    public GameObject _gDice_2_2;
    public GameObject _gDice_2_3;
    public GameObject _gDice_2_4;
    public GameObject _gDice_2_5;
    public GameObject _gDice_2_6;
    public GameObject _gDice_Sum_2;
    public GameObject _gDice_Sum_3;
    public GameObject _gDice_Sum_4;
    public GameObject _gDice_Sum_5;
    public GameObject _gDice_Sum_6;
    public GameObject _gDice_Sum_7;
    public GameObject _gDice_Sum_8;
    public GameObject _gDice_Sum_9;
    public GameObject _gDice_Sum_10;
    public GameObject _gDice_Sum_11;
    public GameObject _gDice_Sum_12;
    public GameObject _gDice1_Anim;
    public GameObject _gDice2_Anim;

    public GameObject _gCard_B_1_Btn2_Img;
    public GameObject _gCard_B_1_Btn3_Img;
    public GameObject _gCard_B_1_Btn4_Img;

   // public GameObject _gCard_End;

    public GameObject _gDice_Background;
    public GameObject _gSystem_Dicing_Img;
    public GameObject _gSystem_Walking_Img;

    public GameObject _gYour_Turn;

    [SyncVar]
    public bool _bDice_1_1;
    [SyncVar]
    public bool _bDice_1_2;
    [SyncVar]
    public bool _bDice_1_3;
    [SyncVar]
    public bool _bDice_1_4;
    [SyncVar]
    public bool _bDice_1_5;
    [SyncVar]
    public bool _bDice_1_6;
    [SyncVar]
    public bool _bDice_2_1;
    [SyncVar]
    public bool _bDice_2_2;
    [SyncVar]
    public bool _bDice_2_3;
    [SyncVar]
    public bool _bDice_2_4;
    [SyncVar]
    public bool _bDice_2_5;
    [SyncVar]
    public bool _bDice_2_6;
    [SyncVar]
    public bool _bDice_Sum_2;
    [SyncVar]
    public bool _bDice_Sum_3;
    [SyncVar]
    public bool _bDice_Sum_4;
    [SyncVar]
    public bool _bDice_Sum_5;
    [SyncVar]
    public bool _bDice_Sum_6;
    [SyncVar]
    public bool _bDice_Sum_7;
    [SyncVar]
    public bool _bDice_Sum_8;
    [SyncVar]
    public bool _bDice_Sum_9;
    [SyncVar]
    public bool _bDice_Sum_10;
    [SyncVar]
    public bool _bDice_Sum_11;
    [SyncVar]
    public bool _bDice_Sum_12;
    [SyncVar]
    public bool _bDice1_Anim;
    [SyncVar]
    public bool _bDice2_Anim;


    [SyncVar]
    public bool _bCard_B1_Btn2_Img;
    [SyncVar]
    public bool _bCard_B1_Btn3_Img;
    [SyncVar]
    public bool _bCard_B1_Btn4_Img;

    //[SyncVar]
    //public bool _bCard_End;

    [SyncVar]
    public bool _bDice_Background;

    [SyncVar]
    public bool _bSystem_Dicing_Img;

    [SyncVar]
    public bool _bSystem_Walking_Img;

    public bool _bYour_Trun;
    // Use this for initialization
    void Start ()
    {
        _bDice_1_1 = false;
        _bDice_1_2 = false;
        _bDice_1_3 = false;
        _bDice_1_4 = false;
        _bDice_1_5 = false;
        _bDice_1_6 = false;
        _bDice_2_1 = false;
        _bDice_2_2 = false;
        _bDice_2_3 = false;
        _bDice_2_4 = false;
        _bDice_2_5 = false;
        _bDice_2_6 = false;
        _bDice_Sum_2 = false;
        _bDice_Sum_3 = false;
        _bDice_Sum_4 = false;
        _bDice_Sum_5 = false;
        _bDice_Sum_6 = false;
        _bDice_Sum_7 = false;
        _bDice_Sum_8 = false;
        _bDice_Sum_9 = false;
        _bDice_Sum_10 = false;
        _bDice_Sum_11 = false;
        _bDice_Sum_12 = false;
        _bDice1_Anim = false;
        _bDice2_Anim = false;

       // _bCard_End = false;

        _bDice_Background = false;

        _bSystem_Dicing_Img = false;
        _bSystem_Walking_Img = false;

        _bYour_Trun = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        _gDice_1_1.SetActive(_bDice_1_1);
        _gDice_1_2.SetActive(_bDice_1_2);
        _gDice_1_3.SetActive(_bDice_1_3);
        _gDice_1_4.SetActive(_bDice_1_4);
        _gDice_1_5.SetActive(_bDice_1_5);
        _gDice_1_6.SetActive(_bDice_1_6);
        _gDice_2_1.SetActive(_bDice_2_1);
        _gDice_2_2.SetActive(_bDice_2_2);
        _gDice_2_3.SetActive(_bDice_2_3);
        _gDice_2_4.SetActive(_bDice_2_4);
        _gDice_2_5.SetActive(_bDice_2_5);
        _gDice_2_6.SetActive(_bDice_2_6);
        _gDice_Sum_2.SetActive(_bDice_Sum_2);
        _gDice_Sum_3.SetActive(_bDice_Sum_3);
        _gDice_Sum_4.SetActive(_bDice_Sum_4);
        _gDice_Sum_5.SetActive(_bDice_Sum_5);
        _gDice_Sum_6.SetActive(_bDice_Sum_6);
        _gDice_Sum_7.SetActive(_bDice_Sum_7);
        _gDice_Sum_8.SetActive(_bDice_Sum_8);
        _gDice_Sum_9.SetActive(_bDice_Sum_9);
        _gDice_Sum_10.SetActive(_bDice_Sum_10);
        _gDice_Sum_11.SetActive(_bDice_Sum_11);
        _gDice_Sum_12.SetActive(_bDice_Sum_12);
        _gDice1_Anim.SetActive(_bDice1_Anim);
        _gDice2_Anim.SetActive(_bDice2_Anim);
        _gCard_B_1_Btn2_Img.SetActive(_bCard_B1_Btn2_Img);
        _gCard_B_1_Btn3_Img.SetActive(_bCard_B1_Btn3_Img);
        _gCard_B_1_Btn4_Img.SetActive(_bCard_B1_Btn4_Img);

        //_gCard_End.SetActive(_bCard_End);
        _gDice_Background.SetActive(_bDice_Background);

        _gSystem_Dicing_Img.SetActive(_bSystem_Dicing_Img);
        _gSystem_Walking_Img.SetActive(_bSystem_Walking_Img);

        _gYour_Turn.SetActive(_bYour_Trun);
    }
}
