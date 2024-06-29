using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Ball")
        {
            StartCoroutine(startNextLevel());
        }
    }

    private IEnumerator startNextLevel()
    {
        yield return new WaitForSecondsRealtime(3);

        if(GameData.levelIndex <= (SceneManager.GetActiveScene().buildIndex + 1))
        {
            GameData.levelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
