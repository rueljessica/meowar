using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    [SerializeField] private GameObject[] points;
    private int currentPointIndex = 0;

    [SerializeField] private float speed = 2f;


    // Update is called once per frame
    [SerializeField]
    private void Update() {
        if (Vector2.Distance(points[currentPointIndex].transform.position, transform.position) < .1f) {
            currentPointIndex++;            if(currentPointIndex >= points.Length) {
                currentPointIndex = 0;
            }        }
        transform.position = Vector2.MoveTowards(transform.position, points[currentPointIndex].transform.position, Time.deltaTime * speed);
    }
}
