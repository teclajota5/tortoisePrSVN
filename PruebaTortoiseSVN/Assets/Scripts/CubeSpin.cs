using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpin : MonoBehaviour
{
    public float rotationSpeed = 90;
    public float stopDuration = 2;

    float angle;

    bool rotating;
    bool clicked;

    float stopTimer;

    // Start is called before the first frame update
    void Start()
    {
        angle = 0;

        rotating = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!rotating && clicked)
        {
            rotating = true;
        }
        else if(rotating && clicked)
        {
            stopTimer = 0;
            rotating = false;
        }

        if(rotating)
        {
            angle += rotationSpeed * Time.deltaTime;
        }
        else
        {
            stopTimer += Time.deltaTime;
            if(stopTimer > stopDuration) { stopTimer = stopDuration; }

            angle = angle + (Mathf.Round(angle / 90) * 90 - angle) * stopTimer / stopDuration;
        }

        transform.rotation = Quaternion.Euler(angle, 0, 0);

        clicked = false;
    }

    void OnMouseDown()
    {
        clicked = true;
    }
}
