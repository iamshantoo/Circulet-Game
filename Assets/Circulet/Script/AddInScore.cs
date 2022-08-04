using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddInScore : MonoBehaviour
{
    public Transform target;
    public bool moveTowardsTarget = false;
    float step;

    UIController _uiController;

    private void Awake()
    {
        _uiController = FindObjectOfType<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(moveTowardsTarget)
        {
            step = 12f * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);


            if(transform.position.Equals(target.position))
            {
                GetComponent<Collider2D>().enabled = true;
                moveTowardsTarget = false;
                gameObject.SetActive(false);
                _uiController.DisplayScore();
            }
        }
    }
}
