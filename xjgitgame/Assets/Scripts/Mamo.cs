using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mamo : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private float howClose = 0.25f;

    [SerializeField]
    GameObject loseVideo;

    [SerializeField]
    GameObject dramaMusic;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < howClose)
        {
            print("CAUGHT BY MAMO");
            // video 3 moment, button to restart level
            dramaMusic.SetActive(false);
            loseVideo.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Destroy(gameObject);
        }
    }
}
