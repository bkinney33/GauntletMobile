using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnCollision : MonoBehaviour {

    [SerializeField]
    string newSceneName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        LoadScene();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(newSceneName);
    }
}
