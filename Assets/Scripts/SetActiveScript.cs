using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetActiveScript : MonoBehaviour
{
    public GameObject gameObject2;

    public void ToggleActiveAfterDelay(float delay)
    {
        StartCoroutine(ToggleActiveCoroutine(delay));
    }

    private IEnumerator ToggleActiveCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject2.SetActive(!gameObject2.activeSelf);
        gameObject.SetActive(!gameObject.activeSelf);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reloads the current scene
    }

}
