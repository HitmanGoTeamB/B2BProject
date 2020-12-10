using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizSceneButtons : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
