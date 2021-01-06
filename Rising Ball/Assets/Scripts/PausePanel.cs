using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject scorePanel;

    [SerializeField] private Button resumeButton;
    [SerializeField] private Button menuButton;

    AudioSource audioS;
    [SerializeField] private AudioClip click;

    void Start()
    {
        audioS = GetComponent<AudioSource>();

        resumeButton.onClick.AddListener(Resume);
        menuButton.onClick.AddListener(Menu);
    }

    private void Resume()
    {
        Time.timeScale = 1f;
        audioS.Play();
        gamePanel.SetActive(true);
        gameObject.SetActive(false);
    }

    private void Menu()
    {
        audioS.Play();
        gamePanel.SetActive(false);
        scorePanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
