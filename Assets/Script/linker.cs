using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linker : MonoBehaviour
{

    [SerializeField] private string url; 

    private void OnMouseDown()
    {
        Application.OpenURL(url);
    }
}
