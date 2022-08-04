using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    Transform center;

    [SerializeField]
    Transform tempPos;

    [SerializeField]
    GameObject[] obstacles;

    [SerializeField]
    GameObject[] scoreObjects;

    int obstacleIndex;

    int scoreObjectsIndex;

    private Vector3 _scaleFactor;

    public float minWaitTime;

    public float maxWaitTime;

    public void Spawner()
    {
        StartCoroutine(SpawnObjects(0f));
    }

    IEnumerator ScaleIN(GameObject scaleObj)
    {
        yield return new WaitForSeconds(0.01f);
        scaleObj.transform.localScale += _scaleFactor;

        if(scaleObj.transform.localScale.x < 0.7f)
        {
            StartCoroutine(ScaleIN(scaleObj));
        }
    }

    IEnumerator SpawnObjects(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SpawningFunction(ChooseTheObject());
        StartCoroutine(SpawnObjects(Random.Range(minWaitTime, maxWaitTime)));

        if (minWaitTime > 0.4f)
        {
            minWaitTime -= 0.05f;
        }

        if(maxWaitTime > 1.2f)
        {
            maxWaitTime -= 0.05f;
        }
    }

    void SpawningFunction(GameObject objToSpawn)
    {
        objToSpawn.transform.position = center.position;
        objToSpawn.SetActive(true);
        objToSpawn.transform.localScale = Vector3.zero;
        objToSpawn.GetComponent<ObstacleBehavior>().moveTowardsDirection = true;

        _scaleFactor = new Vector3(0.05f, 0.05f, 0.05f);
        StartCoroutine(ScaleIN(objToSpawn));
    }

    GameObject ChooseTheObject()
    {
        GameObject _obj = Random.Range(0, 10) % 3 == 0 ? SpawnScoreObjects() : SpawnObstacle();
        return _obj;
    }

    GameObject SpawnObstacle()
    {
        GameObject _obj =  obstacles[obstacleIndex];
        
        if(obstacleIndex < obstacles.Length-1)
        {
            obstacleIndex++;
        }
        else
        {
            obstacleIndex = 0;
        }

        return _obj;
    }

    GameObject SpawnScoreObjects()
    {
        GameObject _obj = scoreObjects[scoreObjectsIndex];

        if (scoreObjectsIndex < scoreObjects.Length - 1)
        {
            scoreObjectsIndex++;
        }
        else
        {
            scoreObjectsIndex = 0;
        }

        return _obj;
    }
}
