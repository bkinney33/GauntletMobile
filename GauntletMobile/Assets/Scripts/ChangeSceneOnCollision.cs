using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnCollision : MonoBehaviour {

    [SerializeField]
    string newSceneName;

    void OnTriggerEnter2D(Collider2D collision) {
        LoadScene();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(newSceneName);
    }
}
