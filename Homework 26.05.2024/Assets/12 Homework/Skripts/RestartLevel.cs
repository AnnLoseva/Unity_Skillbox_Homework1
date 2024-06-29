using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            StartCoroutine(startNextLevel());
        }
    }


    private IEnumerator startNextLevel()
    {
        yield return new WaitForSecondsRealtime(3);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
