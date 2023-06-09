using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    private static GameManager instance;
    public static GameManager Instance => instance;

    private void Start() {
        instance = this;
    }

    public void Enable(){
        gameObject.SetActive(true);
    }
}
