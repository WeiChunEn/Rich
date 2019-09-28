using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager :MonoBehaviour
{
    public enum Round
    {
        non,
        player1,
        player2,
        player3,
        player4
    }

    public enum Process
    {
        start,
        decideReady,
        decideWalking,
        decideDicing,
        p1Action,
        p2Action,
        p3Action,
        p4Action,
        p1DicingReady,
        p2DicingReady,
        p3DicingReady,
        p4DicingReady,
        p1Dicing,
        p2Dicing,
        p3Dicing,
        p4Dicing,
        checkWin,
        end,
    }
    
    
    public Round round = Round.non;
    public Process process = Process.start;
    public int _iroundCount = 0;
    public List<Player> allPlayer = new List<Player>();
    
    public int _iTime;
    public Text _tTime;
    public GameObject _gGame_Over;
    public GameObject _gTop_Panel;
    public GameObject _gCountDown_Panel;
    public Text _tSer_Name;
    public int _iPlayer_Num;
    // Use this for initialization
    void Start()
    {
        _iPlayer_Num = allPlayer.Count;
        _iTime = 1804;
        InvokeRepeating("timer", 0.0f, 1.0f);
        _gTop_Panel = GameObject.Find("TopPanel");
        _gCountDown_Panel = GameObject.Find("CountdownPanel");
        _gCountDown_Panel.SetActive(false);
        _tSer_Name.text = _gTop_Panel.transform.Find("Room_Name").GetComponent<Text>().text;
    }


    //換算時間
	void timer()
    {
        if (_iTime / 60 == 0)
        {
            _tTime.text = "剩餘時間:"+(_iTime / 60).ToString() + "0" + ":" ;
        }
        else if (_iTime / 60 > 0 && _iTime / 60 < 10)
        {
            _tTime.text = "剩餘時間:" + "0" + (_iTime / 60).ToString() + ":" ;
        }
        else
        {
            _tTime.text = "剩餘時間:" + (_iTime / 60).ToString() + ":" ;
        }
        if (_iTime%60==0)
        {
            _tTime.text += (_iTime % 60).ToString() + "0";
        }
        else if(_iTime % 60 >0 && _iTime %60 <10)
        {
            _tTime.text +=  "0" + (_iTime % 60).ToString();
        }
        else
        {
            _tTime.text +=  (_iTime % 60).ToString();
        }

        if (_iTime != 0)
        {
            _iTime--;
        }
        else if(_iTime == 0)
        {
            _iTime = 0;
        }
    }
	// Update is called once per frame
	void Update ()
    {

        _gGame_Over = GameObject.Find("結束畫面");
        //根據State切換玩家們的System Message
        if(allPlayer.Count == 4)
        {
            switch (process)
            {
                case Process.decideReady:
                    if (_iroundCount % allPlayer.Count == 0)
                    {
                        round = Round.player1;
                        process = Process.p1DicingReady;
                    }
                    else if (_iroundCount % allPlayer.Count == 1)
                    {
                        round = Round.player2;
                        process = Process.p2DicingReady;
                    }
                    else if (_iroundCount % allPlayer.Count == 2)
                    {
                        round = Round.player3;
                        process = Process.p3DicingReady;
                    }
                    else if (_iroundCount % allPlayer.Count == 3)
                    {
                        round = Round.player4;
                        process = Process.p4DicingReady;
                    }
                    //_iroundCount++;
                    break;
                case Process.decideDicing:
                    if (_iroundCount % allPlayer.Count == 0)
                    {
                        round = Round.player1;
                        process = Process.p1Dicing;
                    }
                    else if (_iroundCount % allPlayer.Count == 1)
                    {
                        round = Round.player2;
                        process = Process.p2Dicing;
                    }
                    else if (_iroundCount % allPlayer.Count == 2)
                    {
                        round = Round.player3;
                        process = Process.p3Dicing;
                    }
                    else if (_iroundCount % allPlayer.Count == 3)
                    {
                        round = Round.player4;
                        process = Process.p4Dicing;
                    }
                    //_iroundCount++;
                    break;
                case Process.decideWalking:
                    if (_iroundCount % allPlayer.Count == 0)
                    {
                        round = Round.player1;
                        process = Process.p1Action;
                    }
                    else if (_iroundCount % allPlayer.Count == 1)
                    {
                        round = Round.player2;
                        process = Process.p2Action;
                    }
                    else if (_iroundCount % allPlayer.Count == 2)
                    {
                        round = Round.player3;
                        process = Process.p3Action;
                    }
                    else if (_iroundCount % allPlayer.Count == 3)
                    {
                        round = Round.player4;
                        process = Process.p4Action;
                    }
                    _iroundCount++;
                    break;
                case Process.p1DicingReady:
                    allPlayer[0].SysMsg = "請" + allPlayer[0].name + "擲骰子!";
                    allPlayer[0].SetProcess(Player.Process.dicingready);
                    allPlayer[1].SysMsg = "等待" + allPlayer[0].name + "擲骰子";
                    allPlayer[1].SetProcess(Player.Process.wait);
                    allPlayer[2].SysMsg = "等待" + allPlayer[0].name + "擲骰子";
                    allPlayer[2].SetProcess(Player.Process.wait);
                    allPlayer[3].SysMsg = "等待" + allPlayer[0].name + "擲骰子";
                    allPlayer[3].SetProcess(Player.Process.wait);
                    break;
                case Process.p2DicingReady:
                    allPlayer[1].SysMsg = "請" + allPlayer[1].name + "擲骰子";
                    allPlayer[1].SetProcess(Player.Process.dicingready);
                    allPlayer[0].SysMsg = "等待" + allPlayer[1].name + "擲骰子";
                    allPlayer[0].SetProcess(Player.Process.wait);
                    allPlayer[2].SysMsg = "等待" + allPlayer[1].name + "擲骰子";
                    allPlayer[2].SetProcess(Player.Process.wait);
                    allPlayer[3].SysMsg = "等待" + allPlayer[1].name + "擲骰子";
                    allPlayer[3].SetProcess(Player.Process.wait);
                    break;
                case Process.p3DicingReady:
                    allPlayer[2].SysMsg = "請" + allPlayer[2].name + "擲骰子";
                    allPlayer[2].SetProcess(Player.Process.dicingready);
                    allPlayer[1].SysMsg = "等待" + allPlayer[2].name + "擲骰子";
                    allPlayer[1].SetProcess(Player.Process.wait);
                    allPlayer[0].SysMsg = "等待" + allPlayer[2].name + "擲骰子";
                    allPlayer[0].SetProcess(Player.Process.wait);
                    allPlayer[3].SysMsg = "等待" + allPlayer[2].name + "擲骰子";
                    allPlayer[3].SetProcess(Player.Process.wait);
                    break;
                case Process.p4DicingReady:
                    allPlayer[3].SysMsg = "請" + allPlayer[3].name + "擲骰子!";
                    allPlayer[3].SetProcess(Player.Process.dicingready);
                    allPlayer[1].SysMsg = "等待" + allPlayer[3].name + "擲骰子";
                    allPlayer[1].SetProcess(Player.Process.wait);
                    allPlayer[2].SysMsg = "等待" + allPlayer[3].name + "擲骰子";
                    allPlayer[2].SetProcess(Player.Process.wait);
                    allPlayer[0].SysMsg = "等待" + allPlayer[3].name + "擲骰子";
                    allPlayer[0].SetProcess(Player.Process.wait);
                    break;
                case Process.p1Dicing:
                    allPlayer[0].SysMsg = allPlayer[0].name + "擲骰子中";
                    allPlayer[0].SetProcess(Player.Process.dicing);
                    allPlayer[1].SysMsg = "等待" + allPlayer[0].name + "擲骰子";
                    allPlayer[1].SetProcess(Player.Process.wait);
                    allPlayer[2].SysMsg = "等待" + allPlayer[0].name + "擲骰子";
                    allPlayer[2].SetProcess(Player.Process.wait);
                    allPlayer[3].SysMsg = "等待" + allPlayer[0].name + "擲骰子";
                    allPlayer[3].SetProcess(Player.Process.wait);
                    break;
                case Process.p2Dicing:
                    allPlayer[1].SysMsg = allPlayer[1].name + "擲骰子中";
                    allPlayer[1].SetProcess(Player.Process.dicing);
                    allPlayer[0].SysMsg = "等待" + allPlayer[1].name + "擲骰子";
                    allPlayer[0].SetProcess(Player.Process.wait);
                    allPlayer[2].SysMsg = "等待" + allPlayer[1].name + "擲骰子";
                    allPlayer[2].SetProcess(Player.Process.wait);
                    allPlayer[3].SysMsg = "等待" + allPlayer[1].name + "擲骰子";
                    allPlayer[3].SetProcess(Player.Process.wait);
                    break;
                case Process.p3Dicing:
                    allPlayer[2].SysMsg = allPlayer[2].name + "擲骰子中";
                    allPlayer[2].SetProcess(Player.Process.dicing);
                    allPlayer[1].SysMsg = "等待" + allPlayer[2].name + "擲骰子";
                    allPlayer[1].SetProcess(Player.Process.wait);
                    allPlayer[0].SysMsg = "等待" + allPlayer[2].name + "擲骰子";
                    allPlayer[0].SetProcess(Player.Process.wait);
                    allPlayer[3].SysMsg = "等待" + allPlayer[2].name + "擲骰子";
                    allPlayer[3].SetProcess(Player.Process.wait);
                    break;
                case Process.p4Dicing:
                    allPlayer[3].SysMsg = allPlayer[3].name + "擲骰子中";
                    allPlayer[3].SetProcess(Player.Process.dicing);
                    allPlayer[1].SysMsg = "等待" + allPlayer[3].name + "擲骰子";
                    allPlayer[1].SetProcess(Player.Process.wait);
                    allPlayer[2].SysMsg = "等待" + allPlayer[3].name + "擲骰子";
                    allPlayer[2].SetProcess(Player.Process.wait);
                    allPlayer[0].SysMsg = "等待" + allPlayer[3].name + "擲骰子";
                    allPlayer[0].SetProcess(Player.Process.wait);
                    break;
                case Process.p1Action:

                    allPlayer[0].SysMsg = allPlayer[0].name + "走路中";
                    allPlayer[0].SetProcess(Player.Process.action);
                    allPlayer[1].SysMsg = "等待" + allPlayer[0].name + "行動";
                    allPlayer[1].SetProcess(Player.Process.wait);
                    allPlayer[2].SysMsg = "等待" + allPlayer[0].name + "行動";
                    allPlayer[2].SetProcess(Player.Process.wait);
                    allPlayer[3].SysMsg = "等待" + allPlayer[0].name + "行動";
                    allPlayer[3].SetProcess(Player.Process.wait);
                    break;
                case Process.p2Action:
                    allPlayer[1].SysMsg = allPlayer[1].name + "走路中";
                    allPlayer[1].SetProcess(Player.Process.action);
                    allPlayer[0].SysMsg = "等待" + allPlayer[1].name + "行動";
                    allPlayer[0].SetProcess(Player.Process.wait);
                    allPlayer[2].SysMsg = "等待" + allPlayer[1].name + "行動";
                    allPlayer[2].SetProcess(Player.Process.wait);
                    allPlayer[3].SysMsg = "等待" + allPlayer[1].name + "行動";
                    allPlayer[3].SetProcess(Player.Process.wait);
                    break;
                case Process.p3Action:
                    allPlayer[2].SysMsg = allPlayer[2].name + "走路中";
                    allPlayer[2].SetProcess(Player.Process.action);
                    allPlayer[1].SysMsg = "等待" + allPlayer[2].name + "行動";
                    allPlayer[1].SetProcess(Player.Process.wait);
                    allPlayer[0].SysMsg = "等待" + allPlayer[2].name + "行動";
                    allPlayer[0].SetProcess(Player.Process.wait);
                    allPlayer[3].SysMsg = "等待" + allPlayer[2].name + "行動";
                    allPlayer[3].SetProcess(Player.Process.wait);
                    break;
                case Process.p4Action:
                    allPlayer[3].SysMsg = allPlayer[3].name + "走路中";
                    allPlayer[3].SetProcess(Player.Process.action);
                    allPlayer[1].SysMsg = "等待" + allPlayer[3].name + "行動";
                    allPlayer[1].SetProcess(Player.Process.wait);
                    allPlayer[2].SysMsg = "等待" + allPlayer[3].name + "行動";
                    allPlayer[2].SetProcess(Player.Process.wait);
                    allPlayer[0].SysMsg = "等待" + allPlayer[3].name + "行動";
                    allPlayer[0].SetProcess(Player.Process.wait);
                    break;
                case Process.end:
                    allPlayer[3].SysMsg = "遊戲結束";
                    allPlayer[3].SetProcess(Player.Process.end);
                    allPlayer[0].SysMsg = "遊戲結束";
                    allPlayer[0].SetProcess(Player.Process.end);
                    allPlayer[1].SysMsg = "遊戲結束";
                    allPlayer[1].SetProcess(Player.Process.end);
                    allPlayer[2].SysMsg = "遊戲結束";
                    allPlayer[2].SetProcess(Player.Process.end);
                    _iTime = 0;
                    break;
            }
        }
        else if (allPlayer.Count == 3)
        {
            switch (process)
            {
                case Process.decideReady:
                    if (_iroundCount % allPlayer.Count == 0)
                    {
                        round = Round.player1;
                        process = Process.p1DicingReady;
                    }
                    else if (_iroundCount % allPlayer.Count == 1)
                    {
                        round = Round.player2;
                        process = Process.p2DicingReady;
                    }
                    else if (_iroundCount % allPlayer.Count == 2)
                    {
                        round = Round.player3;
                        process = Process.p3DicingReady;
                    }
                   
                    //_iroundCount++;
                    break;
                case Process.decideDicing:
                    if (_iroundCount % allPlayer.Count == 0)
                    {
                        round = Round.player1;
                        process = Process.p1Dicing;
                    }
                    else if (_iroundCount % allPlayer.Count == 1)
                    {
                        round = Round.player2;
                        process = Process.p2Dicing;
                    }
                    else if (_iroundCount % allPlayer.Count == 2)
                    {
                        round = Round.player3;
                        process = Process.p3Dicing;
                    }
                   
                    //_iroundCount++;
                    break;
                case Process.decideWalking:
                    if (_iroundCount % allPlayer.Count == 0)
                    {
                        round = Round.player1;
                        process = Process.p1Action;
                    }
                    else if (_iroundCount % allPlayer.Count == 1)
                    {
                        round = Round.player2;
                        process = Process.p2Action;
                    }
                    else if (_iroundCount % allPlayer.Count == 2)
                    {
                        round = Round.player3;
                        process = Process.p3Action;
                    }
                  
                    _iroundCount++;
                    break;
                case Process.p1DicingReady:
                    allPlayer[0].SysMsg = "請" + allPlayer[0].name + "擲骰子!";
                    allPlayer[0].SetProcess(Player.Process.dicingready);
                    allPlayer[1].SysMsg = "等待" + allPlayer[0].name + "擲骰子";
                    allPlayer[1].SetProcess(Player.Process.wait);
                    allPlayer[2].SysMsg = "等待" + allPlayer[0].name + "擲骰子";
                    allPlayer[2].SetProcess(Player.Process.wait);
                    
                    break;
                case Process.p2DicingReady:
                    allPlayer[1].SysMsg = "請" + allPlayer[1].name + "擲骰子";
                    allPlayer[1].SetProcess(Player.Process.dicingready);
                    allPlayer[0].SysMsg = "等待" + allPlayer[1].name + "擲骰子";
                    allPlayer[0].SetProcess(Player.Process.wait);
                    allPlayer[2].SysMsg = "等待" + allPlayer[1].name + "擲骰子";
                    allPlayer[2].SetProcess(Player.Process.wait);
                   
                    break;
                case Process.p3DicingReady:
                    allPlayer[2].SysMsg = "請" + allPlayer[2].name + "擲骰子";
                    allPlayer[2].SetProcess(Player.Process.dicingready);
                    allPlayer[1].SysMsg = "等待" + allPlayer[2].name + "擲骰子";
                    allPlayer[1].SetProcess(Player.Process.wait);
                    allPlayer[0].SysMsg = "等待" + allPlayer[2].name + "擲骰子";
                    allPlayer[0].SetProcess(Player.Process.wait);
                   
                    break;
             
                case Process.p1Dicing:
                    allPlayer[0].SysMsg = allPlayer[0].name + "擲骰子中";
                    allPlayer[0].SetProcess(Player.Process.dicing);
                    allPlayer[1].SysMsg = "等待" + allPlayer[0].name + "擲骰子";
                    allPlayer[1].SetProcess(Player.Process.wait);
                    allPlayer[2].SysMsg = "等待" + allPlayer[0].name + "擲骰子";
                    allPlayer[2].SetProcess(Player.Process.wait);
                 
                    break;
                case Process.p2Dicing:
                    allPlayer[1].SysMsg = allPlayer[1].name + "擲骰子中";
                    allPlayer[1].SetProcess(Player.Process.dicing);
                    allPlayer[0].SysMsg = "等待" + allPlayer[1].name + "擲骰子";
                    allPlayer[0].SetProcess(Player.Process.wait);
                    allPlayer[2].SysMsg = "等待" + allPlayer[1].name + "擲骰子";
                    allPlayer[2].SetProcess(Player.Process.wait);
                  
                    break;
                case Process.p3Dicing:
                    allPlayer[2].SysMsg = allPlayer[2].name + "擲骰子中";
                    allPlayer[2].SetProcess(Player.Process.dicing);
                    allPlayer[1].SysMsg = "等待" + allPlayer[2].name + "擲骰子";
                    allPlayer[1].SetProcess(Player.Process.wait);
                    allPlayer[0].SysMsg = "等待" + allPlayer[2].name + "擲骰子";
                    allPlayer[0].SetProcess(Player.Process.wait);
                   
                    break;
               
                case Process.p1Action:

                    allPlayer[0].SysMsg = allPlayer[0].name + "走路中";
                    allPlayer[0].SetProcess(Player.Process.action);
                    allPlayer[1].SysMsg = "等待" + allPlayer[0].name + "行動";
                    allPlayer[1].SetProcess(Player.Process.wait);
                    allPlayer[2].SysMsg = "等待" + allPlayer[0].name + "行動";
                    allPlayer[2].SetProcess(Player.Process.wait);
                    
                    break;
                case Process.p2Action:
                    allPlayer[1].SysMsg = allPlayer[1].name + "走路中";
                    allPlayer[1].SetProcess(Player.Process.action);
                    allPlayer[0].SysMsg = "等待" + allPlayer[1].name + "行動";
                    allPlayer[0].SetProcess(Player.Process.wait);
                    allPlayer[2].SysMsg = "等待" + allPlayer[1].name + "行動";
                    allPlayer[2].SetProcess(Player.Process.wait);
                   
                    break;
                case Process.p3Action:
                    allPlayer[2].SysMsg = allPlayer[2].name + "走路中";
                    allPlayer[2].SetProcess(Player.Process.action);
                    allPlayer[1].SysMsg = "等待" + allPlayer[2].name + "行動";
                    allPlayer[1].SetProcess(Player.Process.wait);
                    allPlayer[0].SysMsg = "等待" + allPlayer[2].name + "行動";
                    allPlayer[0].SetProcess(Player.Process.wait);
                  
                    break;
                case Process.end:
                   
                    allPlayer[0].SysMsg = "遊戲結束";
                    allPlayer[0].SetProcess(Player.Process.end);
                    allPlayer[1].SysMsg = "遊戲結束";
                    allPlayer[1].SetProcess(Player.Process.end);
                    allPlayer[2].SysMsg = "遊戲結束";
                    allPlayer[2].SetProcess(Player.Process.end);
                    _iTime = 0;
                    break;

            }
        }
		else if (allPlayer.Count == 2)
        {
            switch (process)
            {
                case Process.decideReady:
                    if (_iroundCount % allPlayer.Count == 0)
                    {
                        round = Round.player1;
                        process = Process.p1DicingReady;
                    }
                    else if (_iroundCount % allPlayer.Count == 1)
                    {
                        round = Round.player2;
                        process = Process.p2DicingReady;
                    }
                   

                    //_iroundCount++;
                    break;
                case Process.decideDicing:
                    if (_iroundCount % allPlayer.Count == 0)
                    {
                        round = Round.player1;
                        process = Process.p1Dicing;
                    }
                    else if (_iroundCount % allPlayer.Count == 1)
                    {
                        round = Round.player2;
                        process = Process.p2Dicing;
                    }
                   

                    //_iroundCount++;
                    break;
                case Process.decideWalking:
                    if (_iroundCount % allPlayer.Count == 0)
                    {
                        round = Round.player1;
                        process = Process.p1Action;
                    }
                    else if (_iroundCount % allPlayer.Count == 1)
                    {
                        round = Round.player2;
                        process = Process.p2Action;
                    }
                  

                    _iroundCount++;
                    break;
                case Process.p1DicingReady:
                    allPlayer[0].SysMsg = "請" + allPlayer[0].name + "擲骰子!";
                    allPlayer[0].SetProcess(Player.Process.dicingready);
                    allPlayer[1].SysMsg = "等待" + allPlayer[0].name + "擲骰子";
                    allPlayer[1].SetProcess(Player.Process.wait);
                   

                    break;
                case Process.p2DicingReady:
                    allPlayer[1].SysMsg = "請" + allPlayer[1].name + "擲骰子";
                    allPlayer[1].SetProcess(Player.Process.dicingready);
                    allPlayer[0].SysMsg = "等待" + allPlayer[1].name + "擲骰子";
                    allPlayer[0].SetProcess(Player.Process.wait);
                   

                    break;
               

                case Process.p1Dicing:
                    allPlayer[0].SysMsg = allPlayer[0].name + "擲骰子中";
                    allPlayer[0].SetProcess(Player.Process.dicing);
                    allPlayer[1].SysMsg = "等待" + allPlayer[0].name + "擲骰子";
                    allPlayer[1].SetProcess(Player.Process.wait);
                  

                    break;
                case Process.p2Dicing:
                    allPlayer[1].SysMsg = allPlayer[1].name + "擲骰子中";
                    allPlayer[1].SetProcess(Player.Process.dicing);
                    allPlayer[0].SysMsg = "等待" + allPlayer[1].name + "擲骰子";
                    allPlayer[0].SetProcess(Player.Process.wait);
                   

                    break;
              

                case Process.p1Action:

                    allPlayer[0].SysMsg = allPlayer[0].name + "走路中";
                    allPlayer[0].SetProcess(Player.Process.action);
                    allPlayer[1].SysMsg = "等待" + allPlayer[0].name + "行動";
                    allPlayer[1].SetProcess(Player.Process.wait);
                    

                    break;
                case Process.p2Action:
                    allPlayer[1].SysMsg = allPlayer[1].name + "走路中";
                    allPlayer[1].SetProcess(Player.Process.action);
                    allPlayer[0].SysMsg = "等待" + allPlayer[1].name + "行動";
                    allPlayer[0].SetProcess(Player.Process.wait);
                  

                    break;
                case Process.end:

                    allPlayer[0].SysMsg = "遊戲結束";
                    allPlayer[0].SetProcess(Player.Process.end);
                    allPlayer[1].SysMsg = "遊戲結束";
                    allPlayer[1].SetProcess(Player.Process.end);
                    _iTime = 0;
                    break;

            }
        }
	}

    //若有玩家加入則增加List總數並切換State
    public void Login(Player player)
    {
        allPlayer.Add(player);
        process = Process.decideReady;//
    }
    //若格子為Again則回合數-1
    public void Play_Again()
    {
        _iroundCount-=1;
        process = Process.decideReady;

    }
    //切換State to decideReady
    public void Change_Player()
    {
        process = Process.decideReady;
    }
    //切換State to decideDicing
    public void Change_Dicing()
    {
        process = Process.decideDicing;
    }
    //切換State to decideWalking
    public void Change_Walking()
    {
        process = Process.decideWalking;
    }
    //切換State to End
    public void Change_Ending()
    {
        process = Process.end;
    }

    //Go_Award Btn
    public void Go_Award()
    {
        
        _gGame_Over.GetComponent<GameOver>()._b1_Name = false;
        _gGame_Over.GetComponent<GameOver>()._b1_Score = false;
        _gGame_Over.GetComponent<GameOver>()._b2_Name = false;
        _gGame_Over.GetComponent<GameOver>()._b2_Score = false;
        _gGame_Over.GetComponent<GameOver>()._b3_Name = false;
        _gGame_Over.GetComponent<GameOver>()._b3_Score = false;
        _gGame_Over.GetComponent<GameOver>()._b4_Name = false;
        _gGame_Over.GetComponent<GameOver>()._b4_Score = false;
        _gGame_Over.GetComponent<GameOver>()._bFirst = false;
        _gGame_Over.GetComponent<GameOver>()._bSecond = false;
        _gGame_Over.GetComponent<GameOver>()._bThird = false;
        _gGame_Over.GetComponent<GameOver>()._bFourth = false;
        _gGame_Over.GetComponent<GameOver>()._bGo_Award = false;
        _gGame_Over.GetComponent<GameOver>()._bAward_Btn = true;
        _gGame_Over.GetComponent<GameOver>()._bScore = true;
        _gGame_Over.GetComponent<GameOver>()._bAward_Text = true;
    }
    //Award_Btn
    public void Award_Btn()
    {
        _gGame_Over.GetComponent<GameOver>()._bAward_Btn = false;
        _gGame_Over.GetComponent<GameOver>()._bAward_Finish = true; 
        _gGame_Over.GetComponent<GameOver>()._bAward_Text = false;
        _gGame_Over.GetComponent<GameOver>()._bRestart = true;
        _gGame_Over.GetComponent<GameOver>()._bClose_Game = true;
        _gGame_Over.GetComponent<GameOver>()._bWarning_Award = false;
    }
    
    //Close_Btn 關閉遊戲
    public void Close_Btn()
    {
        Application.Quit();
    }
    //警告是否要領獎
    public void Warning_Award()
    {
        _gGame_Over.GetComponent<GameOver>()._bWarning_Award = true;
    }

    //取消警告領獎
    public void Close_Warning_Award()
    {
        _gGame_Over.GetComponent<GameOver>()._bWarning_Award = false;
    }

    //警告是否要關閉遊戲
    public void Warning_Close()
    {
        _gGame_Over.GetComponent<GameOver>()._bWarning_Close = true;
    }

    //取消警告關閉遊戲
    public void Close_Warning_Close()
    {
        _gGame_Over.GetComponent<GameOver>()._bWarning_Close = false;
    }

    //Server端，是否要結算分數
    public void Server_Timing()
    {
        _gGame_Over.GetComponent<GameOver>()._bWarning_Server_Timing = true;
    }

    //Server端，是否要結算分數確認鍵
    public void Server_Timing_True()
    {
        _iTime = 0;
        _gGame_Over.GetComponent<GameOver>()._bWarning_Server_Timing = false;
    }

    //Server端，是否要結算分數取消鍵
    public void Server_Timing_False()
    {
        _gGame_Over.GetComponent<GameOver>()._bWarning_Server_Timing = false;
    }
    
    //Client端，結算分數按鈕畫面
    public void Client_Timing()
    {
        _gGame_Over.GetComponent<GameOver>()._bWarning_Client_Timing = true;
        Invoke("Client_Timing_Close", 3.0f);

    }

    //關閉Client端結算分數按鈕畫面
    public void Client_Timing_Close()
    {
        _gGame_Over.GetComponent<GameOver>()._bWarning_Client_Timing = false;
    }

    //Client端，是否要重玩一次遊戲畫面
    public void Client_Restart()
    {
        _gGame_Over.GetComponent<GameOver>()._bWarning_Client_Restart = true;
        Invoke("Client_Restart_Close", 3.0f);
    }

    //關閉Client端，是否要重玩一次遊戲畫面
    public void Client_Restart_Close()
    {
        _gGame_Over.GetComponent<GameOver>()._bWarning_Client_Restart = false;
    }

    //Server端，是否要重玩一次畫面
    public void Server_Restart()
    {
        _gGame_Over.GetComponent<GameOver>()._bWarning_Server_Restart = true;
    }

    //關閉Server端，是否要重玩一次畫面
    public void Close_Server_Restart()
    {
        _gGame_Over.GetComponent<GameOver>()._bWarning_Server_Restart = false;
    }
}
