using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float walkSpeed;
    public LayerMask flipPoint;
    public int patrolDestination;

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, flipPoint))
        {
            if (patrolDestination == 0) { patrolDestination++;}
            else if (patrolDestination == 1) { patrolDestination = 0;}
        }
        if(patrolDestination == 0)
        {
            transform.localScale = new Vector2(transform.localScale.x * 1, transform.localScale.y);
            walkSpeed *= 1;
        }
        else if (patrolDestination == 1)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            walkSpeed *= -1;
        }
            

    }
}
