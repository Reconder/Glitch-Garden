using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float delayStartScreen = 3f;
    int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0) { PlayerPrefsController.MasterDifficulty = 5f; StartCoroutine(LoadSceneWithDelay("Start Screen", delayStartScreen)); }

    }

    public void LoadGame() => SceneManager.LoadScene("Blank Level");
    public void RestartLevel()
    {
        
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public IEnumerator LoadSceneWithDelay(string name, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(name);
    }

    public void LoadScene(string sceneName) => SceneManager.LoadScene(sceneName);

    public void LoadScene(int buildIndex) => SceneManager.LoadScene(buildIndex);
    public void LoadNextScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    public void LoadStartMenu() => LoadScene("Start Screen");
    public void LoadOptionsMenu() => LoadScene("Options Screen");
    public void QuitGame()
    {
        Time.timeScale = 1;
        Application.Quit();
    }
}
