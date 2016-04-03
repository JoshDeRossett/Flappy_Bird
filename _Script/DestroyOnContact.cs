using UnityEngine;
using System.Collections;
public class DestroyOnContact : MonoBehaviour {
	private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.CompareTag("Pipes")) PipeControl.pipeCount--;
        if (coll.gameObject.CompareTag("Background")) BackgroundControl.bgCount--;
        Destroy(coll.gameObject);
    }
}
