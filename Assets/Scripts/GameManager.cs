using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject restartButton;

    private float timer = 30f;
 

    private void Start()
    {
        Time.timeScale = 1f;
        restartButton.SetActive(false);
    }

    private void Update()
    {

        GameTimer();
    }

    private void GameTimer()
    {
        timer -= Time.deltaTime;

        timerText.text = Mathf.Ceil(timer).ToString();

        if (timer <= 0)
        {
            timer = 0;
            
          Time.timeScale = 0f;

          restartButton.SetActive(true);

        }

    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}