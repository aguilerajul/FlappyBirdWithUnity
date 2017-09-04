using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionButtons : MonoBehaviour
{
    void Awake()
    {
        StopAllCoroutines();
    }

    public void RestartGate(string sceneName)
    {
        GlobalVariables.IsPlayerDead = false;
        SceneManager.LoadScene(sceneName);
    }
}
