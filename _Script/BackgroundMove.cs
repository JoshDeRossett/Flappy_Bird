using UnityEngine;
using System.Collections;
public class BackgroundMove : MonoBehaviour {
    public static float bSpeed = 0;
    private BoxCollider2D bg;
    private void Start() {
        bg = GetComponent<BoxCollider2D>();
    }
    private void Update() {
        if (GameManager.move == true) 
            bSpeed = GameManager.stageNumber < 1 ? -5f : GameManager.stageNumber < 2 ? -6f : -7f;
        bg.transform.Translate((Vector3.left * Time.deltaTime) * bSpeed);
        
    }
}
