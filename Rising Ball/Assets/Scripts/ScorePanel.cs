using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ScorePanel : MonoBehaviour
{
    [SerializeField] private BallController ball;

    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject scorePanel;

    [SerializeField] private Button menuButton;
    [SerializeField] private Button restartButton;

    public bool isScorePanel;

    AudioSource audioS;
    [SerializeField] private AudioClip click;

    void Start()
    {
        isScorePanel = true;

        audioS = GetComponent<AudioSource>();
        menuButton.onClick.AddListener(Menu);
        restartButton.onClick.AddListener(Restart);
    }


    private void Restart()
    {
        audioS.Play();

        ball.ResetBall();
        isScorePanel = false;
        Time.timeScale = 1f;

        GameManager.singleton.AddToTotalCoin(GameManager.singleton.coin);
        SceneManager.LoadScene("MainScene");
    }
    private void Menu()
    {
        audioS.Play();

        isScorePanel = false;
        Time.timeScale = 1f;

        GameManager.singleton.AddToTotalCoin(GameManager.singleton.coin);
        SceneManager.LoadScene("MenuScene");
    }
}
