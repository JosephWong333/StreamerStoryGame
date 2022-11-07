using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sens : MonoBehaviour
{

    [SerializeField]
    private TMP_Text SensTxt;

    public void Add()
    {
        Motion.lookSpeed += 1;
        MotionCar.lookSpeed += 1;
    }

    public void Minus()
    {
        if (Motion.lookSpeed > 0)
        {
            Motion.lookSpeed -= 1;
            MotionCar.lookSpeed -= 1;
        }

    }

    private void Update()
    {
        SensTxt.text = Motion.lookSpeed.ToString();
    }
}
