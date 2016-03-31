using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D coll) {
        //Destroy(coll.gameObject);
        if (coll.gameObject.CompareTag("Pipes")) {
            PipeControl.pipeCount--;
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.CompareTag("Background")) {
            BackgroundControl.bgCount--;
            Destroy(coll.gameObject);
        }
    }
}
