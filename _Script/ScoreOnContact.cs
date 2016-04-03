using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ScoreOnContact : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.CompareTag("Player")) GameManager.score++;
    }
}
