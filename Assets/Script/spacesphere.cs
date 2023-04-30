using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spacesphere : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate( 0f, 0f, 90f * Time.deltaTime);
    }
}
