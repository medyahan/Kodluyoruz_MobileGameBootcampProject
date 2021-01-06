using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Text coinTotalText;

    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button soundButton;
    [SerializeField] private Button infoButton;

    [SerializeField] private Button bonusButton;
    [SerializeField] private Button dailyButton;
    [SerializeField] private Button customizeButton;
    [SerializeField] private Button challengeButton;

    [SerializeField] private GameObject bonusPanel;
    [SerializeField] private GameObject dailyPanel;
    [SerializeField] private GameObject customizePanel;
    [SerializeField] private GameObject challengePanel;

    [SerializeField] private Button [] CloseButtons;

    [SerializeField] private GameObject settingsBar;

    public bool isOpenedSettings;

    AudioSource audioS;
    [SerializeField] private AudioClip click;

    void Start()
    {
        isOpenedSettings = false;

        audioS = GetComponent<AudioSource>();

        playButton.onClick.AddListener(Play);
        settingsButton.onClick.AddListener(Settings);
        soundButton.onClick.AddListener(Sound);
        infoButton.onClick.AddListener(Info);


        bonusButton.onClick.AddListener(Bonus);
        dailyButton.onClick.AddListener(Daily);
        customizeButton.onClick.AddListener(Customize);
        challengeButton.onClick.AddListener(Challenge);
        
    }

    private void Update()
    {
        coinTotalText.text = "" + GameManager.singleton.coinTotal;
    }

    private void Play()
    {
        audioS.Play();
        SceneManager.LoadScene("MainScene");
    }

    private void Settings()
    {
        audioS.Play();

        if (isOpenedSettings)
        {
            settingsBar.SetActive(false);
            isOpenedSettings = false;
        }
        else
        {
            settingsBar.SetActive(true);
            isOpenedSettings = true;
        }

    }

    private void Sound()
    {
        audioS.Play();
        Debug.Log("Sound");
    }

    private void Info()
    {
        audioS.Play();
        Debug.Log("Info");
    }

    private void Bonus()
    {
        audioS.Play();
        Debug.Log("Bonus");

        //bonusPanel.SetActive(true);

        //CloseButtons[0].onClick.AddListener(() => ClosePanel(panel));

    }


    private void Daily()
    {
        audioS.Play();
        Debug.Log("Daily");
    }

    private void Customize()
    {
        audioS.Play();
        Debug.Log("Customize");
    }

    private void Challenge()
    {
        audioS.Play();
        Debug.Log("Challenge");
    }

    private void ClosePanel()
    {
        audioS.Play();
    }
}
