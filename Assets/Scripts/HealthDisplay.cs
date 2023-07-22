using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class HealthDisplay : MonoBehaviour {

    public double health;
    public double maxHealth;

    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;

    public Player player;


    // Update is called once per frame
    void Update() {

        health = player.health;
        maxHealth = player.maxHealth;

        for (int i=0; i<hearts.Length; i++) {
            if(i<health) {
                hearts[i].sprite = fullHeart;
            }
            else {
                hearts[i].sprite = emptyHeart;
            }

            if(i < maxHealth) {
                hearts[i].enabled = true;
            }
            else {
                hearts[i].enabled = false;
            }
        }
    }
}
