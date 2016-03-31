using UnityEngine;
using System.Collections;

public class BackgroundMove : MonoBehaviour {
    private float bSpeed;
    BoxCollider2D bg;
    void Start() {
        bg = GetComponent<BoxCollider2D>();
    }
    public void Update() {
        if (GameManager.move == 1) {
            switch (GameManager.stageNumber) {
                case 0:
                    bSpeed = -5f;
                    break;
                case 1:
                    bSpeed = -6f;
                    break;
                case 2:
                    bSpeed = -7f;
                    break;
            }
            bg.transform.Translate((Vector3.left * Time.deltaTime) * bSpeed);
        }
    }
}
