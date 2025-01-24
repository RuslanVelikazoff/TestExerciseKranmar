using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] 
    private int enemyAmount;

    [SerializeField]
    private GameObject winPanel;
    [SerializeField]
    private GameObject losePanel;

    private void Awake()
    {
        Time.timeScale = 1f;
        Instance = this;
    }

    private void WinGame()
    {
        Cursor.lockState = CursorLockMode.Confined;
        winPanel.SetActive(true);
    }

    public void LoseGame()
    {
        Cursor.lockState = CursorLockMode.Confined;
        losePanel.SetActive(true);
    }

    public void KillEnemy()
    {
        enemyAmount--;

        if (enemyAmount <= 0)
        {
            WinGame();
        }
    }
}
