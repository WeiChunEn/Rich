using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Card_Type : NetworkBehaviour
{
    //public GameObject[] _gCard;
    public GameObject _gCard_A_1;
    public GameObject _gCard_A_1_Btn;
    public GameObject _gCard_A_1_Text;
    public GameObject _gCard_A_2;
    public GameObject _gCard_A_2_Btn;
    public GameObject _gCard_A_2_Text;
    public GameObject _gCard_A_3;
    public GameObject _gCard_B_1;
    public GameObject _gCard_B_1_Que;
    public GameObject _gCard_B_1_Btn1;
    public GameObject _gCard_B_1_Btn2;
    public GameObject _gCard_B_1_Btn3;
    public GameObject _gCard_B_1_Btn4;
    public GameObject _gCard_B_2;
    public GameObject _gCard_C_1;
    public GameObject _gCard_D_1;
    public GameObject _gCard_D_1_Btn1;
    public GameObject _gCard_D_1_Btn1_Img_1;
    public GameObject _gCard_D_1_Btn1_Img_2;
    public GameObject _gCard_D_1_Btn1_Img_3;
    public GameObject _gCard_D_1_Btn2;
    public GameObject _gCard_D_1_Btn2_Img_1;
    public GameObject _gCard_D_1_Btn2_Img_2;
    public GameObject _gCard_D_1_Btn2_Img_3;
    public GameObject _gCard_D_1_Btn3;
    public GameObject _gCard_D_1_Btn3_Img_1;
    public GameObject _gCard_D_1_Btn3_Img_2;
    public GameObject _gCard_D_1_Btn3_Img_3;
    public GameObject _gDice;
    public GameObject _gAdd;

    public GameObject _gCard_D_Panel;
    //public GameObject _gDice_Sum;
    [SyncVar]
    public bool _bCard_A_1;
    [SyncVar]
    public bool _bCard_A_1_Btn;
    [SyncVar]
    public bool _bCard_A_1_Text;
    [SyncVar]
    public bool _bCard_A_2;
    [SyncVar]
    public bool _bCard_A_2_Btn;
    [SyncVar]
    public bool _bCard_A_2_Text;
    [SyncVar]
    public bool _bCard_A_3;
    [SyncVar]
    public bool _bCard_B_1;
    [SyncVar]
    public bool _bCard_B_1_Que;
    [SyncVar]
    public bool _bCard_B_1_Btn1;
    [SyncVar]
    public bool _bCard_B_1_Btn2;
    [SyncVar]
    public bool _bCard_B_1_Btn3;
    [SyncVar]
    public bool _bCard_B_1_Btn4;
    [SyncVar]
    public bool _bCard_B_2;
    [SyncVar]
    public bool _bCard_C_1;
    [SyncVar]
    public bool _bCard_D_1;
    [SyncVar]
    public bool _bCard_D_1_Btn1;
    [SyncVar]
    public bool _bCard_D_1_Btn1_Img1;
    [SyncVar]
    public bool _bCard_D_1_Btn1_Img2;
    [SyncVar]
    public bool _bCard_D_1_Btn1_Img3;
    [SyncVar]
    public bool _bCard_D_1_Btn2;
    [SyncVar]
    public bool _bCard_D_1_Btn2_Img1;
    [SyncVar]
    public bool _bCard_D_1_Btn2_Img2;
    [SyncVar]
    public bool _bCard_D_1_Btn2_Img3;
    [SyncVar]
    public bool _bCard_D_1_Btn3;
    [SyncVar]
    public bool _bCard_D_1_Btn3_Img1;
    [SyncVar]
    public bool _bCard_D_1_Btn3_Img2;
    [SyncVar]
    public bool _bCard_D_1_Btn3_Img3;
    [SyncVar]
    public bool _bDice;

    [SyncVar]
    public bool _bCard_D_Panel;
    
    [SyncVar]
    public bool _bAdd;
    //[SyncVar]
    //public bool _bDice_Sum;
    // Use this for initialization
    void Start ()
    {
        //_bCard_A = true;
        //_bCard_B = false;
        //_bCard_C = false;
        //_bCard_D = false;
        _bCard_A_1 = false;
        _bCard_A_1_Btn = false;
        _bCard_A_1_Text = false;
        _bCard_A_2 = false;
        _bCard_A_2_Btn = false;
        _bCard_A_2_Text = false;
        _bCard_A_3 = false;
        _bCard_B_1 = false;
        _bCard_B_1_Que = false;
        _bCard_B_1_Btn1 = false;
        _bCard_B_1_Btn2 = false;
        _bCard_B_1_Btn3 = false;
        _bCard_B_1_Btn4 = false;
        _bCard_B_2 = false;
        _bCard_C_1 = false;
        _bCard_D_1 = false;
        _bCard_D_1_Btn1 = false;
        _bCard_D_1_Btn1_Img1 = false;
        _bCard_D_1_Btn1_Img2 = false;
        _bCard_D_1_Btn1_Img3 = false;
        _bCard_D_1_Btn2 = false;
        _bCard_D_1_Btn2_Img1 = false;
        _bCard_D_1_Btn2_Img2 = false;
        _bCard_D_1_Btn2_Img3 = false;
        _bCard_D_1_Btn3 = false;
        _bCard_D_1_Btn3_Img1 = false;
        _bCard_D_1_Btn3_Img2 = false;
        _bCard_D_1_Btn3_Img3 = false;
        _bDice = true;
      
        _bAdd = false;

        _bCard_D_Panel = false;
        //_bDice_Sum = true;

    }
	
	// Update is called once per frame
	void Update ()
    {
        //_gCard[0].SetActive(_bCard_A);
        //_gCard[1].SetActive(_bCard_B);
        //_gCard[2].SetActive(_bCard_C);
        //_gCard[3].SetActive(_bCard_D);
        _gCard_A_1.SetActive(_bCard_A_1);
        _gCard_A_1_Btn.SetActive(_bCard_A_1_Btn);
        _gCard_A_1_Text.SetActive(_bCard_A_1_Text);
        _gCard_A_2.SetActive(_bCard_A_2);
        _gCard_A_2_Btn.SetActive(_bCard_A_2_Btn);
        _gCard_A_2_Text.SetActive(_bCard_A_2_Text);
        _gCard_A_3.SetActive(_bCard_A_3);
        _gCard_B_1.SetActive(_bCard_B_1);
        _gCard_B_1_Que.SetActive(_bCard_B_1_Que);
        _gCard_B_1_Btn1.SetActive(_bCard_B_1_Btn1);
        _gCard_B_1_Btn2.SetActive(_bCard_B_1_Btn2);
        _gCard_B_1_Btn3.SetActive(_bCard_B_1_Btn3);
        _gCard_B_1_Btn4.SetActive(_bCard_B_1_Btn4);
        _gCard_B_2.SetActive(_bCard_B_2);
        _gCard_C_1.SetActive(_bCard_C_1);
        _gCard_D_1.SetActive(_bCard_D_1);
        _gCard_D_1_Btn1.SetActive(_bCard_D_1_Btn1);
        _gCard_D_1_Btn1_Img_1.SetActive(_bCard_D_1_Btn1_Img1);
        _gCard_D_1_Btn1_Img_2.SetActive(_bCard_D_1_Btn1_Img2);
        _gCard_D_1_Btn1_Img_3.SetActive(_bCard_D_1_Btn1_Img3);
        _gCard_D_1_Btn2.SetActive(_bCard_D_1_Btn2);
        _gCard_D_1_Btn2_Img_1.SetActive(_bCard_D_1_Btn2_Img1);
        _gCard_D_1_Btn2_Img_2.SetActive(_bCard_D_1_Btn2_Img2);
        _gCard_D_1_Btn2_Img_3.SetActive(_bCard_D_1_Btn2_Img3);
        _gCard_D_1_Btn3.SetActive(_bCard_D_1_Btn3);
        _gCard_D_1_Btn3_Img_1.SetActive(_bCard_D_1_Btn3_Img1);
        _gCard_D_1_Btn3_Img_2.SetActive(_bCard_D_1_Btn3_Img2);
        _gCard_D_1_Btn3_Img_3.SetActive(_bCard_D_1_Btn3_Img3);
        _gDice.SetActive(_bDice);
       
        _gAdd.SetActive(_bAdd);

        _gCard_D_Panel.SetActive(_bCard_D_Panel);
        //_gDice_Sum.SetActive(_bDice_Sum);
    }
}
