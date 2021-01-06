using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject endPanel;

    [SerializeField] private BallController ball;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private Button pauseButton;

    private bool isGamePanel;

    AudioSource audioS;
    [SerializeField] private AudioClip music;

    void Start()
    {
        pauseButton.onClick.AddListener(Pause);
        audioS = GetComponent<AudioSource>();
        isGamePanel = true;
    }

    void Update()
    {

        if (ball.isGameOver)
        {
            isGamePanel = false;
            endPanel.SetActive(true);
            gameObject.SetActive(false);
        }

        if (isGamePanel)
        {
            audioS.volume = 0.1f;
            audioS.PlayOneShot(music, 0.1f);
        }
    }

    private void Pause()
    {
        isGamePanel = false;
        pausePanel.SetActive(true);
        gameObject.SetActive(false);
        Time.timeScale = 0f;
    }
}
