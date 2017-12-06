using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingTextController : MonoBehaviour
{
    private static Text damageText;

    public static void Initialize()
    {
        GameObject canvas = GameObject.Find("GameManager").GetComponent<CharacterSelect>().GetCanvas();
        damageText = canvas.transform.Find("Simple/DamageText").GetComponent<Text>();
    }

    public static void CreateFloatingText(string text, Color color)
    {
        damageText.text = text;
        damageText.color = color;
    }
}