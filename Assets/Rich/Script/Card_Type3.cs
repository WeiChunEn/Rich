using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Card_Type3 : NetworkBehaviour
{

    public GameObject _gCard_B2_2_Btn2_Img;
    public GameObject _gCard_B2_2_Btn3_Img;
    public GameObject _gCard_B2_2_Btn4_Img;

    public GameObject _gCard_B3_1;
    public GameObject _gCard_B3_1_Btn1;
    public GameObject _gCard_B3_1_Btn2;
    public GameObject _gCard_B3_1_Btn3;
    public GameObject _gCard_B3_1_Btn4;
    public GameObject _gCard_B3_2;
    public GameObject _gCard_B3_2_Btn2_Img;
    public GameObject _gCard_B3_2_Btn3_Img;
    public GameObject _gCard_B3_2_Btn4_Img;


    public GameObject _gCard_B4_1;
    public GameObject _gCard_B4_1_Btn1;
    public GameObject _gCard_B4_1_Btn2;
    public GameObject _gCard_B4_1_Btn3;
    public GameObject _gCard_B4_1_Btn4;
    public GameObject _gCard_B4_2;
    public GameObject _gCard_B4_2_Btn2_Img;
    public GameObject _gCard_B4_2_Btn3_Img;
    public GameObject _gCard_B4_2_Btn4_Img;

    public GameObject _gCard_B5_1;
    public GameObject _gCard_B5_1_Btn1;
    public GameObject _gCard_B5_1_Btn2;
    public GameObject _gCard_B5_1_Btn3;
    public GameObject _gCard_B5_1_Btn4;
    public GameObject _gCard_B5_2;
    public GameObject _gCard_B5_2_Btn2_Img;
    public GameObject _gCard_B5_2_Btn3_Img;
    public GameObject _gCard_B5_2_Btn4_Img;

    public GameObject _gCard_Again;

    [SyncVar]
    public bool _bCard_B2_2_Btn2_Img;
    [SyncVar]
    public bool _bCard_B2_2_Btn3_Img;
    [SyncVar]
    public bool _bCard_B2_2_Btn4_Img;


    [SyncVar]
    public bool _bCard_B3_1;
    [SyncVar]
    public bool _bCard_B3_1_Btn1;
    [SyncVar]
    public bool _bCard_B3_1_Btn2;
    [SyncVar]
    public bool _bCard_B3_1_Btn3;
    [SyncVar]
    public bool _bCard_B3_1_Btn4;
    [SyncVar]
    public bool _bCard_B3_2;
    [SyncVar]
    public bool _bCard_B3_2_Btn2_Img;
    [SyncVar]
    public bool _bCard_B3_2_Btn3_Img;
    [SyncVar]
    public bool _bCard_B3_2_Btn4_Img;

    [SyncVar]
    public bool _bCard_B4_1;
    [SyncVar]
    public bool _bCard_B4_1_Btn1;
    [SyncVar]
    public bool _bCard_B4_1_Btn2;
    [SyncVar]
    public bool _bCard_B4_1_Btn3;
    [SyncVar]
    public bool _bCard_B4_1_Btn4;
    [SyncVar]
    public bool _bCard_B4_2;
    [SyncVar]
    public bool _bCard_B4_2_Btn2_Img;
    [SyncVar]
    public bool _bCard_B4_2_Btn3_Img;
    [SyncVar]
    public bool _bCard_B4_2_Btn4_Img;

    [SyncVar]
    public bool _bCard_B5_1;
    [SyncVar]
    public bool _bCard_B5_1_Btn1;
    [SyncVar]
    public bool _bCard_B5_1_Btn2;
    [SyncVar]
    public bool _bCard_B5_1_Btn3;
    [SyncVar]
    public bool _bCard_B5_1_Btn4;
    [SyncVar]
    public bool _bCard_B5_2;
    [SyncVar]
    public bool _bCard_B5_2_Btn2_Img;
    [SyncVar]
    public bool _bCard_B5_2_Btn3_Img;
    [SyncVar]
    public bool _bCard_B5_2_Btn4_Img;

    [SyncVar]
    public bool _bCard_Again;


    // Use this for initialization
    void Start ()
    {

        _bCard_B2_2_Btn2_Img = false;
        _bCard_B2_2_Btn3_Img = false;
        _bCard_B2_2_Btn4_Img = false;

        _bCard_B3_1 = false;
        _bCard_B3_1_Btn1 = false;
        _bCard_B3_1_Btn2 = false;
        _bCard_B3_1_Btn3 = false;
        _bCard_B3_1_Btn4 = false;
        _bCard_B3_2 = false;
        _bCard_B3_2_Btn2_Img = false;
        _bCard_B3_2_Btn3_Img = false;
        _bCard_B3_2_Btn4_Img = false;

        _bCard_B4_1 = false;
        _bCard_B4_1_Btn1 = false;
        _bCard_B4_1_Btn2 = false;
        _bCard_B4_1_Btn3 = false;
        _bCard_B4_1_Btn4 = false;
        _bCard_B4_2 = false;
        _bCard_B4_2_Btn2_Img = false;
        _bCard_B4_2_Btn3_Img = false;
        _bCard_B4_2_Btn4_Img = false;

        _bCard_B5_1 = false;
        _bCard_B5_1_Btn1 = false;
        _bCard_B5_1_Btn2 = false;
        _bCard_B5_1_Btn3 = false;
        _bCard_B5_1_Btn4 = false;
        _bCard_B5_2 = false;
        _bCard_B5_2_Btn2_Img = false;
        _bCard_B5_2_Btn3_Img = false;
        _bCard_B5_2_Btn4_Img = false;


        _bCard_Again = false;


    }

    // Update is called once per frame
    void Update()
    {
        _gCard_B2_2_Btn2_Img.SetActive(_bCard_B2_2_Btn2_Img);
        _gCard_B2_2_Btn3_Img.SetActive(_bCard_B2_2_Btn3_Img);
        _gCard_B2_2_Btn4_Img.SetActive(_bCard_B2_2_Btn4_Img);


        _gCard_B3_1.SetActive(_bCard_B3_1);
        _gCard_B3_1_Btn1.SetActive(_bCard_B3_1_Btn1);
        _gCard_B3_1_Btn2.SetActive(_bCard_B3_1_Btn2);
        _gCard_B3_1_Btn3.SetActive(_bCard_B3_1_Btn3);
        _gCard_B3_1_Btn4.SetActive(_bCard_B3_1_Btn4);
        _gCard_B3_2.SetActive(_bCard_B3_2);
        _gCard_B3_2_Btn2_Img.SetActive(_bCard_B3_2_Btn2_Img);
        _gCard_B3_2_Btn3_Img.SetActive(_bCard_B3_2_Btn3_Img);
        _gCard_B3_2_Btn4_Img.SetActive(_bCard_B3_2_Btn4_Img);

        _gCard_B4_1.SetActive(_bCard_B4_1);
        _gCard_B4_1_Btn1.SetActive(_bCard_B4_1_Btn1);
        _gCard_B4_1_Btn2.SetActive(_bCard_B4_1_Btn2);
        _gCard_B4_1_Btn3.SetActive(_bCard_B4_1_Btn3);
        _gCard_B4_1_Btn4.SetActive(_bCard_B4_1_Btn4);
        _gCard_B4_2.SetActive(_bCard_B4_2);
        _gCard_B4_2_Btn2_Img.SetActive(_bCard_B4_2_Btn2_Img);
        _gCard_B4_2_Btn3_Img.SetActive(_bCard_B4_2_Btn3_Img);
        _gCard_B4_2_Btn4_Img.SetActive(_bCard_B4_2_Btn4_Img);

        _gCard_B5_1.SetActive(_bCard_B5_1);
        _gCard_B5_1_Btn1.SetActive(_bCard_B5_1_Btn1);
        _gCard_B5_1_Btn2.SetActive(_bCard_B5_1_Btn2);
        _gCard_B5_1_Btn3.SetActive(_bCard_B5_1_Btn3);
        _gCard_B5_1_Btn4.SetActive(_bCard_B5_1_Btn4);
        _gCard_B5_2.SetActive(_bCard_B5_2);
        _gCard_B5_2_Btn2_Img.SetActive(_bCard_B5_2_Btn2_Img);
        _gCard_B5_2_Btn3_Img.SetActive(_bCard_B5_2_Btn3_Img);
        _gCard_B5_2_Btn4_Img.SetActive(_bCard_B5_2_Btn4_Img);

        _gCard_Again.SetActive(_bCard_Again);

    }
}
