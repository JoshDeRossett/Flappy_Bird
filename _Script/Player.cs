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
    private IEnumerator Wait(float time) {
        yield return new WaitForSeconds(time);
    }
    private void Update() {
        if (GameManager.move == 1) {
            if (coll.collInfo.above || coll.collInfo.below) {
                velocity.y = 0;
            }
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                velocity.y = flapSpeed;
            }
            //Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            velocity.y += gravity * Time.deltaTime;
            coll.Move(velocity * Time.deltaTime);
            switch (GameManager.stageNumber)
            {
                case 0:
                    break;
                case 1:
                    am.SetLayerWeight(0, 0);
                    am.SetLayerWeight(1, 1);
                    break;
                case 2:
                    am.SetLayerWeight(1, 0);
                    am.SetLayerWeight(2, 1);
                    break;
            }
            if (velocity.y > -2)
                am.SetBool("IsFalling", false);
            else {
                Wait(1.0f);
                am.SetBool("IsFalling", true);
            }
        }
    }
}
