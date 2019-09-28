using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;

public class Player : NetworkBehaviour
{

    public enum Process
    {
        start,
        dicingready,
        dicing,
        action,
        wait,
        end
    }
    public GameObject _gCanvas_A;
    public GameObject _gCanvas_B;
    public GameObject _gCanvas_C;
    public GameObject _gCanvas_D;
    public Button A1_Btn;
    public Button A2_Btn;
    public Button A2_1Btn;
    public Button A2_2Btn;
    public Button A3_1Btn;
    public Button A3_2Btn;
    public Button A4_1Btn;
    public Button A4_2Btn;
    public Button A5_2Btn;
    public Button A6_2Btn;
    public Button A7_2Btn;
    public Button A8_2Btn;
    public Button A9_2Btn;
    public Button A10_2Btn;
    public Button A11_2Btn;
    public Button A12_2Btn;
    public Button B1_Btn1;
    public Button B1_Btn2;
    public Button B1_Btn3;
    public Button B1_Btn4;
    public Button B2_Btn1;
    public Button B2_Btn2;
    public Button B2_Btn3;
    public Button B2_Btn4;
    public Button B3_Btn1;
    public Button B3_Btn2;
    public Button B3_Btn3;
    public Button B3_Btn4;
    public Button B4_Btn1;
    public Button B4_Btn2;
    public Button B4_Btn3;
    public Button B4_Btn4;
    public Button B5_Btn1;
    public Button B5_Btn2;
    public Button B5_Btn3;
    public Button B5_Btn4;
    public Button B6_Btn1;
    public Button B6_Btn2;
    public Button B6_Btn3;
    public Button B6_Btn4;
    public Button B7_Btn1;
    public Button B7_Btn2;
    public Button B7_Btn3;
    public Button B7_Btn4;
    public Button D1_Btn1;
    public Button D1_Btn2;
    public Button D1_Btn3;
    public Button D2_Btn1;
    public Button D2_Btn2;
    public Button D2_Btn3;
    public Button Timing;
    public Button Restart;
    public GameObject Dice_1;
    public GameObject Dice_2;
    public GameObject Add;
    [SyncVar]
    public int _iCard_Num = -1;

    public GameObject _gCard;
    public GameObject _gCard2;
    public GameObject _gCard3;
    public GameObject _gCard4;
    public GameObject _gCard5;
    public GameObject _gCard6;
    public GameObject _gDice_Music;
    public GameObject _gDice_List;
    public GameObject _gGameOver;
    public GameObject _gArea;
    public Camera _cGame_Camera;

    public Text _tName;

    [SyncVar]
    public int _iPlayer_Sum;
    [SerializeField]
    private int _iNow_Pos;
    [SyncVar]
    public float _fPlayer_x;
    [SyncVar]
    public string _sName;
    [SyncVar]
    public string _sScore;
    [SyncVar]
    public float _fPlayer_y;

    public GameObject _gPlayer;
    GameManager _gGM;
    public Button btnDice;
    public Text txtsysMsg;

    public Text Dice_Sum;
    [SyncVar]
    public Process process = Process.start;
    [SyncVar]
    public bool _bCan_Change;
    [SyncVar]
    public bool _bCan_Again = false;
    [SyncVar]
    public string SysMsg;
    [SyncVar]
    public int _iDice_Sum;
    [SyncVar]
    public Vector3 _vPlace;
    [SyncVar]
    public bool _bAnswer_Finish;
    [SyncVar]
    public int _iPlayer_Num;
    public GameObject _gStart_Pos;
    [SyncVar]
    public int _iCard_Point;
    [SyncVar]
    public bool _Time_up = false;
    [SyncVar]
    public int Dice_Tmp1 = 1;
    [SyncVar]
    public int Dice_Tmp2 = 1;
    public bool _bScore_List = false;

    public bool _bTouch_Finsih = false;
    public bool _bTouch_Finish_A1 = false;
    public GameObject _gcountdown1;
    public GameObject _gcountdown2;
    public GameObject _gcountdown3;

    private float _Client_x;
    private float _Client_y;
    public string _sPlayer_Num;
    [SyncVar]
    public int _iClient_Now;

    [SyncVar]
    public int _iNow_Time;

    public bool _bYour_Turn_Finish ;
    
    //public int[] tmp_Score;
    //public string[] tmp_Name;

    //設定State
    public void SetProcess(Process process)
    {
        this.process = process;
    }
    //存取玩家們一開始所選擇的顏色圖案
    [Command]
    public void CmdSet_Player_Color(int Player_Num)
    {
        _iPlayer_Num = Player_Num;
    }



