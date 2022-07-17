using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objSposes : MonoBehaviour
{

    public GameObject obj;
    public float change_speed = 0;
    public float change_speed2 = 40f;

    public bool Allrotate = false;

    // Start is called before the first frame update
    void Start()
    {
        if (Allrotate)
            StartCoroutine(timerAllrotate(10f));
    }

    IEnumerator timerAllrotate(float time)
    {
        float i = 0;
        float rate = 1 / time;

        while (i < time)
        {
            obj.transform.RotateAround(obj.transform.position, Vector3.up, change_speed2 * Time.deltaTime);
            yield return new WaitForSeconds(change_speed);
            i += rate * Time.deltaTime;
        }
        StartCoroutine(timerAllrotate(10f));

    }


}
