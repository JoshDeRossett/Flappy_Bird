using UnityEngine;
using System.Collections;
[RequireComponent(typeof(RayController))]
public class Player : MonoBehaviour {
    [SerializeField]
    private float flapHeight = 1.7f;
    [SerializeField]
    private float timeToFlapApex = 0.2f;
    private float flapSpeed;
    private float gravity;
    private Vector2 velocity;
    private RayController coll;
    private Animator am;

    private void Start() {
        coll = GetComponent<RayController>();
        am = GetComponent<Animator>();
        am.SetBool("IsFalling", false);
        gravity = -(2 * flapHeight) / Mathf.Pow(timeToFlapApex, 2);
        flapSpeed = Mathf.Abs(gravity) * timeToFlapApex;
        print("Gravity: " + gravity + "  Flap Speed: " + flapSpeed);
    }
    private void Dead() {
        GameManager.move = false;
        velocity.y = 0;
        PipeMove.pSpeed = 0;
        BackgroundMove.bSpeed = 0;
        GameManager.isDead = true;
    }
    private void Flap() {
        velocity.y = flapSpeed;
        am.SetBool("IsFalling", false);
    }
    private void UpdateAnimation() {
    bool current = velocity.y > -4 ? false : true;
    am.SetBool("IsFalling", current);
    switch (GameManager.stageNumber) {
        case 0:
            am.SetLayerWeight(0, 1);
            am.SetLayerWeight(1, 0);
            am.SetLayerWeight(2, 0);
            break;
        case 1:
            am.SetLayerWeight(0, 0);
            am.SetLayerWeight(1, 1);
            am.SetLayerWeight(2, 0);
            break;
        case 2:
            am.SetLayerWeight(0, 0);
            am.SetLayerWeight(1, 0);
            am.SetLayerWeight(2, 1);
            break;
        }
    }
    private void Update() {
        if (GameManager.move == true) {
            UpdateAnimation();
            if (coll.collInfo.above || coll.collInfo.below || coll.collInfo.left || coll.collInfo.right) Dead();
            if (Input.GetKeyDown(KeyCode.Mouse0)) Flap();
            velocity.y += gravity * Time.deltaTime;
            coll.Move(velocity * Time.deltaTime);
        }
    }
}
