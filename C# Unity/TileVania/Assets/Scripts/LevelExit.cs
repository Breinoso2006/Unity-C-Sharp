using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    Animator myAnimator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(ExitLevel());
    }

    IEnumerator ExitLevel()
    {
        myAnimator = GetComponent<Animator>();
        myAnimator.SetTrigger("Loading");
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }
}
