using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spacecraft : MonoBehaviour
{
    [SerializeField] private Transform[] movePoints;

    private List<Vector2> inGameMovePoint;
    private int currentPoint;
    private bool move;
    private int targetDegree;

    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        inGameMovePoint = new List<Vector2>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        if(move)
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

        float currentScale = targetDegree == 0 ? 1 : .75f;
        float tartgetScale = targetDegree == 0 ? .75f : 1f;

        int turnDir = tartgetScale > currentScale ? 1: -1;

        yield return null;

        while (Mathf.Abs(transform.rotation.y - targetDegree) > 0.01f)
        {
            transform.Rotate(0f, 180f * Time.deltaTime, 0f);

            currentScale += .25f * Time.deltaTime * turnDir;

            transform.localScale = new Vector3(currentScale, currentScale, currentScale);

            yield return null;
        }

        spriteRenderer.sortingOrder *= -1;

        transform.localScale = new Vector3(tartgetScale, tartgetScale, tartgetScale);
        transform.rotation = new Quaternion(transform.rotation.x , targetDegree, transform.rotation.z, transform.rotation.w);

        targetDegree = 1 - targetDegree;
        currentPoint = 1 - currentPoint;
        move = true;
    }

}
