using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectInfo : MonoBehaviour {

    public string name;
    public short characterID;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);	
	}
}
