using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator anim;

    public float transitionTime = 1f;

    public void PlayGame()
    {
        StartCoroutine(LoadLevel(1));
    }

    public void PlayTut()
    {
        StartCoroutine(LoadLevel(2));

    }

    public void PlayLevel1()
    {
        StartCoroutine(LoadLevel(3));

    }

    public void PlayLevel2()
    {
        StartCoroutine(LoadLevel(4));

    }
    
    public void PlayLevel3()
    {
        StartCoroutine(LoadLevel(5));

    }

    public void PlayMulti()
    {
        StartCoroutine(LoadLevel(6));

    }

    IEnumerator LoadLevel(int levelIndex)
    {
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);

    }
}
