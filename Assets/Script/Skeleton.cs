using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    private Transform initialParent;
    private SpriteRenderer spriteRenderer; 


    private void Awake()
    {
        initialParent = transform.parent;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (transform.parent != initialParent && Vector2.Distance(transform.position, initialParent.position) > 5) 
        {
            Interact(initialParent);
            Vector2 dir = initialParent.position - transform.position;
            transform.position = (Vector2)transform.position + dir.normalized;
        }
    }

    public void Interact(Transform interactedOBJ)
    {
        transform.parent = interactedOBJ;
    }

    private void OnMouseDown()
    {
        Interact(FindObjectOfType<Cursor>().transform);
    }
    private void OnMouseUp()
    {
        Interact(initialParent);
    }

    private void OnMouseEnter()
    {
        spriteRenderer.color = new Color(0.5f, 0, 0, 1);
    }
    private void OnMouseExit()
    {
        spriteRenderer.color = Color.white;
    }
}
