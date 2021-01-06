using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EndPanel : MonoBehaviour
{
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject scorePanel;

    [SerializeField] private GameObject countdown;

    [SerializeField] private Button continueButton;
    [SerializeField] private Button nothanksButton;

    private bool isCountdownOver;
    private Coroutine coroutine;

    AudioSource audioS;
    [SerializeField] private AudioClip click;

    void Start()
    {
        isCountdownOver = false;
        audioS = GetComponent<AudioSource>();

        coroutine = StartCoroutine(Countdown());

        if(!isCountdownOver)
        {
            nothanksButton.onClick.AddListener(NoThanks);
            continueButton.onClick.AddListener(Continue);
        }
    }

    void Update()
    {
        if(isCountdownOver)
        {
            StopCoroutine(coroutine);

            Time.timeScale = 0f;
            scorePanel.SetActive(true);
            gameObject.SetActive(false);
        }
       
    }
    
    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);

        countdown.SetActive(true);

        yield return new WaitForSeconds(3);

        countdown.SetActive(false);

        isCountdownOver = true;
    }

    private void NoThanks()
    {
        audioS.Play();
        scorePanel.SetActive(true);
        gameObject.SetActive(false);
    }

    private void Continue()
    {
        audioS.Play();
        // Reklam izleyerek oyunun kaldığı yerden devam etme
    }

}
