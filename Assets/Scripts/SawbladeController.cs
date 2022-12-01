using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawbladeController : MonoBehaviour
{
    [SerializeField] Transform[] Waypoints;
    [SerializeField] float SawSpeed; 

    int NextPointIndex;
    Transform NextPoint;

    public float RotateSpeed;

    void Start()
    {
        NextPoint = Waypoints[0];
    }

    void Update()
    {
        MoveGameObject();

        transform.Rotate(0, 0, RotateSpeed);
    }

    void MoveGameObject()
    {
        if (transform.position == NextPoint.position)
        {
            NextPointIndex++;
            if (NextPointIndex >= Waypoints.Length)
            {
                NextPointIndex = 0;
            }
            NextPoint = Waypoints[NextPointIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, NextPoint.position, SawSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController >();

        if (player != null)
        {
            player.ChangeHealth(-2);
        }
    }
}
