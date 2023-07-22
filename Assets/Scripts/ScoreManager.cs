using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;
    public TextMeshProUGUI text;
    public int score;


    // Start is called before the first frame update
    void Start() {
        if(instance == null) {
            instance = this;
        }
    }


    public void updateScore(int coinVal) {
        score += coinVal;
        text.text = score.ToString();
    }
}
