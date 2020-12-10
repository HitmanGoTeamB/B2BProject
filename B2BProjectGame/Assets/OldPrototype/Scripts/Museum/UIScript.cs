using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) GoToScene("QuizScene");
        if (Input.GetKeyDown(KeyCode.O)) GoToScene("MemoryScene");
        if (Input.GetKeyDown(KeyCode.I)) GoToScene("FindTheDifferencesScene");
        if (Input.GetKeyDown(KeyCode.U)) GoToScene("Bruh");
        if (Input.GetKeyDown(KeyCode.Y)) GoToScene("FindTheIntruderAltScene");
    }
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
