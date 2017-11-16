using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour {

    [SerializeField]
    UnityEngine.UI.Image healthBar;
    [SerializeField]
    UnityEngine.UI.Image manaBar;

    public void UpdateHealth(double percent)
    {

        healthBar.fillAmount = (float)percent;
    }
    public void UpdateMana(double percent)
    {
        manaBar.fillAmount = (float)percent;
    }

    internal void SetBars(Image health, Image resource)
    {
        healthBar = health;
        manaBar = resource;
    }
}
