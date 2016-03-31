using UnityEngine;
using System.Collections;

public class BackgroundControl : MonoBehaviour {
    [SerializeField]
    private Transform bg;
    public static float bgCount;
    private float latestSpawn = 30;
    private void Awake() {
        for (int i = 0; i < 3; i++) {
            //print("X of Last Spawned Background: " + latestSpawn);
            Instantiate(bg, new Vector3(latestSpawn, 0, 0), Quaternion.Euler(0, 180, 0));
            latestSpawn -= 15;
            //print("X of Last Spawned Background: " + latestSpawn);
        }

    }
    private void Start() {
        bgCount = GameObject.FindGameObjectsWithTag("Background").Length;
        print("Background Count: " + bgCount);
    }
    private void Update() {
        if (bgCount < 3) {
            SpawnBg();
        }
    }
    private void SpawnBg() {
        latestSpawn = 23;
        //print("X of Last Spawned Background: " + latestSpawn);
        Instantiate(bg, new Vector3(latestSpawn, 0, 0), Quaternion.Euler(0, 180, 0));
        bgCount = GameObject.FindGameObjectsWithTag("Background").Length;
        //print("Background Count: " + bgCount);
    }
}
