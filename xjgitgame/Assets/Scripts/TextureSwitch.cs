using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureSwitch : MonoBehaviour
{
    [SerializeField]
    float change_speed = 0.1f;

    [SerializeField]
    Material og_mat;

    [SerializeField]
    Material new_mat;

    [SerializeField]
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timer(10f));
    }

    IEnumerator timer(float time)
    {
        float i = 0;
        float rate = 1 / time;

        while (i < time)
        {
            rend.sharedMaterial = new_mat;
            yield return new WaitForSeconds(change_speed);
            rend.sharedMaterial = og_mat;
            yield return new WaitForSeconds(change_speed);
            i += rate * Time.deltaTime;
        }
        StartCoroutine(timer(10f));

    }
}
