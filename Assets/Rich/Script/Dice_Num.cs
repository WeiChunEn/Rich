using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;

public class Dice_Num : NetworkBehaviour
{
    
    public Sprite[] Dice_Picture;
    [SyncVar]
    public int _iDice_Nume;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.GetComponent<Image>().sprite = Dice_Picture[_iDice_Nume];
	}
}
