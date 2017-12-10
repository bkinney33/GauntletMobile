using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CaracterSetup : MonoBehaviour {

    public short characterID;

    public void ChooseCharacter()
    {
        GameObject g = GameObject.Find("CharacterSelectInfo");
        CharacterSelectInfo c = g.GetComponent<CharacterSelectInfo>();
        GameObject g2 = GameObject.Find("Text");
        Text t = g2.GetComponent<Text>();
        c.name = t.text;
        c.characterID = characterID;
    }
}
