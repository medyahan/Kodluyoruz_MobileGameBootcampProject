using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    public int best; //
    public int score; //

    public int coin;
    public int coinTotal;

    public int meter = 5;
    public int i = 1;

    [SerializeField] private BallController ball;

    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private ScorePanel scorePanel;

    [SerializeField] private Renderer skyRenderer;
    [SerializeField] private Material[] skyColors;

    private bool changeability;

    private void Awake()
    {
        if (singleton == null)
            singleton = this;
        else if (singleton != this)
            Destroy(gameObject);

        best = PlayerPrefs.GetInt("bestscore");
        coinTotal = PlayerPrefs.GetInt("coin");

        gamePanel.SetActive(true);

    }

    private void Update()
    {
        ScoreKeeper();

    }

    public void Restart()
    {
        singleton.score = 0;
        FindObjectOfType<BallController>().ResetBall();
        SceneManager.LoadScene("MainScene");
    }

    public void ScoreKeeper()
    {
        if ((int) ball.transform.position.y + 2 > score)
            score = (int) ball.transform.position.y + 2;

        if (score > best)
        {
            PlayerPrefs.SetInt("bestscore", score);
            best = score;
        }
    }

    public void CoinKeeper()
    {
        coin += 1;

    }

    public void AddToTotalCoin(int coin)
    {
        PlayerPrefs.SetInt("coin", coinTotal + coin);

        coinTotal += coin;
    }

    public void ChangeSky()
    {
        if (score % meter == 0 && score != 0)
        {
            skyRenderer.material = skyColors[i];
            i++;

            if(skyColors.Length == i)
                i = 0;
        }
    }
}