    void Start()
    {
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.SetActive(false);
        _gcountdown1 = GameObject.Find("Count1");
        _gcountdown2 = GameObject.Find("Count2");
        _gcountdown3 = GameObject.Find("Count3");
        _bYour_Turn_Finish  = true;


        _gStart_Pos = GameObject.Find("Start_Position");
        _iCard_Num = -1;
        _bAnswer_Finish = false;
        _gArea = GameObject.Find("Place");
        _bCan_Change = false;
        _cGame_Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        _gGM = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (isServer)
        {
            _gGM = GameObject.Find("GameManager").GetComponent<GameManager>();
            _gGM.Login(this);

        }
        _sPlayer_Num = GameObject.Find("123").transform.Find("Player_Num").GetComponent<Text>().text;
        CmdSetName(GameObject.Find("123").GetComponent<InputField>().text);
       
        //CmdSet_Player_Color(GameObject.Find("123").transform.Find("Player_Num").GetComponent<Text>().text);
        CmdSet_Player_Color(int.Parse(_sPlayer_Num));
        if (isLocalPlayer)
        {
            Invoke("Countdown3", 1.0f);
            Invoke("Countdown2", 2.0f);
            Invoke("Countdown1", 3.0f);
            Invoke("Close", 4.0f);
            Timing = GameObject.Find("Timing").GetComponent<Button>();
            Timing.onClick.AddListener(() => Timing_Button());
            Restart = GameObject.Find("Restart").GetComponent<Button>();
            Restart.onClick.AddListener(() => Restart_Btn());

            _iCard_Point = 0;
            _sScore = "累積分數:" + _iCard_Point.ToString();
            A1_Btn = GameObject.Find("A1_Btn").GetComponent<Button>();
            A2_Btn = GameObject.Find("A2_Btn").GetComponent<Button>();
            A2_1Btn = GameObject.Find("A2_1_Btn").GetComponent<Button>();
            A2_2Btn = GameObject.Find("A2_2_Btn").GetComponent<Button>();
            A3_1Btn = GameObject.Find("A3_1_Btn").GetComponent<Button>();
            A3_2Btn = GameObject.Find("A3_2_Btn").GetComponent<Button>();
            A4_1Btn = GameObject.Find("A4_1_Btn").GetComponent<Button>();
            A4_2Btn = GameObject.Find("A4_2_Btn").GetComponent<Button>();
            A5_2Btn = GameObject.Find("A5_2_Btn").GetComponent<Button>();
            A6_2Btn = GameObject.Find("A6_2_Btn").GetComponent<Button>();
            A7_2Btn = GameObject.Find("A7_2_Btn").GetComponent<Button>();
            A8_2Btn = GameObject.Find("A8_2_Btn").GetComponent<Button>();
            A9_2Btn = GameObject.Find("A9_2_Btn").GetComponent<Button>();
            A10_2Btn = GameObject.Find("A10_2_Btn").GetComponent<Button>();
            A11_2Btn = GameObject.Find("A11_2_Btn").GetComponent<Button>();
            A12_2Btn = GameObject.Find("A12_2_Btn").GetComponent<Button>();
            B1_Btn1 = GameObject.Find("B1_Btn1").GetComponent<Button>();
            B1_Btn2 = GameObject.Find("B1_Btn2").GetComponent<Button>();
            B1_Btn3 = GameObject.Find("B1_Btn3").GetComponent<Button>();
            B1_Btn4 = GameObject.Find("B1_Btn4").GetComponent<Button>();
            B2_Btn1 = GameObject.Find("B2_1_Btn1").GetComponent<Button>();
            B2_Btn2 = GameObject.Find("B2_1_Btn2").GetComponent<Button>();
            B2_Btn3 = GameObject.Find("B2_1_Btn3").GetComponent<Button>();
            B2_Btn4 = GameObject.Find("B2_1_Btn4").GetComponent<Button>();
            B3_Btn1 = GameObject.Find("B3_1_Btn1").GetComponent<Button>();
            B3_Btn2 = GameObject.Find("B3_1_Btn2").GetComponent<Button>();
            B3_Btn3 = GameObject.Find("B3_1_Btn3").GetComponent<Button>();
            B3_Btn4 = GameObject.Find("B3_1_Btn4").GetComponent<Button>();
            B4_Btn1 = GameObject.Find("B4_1_Btn1").GetComponent<Button>();
            B4_Btn2 = GameObject.Find("B4_1_Btn2").GetComponent<Button>();
            B4_Btn3 = GameObject.Find("B4_1_Btn3").GetComponent<Button>();
            B4_Btn4 = GameObject.Find("B4_1_Btn4").GetComponent<Button>();
            B5_Btn1 = GameObject.Find("B5_1_Btn1").GetComponent<Button>();
            B5_Btn2 = GameObject.Find("B5_1_Btn2").GetComponent<Button>();
            B5_Btn3 = GameObject.Find("B5_1_Btn3").GetComponent<Button>();
            B5_Btn4 = GameObject.Find("B5_1_Btn4").GetComponent<Button>();
            B6_Btn1 = GameObject.Find("B6_1_Btn1").GetComponent<Button>();
            B6_Btn2 = GameObject.Find("B6_1_Btn2").GetComponent<Button>();
            B6_Btn3 = GameObject.Find("B6_1_Btn3").GetComponent<Button>();
            B6_Btn4 = GameObject.Find("B6_1_Btn4").GetComponent<Button>();
            B7_Btn1 = GameObject.Find("B7_1_Btn1").GetComponent<Button>();
            B7_Btn2 = GameObject.Find("B7_1_Btn2").GetComponent<Button>();
            B7_Btn3 = GameObject.Find("B7_1_Btn3").GetComponent<Button>();
            B7_Btn4 = GameObject.Find("B7_1_Btn4").GetComponent<Button>();
            D1_Btn1 = GameObject.Find("D1_Btn1").GetComponent<Button>();
            D1_Btn2 = GameObject.Find("D1_Btn2").GetComponent<Button>();
            D1_Btn3 = GameObject.Find("D1_Btn3").GetComponent<Button>();
            D2_Btn1 = GameObject.Find("D2_Btn1").GetComponent<Button>();
            D2_Btn2 = GameObject.Find("D2_Btn2").GetComponent<Button>();
            D2_Btn3 = GameObject.Find("D2_Btn3").GetComponent<Button>();
            txtsysMsg = GameObject.Find("sysMsg").GetComponent<Text>();
            btnDice = GameObject.Find("Dice_Btn").GetComponent<Button>();
            Add = GameObject.Find("Add");

            A1_Btn.onClick.AddListener(() =>
            {
                if (_bTouch_Finish_A1 == false && process == Process.action)
                {
                    _bTouch_Finish_A1 = true;
                    CmdA_Btn_1();
                }

            }
            );
            A2_Btn.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdA_Btn_2();
                }
            });
            A2_1Btn.onClick.AddListener(() => CmdA2_Btn_1());
            A2_2Btn.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdA2_Btn_2();
                }
            });
            A3_1Btn.onClick.AddListener(() => CmdA3_Btn_1());
            A3_2Btn.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdA3_Btn_2();
                }
            });
            A4_1Btn.onClick.AddListener(() => CmdA4_Btn_1());
            A4_2Btn.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdA4_Btn_2();
                }
            });
            A5_2Btn.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdA5_Btn_2();
                }
            }); 
            A6_2Btn.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdA6_Btn_2();
                }
            });
            
            A7_2Btn.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdA7_Btn_2();
                }
            });
           
            A8_2Btn.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdA8_Btn_2();
                }
            });

            A9_2Btn.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdA9_Btn_2();
                }
            });
            
            A10_2Btn.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdA10_Btn_2();
                }
            });
            
            A11_2Btn.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdA11_Btn_2();
                }
            });
            
            A12_2Btn.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdA12_Btn_2();
                }
            });
            
            B1_Btn1.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdB1_Btn1();
                }
            });
            
            B1_Btn2.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdB1_Btn2();
                }
            });
            
            B1_Btn3.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdB1_Btn3();
                }
            }); 
            B1_Btn4.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdB1_Btn4();
                }
            });
            
            B2_Btn1.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdB2_Btn1();
                }
            });
            
            B2_Btn2.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdB2_Btn2();
                }   
            }); 
            B2_Btn3.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdB2_Btn3();
                }
            });
            
            B2_Btn4.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdB2_Btn4();
                }
            });
            B3_Btn1.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdB3_Btn1();
                }
            });
            
            B3_Btn2.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdB3_Btn2();
                }
            });
            B3_Btn3.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdB3_Btn3();
                }
            });
            
            B3_Btn4.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdB3_Btn4();
                }
            });
            
            B4_Btn1.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdB4_Btn1();
                }
            }); 
            B4_Btn2.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdB4_Btn2();
                }
            });
            
            B4_Btn3.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdB4_Btn3();
                }
            });
            
            B4_Btn4.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdB4_Btn4();
                }
            });
            
            B5_Btn1.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdB5_Btn1();
                }
            });
            
            B5_Btn2.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdB5_Btn2();
                }
            });
            
            B5_Btn3.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdB5_Btn3();
                }
            });
            
            B5_Btn4.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdB5_Btn4();
                }
            });
            
            B6_Btn1.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdB6_Btn1();
                }
            });
            
            B6_Btn2.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdB6_Btn2();
                }
            });
            
            B6_Btn3.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdB6_Btn3();
                }
            });
            
            B6_Btn4.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdB6_Btn4();
                }
            });
            
            B7_Btn1.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdB7_Btn1();
                }
            });
            
            B7_Btn2.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdB7_Btn2();
                }
            });
            
            B7_Btn3.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdB7_Btn3();
                }
            });
            
            B7_Btn4.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdB7_Btn4();
                }
            });
            
            D1_Btn1.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdD1_Btn1();
                }
            });
            
            D1_Btn2.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdD1_Btn2();
                }
            });
            
            D1_Btn3.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                     CmdD1_Btn3();
                }
            });
            
            D2_Btn1.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdD2_Btn1();
                }
            });
            
            D2_Btn2.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdD2_Btn2();
                }
            });
            
            D2_Btn3.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.action)
                {
                    _bTouch_Finsih = true;
                    CmdD2_Btn3();
                }
            });
            
            btnDice.onClick.AddListener(() =>
            {
                if (_bTouch_Finsih == false && process == Process.dicingready)
                {
                    _bTouch_Finsih = true;
                    CmdDice();
                }
            });
            
            
        }
        if (!isLocalPlayer)
        {
            gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }


    }
    // 結算分數
    public void Timing_Button()
    {
        if(isServer && process !=Process.end)
        {
            _gGM.Server_Timing();
        }
        else if(isClient && process !=Process.end)
        {
            _gGM.Client_Timing();
        }
    }
    //再玩一次按鈕
    public void Restart_Btn()
    {
        if (isServer && process == Process.end)
        {
            _gGM.Server_Restart();
        }
        else if (isClient && process == Process.end)
        {
            _gGM.Client_Restart();
        }
    }
    //擲骰子
    [Command]
    public void CmdDice()
    {
       
            if (process == Process.dicingready && _bCan_Change == false)
            {
                 
                _gCard.GetComponent<Card_Type>()._bDice = false;
                _gDice_List.GetComponent<Dice>()._bSystem_Dicing_Img = true;
                print(1);
                CmdSet_Player();
                _gDice_List.GetComponent<Dice>()._bDice_Background = true;
                _gDice_List.GetComponent<Dice>()._bDice1_Anim = true;
                _gDice_List.GetComponent<Dice>()._bDice2_Anim = true;

                _gCard.GetComponent<Card_Type>()._bAdd = true;
                Invoke("CmdDice_Anim_Off", 2.0f);
                _iDice_Sum = 0;
                Dice_Tmp1 = Random.Range(1, 7);
                Dice_Tmp2 = Random.Range(1, 7);
                _iDice_Sum = Dice_Tmp1 + Dice_Tmp2;

                Dice_Sum.text = "=" + _iDice_Sum.ToString() + " 點";
                //RpcSet_Dice();
                Invoke("CmdDice_Off", 5.0f);
                if (_iNow_Pos + _iDice_Sum > 33)
                {
                    _vPlace = _gArea.GetComponent<Area_Pos>()._gPlace[_iDice_Sum - (33 - _iNow_Pos)].transform.position;
                }
                else
                {
                    _vPlace = _gArea.GetComponent<Area_Pos>()._gPlace[_iNow_Pos + _iDice_Sum].transform.position;
                }
            }
        
        


    }

    //骰子數值關閉
    [Command]
    public void CmdDice_Off()
    {
        _gDice_Music.GetComponent<Dice_Music>()._bWalk_Music = true;
        switch (Dice_Tmp1)
        {
            case 1:
                _gDice_List.GetComponent<Dice>()._bDice_1_1 = false;
                break;
            case 2:
                _gDice_List.GetComponent<Dice>()._bDice_1_2 = false;
                break;
            case 3:
                _gDice_List.GetComponent<Dice>()._bDice_1_3 = false;
                break;
            case 4:
                _gDice_List.GetComponent<Dice>()._bDice_1_4 = false;
                break;
            case 5:
                _gDice_List.GetComponent<Dice>()._bDice_1_5 = false;
                break;
            case 6:
                _gDice_List.GetComponent<Dice>()._bDice_1_6 = false;
                break;
        }
        switch (Dice_Tmp2)
        {
            case 1:
                _gDice_List.GetComponent<Dice>()._bDice_2_1 = false;
                break;
            case 2:
                _gDice_List.GetComponent<Dice>()._bDice_2_2 = false;
                break;
            case 3:
                _gDice_List.GetComponent<Dice>()._bDice_2_3 = false;
                break;
            case 4:
                _gDice_List.GetComponent<Dice>()._bDice_2_4 = false;
                break;
            case 5:
                _gDice_List.GetComponent<Dice>()._bDice_2_5 = false;
                break;
            case 6:
                _gDice_List.GetComponent<Dice>()._bDice_2_6 = false;
                break;
        }
        switch (_iDice_Sum)
        {
            case 2:
                _gDice_List.GetComponent<Dice>()._bDice_Sum_2 = false;
                _gDice_Music.GetComponent<Dice_Music>()._bDice_Two_Music = false;
                break;
            case 3:
                _gDice_List.GetComponent<Dice>()._bDice_Sum_3 = false;
                _gDice_Music.GetComponent<Dice_Music>()._bDice_Three_Music = false;
                break;
            case 4:
                _gDice_List.GetComponent<Dice>()._bDice_Sum_4 = false;
                _gDice_Music.GetComponent<Dice_Music>()._bDice_Four_Music = false;
                break;
            case 5:
                _gDice_List.GetComponent<Dice>()._bDice_Sum_5 = false;
                _gDice_Music.GetComponent<Dice_Music>()._bDice_Five_Music = false;
                break;
            case 6:
                _gDice_List.GetComponent<Dice>()._bDice_Sum_6 = false;
                _gDice_Music.GetComponent<Dice_Music>()._bDice_Six_Music = false;
                break;
            case 7:
                _gDice_List.GetComponent<Dice>()._bDice_Sum_7 = false;
                _gDice_Music.GetComponent<Dice_Music>()._bDice_Seven_Music = false;
                break;
            case 8:
                _gDice_List.GetComponent<Dice>()._bDice_Sum_8 = false;
                _gDice_Music.GetComponent<Dice_Music>()._bDice_Eight_Music = false;
                break;
            case 9:
                _gDice_List.GetComponent<Dice>()._bDice_Sum_9 = false;
                _gDice_Music.GetComponent<Dice_Music>()._bDice_Nine_Music = false;
                break;
            case 10:
                _gDice_List.GetComponent<Dice>()._bDice_Sum_10 = false;
                _gDice_Music.GetComponent<Dice_Music>()._bDice_Ten_Music = false;
                break;
            case 11:
                _gDice_List.GetComponent<Dice>()._bDice_Sum_11 = false;
                _gDice_Music.GetComponent<Dice_Music>()._bDice_Eleven_Music = false;
                break;
            case 12:
                _gDice_List.GetComponent<Dice>()._bDice_Sum_12 = false;
                _gDice_Music.GetComponent<Dice_Music>()._bDice_Twelve_Music = false;
                break;
        }
        _bCan_Change = true;
        _gCard.GetComponent<Card_Type>()._bAdd = false;
        _gDice_List.GetComponent<Dice>()._bDice_Background = false;
        _gDice_List.GetComponent<Dice>()._bSystem_Dicing_Img = false;
        _gDice_List.GetComponent<Dice>()._bSystem_Walking_Img = true;
       
        CmdSet_Player();

    }

    //骰子動畫關閉及數值計算
    [Command]
    public void CmdDice_Anim_Off()
    {
        _gDice_List.GetComponent<Dice>()._bDice1_Anim = false;
        _gDice_List.GetComponent<Dice>()._bDice2_Anim = false;
        switch (_iDice_Sum)
        {
            case 2:
                _gDice_List.GetComponent<Dice>()._bDice_Sum_2 = true;
                _gDice_Music.GetComponent<Dice_Music>()._bDice_Two_Music = true;
                break;
            case 3:
                _gDice_List.GetComponent<Dice>()._bDice_Sum_3 = true;
                _gDice_Music.GetComponent<Dice_Music>()._bDice_Three_Music = true;
                break;
            case 4:
                _gDice_List.GetComponent<Dice>()._bDice_Sum_4 = true;
                _gDice_Music.GetComponent<Dice_Music>()._bDice_Four_Music = true;
                break;
            case 5:
                _gDice_List.GetComponent<Dice>()._bDice_Sum_5 = true;
                _gDice_Music.GetComponent<Dice_Music>()._bDice_Five_Music = true;
                break;
            case 6:
                _gDice_List.GetComponent<Dice>()._bDice_Sum_6 = true;
                _gDice_Music.GetComponent<Dice_Music>()._bDice_Six_Music = true;
                break;
            case 7:
                _gDice_List.GetComponent<Dice>()._bDice_Sum_7 = true;
                _gDice_Music.GetComponent<Dice_Music>()._bDice_Seven_Music = true;
                break;
            case 8:
                _gDice_List.GetComponent<Dice>()._bDice_Sum_8 = true;
                _gDice_Music.GetComponent<Dice_Music>()._bDice_Eight_Music = true;
                break;
            case 9:
                _gDice_List.GetComponent<Dice>()._bDice_Sum_9 = true;
                _gDice_Music.GetComponent<Dice_Music>()._bDice_Nine_Music = true;
                break;
            case 10:
                _gDice_List.GetComponent<Dice>()._bDice_Sum_10 = true;
                _gDice_Music.GetComponent<Dice_Music>()._bDice_Ten_Music = true;
                break;
            case 11:
                _gDice_List.GetComponent<Dice>()._bDice_Sum_11 = true;
                _gDice_Music.GetComponent<Dice_Music>()._bDice_Eleven_Music = true;
                break;
            case 12:
                _gDice_List.GetComponent<Dice>()._bDice_Sum_12 = true;
                _gDice_Music.GetComponent<Dice_Music>()._bDice_Twelve_Music = true;
                break;
        }

        switch (Dice_Tmp1)
        {
            case 1:
                _gDice_List.GetComponent<Dice>()._bDice_1_1 = true;
                break;
            case 2:
                _gDice_List.GetComponent<Dice>()._bDice_1_2 = true;
                break;
            case 3:
                _gDice_List.GetComponent<Dice>()._bDice_1_3 = true;
                break;
            case 4:
                _gDice_List.GetComponent<Dice>()._bDice_1_4 = true;
                break;
            case 5:
                _gDice_List.GetComponent<Dice>()._bDice_1_5 = true;
                break;
            case 6:
                _gDice_List.GetComponent<Dice>()._bDice_1_6 = true;
                break;
        }
        switch (Dice_Tmp2)
        {
            case 1:
                _gDice_List.GetComponent<Dice>()._bDice_2_1 = true;
                break;
            case 2:
                _gDice_List.GetComponent<Dice>()._bDice_2_2 = true;
                break;
            case 3:
                _gDice_List.GetComponent<Dice>()._bDice_2_3 = true;
                break;
            case 4:
                _gDice_List.GetComponent<Dice>()._bDice_2_4 = true;
                break;
            case 5:
                _gDice_List.GetComponent<Dice>()._bDice_2_5 = true;
                break;
            case 6:
                _gDice_List.GetComponent<Dice>()._bDice_2_6 = true;
                break;
        }
    }

    //Set角色名字
    [Command]
    public void CmdSetName(string name)
    {
        _sName = name;
        gameObject.name = _sName;
        _tName.text = _sName;
    }

    //Set角色State
    [Command]
    public void CmdSet_Player()
    {
        if (process == Process.dicingready && _bCan_Change == false && _bAnswer_Finish == false)
        {
            print(11);
            _gGM.Change_Dicing();
        }
        else if (process == Process.dicing && _bCan_Change == true && _bAnswer_Finish == false)
        {

            print(22);
            _gGM.Change_Walking();
        }
       
        else if (process == Process.action && _bAnswer_Finish == true && _bCan_Again == false)
        {
            print(44);
            _gGM.Change_Player();
        }
        else if (_Time_up == true)
        {
            _gGM.Change_Ending();
        }
    }

    //Return一回合
    [Command]
    public void CmdReturn()
    {
        if (process == Process.action && _bCan_Again == true)
        {
            print("安安");
            _bCan_Again = false;
            _gGM.Play_Again();
        }
    }
   
    //判斷地板的種類
    [Command]
    public void CmdCard_Type()
    {
        _gDice_Music.GetComponent<Dice_Music>()._bWalk_Music = false;
        print("AAAA");
        switch (_gArea.GetComponent<Area_Pos>()._gPlace[_iNow_Pos].tag)
        {
            case "A":
                
                _iCard_Num = 0;
                     _gCard.GetComponent<Card_Type>()._bCard_A_1 = true;
                    _gCard.GetComponent<Card_Type>()._bCard_A_1_Btn = true;
                    _gCard.GetComponent<Card_Type>()._bCard_A_1_Text = true;
                break;
            case "B":
                _iCard_Num = 1;
                _gCard.GetComponent<Card_Type>()._bCard_B_1 = true;
                _gCard.GetComponent<Card_Type>()._bCard_B_1_Que = true;
                _gCard.GetComponent<Card_Type>()._bCard_B_1_Btn1 = true;
                _gCard.GetComponent<Card_Type>()._bCard_B_1_Btn2 = true;
                _gCard.GetComponent<Card_Type>()._bCard_B_1_Btn3 = true;
                _gCard.GetComponent<Card_Type>()._bCard_B_1_Btn4 = true;
                break;
            case "B2":
                _iCard_Num = 1;
                _gCard2.GetComponent<Card_Type2>()._bCard_B2_1 = true;
                _gCard2.GetComponent<Card_Type2>()._bCard_B2_1_Btn1 = true;
                _gCard2.GetComponent<Card_Type2>()._bCard_B2_1_Btn2 = true;
                _gCard2.GetComponent<Card_Type2>()._bCard_B2_1_Btn3 = true;
                _gCard2.GetComponent<Card_Type2>()._bCard_B2_1_Btn4 = true;
                break;
            case "B3":
                _iCard_Num = 1;
                _gCard3.GetComponent<Card_Type3>()._bCard_B3_1 = true;
                _gCard3.GetComponent<Card_Type3>()._bCard_B3_1_Btn1 = true;
                _gCard3.GetComponent<Card_Type3>()._bCard_B3_1_Btn2 = true;
                _gCard3.GetComponent<Card_Type3>()._bCard_B3_1_Btn3 = true;
                _gCard3.GetComponent<Card_Type3>()._bCard_B3_1_Btn4 = true;
                break;
            case "B4":
                _iCard_Num = 1;
                _gCard3.GetComponent<Card_Type3>()._bCard_B4_1 = true;
                _gCard3.GetComponent<Card_Type3>()._bCard_B4_1_Btn1 = true;
                _gCard3.GetComponent<Card_Type3>()._bCard_B4_1_Btn2 = true;
                _gCard3.GetComponent<Card_Type3>()._bCard_B4_1_Btn3 = true;
                _gCard3.GetComponent<Card_Type3>()._bCard_B4_1_Btn4 = true;
                break;
            case "B5":
                _iCard_Num = 1;
                _gCard3.GetComponent<Card_Type3>()._bCard_B5_1 = true;
                _gCard3.GetComponent<Card_Type3>()._bCard_B5_1_Btn1 = true;
                _gCard3.GetComponent<Card_Type3>()._bCard_B5_1_Btn2 = true;
                _gCard3.GetComponent<Card_Type3>()._bCard_B5_1_Btn3 = true;
                _gCard3.GetComponent<Card_Type3>()._bCard_B5_1_Btn4 = true;
                break;
            case "B6":
                _iCard_Num = 1;
                _gCard4.GetComponent<Card_Type4>()._bCard_B6_1 = true;
                _gCard4.GetComponent<Card_Type4>()._bCard_B6_1_Btn1 = true;
                _gCard4.GetComponent<Card_Type4>()._bCard_B6_1_Btn2 = true;
                _gCard4.GetComponent<Card_Type4>()._bCard_B6_1_Btn3 = true;
                _gCard4.GetComponent<Card_Type4>()._bCard_B6_1_Btn4 = true;
                break;
            case "B7":
                _iCard_Num = 1;
                _gCard4.GetComponent<Card_Type4>()._bCard_B7_1 = true;
                _gCard4.GetComponent<Card_Type4>()._bCard_B7_1_Btn1 = true;
                _gCard4.GetComponent<Card_Type4>()._bCard_B7_1_Btn2 = true;
                _gCard4.GetComponent<Card_Type4>()._bCard_B7_1_Btn3 = true;
                _gCard4.GetComponent<Card_Type4>()._bCard_B7_1_Btn4 = true;
                break;
            case "C":
                _iCard_Num = 2;
                _gCard.GetComponent<Card_Type>()._bCard_C_1 = true;
                _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
                _iCard_Point += 200;
                _sScore = "累積分數:" + _iCard_Point.ToString();
                Invoke("CmdC_Card", 3.0f);
                break;
            case "C3":
                _iCard_Num = 2;
                _gCard2.GetComponent<Card_Type2>()._bCard_C_3 = true;
                _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
                _iCard_Point += 200;
                
                _sScore = "累積分數:" + _iCard_Point.ToString();
                Invoke("CmdC_Card", 3.0f);
                break;
            case "C4":
                _iCard_Num = 2;
                _gCard2.GetComponent<Card_Type2>()._bCard_C_4 = true;
                _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
                _iCard_Point += 200;
                _sScore = "累積分數:" + _iCard_Point.ToString();
                Invoke("CmdC_Card", 3.0f);
                break;
            case "C2":
                _iCard_Num = 2;
                _gCard2.GetComponent<Card_Type2>()._bCard_C_2 = true;
                _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
                _iCard_Point += 200;
                _sScore = "累積分數:" + _iCard_Point.ToString();
                Invoke("CmdC_Card", 3.0f);
                break;
            case "D":
                _iCard_Num = 3;
                _gCard.GetComponent<Card_Type>()._bCard_D_1 = true;
                _gCard.GetComponent<Card_Type>()._bCard_D_1_Btn1 = true;
                _gCard.GetComponent<Card_Type>()._bCard_D_1_Btn2 = true;
                _gCard.GetComponent<Card_Type>()._bCard_D_1_Btn3 = true;
                break;
            case "D2":
                _iCard_Num = 3;
                _gCard4.GetComponent<Card_Type4>()._bCard_D_2 = true;
                _gCard4.GetComponent<Card_Type4>()._bCard_D_2_Btn1 = true;
                _gCard4.GetComponent<Card_Type4>()._bCard_D_2_Btn2 = true;
                _gCard4.GetComponent<Card_Type4>()._bCard_D_2_Btn3 = true;
                break;
            case "Again":
                _bCan_Again = true;
                //_gCard3.GetComponent<Card_Type3>()._bCard_Again = true;
                Invoke("CmdAgain", 3.0f);
                break;
            case "End":
                //_gDice_List.GetComponent<Dice>()._bCard_End = true;
                Invoke("CmdEnd", 3.0f);
                break;

        }
    }

   
    [Command]
    public void CmdA_Btn_1()
    {

        if(process == Process.action)
        {
            
            _gCard.GetComponent<Card_Type>()._bCard_A_1 = false;
            _gCard.GetComponent<Card_Type>()._bCard_A_1_Btn = false;
            _gCard.GetComponent<Card_Type>()._bCard_A_1_Text = false;
            int A_type;

            A_type = Random.Range(1, 13);

            _iCard_Num = 0;
            _gCard6.GetComponent<Card_Type6>()._bCard_A_Music = true;
            switch (A_type)
            {
               
                case 1:
                    _gCard.GetComponent<Card_Type>()._bCard_A_1 = false;
                    _gCard.GetComponent<Card_Type>()._bCard_A_1_Btn = false;
                    _gCard.GetComponent<Card_Type>()._bCard_A_1_Text = false;
                    _gCard.GetComponent<Card_Type>()._bCard_A_2 = true;
                    _gCard.GetComponent<Card_Type>()._bCard_A_2_Btn = true;
                    _gCard.GetComponent<Card_Type>()._bCard_A_2_Text = true;
                    break;

                case 2:
                    _gCard.GetComponent<Card_Type>()._bCard_A_1 = false;
                    _gCard.GetComponent<Card_Type>()._bCard_A_1_Btn = false;
                    _gCard.GetComponent<Card_Type>()._bCard_A_1_Text = false;
                    _gCard2.GetComponent<Card_Type2>()._bCard_A2_2 = true;
                    _gCard2.GetComponent<Card_Type2>()._bCard_A2_2_Btn = true;
                    _gCard2.GetComponent<Card_Type2>()._bCard_A2_2_Text = true;
                    break;

                case 3:
                    _gCard.GetComponent<Card_Type>()._bCard_A_1 = false;
                    _gCard.GetComponent<Card_Type>()._bCard_A_1_Btn = false;
                    _gCard.GetComponent<Card_Type>()._bCard_A_1_Text = false;
                    _gCard2.GetComponent<Card_Type2>()._bCard_A3_2 = true;
                    _gCard2.GetComponent<Card_Type2>()._bCard_A3_2_Btn = true;
                    _gCard2.GetComponent<Card_Type2>()._bCard_A3_2_Text = true;
                    break;
                case 4:
                    _gCard.GetComponent<Card_Type>()._bCard_A_1 = false;
                    _gCard.GetComponent<Card_Type>()._bCard_A_1_Btn = false;
                    _gCard.GetComponent<Card_Type>()._bCard_A_1_Text = false;
                    _gCard2.GetComponent<Card_Type2>()._bCard_A4_2 = true;
                    _gCard2.GetComponent<Card_Type2>()._bCard_A4_2_Btn = true;
                    _gCard2.GetComponent<Card_Type2>()._bCard_A4_2_Text = true;
                    break;
                case 5:
                    _gCard.GetComponent<Card_Type>()._bCard_A_1 = false;
                    _gCard.GetComponent<Card_Type>()._bCard_A_1_Btn = false;
                    _gCard.GetComponent<Card_Type>()._bCard_A_1_Text = false;
                    _gCard5.GetComponent<Card_Type5>()._bCard_A5_2_Btn = true;
                    _gCard5.GetComponent<Card_Type5>()._bCard_A5_2_Text = true;
                    break;
                case 6:
                    _gCard.GetComponent<Card_Type>()._bCard_A_1 = false;
                    _gCard.GetComponent<Card_Type>()._bCard_A_1_Btn = false;
                    _gCard.GetComponent<Card_Type>()._bCard_A_1_Text = false;
                    _gCard5.GetComponent<Card_Type5>()._bCard_A6_2_Btn = true;
                    _gCard5.GetComponent<Card_Type5>()._bCard_A6_2_Text = true;
                    break;
                case 7:
                    _gCard.GetComponent<Card_Type>()._bCard_A_1 = false;
                    _gCard.GetComponent<Card_Type>()._bCard_A_1_Btn = false;
                    _gCard.GetComponent<Card_Type>()._bCard_A_1_Text = false;
                    _gCard5.GetComponent<Card_Type5>()._bCard_A7_2_Btn = true;
                    _gCard5.GetComponent<Card_Type5>()._bCard_A7_2_Text = true;
                    break;
                case 8:
                    _gCard.GetComponent<Card_Type>()._bCard_A_1 = false;
                    _gCard.GetComponent<Card_Type>()._bCard_A_1_Btn = false;
                    _gCard.GetComponent<Card_Type>()._bCard_A_1_Text = false;
                    _gCard5.GetComponent<Card_Type5>()._bCard_A8_2_Btn = true;
                    _gCard5.GetComponent<Card_Type5>()._bCard_A8_2_Text = true;
                    break;
                case 9:
                    _gCard.GetComponent<Card_Type>()._bCard_A_1 = false;
                    _gCard.GetComponent<Card_Type>()._bCard_A_1_Btn = false;
                    _gCard.GetComponent<Card_Type>()._bCard_A_1_Text = false;
                    _gCard5.GetComponent<Card_Type5>()._bCard_A9_2_Btn = true;
                    _gCard5.GetComponent<Card_Type5>()._bCard_A9_2_Text = true;
                    break;
                case 10:
                    _gCard.GetComponent<Card_Type>()._bCard_A_1 = false;
                    _gCard.GetComponent<Card_Type>()._bCard_A_1_Btn = false;
                    _gCard.GetComponent<Card_Type>()._bCard_A_1_Text = false;
                    _gCard5.GetComponent<Card_Type5>()._bCard_A10_2_Btn = true;
                    _gCard5.GetComponent<Card_Type5>()._bCard_A10_2_Text = true;
                    break;
                case 11:
                    _gCard.GetComponent<Card_Type>()._bCard_A_1 = false;
                    _gCard.GetComponent<Card_Type>()._bCard_A_1_Btn = false;
                    _gCard.GetComponent<Card_Type>()._bCard_A_1_Text = false;
                    _gCard5.GetComponent<Card_Type5>()._bCard_A11_2_Btn = true;
                    _gCard5.GetComponent<Card_Type5>()._bCard_A11_2_Text = true;
                    break;
                case 12:
                    _gCard.GetComponent<Card_Type>()._bCard_A_1 = false;
                    _gCard.GetComponent<Card_Type>()._bCard_A_1_Btn = false;
                    _gCard.GetComponent<Card_Type>()._bCard_A_1_Text = false;
                    _gCard5.GetComponent<Card_Type5>()._bCard_A12_2_Btn = true;
                    _gCard5.GetComponent<Card_Type5>()._bCard_A11_2_Text = true;
                    break;
            }
            
            
        }
    }
    [Command]
    public void CmdA_Btn_2()
    {
        if (process == Process.action)
        {
            
            _gCard.GetComponent<Card_Type>()._bCard_A_2 = false;
            _gCard.GetComponent<Card_Type>()._bCard_A_2_Btn = false;
            _gCard.GetComponent<Card_Type>()._bCard_A_2_Text = false;
            _gCard.GetComponent<Card_Type>()._bCard_A_3 = true;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            Invoke("CmdA_Card", 3.0f);
            _iCard_Point += 200;
            _sScore = "累積分數:" + _iCard_Point.ToString();
        }
    }
    [Command]
    public void CmdA2_Btn_1()
    {
        if (process == Process.action)
        {
            _gCard2.GetComponent<Card_Type2>()._bCard_A2_1 = false;
            _gCard2.GetComponent<Card_Type2>()._bCard_A2_1_Btn = false;
            _gCard2.GetComponent<Card_Type2>()._bCard_A2_1_Text = false;
            _gCard2.GetComponent<Card_Type2>()._bCard_A2_2 = true;
            _gCard2.GetComponent<Card_Type2>()._bCard_A2_2_Btn = true;
            _gCard2.GetComponent<Card_Type2>()._bCard_A2_2_Text = true;
        }
    }
    [Command]
    public void CmdA2_Btn_2()
    {
        if (process == Process.action)
        {
            
            _gCard2.GetComponent<Card_Type2>()._bCard_A2_2 = false;
            _gCard2.GetComponent<Card_Type2>()._bCard_A2_2_Btn = false;
            _gCard2.GetComponent<Card_Type2>()._bCard_A2_2_Text = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            _gCard2.GetComponent<Card_Type2>()._bCard_A2_3 = true;
            //StartCoroutine(Waiting());
            Invoke("CmdA_Card", 3.0f);
            _iCard_Point += 200;
            _sScore = "累積分數:" + _iCard_Point.ToString();
        }
    }
    [Command]
    public void CmdA3_Btn_1()
    {
        if (process == Process.action)
        {

            _gCard2.GetComponent<Card_Type2>()._bCard_A3_1 = false;
            _gCard2.GetComponent<Card_Type2>()._bCard_A3_1_Btn = false;
            _gCard2.GetComponent<Card_Type2>()._bCard_A3_1_Text = false;
            _gCard2.GetComponent<Card_Type2>()._bCard_A3_2 = true;
            _gCard2.GetComponent<Card_Type2>()._bCard_A3_2_Btn = true;
            _gCard2.GetComponent<Card_Type2>()._bCard_A3_2_Text = true;
        }
    }
    [Command]
    public void CmdA3_Btn_2()
    {
        if (process == Process.action)
        {
            
            _gCard2.GetComponent<Card_Type2>()._bCard_A3_2 = false;
            _gCard2.GetComponent<Card_Type2>()._bCard_A3_2_Btn = false;
            _gCard2.GetComponent<Card_Type2>()._bCard_A3_2_Text = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            _gCard2.GetComponent<Card_Type2>()._bCard_A3_3 = true;
            //StartCoroutine(Waiting());
            Invoke("CmdA_Card", 3.0f);
            _iCard_Point += 200;
            _sScore = "累積分數:" + _iCard_Point.ToString();
        }
    }
    [Command]
    public void CmdA4_Btn_1()
    {
        if (process == Process.action)
        {
            _gCard2.GetComponent<Card_Type2>()._bCard_A4_1 = false;
            _gCard2.GetComponent<Card_Type2>()._bCard_A4_1_Btn = false;
            _gCard2.GetComponent<Card_Type2>()._bCard_A4_1_Text = false;
            _gCard2.GetComponent<Card_Type2>()._bCard_A4_2 = true;
            _gCard2.GetComponent<Card_Type2>()._bCard_A4_2_Btn = true;
            _gCard2.GetComponent<Card_Type2>()._bCard_A4_2_Text = true;
        }
    }
    [Command]
    public void CmdA4_Btn_2()
    {
        if (process == Process.action)
        {
            
            _gCard2.GetComponent<Card_Type2>()._bCard_A4_2 = false;
            _gCard2.GetComponent<Card_Type2>()._bCard_A4_2_Btn = false;
            _gCard2.GetComponent<Card_Type2>()._bCard_A4_2_Text = false;
            _gCard2.GetComponent<Card_Type2>()._bCard_A4_3 = true;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            Invoke("CmdA_Card", 3.0f);
            _iCard_Point += 200;
            _sScore = "累積分數:" + _iCard_Point.ToString();
        }
    }
    [Command]
    public void CmdA5_Btn_2()
    {
        if (process == Process.action)
        {
            
            _gCard5.GetComponent<Card_Type5>()._bCard_A5_2 = false;
            _gCard5.GetComponent<Card_Type5>()._bCard_A5_2_Btn = false;
            _gCard5.GetComponent<Card_Type5>()._bCard_A5_2_Text = false;
            _gCard5.GetComponent<Card_Type5>()._bCard_A5_3 = true;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            Invoke("CmdA_Card", 3.0f);
            _iCard_Point += 200;
            _sScore = "累積分數:" + _iCard_Point.ToString();
        }
    }
    [Command]
    public void CmdA6_Btn_2()
    {
        if (process == Process.action)
        {
            
            _gCard5.GetComponent<Card_Type5>()._bCard_A6_2 = false;
            _gCard5.GetComponent<Card_Type5>()._bCard_A6_2_Btn = false;
            _gCard5.GetComponent<Card_Type5>()._bCard_A6_2_Text = false;
            _gCard5.GetComponent<Card_Type5>()._bCard_A6_3 = true;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            Invoke("CmdA_Card", 3.0f);
            _iCard_Point += 200;
            _sScore = "累積分數:" + _iCard_Point.ToString();
        }
    }
    [Command]
    public void CmdA7_Btn_2()
    {
        if (process == Process.action)
        {
           
            _gCard5.GetComponent<Card_Type5>()._bCard_A7_2 = false;
            _gCard5.GetComponent<Card_Type5>()._bCard_A7_2_Btn = false;
            _gCard5.GetComponent<Card_Type5>()._bCard_A7_2_Text = false;
            _gCard5.GetComponent<Card_Type5>()._bCard_A7_3 = true;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            Invoke("CmdA_Card", 3.0f);
            _iCard_Point += 200;
            _sScore = "累積分數:" + _iCard_Point.ToString();
        }
    }
    [Command]
    public void CmdA8_Btn_2()
    {
        if (process == Process.action)
        {
            
            _gCard5.GetComponent<Card_Type5>()._bCard_A8_2 = false;
            _gCard5.GetComponent<Card_Type5>()._bCard_A8_2_Btn = false;
            _gCard5.GetComponent<Card_Type5>()._bCard_A8_2_Text = false;
            _gCard5.GetComponent<Card_Type5>()._bCard_A8_3 = true;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            Invoke("CmdA_Card", 3.0f);
            _iCard_Point += 200;
            _sScore = "累積分數:" + _iCard_Point.ToString();
        }
    }
    [Command]
    public void CmdA9_Btn_2()
    {
        if (process == Process.action)
        {
           
            _gCard5.GetComponent<Card_Type5>()._bCard_A9_2 = false;
            _gCard5.GetComponent<Card_Type5>()._bCard_A9_2_Btn = false;
            _gCard5.GetComponent<Card_Type5>()._bCard_A9_2_Text = false;
            _gCard5.GetComponent<Card_Type5>()._bCard_A9_3 = true;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            Invoke("CmdA_Card", 3.0f);
            _iCard_Point += 200;
            _sScore = "累積分數:" + _iCard_Point.ToString();
        }
    }
    [Command]
    public void CmdA10_Btn_2()
    {
        if (process == Process.action)
        {
            
            _gCard5.GetComponent<Card_Type5>()._bCard_A10_2 = false;
            _gCard5.GetComponent<Card_Type5>()._bCard_A10_2_Btn = false;
            _gCard5.GetComponent<Card_Type5>()._bCard_A10_2_Text = false;
            _gCard5.GetComponent<Card_Type5>()._bCard_A10_3 = true;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            Invoke("CmdA_Card", 3.0f);
            _iCard_Point += 200;
            _sScore = "累積分數:" + _iCard_Point.ToString();
        }
    }
    [Command]
    public void CmdA11_Btn_2()
    {
        if (process == Process.action)
        {
            
            _gCard5.GetComponent<Card_Type5>()._bCard_A11_2 = false;
            _gCard5.GetComponent<Card_Type5>()._bCard_A11_2_Btn = false;
            _gCard5.GetComponent<Card_Type5>()._bCard_A11_2_Text = false;
            _gCard5.GetComponent<Card_Type5>()._bCard_A11_3 = true;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            Invoke("CmdA_Card", 3.0f);
            _iCard_Point += 200;
            _sScore = "累積分數:" + _iCard_Point.ToString();
        }
    }
    [Command]
    public void CmdA12_Btn_2()
    {
        if (process == Process.action)
        {
            
            _gCard5.GetComponent<Card_Type5>()._bCard_A12_2 = false;
            _gCard5.GetComponent<Card_Type5>()._bCard_A12_2_Btn = false;
            _gCard5.GetComponent<Card_Type5>()._bCard_A11_2_Text = false;
            _gCard5.GetComponent<Card_Type5>()._bCard_A12_3 = true;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            Invoke("CmdA_Card", 3.0f);
            _iCard_Point += 200;
            _sScore = "累積分數:" + _iCard_Point.ToString();
        }

    }
    [Command]
    public void CmdA_Card()
    {
        _gCard.GetComponent<Card_Type>()._bCard_A_3 = false;
        _gCard2.GetComponent<Card_Type2>()._bCard_A2_3 = false;
        _gCard2.GetComponent<Card_Type2>()._bCard_A3_3 = false;
        _gCard2.GetComponent<Card_Type2>()._bCard_A4_3 = false;
        _gCard5.GetComponent<Card_Type5>()._bCard_A5_3 = false;
        _gCard5.GetComponent<Card_Type5>()._bCard_A6_3 = false;
        _gCard5.GetComponent<Card_Type5>()._bCard_A7_3 = false;
        _gCard5.GetComponent<Card_Type5>()._bCard_A8_3 = false;
        _gCard5.GetComponent<Card_Type5>()._bCard_A9_3 = false;
        _gCard5.GetComponent<Card_Type5>()._bCard_A10_3 = false;
        _gCard5.GetComponent<Card_Type5>()._bCard_A11_3 = false;
        _gCard5.GetComponent<Card_Type5>()._bCard_A12_3 = false;
        _gDice_List.GetComponent<Dice>()._bSystem_Walking_Img = false;
        _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = false;
        _gCard6.GetComponent<Card_Type6>()._bCard_A_Music = false;
        _gCard.GetComponent<Card_Type>()._bDice = true;
        _bAnswer_Finish = true;
        _bTouch_Finsih = false;
    }
    [Command]
    public void CmdB_Card()
    {
        _gCard.GetComponent<Card_Type>()._bCard_B_2 = false;
        _gDice_List.GetComponent<Dice>()._bCard_B1_Btn2_Img = false;
        _gDice_List.GetComponent<Dice>()._bCard_B1_Btn3_Img = false;
        _gDice_List.GetComponent<Dice>()._bCard_B1_Btn4_Img = false;

        _gCard2.GetComponent<Card_Type2>()._bCard_B2_2 = false;
        _gCard3.GetComponent<Card_Type3>()._bCard_B2_2_Btn2_Img = false;
        _gCard3.GetComponent<Card_Type3>()._bCard_B2_2_Btn3_Img = false;
        _gCard3.GetComponent<Card_Type3>()._bCard_B2_2_Btn4_Img = false;

        _gCard3.GetComponent<Card_Type3>()._bCard_B3_2 = false;
        _gCard3.GetComponent<Card_Type3>()._bCard_B3_2_Btn2_Img = false;
        _gCard3.GetComponent<Card_Type3>()._bCard_B3_2_Btn3_Img = false;
        _gCard3.GetComponent<Card_Type3>()._bCard_B3_2_Btn4_Img = false;

        _gCard3.GetComponent<Card_Type3>()._bCard_B4_2 = false;
        _gCard3.GetComponent<Card_Type3>()._bCard_B4_2_Btn2_Img = false;
        _gCard3.GetComponent<Card_Type3>()._bCard_B4_2_Btn3_Img = false;
        _gCard3.GetComponent<Card_Type3>()._bCard_B4_2_Btn4_Img = false;

        _gCard3.GetComponent<Card_Type3>()._bCard_B5_2 = false;
        _gCard3.GetComponent<Card_Type3>()._bCard_B5_2_Btn2_Img = false;
        _gCard3.GetComponent<Card_Type3>()._bCard_B5_2_Btn3_Img = false;
        _gCard3.GetComponent<Card_Type3>()._bCard_B5_2_Btn4_Img = false;

        _gCard4.GetComponent<Card_Type4>()._bCard_B6_2 = false;
        _gCard4.GetComponent<Card_Type4>()._bCard_B6_2_Btn2_Img = false;
        _gCard4.GetComponent<Card_Type4>()._bCard_B6_2_Btn3_Img = false;
        _gCard4.GetComponent<Card_Type4>()._bCard_B6_2_Btn4_Img = false;

        _gCard4.GetComponent<Card_Type4>()._bCard_B7_2 = false;
        _gCard4.GetComponent<Card_Type4>()._bCard_B7_2_Btn2_Img = false;
        _gCard4.GetComponent<Card_Type4>()._bCard_B7_2_Btn3_Img = false;
        _gCard4.GetComponent<Card_Type4>()._bCard_B7_2_Btn4_Img = false;

        _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = false;
        _gDice_List.GetComponent<Dice>()._bSystem_Walking_Img = false;
        _gCard.GetComponent<Card_Type>()._bDice = true;
        _bAnswer_Finish = true;
        _bTouch_Finsih = false;
    }
    [Command]
    public void CmdC_Card()
    {
        _gCard.GetComponent<Card_Type>()._bCard_C_1 = false;
        _gCard2.GetComponent<Card_Type2>()._bCard_C_2 = false;
        _gCard2.GetComponent<Card_Type2>()._bCard_C_3 = false;
        _gCard2.GetComponent<Card_Type2>()._bCard_C_4 = false;
        _bAnswer_Finish = true;
        _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = false;
        _gDice_List.GetComponent<Dice>()._bSystem_Walking_Img = false;
        _gCard.GetComponent<Card_Type>()._bDice = true;
        _bTouch_Finsih = false;

    }
    [Command]
    public void CmdD_Card()
    {
        
        _gCard.GetComponent<Card_Type>()._bCard_D_1 = false;
        _gCard.GetComponent<Card_Type>()._bCard_D_1_Btn1 = false;
        _gCard.GetComponent<Card_Type>()._bCard_D_1_Btn2 = false;
        _gCard.GetComponent<Card_Type>()._bCard_D_1_Btn3 = false;
        _gCard.GetComponent<Card_Type>()._bCard_D_1_Btn1_Img1 = false;
        _gCard.GetComponent<Card_Type>()._bCard_D_1_Btn1_Img2 = false;
        _gCard.GetComponent<Card_Type>()._bCard_D_1_Btn1_Img3 = false;
        _gCard.GetComponent<Card_Type>()._bCard_D_1_Btn2_Img1 = false;
        _gCard.GetComponent<Card_Type>()._bCard_D_1_Btn2_Img2 = false;
        _gCard.GetComponent<Card_Type>()._bCard_D_1_Btn2_Img3 = false;
        _gCard.GetComponent<Card_Type>()._bCard_D_1_Btn3_Img1 = false;
        _gCard.GetComponent<Card_Type>()._bCard_D_1_Btn3_Img2 = false;
        _gCard.GetComponent<Card_Type>()._bCard_D_1_Btn3_Img3 = false;

        _gCard4.GetComponent<Card_Type4>()._bCard_D_2 = false;
        _gCard4.GetComponent<Card_Type4>()._bCard_D_2_Btn1 = false;
        _gCard4.GetComponent<Card_Type4>()._bCard_D_2_Btn2 = false;
        _gCard4.GetComponent<Card_Type4>()._bCard_D_2_Btn3 = false;
        _gCard4.GetComponent<Card_Type4>()._bCard_D_2_Btn1_Img1 = false;
        _gCard4.GetComponent<Card_Type4>()._bCard_D_2_Btn1_Img2 = false;
        _gCard4.GetComponent<Card_Type4>()._bCard_D_2_Btn1_Img3 = false;
        _gCard4.GetComponent<Card_Type4>()._bCard_D_2_Btn2_Img1 = false;
        _gCard4.GetComponent<Card_Type4>()._bCard_D_2_Btn2_Img2 = false;
        _gCard4.GetComponent<Card_Type4>()._bCard_D_2_Btn2_Img3 = false;
        _gCard4.GetComponent<Card_Type4>()._bCard_D_2_Btn3_Img1 = false;
        _gCard4.GetComponent<Card_Type4>()._bCard_D_2_Btn3_Img2 = false;
        _gCard4.GetComponent<Card_Type4>()._bCard_D_2_Btn3_Img3 = false;

        _gCard6.GetComponent<Card_Type6>()._bCardD1_Btn1_Finish = false;
        _gCard6.GetComponent<Card_Type6>()._bCardD1_Btn2_Finish = false;
        _gCard6.GetComponent<Card_Type6>()._bCardD1_Btn3_Finish = false;
        _gCard6.GetComponent<Card_Type6>()._bCardD2_Btn1_Finish = false;
        _gCard6.GetComponent<Card_Type6>()._bCardD2_Btn2_Finish = false;
        _gCard6.GetComponent<Card_Type6>()._bCardD2_Btn3_Finish = false;

        _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = false;
        _gCard.GetComponent<Card_Type>()._bCard_D_Panel = false;
        _gDice_List.GetComponent<Dice>()._bSystem_Walking_Img = false;
        _gCard.GetComponent<Card_Type>()._bDice = true;
        _bAnswer_Finish = true;
        _bTouch_Finsih = false;
    }
    [Command]
    public void CmdAgain()
    {
        _bAnswer_Finish = true;
        _gDice_List.GetComponent<Dice>()._bSystem_Walking_Img = false;
        _gCard3.GetComponent<Card_Type3>()._bCard_Again = false;
        _gCard.GetComponent<Card_Type>()._bDice = true;
        _bTouch_Finsih = false;
    }
    [Command]
    public void CmdSet_Btn_True()
    {

    }



    [Command]
    public void CmdEnd()
    {
        //_gDice_List.GetComponent<Dice>()._bCard_End = false;
        _bAnswer_Finish = true;
        _gDice_List.GetComponent<Dice>()._bSystem_Walking_Img = false;
        _gCard.GetComponent<Card_Type>()._bDice = true;
        _bTouch_Finsih = false;
    }
    [Command]
    public void CmdB1_Btn1()
    {
        if (process == Process.action )
        {
           
            _gCard.GetComponent<Card_Type>()._bCard_B_1 = false;
            _gCard.GetComponent<Card_Type>()._bCard_B_1_Que = false;
            _gCard.GetComponent<Card_Type>()._bCard_B_2 = true;
            _gCard.GetComponent<Card_Type>()._bCard_B_1_Btn1 = false;
            _gCard.GetComponent<Card_Type>()._bCard_B_1_Btn2 = false;
            _gCard.GetComponent<Card_Type>()._bCard_B_1_Btn3 = false;
            _gCard.GetComponent<Card_Type>()._bCard_B_1_Btn4 = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            //_gCard.GetComponent<Card_Type>()._bCard_B_2 = false;
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            //_bAnswer_Finish = true;
            _iCard_Point += 200;
            _sScore = "累積分數:" + _iCard_Point.ToString();
            Invoke("CmdB_Card", 3.0f);

        }

    }
    [Command]
    public void CmdB1_Btn2()
    {
        if (process == Process.action)
        {
            
            _gCard.GetComponent<Card_Type>()._bCard_B_1 = false;
            _gCard.GetComponent<Card_Type>()._bCard_B_1_Que = false;
            _gDice_List.GetComponent<Dice>()._bCard_B1_Btn2_Img = true;
            _gCard.GetComponent<Card_Type>()._bCard_B_1_Btn1 = false;
            _gCard.GetComponent<Card_Type>()._bCard_B_1_Btn2 = false;
            _gCard.GetComponent<Card_Type>()._bCard_B_1_Btn3 = false;
            _gCard.GetComponent<Card_Type>()._bCard_B_1_Btn4 = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            //_gCard.GetComponent<Card_Type>()._bCard_B_2 = false;
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            //_bAnswer_Finish = true;
            _iCard_Point += 200;
            _sScore = "累積分數:" + _iCard_Point.ToString();
            Invoke("CmdB_Card", 3.0f);
        }
    }
    [Command]
    public void CmdB1_Btn3()
    {
        if (process == Process.action)
        {
            
            _gCard.GetComponent<Card_Type>()._bCard_B_1 = false;
            _gCard.GetComponent<Card_Type>()._bCard_B_1_Que = false;
            _gDice_List.GetComponent<Dice>()._bCard_B1_Btn3_Img = true;
            _gCard.GetComponent<Card_Type>()._bCard_B_1_Btn1 = false;
            _gCard.GetComponent<Card_Type>()._bCard_B_1_Btn2 = false;
            _gCard.GetComponent<Card_Type>()._bCard_B_1_Btn3 = false;
            _gCard.GetComponent<Card_Type>()._bCard_B_1_Btn4 = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            //_gCard.GetComponent<Card_Type>()._bCard_B_2 = false;
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            //_bAnswer_Finish = true;
            _iCard_Point += 200;
            _sScore = "累積分數:" + _iCard_Point.ToString();
            Invoke("CmdB_Card", 3.0f);
        }
    }
    [Command]
    public void CmdB1_Btn4()
    {
        if (process == Process.action)
        {
           
            _gCard.GetComponent<Card_Type>()._bCard_B_1 = false;
            _gCard.GetComponent<Card_Type>()._bCard_B_1_Que = false;
            _gDice_List.GetComponent<Dice>()._bCard_B1_Btn4_Img = true;
            _gCard.GetComponent<Card_Type>()._bCard_B_1_Btn1 = false;
            _gCard.GetComponent<Card_Type>()._bCard_B_1_Btn2 = false;
            _gCard.GetComponent<Card_Type>()._bCard_B_1_Btn3 = false;
            _gCard.GetComponent<Card_Type>()._bCard_B_1_Btn4 = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            //_gCard.GetComponent<Card_Type>()._bCard_B_2 = false;
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            //_bAnswer_Finish = true;
            _iCard_Point += 200;
            _sScore = "累積分數:" + _iCard_Point.ToString();
            Invoke("CmdB_Card", 3.0f);
        }
    }
    [Command]
    public void CmdB2_Btn1()
    {
        if (process == Process.action)
        {
            
            _gCard2.GetComponent<Card_Type2>()._bCard_B2_1 = false;
            _gCard2.GetComponent<Card_Type2>()._bCard_B2_2 = true;
            _gCard2.GetComponent<Card_Type2>()._bCard_B2_1_Btn1 = false;
            _gCard2.GetComponent<Card_Type2>()._bCard_B2_1_Btn2 = false;
            _gCard2.GetComponent<Card_Type2>()._bCard_B2_1_Btn3 = false;
            _gCard2.GetComponent<Card_Type2>()._bCard_B2_1_Btn4 = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            //_gCard.GetComponent<Card_Type>()._bCard_B_2 = false;
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            //_bAnswer_Finish = true;
            _iCard_Point += 200;
            _sScore = "累積分數:" + _iCard_Point.ToString();
            Invoke("CmdB_Card", 3.0f);

        }

    }
    [Command]
    public void CmdB2_Btn2()
    {
        if (process == Process.action)
        {
            
            _gCard2.GetComponent<Card_Type2>()._bCard_B2_1 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B2_2_Btn2_Img = true;
            _gCard2.GetComponent<Card_Type2>()._bCard_B2_1_Btn1 = false;
            _gCard2.GetComponent<Card_Type2>()._bCard_B2_1_Btn2 = false;
            _gCard2.GetComponent<Card_Type2>()._bCard_B2_1_Btn3 = false;
            _gCard2.GetComponent<Card_Type2>()._bCard_B2_1_Btn4 = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            //_gCard.GetComponent<Card_Type>()._bCard_B_2 = false;
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            //_bAnswer_Finish = true;
            _iCard_Point += 200;
            _sScore = "累積分數:" + _iCard_Point.ToString();
            Invoke("CmdB_Card", 3.0f);
        }
    }
    [Command]
    public void CmdB2_Btn3()
    {
        if (process == Process.action)
        {
            
            _gCard2.GetComponent<Card_Type2>()._bCard_B2_1 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B2_2_Btn3_Img = true;
            _gCard2.GetComponent<Card_Type2>()._bCard_B2_1_Btn1 = false;
            _gCard2.GetComponent<Card_Type2>()._bCard_B2_1_Btn2 = false;
            _gCard2.GetComponent<Card_Type2>()._bCard_B2_1_Btn3 = false;
            _gCard2.GetComponent<Card_Type2>()._bCard_B2_1_Btn4 = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            //_gCard.GetComponent<Card_Type>()._bCard_B_2 = false;
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            //_bAnswer_Finish = true;
            _iCard_Point += 200;
            _sScore = "累積分數:" + _iCard_Point.ToString();
            Invoke("CmdB_Card", 3.0f);
        }
    }
    [Command]
    public void CmdB2_Btn4()
    {
        if (process == Process.action)
        {
            
            _gCard2.GetComponent<Card_Type2>()._bCard_B2_1 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B2_2_Btn4_Img = true;
            _gCard2.GetComponent<Card_Type2>()._bCard_B2_1_Btn1 = false;
            _gCard2.GetComponent<Card_Type2>()._bCard_B2_1_Btn2 = false;
            _gCard2.GetComponent<Card_Type2>()._bCard_B2_1_Btn3 = false;
            _gCard2.GetComponent<Card_Type2>()._bCard_B2_1_Btn4 = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            //_gCard.GetComponent<Card_Type>()._bCard_B_2 = false;
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            //_bAnswer_Finish = true;
            _iCard_Point += 200;
            _sScore = "累積分數:" + _iCard_Point.ToString();
            Invoke("CmdB_Card", 3.0f);
        }
    }
    [Command]
    public void CmdB3_Btn1()
    {
        if (process == Process.action)
        {
            
            _gCard3.GetComponent<Card_Type3>()._bCard_B3_1 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B3_2 = true;
            _gCard3.GetComponent<Card_Type3>()._bCard_B3_1_Btn1 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B3_1_Btn2 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B3_1_Btn3 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B3_1_Btn4 = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            //_gCard.GetComponent<Card_Type>()._bCard_B_2 = false;
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            //_bAnswer_Finish = true;
            _iCard_Point += 400;
            _sScore = "累積分數:" + _iCard_Point.ToString();
            Invoke("CmdB_Card", 3.0f);

        }

    }
    [Command]
    public void CmdB3_Btn2()
    {
        if (process == Process.action)
        {
           
            _gCard3.GetComponent<Card_Type3>()._bCard_B3_1 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B3_2_Btn2_Img = true;
            _gCard3.GetComponent<Card_Type3>()._bCard_B3_1_Btn1 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B3_1_Btn2 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B3_1_Btn3 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B3_1_Btn4 = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            //_gCard.GetComponent<Card_Type>()._bCard_B_2 = false;
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            //_bAnswer_Finish = true;
            _iCard_Point += 300;
            _sScore = "累積分數:" + _iCard_Point.ToString();
            Invoke("CmdB_Card", 3.0f);
        }
    }
    [Command]
    public void CmdB3_Btn3()
    {
        if (process == Process.action)
        {
            
            _gCard3.GetComponent<Card_Type3>()._bCard_B3_1 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B3_2_Btn3_Img = true;
            _gCard3.GetComponent<Card_Type3>()._bCard_B3_1_Btn1 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B3_1_Btn2 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B3_1_Btn3 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B3_1_Btn4 = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            //_gCard.GetComponent<Card_Type>()._bCard_B_2 = false;
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            //_bAnswer_Finish = true;
            _iCard_Point += 500;
            _sScore = "累積分數:" + _iCard_Point.ToString();
            Invoke("CmdB_Card", 3.0f);
        }
    }
    [Command]
    public void CmdB3_Btn4()
    {
        if (process == Process.action)
        {
            
            _gCard3.GetComponent<Card_Type3>()._bCard_B3_1 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B3_2_Btn4_Img = true;
            _gCard3.GetComponent<Card_Type3>()._bCard_B3_1_Btn1 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B3_1_Btn2 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B3_1_Btn3 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B3_1_Btn4 = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            //_gCard.GetComponent<Card_Type>()._bCard_B_2 = false;
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            //_bAnswer_Finish = true;
            _iCard_Point += 200;
            _sScore = "累積分數:" + _iCard_Point.ToString();
            Invoke("CmdB_Card", 3.0f);
        }
    }
    [Command]
    public void CmdB4_Btn1()
    {
        if (process == Process.action)
        {
            
            _gCard3.GetComponent<Card_Type3>()._bCard_B4_1 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B4_2 = true;
            _gCard3.GetComponent<Card_Type3>()._bCard_B4_1_Btn1 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B4_1_Btn2 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B4_1_Btn3 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B4_1_Btn4 = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            //_gCard.GetComponent<Card_Type>()._bCard_B_2 = false;
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            //_bAnswer_Finish = true;
            _iCard_Point += 100;
            _sScore = "累積分數:" + _iCard_Point.ToString();
            Invoke("CmdB_Card", 3.0f);

        }

    }
    [Command]
    public void CmdB4_Btn2()
    {
        if (process == Process.action)
        {
            
            _gCard3.GetComponent<Card_Type3>()._bCard_B4_1 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B4_2_Btn2_Img = true;
            _gCard3.GetComponent<Card_Type3>()._bCard_B4_1_Btn1 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B4_1_Btn2 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B4_1_Btn3 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B4_1_Btn4 = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            //_gCard.GetComponent<Card_Type>()._bCard_B_2 = false;
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            //_bAnswer_Finish = true;
            _iCard_Point += 100;
            _sScore = "累積分數:" + _iCard_Point.ToString();
            Invoke("CmdB_Card", 3.0f);
        }
    }
    [Command]
    public void CmdB4_Btn3()
    {
        if (process == Process.action)
        {
            
            _gCard3.GetComponent<Card_Type3>()._bCard_B4_1 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B4_2_Btn3_Img = true;
            _gCard3.GetComponent<Card_Type3>()._bCard_B4_1_Btn1 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B4_1_Btn2 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B4_1_Btn3 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B4_1_Btn4 = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            //_gCard.GetComponent<Card_Type>()._bCard_B_2 = false;
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            //_bAnswer_Finish = true;
            _iCard_Point += 100;
            _sScore = "累積分數:" + _iCard_Point.ToString();
            Invoke("CmdB_Card", 3.0f);
        }
    }
    [Command]
    public void CmdB4_Btn4()
    {
        if (process == Process.action)
        {
            
            _gCard3.GetComponent<Card_Type3>()._bCard_B4_1 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B4_2_Btn4_Img = true;
            _gCard3.GetComponent<Card_Type3>()._bCard_B4_1_Btn1 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B4_1_Btn2 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B4_1_Btn3 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B4_1_Btn4 = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            //_gCard.GetComponent<Card_Type>()._bCard_B_2 = false;
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            //_bAnswer_Finish = true;
            _iCard_Point += 500;
            _sScore = "累積分數:" + _iCard_Point.ToString();
            Invoke("CmdB_Card", 3.0f);
        }
    }
    [Command]
    public void CmdB5_Btn1()
    {
        if (process == Process.action)
        {
           
            _gCard3.GetComponent<Card_Type3>()._bCard_B5_1 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B5_2 = true;
            _gCard3.GetComponent<Card_Type3>()._bCard_B5_1_Btn1 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B5_1_Btn2 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B5_1_Btn3 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B5_1_Btn4 = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            //_gCard.GetComponent<Card_Type>()._bCard_B_2 = false;
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            //_bAnswer_Finish = true;
            _iCard_Point += 500;
            _sScore = "累積分數:" + _iCard_Point.ToString();
            Invoke("CmdB_Card", 3.0f);

        }

    }
    [Command]
    public void CmdB5_Btn2()
    {
        if (process == Process.action)
        {
            
            _gCard3.GetComponent<Card_Type3>()._bCard_B5_1 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B5_2_Btn2_Img = true;
            _gCard3.GetComponent<Card_Type3>()._bCard_B5_1_Btn1 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B5_1_Btn2 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B5_1_Btn3 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B5_1_Btn4 = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            //_gCard.GetComponent<Card_Type>()._bCard_B_2 = false;
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            //_bAnswer_Finish = true;
            _iCard_Point += 100;
            _sScore = "累積分數:" + _iCard_Point.ToString();
            Invoke("CmdB_Card", 3.0f);
        }
    }
    [Command]
    public void CmdB5_Btn3()
    {
        if (process == Process.action)
        {
            
            _gCard3.GetComponent<Card_Type3>()._bCard_B5_1 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B5_2_Btn3_Img = true;
            _gCard3.GetComponent<Card_Type3>()._bCard_B5_1_Btn1 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B5_1_Btn2 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B5_1_Btn3 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B5_1_Btn4 = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            //_gCard.GetComponent<Card_Type>()._bCard_B_2 = false;
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            //_bAnswer_Finish = true;
            _iCard_Point += 100;
            _sScore = "累積分數:" + _iCard_Point.ToString();
            Invoke("CmdB_Card", 3.0f);
        }
    }
    [Command]
    public void CmdB5_Btn4()
    {
        if (process == Process.action)
        {
            
            _gCard3.GetComponent<Card_Type3>()._bCard_B5_1 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B5_2_Btn4_Img = true;
            _gCard3.GetComponent<Card_Type3>()._bCard_B5_1_Btn1 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B5_1_Btn2 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B5_1_Btn3 = false;
            _gCard3.GetComponent<Card_Type3>()._bCard_B5_1_Btn4 = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            //_gCard.GetComponent<Card_Type>()._bCard_B_2 = false;
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            //_bAnswer_Finish = true;
            _iCard_Point += 100;
            _sScore = "累積分數:" + _iCard_Point.ToString();
            Invoke("CmdB_Card", 3.0f);
        }
    }
    [Command]
    public void CmdB6_Btn1()
    {
        if (process == Process.action)
        {
            
            _gCard4.GetComponent<Card_Type4>()._bCard_B6_1 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B6_2 = true;
            _gCard4.GetComponent<Card_Type4>()._bCard_B6_1_Btn1 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B6_1_Btn2 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B6_1_Btn3 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B6_1_Btn4 = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            //_gCard.GetComponent<Card_Type>()._bCard_B_2 = false;
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            //_bAnswer_Finish = true;
            _iCard_Point += 100;
            _sScore = "累積分數:" + _iCard_Point.ToString();
            Invoke("CmdB_Card", 3.0f);

        }

    }
    [Command]
    public void CmdB6_Btn2()
    {
        if (process == Process.action)
        {
            
            _gCard4.GetComponent<Card_Type4>()._bCard_B6_1 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B6_2_Btn2_Img = true;
            _gCard4.GetComponent<Card_Type4>()._bCard_B6_1_Btn1 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B6_1_Btn2 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B6_1_Btn3 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B6_1_Btn4 = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            //_gCard.GetComponent<Card_Type>()._bCard_B_2 = false;
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            //_bAnswer_Finish = true;
            _iCard_Point += 500;
            _sScore = "累積分數:" + _iCard_Point.ToString();
            Invoke("CmdB_Card", 3.0f);
        }
    }
    [Command]
    public void CmdB6_Btn3()
    {
        if (process == Process.action)
        {
            
            _gCard4.GetComponent<Card_Type4>()._bCard_B6_1 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B6_2_Btn3_Img = true;
            _gCard4.GetComponent<Card_Type4>()._bCard_B6_1_Btn1 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B6_1_Btn2 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B6_1_Btn3 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B6_1_Btn4 = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            //_gCard.GetComponent<Card_Type>()._bCard_B_2 = false;
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            //_bAnswer_Finish = true;
            _iCard_Point += 100;
            _sScore = "累積分數:" + _iCard_Point.ToString();
            Invoke("CmdB_Card", 3.0f);
        }
    }
    [Command]
    public void CmdB6_Btn4()
    {
        if (process == Process.action)
        {
            
            _gCard4.GetComponent<Card_Type4>()._bCard_B6_1 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B6_2_Btn4_Img = true;
            _gCard4.GetComponent<Card_Type4>()._bCard_B6_1_Btn1 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B6_1_Btn2 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B6_1_Btn3 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B6_1_Btn4 = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            //_gCard.GetComponent<Card_Type>()._bCard_B_2 = false;
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            //_bAnswer_Finish = true;
            _iCard_Point += 100;
            _sScore = "累積分數:" + _iCard_Point.ToString();
            Invoke("CmdB_Card", 3.0f);
        }
    }
    [Command]
    public void CmdB7_Btn1()
    {
        if (process == Process.action)
        {
            
            _gCard4.GetComponent<Card_Type4>()._bCard_B7_1 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B7_2 = true;
            _gCard4.GetComponent<Card_Type4>()._bCard_B7_1_Btn1 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B7_1_Btn2 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B7_1_Btn3 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B7_1_Btn4 = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            //_gCard.GetComponent<Card_Type>()._bCard_B_2 = false;
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            //_bAnswer_Finish = true;
            _iCard_Point += 300;
            _sScore = "累積分數:" + _iCard_Point.ToString();
            Invoke("CmdB_Card", 3.0f);

        }

    }
    [Command]
    public void CmdB7_Btn2()
    {
        if (process == Process.action)
        {
           
            _gCard4.GetComponent<Card_Type4>()._bCard_B7_1 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B7_2_Btn2_Img = true;
            _gCard4.GetComponent<Card_Type4>()._bCard_B7_1_Btn1 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B7_1_Btn2 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B7_1_Btn3 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B7_1_Btn4 = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            //_gCard.GetComponent<Card_Type>()._bCard_B_2 = false;
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            //_bAnswer_Finish = true;
            _iCard_Point += 300;
            _sScore = "累積分數:" + _iCard_Point.ToString();
            Invoke("CmdB_Card", 3.0f);
        }
    }
    [Command]
    public void CmdB7_Btn3()
    {
        if (process == Process.action)
        {
            
            _gCard4.GetComponent<Card_Type4>()._bCard_B7_1 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B7_2_Btn3_Img = true;
            _gCard4.GetComponent<Card_Type4>()._bCard_B7_1_Btn1 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B7_1_Btn2 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B7_1_Btn3 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B7_1_Btn4 = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            //_gCard.GetComponent<Card_Type>()._bCard_B_2 = false;
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            //_bAnswer_Finish = true;
            _iCard_Point += 300;
            _sScore = "累積分數:" + _iCard_Point.ToString();
            Invoke("CmdB_Card", 3.0f);
        }
    }
    [Command]
    public void CmdB7_Btn4()
    {
        if (process == Process.action)
        {
            
            _gCard4.GetComponent<Card_Type4>()._bCard_B7_1 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B7_2_Btn4_Img = true;
            _gCard4.GetComponent<Card_Type4>()._bCard_B7_1_Btn1 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B7_1_Btn2 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B7_1_Btn3 = false;
            _gCard4.GetComponent<Card_Type4>()._bCard_B7_1_Btn4 = false;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            //StartCoroutine(Waiting());
            //_gCard.GetComponent<Card_Type>()._bCard_B_2 = false;
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            //_bAnswer_Finish = true;
            _iCard_Point += 300;
            _sScore = "累積分數:" + _iCard_Point.ToString();
            Invoke("CmdB_Card", 3.0f);
        }
    }
    [Command]
    public void CmdD1_Btn1()
    {
        if (process == Process.action)
        {
            
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            _gCard6.GetComponent<Card_Type6>()._bCardD1_Btn2_Finish = true;
            _gCard6.GetComponent<Card_Type6>()._bCardD1_Btn3_Finish = true;
            _gCard.GetComponent<Card_Type>()._bCard_D_Panel = true;
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            int Tmp_Rnd;
            Tmp_Rnd = Random.Range(1, 4);
            switch (Tmp_Rnd)
            {
                case 1:
                    _gCard.GetComponent<Card_Type>()._bCard_D_1_Btn1_Img1 = true;
                    _iCard_Point += 200;
                    _sScore = "累積分數:" + _iCard_Point.ToString();
                    break;
                case 2:
                    _gCard.GetComponent<Card_Type>()._bCard_D_1_Btn1_Img2 = true;
                    _iCard_Point += 500;
                    _sScore = "累積分數:" + _iCard_Point.ToString();
                    break;
                case 3:
                    _gCard.GetComponent<Card_Type>()._bCard_D_1_Btn1_Img3 = true;
                    
                    
                    _iCard_Point += 300;
                    _sScore = "累積分數:" + _iCard_Point.ToString();
                    break;

            }
          
            Invoke("CmdD_Card", 3.0f);
            //_bAnswer_Finish = true;
        }
    }
    [Command]
    public void CmdD1_Btn2()
    {
        if (process == Process.action)
        {
           
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            _gCard6.GetComponent<Card_Type6>()._bCardD1_Btn1_Finish = true;
            _gCard6.GetComponent<Card_Type6>()._bCardD1_Btn3_Finish = true;
            _gCard.GetComponent<Card_Type>()._bCard_D_Panel = true;
            int Tmp_Rnd;
            Tmp_Rnd = Random.Range(1, 4);
            switch (Tmp_Rnd)
            {
                case 1:
                    _gCard.GetComponent<Card_Type>()._bCard_D_1_Btn2_Img1 = true;
                    _iCard_Point += 200;
                    _sScore = "累積分數:" + _iCard_Point.ToString();
                    break;
                case 2:
                    _gCard.GetComponent<Card_Type>()._bCard_D_1_Btn2_Img2 = true;
                    _iCard_Point += 500;
                    _sScore = "累積分數:" + _iCard_Point.ToString();
                    break;
                case 3:
                    _gCard.GetComponent<Card_Type>()._bCard_D_1_Btn2_Img3 = true;
                    _iCard_Point += 300;
                    _sScore = "累積分數:" + _iCard_Point.ToString();
                    break;

            }
           
            Invoke("CmdD_Card", 3.0f);
            //_bAnswer_Finish = true;
        }
    }
    [Command]
    public void CmdD1_Btn3()
    {
        if (process == Process.action)
        {
           
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            _gCard6.GetComponent<Card_Type6>()._bCardD1_Btn1_Finish = true;
            _gCard6.GetComponent<Card_Type6>()._bCardD1_Btn2_Finish = true;
            _gCard.GetComponent<Card_Type>()._bCard_D_Panel = true;
            int Tmp_Rnd;
            Tmp_Rnd = Random.Range(1, 4);
            switch (Tmp_Rnd)
            {
                case 1:
                    _gCard.GetComponent<Card_Type>()._bCard_D_1_Btn3_Img1 = true;
                    _iCard_Point += 200;
                    _sScore = "累積分數:" + _iCard_Point.ToString();
                    break;
                case 2:
                    _gCard.GetComponent<Card_Type>()._bCard_D_1_Btn3_Img2 = true;
                    _iCard_Point += 500;
                    _sScore = "累積分數:" + _iCard_Point.ToString();
                    break;
                case 3:
                    _gCard.GetComponent<Card_Type>()._bCard_D_1_Btn3_Img3 = true;
                    _iCard_Point += 300;
                    _sScore = "累積分數:" + _iCard_Point.ToString();
                    break;

            }
        
            Invoke("CmdD_Card", 3.0f);
            //_bAnswer_Finish = true;
        }
    }
    [Command]
    public void CmdD2_Btn1()
    {
        if (process == Process.action)
        {
            
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            _gCard6.GetComponent<Card_Type6>()._bCardD2_Btn2_Finish = true;
            _gCard6.GetComponent<Card_Type6>()._bCardD2_Btn3_Finish = true;
            _gCard.GetComponent<Card_Type>()._bCard_D_Panel = true;
            int Tmp_Rnd;
            Tmp_Rnd = Random.Range(1, 4);
            switch (Tmp_Rnd)
            {
                case 1:
                    _gCard4.GetComponent<Card_Type4>()._bCard_D_2_Btn1_Img1 = true;
                    _iCard_Point += 200;
                    _sScore = "累積分數:" + _iCard_Point.ToString();
                    break;
                case 2:
                    _gCard4.GetComponent<Card_Type4>()._bCard_D_2_Btn1_Img2 = true;
                    _iCard_Point += 500;
                    _sScore = "累積分數:" + _iCard_Point.ToString();
                    break;
                case 3:
                    _gCard4.GetComponent<Card_Type4>()._bCard_D_2_Btn1_Img3 = true;
                    _iCard_Point += 300;
                    _sScore = "累積分數:" + _iCard_Point.ToString();
                    break;

            }
          
            Invoke("CmdD_Card", 3.0f);
            //_bAnswer_Finish = true;
        }
    }
    [Command]
    public void CmdD2_Btn2()
    {
        if (process == Process.action)
        {
           
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            _gCard6.GetComponent<Card_Type6>()._bCardD2_Btn1_Finish = true;
            _gCard6.GetComponent<Card_Type6>()._bCardD2_Btn3_Finish = true;
            _gCard.GetComponent<Card_Type>()._bCard_D_Panel = true;
            int Tmp_Rnd;
            Tmp_Rnd = Random.Range(1, 4);
            switch (Tmp_Rnd)
            {
                case 1:
                    _gCard4.GetComponent<Card_Type4>()._bCard_D_2_Btn2_Img1 = true;
                    _iCard_Point += 200;
                    _sScore = "累積分數:" + _iCard_Point.ToString();
                    break;
                case 2:
                    _gCard4.GetComponent<Card_Type4>()._bCard_D_2_Btn2_Img2 = true;
                    _iCard_Point += 500;
                    _sScore = "累積分數:" + _iCard_Point.ToString();
                    break;
                case 3:
                    _gCard4.GetComponent<Card_Type4>()._bCard_D_2_Btn2_Img3 = true;
                    _iCard_Point += 300;
                    _sScore = "累積分數:" + _iCard_Point.ToString();
                    break;

            }
        
            Invoke("CmdD_Card", 3.0f);
            //_bAnswer_Finish = true;
        }
    }
    [Command]
    public void CmdD2_Btn3()
    {
        if (process == Process.action)
        {
           
            //_gCard.GetComponent<Card_Type>()._bDice = true;
            _gCard6.GetComponent<Card_Type6>()._bCard_Select_Music = true;
            _gCard6.GetComponent<Card_Type6>()._bCardD2_Btn1_Finish = true;
            _gCard6.GetComponent<Card_Type6>()._bCardD2_Btn2_Finish = true;
            _gCard.GetComponent<Card_Type>()._bCard_D_Panel = true;
            int Tmp_Rnd;
            Tmp_Rnd = Random.Range(1, 4);
            switch (Tmp_Rnd)
            {
                case 1:
                    _gCard4.GetComponent<Card_Type4>()._bCard_D_2_Btn3_Img1 = true;
                    _iCard_Point += 200;
                    _sScore = "累積分數:" + _iCard_Point.ToString();
                    break;
                case 2:
                    _gCard4.GetComponent<Card_Type4>()._bCard_D_2_Btn3_Img2 = true;
                    _iCard_Point += 500;
                    _sScore = "累積分數:" + _iCard_Point.ToString();
                    break;
                case 3:
                    _gCard4.GetComponent<Card_Type4>()._bCard_D_2_Btn3_Img3 = true;
                    _iCard_Point += 300;
                    _sScore = "累積分數:" + _iCard_Point.ToString();
                    break;

            }
           
            Invoke("CmdD_Card", 3.0f);
            //_bAnswer_Finish = true;
        }
    }

    [ClientRpc]
    public void RpcSet_Btn()
    {
        _bTouch_Finish_A1 = false;
        _bTouch_Finsih = false;
    }
    //排序分數
    public void Sort_Score()
    {
        print("安安");
       int[] tmp_Score = new int[6];
        string[] tmp_Name = new string[6];
        
                tmp_Score[0] = int.Parse(_gGameOver.GetComponent<GameOver>()._g1_Score.GetComponent<Text>().text);
                tmp_Name[0] = _gGameOver.GetComponent<GameOver>()._g1_Name.GetComponent<Text>().text;
            
           
                tmp_Score[1] = int.Parse(_gGameOver.GetComponent<GameOver>()._g2_Score.GetComponent<Text>().text);
                tmp_Name[1] = _gGameOver.GetComponent<GameOver>()._g2_Name.GetComponent<Text>().text;
            
            
                tmp_Score[2] = int.Parse(_gGameOver.GetComponent<GameOver>()._g3_Score.GetComponent<Text>().text);
                tmp_Name[2] = _gGameOver.GetComponent<GameOver>()._g3_Name.GetComponent<Text>().text;
           
                tmp_Score[3] = int.Parse(_gGameOver.GetComponent<GameOver>()._g4_Score.GetComponent<Text>().text);
                tmp_Name[3] = _gGameOver.GetComponent<GameOver>()._g4_Name.GetComponent<Text>().text;

                tmp_Score[4] = int.Parse(_gGameOver.GetComponent<GameOver>()._g5_Score.GetComponent<Text>().text);
                tmp_Name[4] = _gGameOver.GetComponent<GameOver>()._g5_Name.GetComponent<Text>().text;

                tmp_Score[5] = int.Parse(_gGameOver.GetComponent<GameOver>()._g6_Score.GetComponent<Text>().text);
                tmp_Name[5] = _gGameOver.GetComponent<GameOver>()._g6_Name.GetComponent<Text>().text;

                _gGameOver.GetComponent<GameOver>()._g1_Score.GetComponent<Text>().text = "0";
                _gGameOver.GetComponent<GameOver>()._g1_Name.GetComponent<Text>().text = "";

                _gGameOver.GetComponent<GameOver>()._g2_Score.GetComponent<Text>().text = "0";
                _gGameOver.GetComponent<GameOver>()._g2_Name.GetComponent<Text>().text = "";

                _gGameOver.GetComponent<GameOver>()._g3_Score.GetComponent<Text>().text = "0";
                _gGameOver.GetComponent<GameOver>()._g3_Name.GetComponent<Text>().text = "";

                _gGameOver.GetComponent<GameOver>()._g4_Score.GetComponent<Text>().text = "0";
                _gGameOver.GetComponent<GameOver>()._g4_Name.GetComponent<Text>().text = "";

                _gGameOver.GetComponent<GameOver>()._g5_Score.GetComponent<Text>().text = "0";
                _gGameOver.GetComponent<GameOver>()._g5_Name.GetComponent<Text>().text = "";

                _gGameOver.GetComponent<GameOver>()._g6_Score.GetComponent<Text>().text = "0";
                _gGameOver.GetComponent<GameOver>()._g6_Name.GetComponent<Text>().text = "";

       


        for (int j = 5; j>0;--j)
            for(int k = 0;k<j;++k)
            {
                print("碰碰");
                if(tmp_Score[k] < tmp_Score[k+1])
                {
                    print("ㄅㄅ");
                    int tmp2;
                    string tmp3;
                    tmp2 = tmp_Score[k];
                    tmp_Score[k] = tmp_Score[k + 1];
                    tmp_Score[k + 1] = tmp2;
                    tmp3 = tmp_Name[k];
                    tmp_Name[k] = tmp_Name[k + 1];
                    tmp_Name[k + 1] = tmp3;
                }
            }

        _gGameOver.GetComponent<GameOver>()._g1_Score.GetComponent<Text>().text = tmp_Score[0].ToString() ;
        _gGameOver.GetComponent<GameOver>()._g1_Name.GetComponent<Text>().text = tmp_Name[0] ;

        _gGameOver.GetComponent<GameOver>()._g2_Score.GetComponent<Text>().text = tmp_Score[1].ToString();
        _gGameOver.GetComponent<GameOver>()._g2_Name.GetComponent<Text>().text = tmp_Name[1];
        _gGameOver.GetComponent<GameOver>()._g3_Score.GetComponent<Text>().text = tmp_Score[2].ToString();
        _gGameOver.GetComponent<GameOver>()._g3_Name.GetComponent<Text>().text = tmp_Name[2];

        _gGameOver.GetComponent<GameOver>()._g4_Score.GetComponent<Text>().text = tmp_Score[3].ToString();
        _gGameOver.GetComponent<GameOver>()._g4_Name.GetComponent<Text>().text = tmp_Name[3];


    }

    //倒數頁面
    public void Countdown1()
    {
        
        _gcountdown1.SetActive(true);
        _gcountdown2.SetActive(false);
        _gcountdown3.SetActive(false);
    }

    public void Countdown2()
    {
        _gcountdown1.SetActive(false);
        _gcountdown2.SetActive(true);
        _gcountdown3.SetActive(false);
    }

    public void Countdown3()
    {
        _gcountdown1.SetActive(false);
        _gcountdown2.SetActive(false);
        _gcountdown3.SetActive(true);

    }
    public void Close()
    {
        _gcountdown1.SetActive(false);
        
        if (isLocalPlayer)
        {
            _bYour_Turn_Finish = false;
            gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.SetActive(true);
            
            gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.SetActive(true);
            
        }
    }

    //分數列表
    public void Score_List()
    {
        Sort_Score();
        _gGameOver.GetComponent<GameOver>()._bTime_Up = false;
        _gGameOver.GetComponent<GameOver>()._bTime_Text = false;
        //_gGameOver.GetComponent<GameOver>()._gName.GetComponent<Text>().text = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>().text;
        _gGameOver.GetComponent<GameOver>()._bName = true;
        //
        //_gGameOver.GetComponent<GameOver>()._gScord.GetComponent<Text>().text = _iCard_Point.ToString();
        if (_iPlayer_Sum == 2)
        {
            _gGameOver.GetComponent<GameOver>()._b1_Name = true;
            _gGameOver.GetComponent<GameOver>()._b1_Score = true;
            _gGameOver.GetComponent<GameOver>()._b2_Name = true;
            _gGameOver.GetComponent<GameOver>()._b2_Score = true;
            _gGameOver.GetComponent<GameOver>()._bFirst = true;
            _gGameOver.GetComponent<GameOver>()._bSecond = true;
            
        }
        else if (_iPlayer_Sum == 3)
        {
            _gGameOver.GetComponent<GameOver>()._b1_Name = true;
            _gGameOver.GetComponent<GameOver>()._b1_Score = true;
            _gGameOver.GetComponent<GameOver>()._b2_Name = true;
            _gGameOver.GetComponent<GameOver>()._b2_Score = true;
            _gGameOver.GetComponent<GameOver>()._b3_Name = true;
            _gGameOver.GetComponent<GameOver>()._b3_Score = true;
            _gGameOver.GetComponent<GameOver>()._bFirst = true;
            _gGameOver.GetComponent<GameOver>()._bSecond = true;
            _gGameOver.GetComponent<GameOver>()._bThird = true;
            

        }
        else if (_iPlayer_Sum == 4)
        {
            _gGameOver.GetComponent<GameOver>()._b1_Name = true;
            _gGameOver.GetComponent<GameOver>()._b1_Score = true;
            _gGameOver.GetComponent<GameOver>()._b2_Name = true;
            _gGameOver.GetComponent<GameOver>()._b2_Score = true;
            _gGameOver.GetComponent<GameOver>()._b3_Name = true;
            _gGameOver.GetComponent<GameOver>()._b3_Score = true;
            _gGameOver.GetComponent<GameOver>()._b4_Name = true;
            _gGameOver.GetComponent<GameOver>()._b4_Score = true;
            _gGameOver.GetComponent<GameOver>()._bFirst = true;
            _gGameOver.GetComponent<GameOver>()._bSecond = true;
            _gGameOver.GetComponent<GameOver>()._bThird = true;
            _gGameOver.GetComponent<GameOver>()._bFourth = true;
        }
       
        _gGameOver.GetComponent<GameOver>()._bGameOver = true;
        _gGameOver.GetComponent<GameOver>()._bGo_Award = true;
    }

    public void Close_Your_Turn()
    {
        _gDice_List.GetComponent<Dice>()._bYour_Trun = false;
        

    }

    void Update()
    {
       
        _gCard = GameObject.Find("歡樂卡");
        _gCard2 = GameObject.Find("歡樂卡2");
        _gCard3 = GameObject.Find("歡樂卡3");
        _gCard4 = GameObject.Find("歡樂卡4");
        _gCard5 = GameObject.Find("歡樂卡5");
        _gCard6 = GameObject.Find("歡樂卡6");
        _gDice_Music = GameObject.Find("骰子聲音");
        _gDice_List = GameObject.Find("骰子");
        _gGameOver = GameObject.Find("結束畫面");

        if (isServer)
        {
            
            _iNow_Time = _gGM._iTime;
        }
       
        //存取角色資料
        if (_Time_up == false)
        {
           
            _gGM._iTime = _iNow_Time;
            switch (_iPlayer_Num)
            {

                case 0:
                   
                   
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(255,255,255,0);
                    gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("role01-01");
                    gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
                    gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>("role01-01");
                    _gGameOver.GetComponent<GameOver>()._g1_Name.GetComponent<Text>().text = gameObject.name;
                    _gGameOver.GetComponent<GameOver>()._g1_Score.GetComponent<Text>().text = _iCard_Point.ToString();
                    if (isLocalPlayer)
                    {
                        _gGameOver.GetComponent<GameOver>()._gName.GetComponent<Text>().text =  gameObject.name + "您好";
                        _gGameOver.GetComponent<GameOver>()._gScord.GetComponent<Text>().text = _iCard_Point.ToString();
                    }
                    break;
                case 1:

                    gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
                    gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("role02-01");
                    gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
                    gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>("role02-01");
                    _gGameOver.GetComponent<GameOver>()._g2_Name.GetComponent<Text>().text = gameObject.name;
                    _gGameOver.GetComponent<GameOver>()._g2_Score.GetComponent<Text>().text = _iCard_Point.ToString();
                    if (isLocalPlayer)
                    {
                        _gGameOver.GetComponent<GameOver>()._gName.GetComponent<Text>().text = gameObject.name + "您好";
                        _gGameOver.GetComponent<GameOver>()._gScord.GetComponent<Text>().text = _iCard_Point.ToString();
                    }
                    break;
                case 2:

                    gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
                    gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("role03-01");
                    gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
                    gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>("role03-01");
                    _gGameOver.GetComponent<GameOver>()._g3_Name.GetComponent<Text>().text = gameObject.name;
                    _gGameOver.GetComponent<GameOver>()._g3_Score.GetComponent<Text>().text = _iCard_Point.ToString();
                    if (isLocalPlayer)
                    {
                        _gGameOver.GetComponent<GameOver>()._gName.GetComponent<Text>().text =  gameObject.name + "您好";
                        _gGameOver.GetComponent<GameOver>()._gScord.GetComponent<Text>().text = _iCard_Point.ToString();
                    }
                    break;
                case 3:

                    gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
                    gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("role04-01");
                    gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
                    gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>("role04-01");
                    _gGameOver.GetComponent<GameOver>()._g4_Name.GetComponent<Text>().text = gameObject.name;
                    _gGameOver.GetComponent<GameOver>()._g4_Score.GetComponent<Text>().text = _iCard_Point.ToString();
                    if (isLocalPlayer)
                    {
                        _gGameOver.GetComponent<GameOver>()._gName.GetComponent<Text>().text = gameObject.name + "您好";
                        _gGameOver.GetComponent<GameOver>()._gScord.GetComponent<Text>().text = _iCard_Point.ToString();
                    }
                    break;
                case 4:

                    gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
                    gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("role05-01");
                    gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
                    gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>("role05-01");
                    _gGameOver.GetComponent<GameOver>()._g5_Name.GetComponent<Text>().text = gameObject.name;
                    _gGameOver.GetComponent<GameOver>()._g5_Score.GetComponent<Text>().text = _iCard_Point.ToString();
                    if (isLocalPlayer)
                    {
                        _gGameOver.GetComponent<GameOver>()._gName.GetComponent<Text>().text = gameObject.name + "您好";
                        _gGameOver.GetComponent<GameOver>()._gScord.GetComponent<Text>().text = _iCard_Point.ToString();
                    }
                    break;
                case 5:

                    gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
                    gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("role06-01");
                    gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
                    gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>("role06-01");
                    _gGameOver.GetComponent<GameOver>()._g6_Name.GetComponent<Text>().text = gameObject.name;
                    _gGameOver.GetComponent<GameOver>()._g6_Score.GetComponent<Text>().text = _iCard_Point.ToString();
                    if (isLocalPlayer)
                    {
                        _gGameOver.GetComponent<GameOver>()._gName.GetComponent<Text>().text = gameObject.name + "您好";
                        _gGameOver.GetComponent<GameOver>()._gScord.GetComponent<Text>().text = _iCard_Point.ToString();
                    }
                    break;
            }
        }
        else if(_Time_up == true)
        {
            gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.SetActive(false);
        }
        

       
        gameObject.name = _sName;
        _tName.text = _sName;
        
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>().text = _sScore;

        //拉近鏡頭顯示移動的角色名稱圖像
        if (SysMsg == (_sName +"走路中") && _bCan_Change == true && _bAnswer_Finish == false)
        {
            //gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.SetActive(true);
            _cGame_Camera.orthographicSize = Mathf.Lerp(_cGame_Camera.orthographicSize, 1.1f, Time.deltaTime);
            _cGame_Camera.transform.position = new Vector3(_Client_x, _Client_y, _cGame_Camera.transform.position.z);
            _bYour_Turn_Finish = false;
            
            _gCard.GetComponent<Card_Type>()._gDice.GetComponent<Animator>().enabled = false;
        }
        else
        {
            //gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.SetActive(false);
            //gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        if (process == Process.action && _bCan_Change == true)
        {
            
            gameObject.transform.GetChild(1).gameObject.GetComponent<Animator>().enabled = true;
            
        }
        else if (_bCan_Change == false)
        {
            
            gameObject.transform.GetChild(1).gameObject.GetComponent<Animator>().enabled = false;
            
        }
        //判斷是否到達骰子的點數位置並一步一步移動
        if (gameObject.transform.position != _vPlace  && _bCan_Change == true)
        {
            if (_iNow_Pos != 33)
            {
                
            }
            else if(_iNow_Pos == 33)
            {
                _iNow_Pos = 0;
            }
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _gArea.GetComponent<Area_Pos>()._gPlace[_iNow_Pos + 1].transform.position, Time.deltaTime * 1.0f);
            

            if (gameObject.transform.position == _gArea.GetComponent<Area_Pos>()._gPlace[_iNow_Pos + 1].transform.position)
            {
                    _iNow_Pos++;
                    if(_iNow_Pos == 33)
                    {
                        if (process == Process.action && isServer)
                        {
                            print(10040);
                            _iCard_Point += 1000;
                            _gCard6.GetComponent<Card_Type6>()._b1000_Point= true;
                            _sScore = "累積分數:" + _iCard_Point.ToString();
                            
                        }
                    }
            }
        }
        else if(gameObject.transform.position == _vPlace && _bCan_Change == true && _bAnswer_Finish == false)   //若到達則呼叫判斷卡片函式
        {
            
            if (process == Process.action)
            {
                RpcSet_Btn();
                print("CCCCC");
                if (isServer)
                {
                    CmdCard_Type();
                }
            }
            _bCan_Change = false;
        }
        //回答完卡片則切換State
        if (_bAnswer_Finish == true && _bCan_Again == false)
        {
            _gCard6.GetComponent<Card_Type6>()._b1000_Point = false ;
            RpcSet_Btn();
            CmdSet_Player();
            print(4);
            _bAnswer_Finish = false;
        }
        else if(_bAnswer_Finish == true && _bCan_Again == true)   //若是Again Card則重來
        {
            CmdReturn();
            print("重來");
            _bAnswer_Finish = false;
        }
        if (isServer)
        {
            _fPlayer_x = gameObject.transform.position.x;
            _fPlayer_y = gameObject.transform.position.y;
            _iClient_Now = _iNow_Pos;

        }
        //切換完之後鏡頭拉遠換下一個人
        if (_bCan_Change == false && _bAnswer_Finish == false && _gCard.GetComponent<Card_Type>()._bDice == true)
        {
            print(22222);

            gameObject.transform.GetChild(1).gameObject.GetComponent<Animator>().enabled = false;
            if (_Time_up == false)
            {

                switch (_iPlayer_Num)
                {

                    case 0:
                        _iNow_Pos = _iClient_Now;
                        gameObject.transform.position = new Vector3(_fPlayer_x, _fPlayer_y);

                        break;
                    case 1:
                        _iNow_Pos = _iClient_Now;
                        gameObject.transform.position = new Vector3(_fPlayer_x, _fPlayer_y);

                        break;
                    case 2:
                        _iNow_Pos = _iClient_Now;
                        gameObject.transform.position = new Vector3(_fPlayer_x, _fPlayer_y);
                        break;
                    case 3:
                        _iNow_Pos = _iClient_Now;
                        gameObject.transform.position = new Vector3(_fPlayer_x, _fPlayer_y);
                        break;
                    case 4:
                        _iNow_Pos = _iClient_Now;
                        gameObject.transform.position = new Vector3(_fPlayer_x, _fPlayer_y);
                        break;
                    case 5:
                        _iNow_Pos = _iClient_Now;
                        gameObject.transform.position = new Vector3(_fPlayer_x, _fPlayer_y);
                        break;
                }
            }
            _cGame_Camera.orthographicSize = Mathf.Lerp(_cGame_Camera.orthographicSize, 3.83f, Time.deltaTime);
            _cGame_Camera.transform.position = new Vector3(-7.97f, -0.78f, _cGame_Camera.transform.position.z);
        }
        
        _Client_x = gameObject.transform.position.x;
        _Client_y = gameObject.transform.position.y;
       
        //時間到達且這回合結束停止遊戲
        if (isServer)
        {
            if (_gGM._iTime <= 0 && _bCan_Change == false && _bAnswer_Finish == false && _gCard.GetComponent<Card_Type>()._bDice == true  &&_Time_up == false)
            {
                _iPlayer_Sum = _gGM.allPlayer.Count;
                //Sort_Score();
                _Time_up = true;
                _gGameOver.GetComponent<GameOver>()._bTime_Up = true;
                _gGameOver.GetComponent<GameOver>()._bTime_Text = true;
                _gCard6.GetComponent<Card_Type6>()._bAward_Music = true;

            }
        }

        //切換State為結束狀態並結算分數並且列出
        if(_Time_up == true && _bScore_List == false)
        {
            CmdSet_Player();
           if (isLocalPlayer)
            {
                
            }
            _cGame_Camera.GetComponent<AudioSource>().Pause();
            Invoke("Score_List", 3.0f);
            _bScore_List = true;
        }
        
        //設定玩家們的System Message
        if (isLocalPlayer)
        {
            txtsysMsg.text = SysMsg;
            
        }
        //若State為結束狀態則使時間歸零
        if(process == Process.end)
        {
            _gGM._iTime = 0;
        }

        if(isLocalPlayer)
        {
            if (process == Process.dicingready && _bYour_Turn_Finish == false)
            {
                _bYour_Turn_Finish = true;
                _gCard.GetComponent<Card_Type>()._gDice.GetComponent<Animator>().enabled = true;
                _gDice_List.GetComponent<Dice>()._bYour_Trun = true;
                Invoke("Close_Your_Turn", 3.0f);
            }
           
        }
        

    }
}