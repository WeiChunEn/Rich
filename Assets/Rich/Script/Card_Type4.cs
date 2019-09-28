using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Card_Type4 : NetworkBehaviour
{
   

    public GameObject _gCard_B7_1;
    public GameObject _gCard_B7_1_Btn1;
    public GameObject _gCard_B7_1_Btn2;
    public GameObject _gCard_B7_1_Btn3;
    public GameObject _gCard_B7_1_Btn4;
    public GameObject _gCard_B7_2;
    public GameObject _gCard_B7_2_Btn2_Img;
    public GameObject _gCard_B7_2_Btn3_Img;
    public GameObject _gCard_B7_2_Btn4_Img;

    public GameObject _gCard_B6_1;
    public GameObject _gCard_B6_1_Btn1;
    public GameObject _gCard_B6_1_Btn2;
    public GameObject _gCard_B6_1_Btn3;
    public GameObject _gCard_B6_1_Btn4;
    public GameObject _gCard_B6_2;
    public GameObject _gCard_B6_2_Btn2_Img;
    public GameObject _gCard_B6_2_Btn3_Img;
    public GameObject _gCard_B6_2_Btn4_Img;

    public GameObject _gCard_D_2;
    public GameObject _gCard_D_2_Btn1;
    public GameObject _gCard_D_2_Btn1_Img_1;
    public GameObject _gCard_D_2_Btn1_Img_2;
    public GameObject _gCard_D_2_Btn1_Img_3;
    public GameObject _gCard_D_2_Btn2;
    public GameObject _gCard_D_2_Btn2_Img_1;
    public GameObject _gCard_D_2_Btn2_Img_2;
    public GameObject _gCard_D_2_Btn2_Img_3;
    public GameObject _gCard_D_2_Btn3;
    public GameObject _gCard_D_2_Btn3_Img_1;
    public GameObject _gCard_D_2_Btn3_Img_2;
    public GameObject _gCard_D_2_Btn3_Img_3;
    
    [SyncVar]
    public bool _bCard_B6_1;
    [SyncVar]
    public bool _bCard_B6_1_Btn1;
    [SyncVar]
    public bool _bCard_B6_1_Btn2;
    [SyncVar]
    public bool _bCard_B6_1_Btn3;
    [SyncVar]
    public bool _bCard_B6_1_Btn4;
    [SyncVar]
    public bool _bCard_B6_2;
    [SyncVar]
    public bool _bCard_B6_2_Btn2_Img;
    [SyncVar]
    public bool _bCard_B6_2_Btn3_Img;
    [SyncVar]
    public bool _bCard_B6_2_Btn4_Img;

    [SyncVar]
    public bool _bCard_B7_1;
    [SyncVar]
    public bool _bCard_B7_1_Btn1;
    [SyncVar]
    public bool _bCard_B7_1_Btn2;
    [SyncVar]
    public bool _bCard_B7_1_Btn3;
    [SyncVar]
    public bool _bCard_B7_1_Btn4;
    [SyncVar]
    public bool _bCard_B7_2;
    [SyncVar]
    public bool _bCard_B7_2_Btn2_Img;
    [SyncVar]
    public bool _bCard_B7_2_Btn3_Img;
    [SyncVar]
    public bool _bCard_B7_2_Btn4_Img;

    [SyncVar]
    public bool _bCard_D_2;
    [SyncVar]
    public bool _bCard_D_2_Btn1;
    [SyncVar]
    public bool _bCard_D_2_Btn1_Img1;
    [SyncVar]
    public bool _bCard_D_2_Btn1_Img2;
    [SyncVar]
    public bool _bCard_D_2_Btn1_Img3;
    [SyncVar]
    public bool _bCard_D_2_Btn2;
    [SyncVar]
    public bool _bCard_D_2_Btn2_Img1;
    [SyncVar]
    public bool _bCard_D_2_Btn2_Img2;
    [SyncVar]
    public bool _bCard_D_2_Btn2_Img3;
    [SyncVar]
    public bool _bCard_D_2_Btn3;
    [SyncVar]
    public bool _bCard_D_2_Btn3_Img1;
    [SyncVar]
    public bool _bCard_D_2_Btn3_Img2;
    [SyncVar]
    public bool _bCard_D_2_Btn3_Img3;

    


    // Use this for initialization
    void Start()
    {
        _bCard_B6_1 = false;
        _bCard_B6_1_Btn1 = false;
        _bCard_B6_1_Btn2 = false;
        _bCard_B6_1_Btn3 = false;
        _bCard_B6_1_Btn4 = false;
        _bCard_B6_2 = false;
        _bCard_B6_2_Btn2_Img = false;
        _bCard_B6_2_Btn3_Img = false;
        _bCard_B6_2_Btn4_Img = false;

        _bCard_B7_1 = false;
        _bCard_B7_1_Btn1 = false;
        _bCard_B7_1_Btn2 = false;
        _bCard_B7_1_Btn3 = false;
        _bCard_B7_1_Btn4 = false;
        _bCard_B7_2 = false;
        _bCard_B7_2_Btn2_Img = false;
        _bCard_B7_2_Btn3_Img = false;
        _bCard_B7_2_Btn4_Img = false;

        _bCard_D_2 = false;
        _bCard_D_2_Btn1 = false;
        _bCard_D_2_Btn1_Img1 = false;
        _bCard_D_2_Btn1_Img2 = false;
        _bCard_D_2_Btn1_Img3 = false;
        _bCard_D_2_Btn2 = false;
        _bCard_D_2_Btn2_Img1 = false;
        _bCard_D_2_Btn2_Img2 = false;
        _bCard_D_2_Btn2_Img3 = false;
        _bCard_D_2_Btn3 = false;
        _bCard_D_2_Btn3_Img1 = false;
        _bCard_D_2_Btn3_Img2 = false;
        _bCard_D_2_Btn3_Img3 = false;

        

    }

    // Update is called once per frame
    void Update()
    {
        _gCard_B6_1.SetActive(_bCard_B6_1);
        _gCard_B6_1_Btn1.SetActive(_bCard_B6_1_Btn1);
        _gCard_B6_1_Btn2.SetActive(_bCard_B6_1_Btn2);
        _gCard_B6_1_Btn3.SetActive(_bCard_B6_1_Btn3);
        _gCard_B6_1_Btn4.SetActive(_bCard_B6_1_Btn4);
        _gCard_B6_2.SetActive(_bCard_B6_2);
        _gCard_B6_2_Btn2_Img.SetActive(_bCard_B6_2_Btn2_Img);
        _gCard_B6_2_Btn3_Img.SetActive(_bCard_B6_2_Btn3_Img);
        _gCard_B6_2_Btn4_Img.SetActive(_bCard_B6_2_Btn4_Img);

        _gCard_B7_1.SetActive(_bCard_B7_1);
        _gCard_B7_1_Btn1.SetActive(_bCard_B7_1_Btn1);
        _gCard_B7_1_Btn2.SetActive(_bCard_B7_1_Btn2);
        _gCard_B7_1_Btn3.SetActive(_bCard_B7_1_Btn3);
        _gCard_B7_1_Btn4.SetActive(_bCard_B7_1_Btn4);
        _gCard_B7_2.SetActive(_bCard_B7_2);
        _gCard_B7_2_Btn2_Img.SetActive(_bCard_B7_2_Btn2_Img);
        _gCard_B7_2_Btn3_Img.SetActive(_bCard_B7_2_Btn3_Img);
        _gCard_B7_2_Btn4_Img.SetActive(_bCard_B7_2_Btn4_Img);

        _gCard_D_2.SetActive(_bCard_D_2);
        _gCard_D_2_Btn1.SetActive(_bCard_D_2_Btn1);
        _gCard_D_2_Btn1_Img_1.SetActive(_bCard_D_2_Btn1_Img1);
        _gCard_D_2_Btn1_Img_2.SetActive(_bCard_D_2_Btn1_Img2);
        _gCard_D_2_Btn1_Img_3.SetActive(_bCard_D_2_Btn1_Img3);
        _gCard_D_2_Btn2.SetActive(_bCard_D_2_Btn2);
        _gCard_D_2_Btn2_Img_1.SetActive(_bCard_D_2_Btn2_Img1);
        _gCard_D_2_Btn2_Img_2.SetActive(_bCard_D_2_Btn2_Img2);
        _gCard_D_2_Btn2_Img_3.SetActive(_bCard_D_2_Btn2_Img3);
        _gCard_D_2_Btn3.SetActive(_bCard_D_2_Btn3);
        _gCard_D_2_Btn3_Img_1.SetActive(_bCard_D_2_Btn3_Img1);
        _gCard_D_2_Btn3_Img_2.SetActive(_bCard_D_2_Btn3_Img2);
        _gCard_D_2_Btn3_Img_3.SetActive(_bCard_D_2_Btn3_Img3);

        
    }
}
