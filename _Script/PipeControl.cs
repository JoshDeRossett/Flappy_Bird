using UnityEngine;
using System.Collections;

public class PipeControl : MonoBehaviour {
    [SerializeField]
    private Transform pipes;
    private Transform newPipes;
    public static float pipeCount;
    private float latestSpawn;
    private bool spawn;
    void Awake () {
        latestSpawn = 8;
        for (int i = 0; i < 7; i++) {
            Transform newPipes = (Transform)Instantiate(pipes, new Vector3(latestSpawn + (Random.Range(4, 5)), Random.Range(-1.5f, 2f), 0), Quaternion.identity);
            latestSpawn = newPipes.transform.position.x;
            //print("X of Last Spawned Pipe: " + latestSpawn);
        }
	}
    private void Start() {
        pipeCount = GameObject.FindGameObjectsWithTag("Pipes").Length;
        print("Pipe Count: " + pipeCount);
        latestSpawn = 17;
        spawn = true;
    }
    private void Update () {
        /* if (pipeCount < 8 && GameManager.stageNumber == 0 && spawn) {
             SpawnPipe();
         }
         if (pipeCount < 10 && GameManager.stageNumber == 1 && spawn)
         {
             SpawnPipe();
         }
         if (pipeCount < 12 && GameManager.stageNumber == 2 && spawn)
         {
             SpawnPipe();
         }*/
        if (pipeCount < 8)
            SpawnPipe();
    }
    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
    private void SpawnPipe () {
        spawn = false;
        switch (GameManager.stageNumber) {
            case 0:
                newPipes = (Transform)Instantiate(pipes, new Vector3(latestSpawn, Random.Range(-1.5f, 2f), 0), Quaternion.identity);
                break;
            case 1:
                newPipes = (Transform)Instantiate(pipes, new Vector3(latestSpawn, Random.Range(-1.5f, 2f), 0), Quaternion.identity);
                break;
            case 2:
                newPipes = (Transform)Instantiate(pipes, new Vector3(latestSpawn, Random.Range(-1.5f, 2f), 0), Quaternion.identity);
                break;
        }
        pipeCount = GameObject.FindGameObjectsWithTag("Pipes").Length;
        latestSpawn = newPipes.transform.position.x;
        Wait(2.0f);
        spawn = true;
    }
}
