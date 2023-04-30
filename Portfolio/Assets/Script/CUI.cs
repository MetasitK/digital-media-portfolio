using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUI : MonoBehaviour
{
    [SerializeField] private Transform[] camTarget;

    private Cam mainCam;

    private int currentTargetIndex;

    private void Awake()
    {
        mainCam = FindObjectOfType<Cam>();
    }

    private void Start()
    {
        currentTargetIndex = 0;
        mainCam.SetTarget(camTarget[0]);
    }

    public void ChangeTarget(int changeVar) 
    {
        currentTargetIndex += changeVar;
        if (currentTargetIndex < 0)
        {
            currentTargetIndex = 0;
        }
        else if (currentTargetIndex >= camTarget.Length)
        {
            currentTargetIndex = camTarget.Length - 1;
        }
        mainCam.SetTarget(camTarget[currentTargetIndex]);
    }


    public void Quit() 
    {
        Application.Quit();
    }
}
