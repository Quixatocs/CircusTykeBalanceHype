using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelebrationSpawner : MonoBehaviour {

    public GameObject rose;
    public GameObject boot;
    public GameObject boxer;

    public int numberOfSpawnedObjects = 10;

    private bool hasSpawned = false;


    void OnEnable()
    {
        EventManager.failure += Failure;
        EventManager.success += Success;

    }

    void OnDisable()
    {
        EventManager.failure -= Failure;
        EventManager.success -= Success;
    }


    private void Failure()
    {
        if (!hasSpawned)
            StartCoroutine(SpawnCelebratoryObjectsAndABoxer(boot));
    }


    private void Success()
    {
        if (!hasSpawned)
            StartCoroutine(SpawnCelebratoryObjectsAndABoxer(rose));
    }

    private IEnumerator SpawnCelebratoryObjectsAndABoxer(GameObject go)
    {
        WaitForSeconds wait = new WaitForSeconds(0.01f);
        hasSpawned = true;
        for (int i = 0; i < numberOfSpawnedObjects; i++)
        {
            float xSalt = Random.Range(-3.2f, 3.2f);
            Vector3 newPosition = new Vector3(transform.position.x + xSalt, transform.position.y, transform.position.z);
            Instantiate(go, newPosition, Quaternion.identity, transform);
            yield return wait;
        }
        Instantiate(boxer, transform.position, Quaternion.identity, transform);
        
    }

}

