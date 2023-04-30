using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ultrsonic : MonoBehaviour
{
    [SerializeField] private SpriteRenderer led;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        led.color = Color.red;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        led.color = Color.white;
    }
}
