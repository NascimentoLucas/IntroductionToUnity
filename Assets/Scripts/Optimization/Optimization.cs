using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Optimization : MonoBehaviour
{
    [Header("GD")]
    [SerializeField]
    [Range(0, 179)]
    private float angleRange;
    [SerializeField]
    private float lodDist = 35;
    private float angle;


    [Header("Debug")]
    [SerializeField]
    private bool use;

    private void Update()
    {
        if (use)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (Vector3.Distance(Camera.main.transform.position, transform.GetChild(i).position) < lodDist)
                {
                    AngleBetween(transform.GetChild(i).transform.position);
                    transform.GetChild(i).transform.gameObject.SetActive(angle > 360 - angleRange || angle < angleRange);
                    transform.GetChild(i).transform.gameObject.name = angle.ToString();
                }
                else
                {
                    transform.GetChild(i).transform.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).transform.gameObject.SetActive(true);
            }
        }
    }

    private void AngleBetween(Vector3 childDir)
    {
        Vector3 targetDir = Camera.main.transform.position;
        targetDir.y = 0;
        childDir.y = 0;

        targetDir = childDir - Camera.main.transform.position;
        angle = Vector3.Angle(targetDir, Camera.main.transform.forward);
    }
}
