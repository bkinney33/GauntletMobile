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
    [SerializeField]
    short selectedCharacter;
    [SerializeField]
    Transform characterStart;

    private Canvas newCanvas;
    private GameObject newCharacter;

	// Use this for initialization
	void Start () {
        SetupCanvas();
        SetupCharacter();

	}

    private void SetupCanvas()
    {
        newCanvas = Instantiate(characters[selectedCharacter].characterCanvas);
    }

    private void SetupCharacter()
    {
        Character currentCharacter = characters[selectedCharacter];
        newCharacter = Instantiate(currentCharacter.characterPrefab.gameObject, characterStart);
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
