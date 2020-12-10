using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonFunctions : MonoBehaviour
{
    public void ReturnToMuseum(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
