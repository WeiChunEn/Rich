using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Dice_Music : NetworkBehaviour
{
    public GameObject _gDice_Two_Music;
    public GameObject _gDice_Three_Music;
    public GameObject _gDice_Four_Music;
    public GameObject _gDice_Five_Music;
    public GameObject _gDice_Six_Music;
    public GameObject _gDice_Seven_Music;
    public GameObject _gDice_Eight_Music;
    public GameObject _gDice_Nine_Music;
    public GameObject _gDice_Ten_Music;
    public GameObject _gDice_Eleven_Music;
    public GameObject _gDice_Twelve_Music;

    public GameObject _gWalk_Music;

    [SyncVar]
    public bool _bDice_Two_Music;
    [SyncVar]
    public bool _bDice_Three_Music;
    [SyncVar]
    public bool _bDice_Four_Music;
    [SyncVar]
    public bool _bDice_Five_Music;
    [SyncVar]
    public bool _bDice_Six_Music;
    [SyncVar]
    public bool _bDice_Seven_Music;
    [SyncVar]
    public bool _bDice_Eight_Music;
    [SyncVar]
    public bool _bDice_Nine_Music;
    [SyncVar]
    public bool _bDice_Ten_Music;
    [SyncVar]
    public bool _bDice_Eleven_Music;
    [SyncVar]
    public bool _bDice_Twelve_Music;

    [SyncVar]
    public bool _bWalk_Music;

    // Use this for initialization
    void Start()
    {
        _bDice_Two_Music = false;
        _bDice_Three_Music = false;
        _bDice_Four_Music = false;
        _bDice_Five_Music = false;
        _bDice_Six_Music = false;
        _bDice_Seven_Music = false;
        _bDice_Eight_Music = false;
        _bDice_Nine_Music = false;
        _bDice_Ten_Music = false;
        _bDice_Eleven_Music = false;
        _bDice_Twelve_Music = false;
        _bWalk_Music = false;
    }

    // Update is called once per frame
    void Update()
    {
        _gDice_Two_Music.SetActive(_bDice_Two_Music);
        _gDice_Three_Music.SetActive(_bDice_Three_Music);
        _gDice_Four_Music.SetActive(_bDice_Four_Music);
        _gDice_Five_Music.SetActive(_bDice_Five_Music);
        _gDice_Six_Music.SetActive(_bDice_Six_Music);
        _gDice_Seven_Music.SetActive(_bDice_Seven_Music);
        _gDice_Eight_Music.SetActive(_bDice_Eight_Music);
        _gDice_Nine_Music.SetActive(_bDice_Nine_Music);
        _gDice_Ten_Music.SetActive(_bDice_Ten_Music);
        _gDice_Eleven_Music.SetActive(_bDice_Eleven_Music);
        _gDice_Twelve_Music.SetActive(_bDice_Twelve_Music);
        _gWalk_Music.SetActive(_bWalk_Music);
    }
}
