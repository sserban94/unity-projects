using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomPillarCreator : MonoBehaviour
{
    private PlayerMotor motor;
    public GameObject[] myObjects;
    private readonly List<GameObject> spawnedObjects = new();
    private int k = 0;

    private int tankCount = 10;


    // Start is called before the first frame update
    void Start()
    {
        motor = FindObjectOfType<PlayerMotor>();
        for (int i = 0; i < tankCount; i++)
        {
            SpawnRandomObject();
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckForOverlaps("EndScreen");
    }

    private void SpawnRandomObject()
    {
        int randomIndex = Random.Range(0, myObjects.Length);
        Vector3 randomSpawnPosition = new(Random.Range(-20, 20), 0.8f, Random.Range(-20, 20));
        GameObject spawnedObject = Instantiate(myObjects[randomIndex], randomSpawnPosition, Quaternion.Euler(0, Random.Range(0, 90), 0));
        spawnedObjects.Add(spawnedObject);
    }

    private void CheckForOverlaps(string sceneName)
    {
        int crashCount = 0;
        List<GameObject> objectsToRemove = new();

        foreach (GameObject obj in spawnedObjects)
        {
            if (Vector3.Distance(motor.transform.position, obj.transform.position) < 2.0f)
            {
                // crashCount++;
                // if (crashCount >= 1)
                // {
                Destroy(obj);
                objectsToRemove.Add(obj);
                k++;
                // }

            }
        }

        foreach (GameObject objToRemove in objectsToRemove)
        {
            spawnedObjects.Remove(objToRemove);
        }
        if (k == tankCount)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
