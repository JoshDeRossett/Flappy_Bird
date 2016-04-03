using UnityEngine;
using System.Collections;
public class PipeControl : MonoBehaviour {
    //[SerializeField]
    public GameObject[] pipes;
    public static float pipeCount;
    private float latestSpawn;
    private void Awake () {
        latestSpawn = 8;
        for (int i = 0; i < 7; i++) {
            GameManager.piperange = Random.Range(-1.5f, 0.5f);
            GameObject newPipes = (GameObject)Instantiate(pipes[GameManager.difficulty], new Vector3(latestSpawn + 3, GameManager.piperange, 0), Quaternion.identity);
            latestSpawn = newPipes.transform.position.x;
            print(latestSpawn);
        }
	}
    private void Start() {
        pipeCount = GameObject.FindGameObjectsWithTag("Pipes").Length;
        latestSpawn = 12;
    }
    private void Update () {
        if (pipeCount < 8) SpawnPipe();
    }
    private void SpawnPipe () {
        Instantiate(pipes[GameManager.difficulty], new Vector3(latestSpawn, GameManager.piperange, 0), Quaternion.identity);
        pipeCount = GameObject.FindGameObjectsWithTag("Pipes").Length;
    }
}
