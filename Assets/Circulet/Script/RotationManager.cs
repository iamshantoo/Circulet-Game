using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour
{
    public float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        if (TheGlobals.playingMode)
        {
            if (Input.GetMouseButtonDown(0) && Time.timeScale > 0f)
            {
                rotationSpeed = rotationSpeed * -1;
            }

            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
    }
}
