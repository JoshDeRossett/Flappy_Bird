using UnityEngine;
using System.Collections;

public class PipeMove : MonoBehaviour {
    private float pSpeed;
    BoxCollider2D pipes;
    void Start() {
        pipes = GetComponent<BoxCollider2D>();
    }
    public void Update() {
        if (GameManager.move == 1) {
            switch (GameManager.stageNumber) {
                case 0:
                    pSpeed = 5f;
                    break;
                case 1:
                    pSpeed = 6f;
                    break;
                case 2:
                    pSpeed = 7f;
                    break;
            }
            pipes.transform.Translate((Vector3.left * Time.deltaTime) * pSpeed);
        }
    }
}
