using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadSceneByIndex(int index)
    {
        if (index == 0) // Destroy the score tracker if going to the main menu
        {
            var scoreTracker = FindAnyObjectByType<ScoreTracker>();
            if (scoreTracker) Destroy(scoreTracker);
        }
        SceneManager.LoadScene(index);
    }
}
