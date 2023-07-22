using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class MainMenu : MonoBehaviour{
    public GameManager gameManager;

    private void Start() {
        GetComponentInChildren<TMPro.TextMeshProUGUI>().gameObject.LeanScale(new Vector3(1.2f, 1.2f), 0.3f).setLoopPingPong();
    }

    public void play() {
        GetComponent<CanvasGroup>().LeanAlpha(0, 0.3f).setOnComplete(OnComplete);
    }

    private void OnComplete() {
        gameManager.Enable();
        Destroy(gameObject);
    }
}
