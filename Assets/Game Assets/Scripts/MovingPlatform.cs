using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int Currentwayindex = 0;
    private float speed = 5f;
    private int i;

    private void Start()
    {
        transform.position = waypoints[Currentwayindex].position;
    }
    private void Update()
    {
        if ()
        {
            if ()
            { 
            
            
            
            }
        
        
        }


        transform.position = Vector2.MoveTowards(transform.position, waypoints[i].position, speed * Time.deltaTime);

    }
}
