using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    Vector2 Direction;
    public bool moveTowardsDirection = false;
    float step;

    private void OnEnable()
    {
        Direction = RandomVector(-5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(moveTowardsDirection && TheGlobals.playingMode)
        {
            step = 1.2f * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, Direction, step);
        }
    }

    private Vector3 RandomVector(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = Random.Range(0, 5) % 2 == 0 ? Random.Range(-5f, -10f) : Random.Range(5f, 10f);
        var z = 0f;

        return new Vector3(x, y, z);
    }
}
