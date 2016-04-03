using UnityEngine;
using System.Collections;
public class PipeMove : MonoBehaviour {
    public static float pSpeed = 0;
    private BoxCollider2D pipes;
    private void Start() {
        pipes = GetComponent<BoxCollider2D>();
    }
    private void Update() {
        if (GameManager.move == true)
            pSpeed = GameManager.stageNumber < 1 ? 5f : GameManager.stageNumber < 2 ? 6f : 7f;
        pipes.transform.Translate((Vector3.left * Time.deltaTime) * pSpeed);
    }
}
