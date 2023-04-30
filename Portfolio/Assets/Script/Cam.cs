using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    private Transform target;

    private void FixedUpdate()
    {
        if (target != null && Vector2.Distance(transform.position, target.position) > 0.01f)
        {
            Vector2 newpos = Vector2.MoveTowards(transform.position, target.position, 3f * Vector2.Distance(transform.position, target.position) * Time.deltaTime);
            transform.position = new Vector3(newpos.x, newpos.y, transform.position.z);
        }
    }

    public void SetTarget(Transform target) 
    {
        this.target = target;
    }
}
