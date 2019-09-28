using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class GameOver : NetworkBehaviour
{
    public GameObject _g1_Score;
    public GameObject _g2_Score;
    public GameObject _g3_Score;
    public GameObject _g4_Score;
    public GameObject _g5_Score;
    public GameObject _g6_Score;

    public GameObject _g1_Name;
    public GameObject _g2_Name;
    public GameObject _g3_Name;
    public GameObject _g4_Name;
    public GameObject _g5_Name;
    public GameObject _g6_Name;

    public GameObject _gFirst;
    public GameObject _gSecond;
    public GameObject _gThird;
    public GameObject _gFourth;
    public GameObject _gGameOver;
    public GameObject _gTime_Up;
    public GameObject _gTime_Text;
    public GameObject _gName;
    public GameObject _gScord;
    public GameObject _gAward_Text;
    public GameObject _gGo_Award;
    public GameObject _gAward_Btn;
    public GameObject _gAward_Finish;
    public GameObject _gRestart;
    public GameObject _gClose_Game;
    public GameObject _gWarning_Award;
    public GameObject _gWarning_Close;
    public GameObject _gWarning_Server_Timing;
    public GameObject _gWarning_Client_Timing;
    public GameObject _gWarning_Client_Restart;
    public GameObject _gWarning_Server_Restart;


    //[SyncVar]
    public bool _b1_Score;
    //[SyncVar]
    public bool _b2_Score;
    //[SyncVar]
    public bool _b3_Score;
   // [SyncVar]
    public bool _b4_Score;
    public bool _b5_Score;
    public bool _b6_Score;

   // [SyncVar]
    public bool _b1_Name;
    //[SyncVar]
    public bool _b2_Name;
   // [SyncVar]
    public bool _b3_Name;
   // [SyncVar]
    public bool _b4_Name;

    public bool _b5_Name;
    public bool _b6_Name;
   // [SyncVar]
    public bool _bFirst;
  //  [SyncVar]
    public bool _bSecond;
  //  [SyncVar]
    public bool _bThird;
  //  [SyncVar]
    public bool _bFourth;
  //  [SyncVar]
    public bool _bGameOver;
    [SyncVar]
    public bool _bTime_Up;
    [SyncVar]
    public bool _bTime_Text;

    
    public bool _bGo_Award;
    public bool _bName;
    public bool _bScore;
    public bool _bRestart;
    public bool _bClose_Game;
    public bool _bAward_Btn;
    public bool _bAward_Text;
    public bool _bAward_Finish;
    public bool _bWarning_Award;
    public bool _bWarning_Close;
    public bool _bWarning_Server_Timing;
    public bool _bWarning_Client_Timing;
    public bool _bWarning_Server_Restart;
    public bool _bWarning_Client_Restart;


    // Use this for initialization
    void Start ()
    {
        _b1_Score = false;
        _b2_Score = false;
        _b3_Score = false;
        _b4_Score = false;
        _b5_Score = false;
        _b6_Score = false;

        _b1_Name = false;
        _b2_Name = false;
        _b3_Name = false;
        _b4_Name = false;
        _b5_Name = false;
        _b6_Name = false;

        _bFirst = false;
        _bSecond = false;
        _bThird = false;
        _bFourth = false;
        _bGameOver = false;
        _bGo_Award = false;
        _bName = false;
        _bScore = false;
        _bRestart = false;
        _bClose_Game = false;
        _bAward_Btn = false;
        _bAward_Text = false;
        _bAward_Finish = false;
        _bTime_Up = false;
        _bTime_Text = false;
        _bWarning_Award = false;
        _bWarning_Close = false;
        _bWarning_Server_Timing = false;
        _bWarning_Client_Timing = false;
        _bWarning_Server_Restart = false;
        _bWarning_Client_Restart = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        _g1_Name.SetActive(_b1_Name);
        _g2_Name.SetActive(_b2_Name);
        _g3_Name.SetActive(_b3_Name);
        _g4_Name.SetActive(_b4_Name);
        _g5_Name.SetActive(_b5_Name);
        _g6_Name.SetActive(_b6_Name);
        _g1_Score.SetActive(_b1_Score);
        _g2_Score.SetActive(_b2_Score);
        _g3_Score.SetActive(_b3_Score);
        _g4_Score.SetActive(_b4_Score);
        _g5_Score.SetActive(_b5_Score);
        _g6_Score.SetActive(_b6_Score);
        _gFirst.SetActive(_bFirst);
        _gSecond.SetActive(_bSecond);
        _gThird.SetActive(_bThird);
        _gFourth.SetActive(_bFourth);
        _gGameOver.SetActive(_bGameOver);
        _gTime_Text.SetActive(_bTime_Text);
        _gTime_Up.SetActive(_bTime_Up);
        _gGo_Award.SetActive(_bGo_Award);
        _gName.SetActive(_bName);
        _gScord.SetActive(_bScore);
        _gAward_Text.SetActive(_bAward_Text);
        _gAward_Btn.SetActive(_bAward_Btn);
        _gAward_Finish.SetActive(_bAward_Finish);
        _gRestart.SetActive(_bRestart);
        _gClose_Game.SetActive(_bClose_Game);
        _gWarning_Award.SetActive(_bWarning_Award);
        _gWarning_Close.SetActive(_bWarning_Close);
        _gWarning_Server_Timing.SetActive(_bWarning_Server_Timing);
        _gWarning_Client_Timing.SetActive(_bWarning_Client_Timing);
        _gWarning_Server_Restart.SetActive(_bWarning_Server_Restart);
        _gWarning_Client_Restart.SetActive(_bWarning_Client_Restart);
	}
}
