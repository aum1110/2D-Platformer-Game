using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    public int startingpoint;
    public float speed = 5f;
    private int i;

   
    private void Start()
    {
        transform.position = waypoints[startingpoint].position;
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position , waypoints[i].position) < 0.02f)
        {
            i++;
            if (i == waypoints.Length)
            {
                i = 0;
            
            
            }
        
        
        }


        transform.position = Vector2.MoveTowards(transform.position, waypoints[i].position, speed * Time.deltaTime);


        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }

}

