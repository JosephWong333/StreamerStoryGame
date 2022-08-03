using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ReturnNewScene : MonoBehaviour
{
    public LevelLoader levelLoader;

    // Update is called once per frame
    void Update()
    {
        // to skip video
        if (Input.GetKeyDown(KeyCode.Return))
        {
            levelLoader.LoadNextLevel();
        }
    }
}
