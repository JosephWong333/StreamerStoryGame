using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    int to_scene_index = 0;

    [SerializeField]
    bool updater = false;

    public Animator transition;
    public float transitionTime = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && updater)
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(timer());
    }

    IEnumerator timer()
    {
        // Play anim
        transition.SetTrigger("start");
        // Wait
        yield return new WaitForSeconds(transitionTime);
        // Load scene
        SceneManager.LoadScene(to_scene_index);

    }
}
