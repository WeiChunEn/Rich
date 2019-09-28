using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Change_Scene : NetworkBehaviour
{
    public GameObject _gTopPanel;
	// Use this for initialization
	void Start ()
    {
        _gTopPanel = GameObject.Find("TopPanel");
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    
    public void Restart_Btn()
    {
       
        NetworkManager.singleton.ServerChangeScene("Lobby");
        
    }
}
