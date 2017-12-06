using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour {

    [System.Serializable]
    class Character
    {
        public String character;
        public Class characterPrefab;
        [Tooltip("Make sure this is the correct canvas for the character.")]
        public Canvas characterCanvas;
    }

    [SerializeField]
    Character[] characters;
    short selectedCharacter;
    [SerializeField]
    Transform characterStart;

    private Canvas newCanvas;
    private GameObject newCharacter;

	// Use this for initialization
	void Awake () {
        CharacterSelectInfo g = GameObject.Find("CharacterSelectInfo").GetComponent<CharacterSelectInfo>();
        selectedCharacter = g.characterID;
        SetupCanvas();
        GameObject g2 = GameObject.Find("Simple");
        Text t = g2.GetComponentInChildren<Text>();
        t.text = g.name;
        SetupCharacter();

	}

    private void SetupCanvas()
    {
        newCanvas = Instantiate(characters[selectedCharacter].characterCanvas);
    }

    private void SetupCharacter()
    {
        Character currentCharacter = characters[selectedCharacter];
        Vector3 position = characterStart.position;
        position.z = -1;
        newCharacter = Instantiate(currentCharacter.characterPrefab.gameObject, position, Quaternion.identity);
        GameObject healthBar = newCanvas.transform.Find("Simple/Bars/Healthbar").gameObject;
        Image health = healthBar.GetComponent<Image>();
        health.fillAmount = 1;
        GameObject manaBar = newCanvas.transform.Find("Simple/Bars/Manabar").gameObject;
        Image resource = manaBar.GetComponent<Image>();
        resource.fillAmount = 1;
        newCharacter.GetComponent<ResourceManager>().SetBars(health, resource);
    }
   

    // Update is called once per frame
    void Update () {
		
	}
}
