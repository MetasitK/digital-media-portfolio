using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theif : MonoBehaviour
{
    [SerializeField] private Transform[] movePoints;

    private List<Vector2> inGameMovePoint;
    private int currentPoint;
    private bool move;
    private int targetDegree;

    private Rigidbody2D rb2d;

    private void Awake()
    {
        inGameMovePoint = new List<Vector2>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        inGameMovePoint.Add(movePoints[0].position);
        inGameMovePoint.Add(movePoints[1].position);

        currentPoint = 0;
        move = true;

        targetDegree = (int)(1 - transform.rotation.y);
    }

    private void Update()
    {
        if (move)
        {
            if (Vector2.Distance(transform.position, inGameMovePoint[1 - currentPoint]) < 0.1f)
            {
                rb2d.velocity = Vector2.zero;
                StartCoroutine(Turn());
            }
        }
    }

    private void FixedUpdate()
    {
        if (move)
        {
            rb2d.velocity = transform.right * 300 * Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (movePoints != null && movePoints.Length > 1)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(movePoints[0].position, movePoints[1].position);
        }
    }

    private IEnumerator Turn()
    {
        move = false;

        yield return null;

        while (Mathf.Abs(transform.rotation.y - targetDegree) > 0.01f)
        {
            transform.Rotate(0f, 180f * Time.deltaTime, 0f);


            yield return null;
        }

        transform.rotation = new Quaternion(transform.rotation.x, targetDegree, transform.rotation.z, transform.rotation.w);

        targetDegree = 1 - targetDegree;
        currentPoint = 1 - currentPoint;
        move = true;
    }

}

