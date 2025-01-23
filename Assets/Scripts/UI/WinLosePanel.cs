using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLosePanel : MonoBehaviour
{
    [SerializeField] 
    private Button restartButton;

    private void Awake()
    {
        if (restartButton != null)
        {
            restartButton.onClick.RemoveAllListeners();
            restartButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            });
        }

        Time.timeScale = 0f;
    }
}
