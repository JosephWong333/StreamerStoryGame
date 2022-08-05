using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Audio;

public class VideoSystem : MonoBehaviour
{

    [SerializeField]
    bool Prep_WhenDone_Shoot = false;

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<VideoPlayer>().Prepare();

        if (Prep_WhenDone_Shoot)
            StartCoroutine(EShoot());
    }

    IEnumerator EShoot()
    {

        GetComponent<RawImage>().enabled = true;

        VideoPlayer vp = GetComponent<VideoPlayer>();

        while (!vp.isPrepared)
        {
            yield return null;
        }

        vp.Play();
        //external audio? maybe later
        //GetComponent<AudioSource>().Play();

    }

    public void Shoot()
    {
        StartCoroutine(EShoot());
    }

    //Shoot w new scene may be done later
}
