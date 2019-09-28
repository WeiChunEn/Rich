using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Card_Type6 : NetworkBehaviour
{
    public GameObject _gCardD1_Btn1_Finish;
    public GameObject _gCardD1_Btn2_Finish;
    public GameObject _gCardD1_Btn3_Finish;
    public GameObject _gCardD2_Btn1_Finish;
    public GameObject _gCardD2_Btn2_Finish;
    public GameObject _gCardD2_Btn3_Finish;

    public GameObject _gCard_Select_Music;
    public GameObject _gCard_A_Music;
    public GameObject _g1000_Point;
    public GameObject _gAward_Music;

    [SyncVar]
    public bool _bCardD1_Btn1_Finish;
    [SyncVar]
    public bool _bCardD1_Btn2_Finish;
    [SyncVar]
    public bool _bCardD1_Btn3_Finish;

    [SyncVar]
    public bool _bCardD2_Btn1_Finish;
    [SyncVar]
    public bool _bCardD2_Btn2_Finish;
    [SyncVar]
    public bool _bCardD2_Btn3_Finish;

    [SyncVar]
    public bool _bCard_Select_Music;

    [SyncVar]
    public bool _bCard_A_Music;

    [SyncVar]
    public bool _b1000_Point;

    [SyncVar]
    public bool _bAward_Music;

    void Start()
    {
        _bCardD1_Btn1_Finish = false;
        _bCardD1_Btn2_Finish = false;
        _bCardD1_Btn3_Finish = false;
        _bCardD2_Btn1_Finish = false;
        _bCardD2_Btn2_Finish = false;
        _bCardD2_Btn3_Finish = false;
        _bCard_Select_Music = false;
        _bCard_A_Music = false;
        _b1000_Point = false;
        _bAward_Music = false;
    }

    // Update is called once per frame
    void Update()
    {
        _gCardD1_Btn1_Finish.SetActive(_bCardD1_Btn1_Finish);
        _gCardD1_Btn2_Finish.SetActive(_bCardD1_Btn2_Finish);
        _gCardD1_Btn3_Finish.SetActive(_bCardD1_Btn3_Finish);

        _gCardD2_Btn1_Finish.SetActive(_bCardD2_Btn1_Finish);
        _gCardD2_Btn2_Finish.SetActive(_bCardD2_Btn2_Finish);
        _gCardD2_Btn3_Finish.SetActive(_bCardD2_Btn3_Finish);

        _gCard_Select_Music.SetActive(_bCard_Select_Music);
        _gCard_A_Music.SetActive(_bCard_A_Music);
        _g1000_Point.SetActive(_b1000_Point);
        _gAward_Music.SetActive(_bAward_Music);
    }
}
