using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class Limit_Text : MonoBehaviour
{
    public InputField _Name_Input;
    public InputField _Room_Input;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void _Name_Limit()
    {
        MatchCollection matches = Regex.Matches(_Name_Input.text, @"[^\W_]+", RegexOptions.IgnoreCase);
        _Name_Input.text = "";
        foreach (Match match in matches)
        {
            _Name_Input.text += match.Value;
           
        }
    }
    public void _Room_Limit()
    {
        MatchCollection matches = Regex.Matches(_Room_Input.text, @"[^\W_]+", RegexOptions.IgnoreCase);
        _Room_Input.text = "";
        foreach (Match match in matches)
        {
            _Room_Input.text += match.Value;

        }
    }
}
