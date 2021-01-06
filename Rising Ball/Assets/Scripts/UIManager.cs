using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Text scoreText1; // Oyun Ekranı
    [SerializeField] private Text bestText1;
    [SerializeField] private Text coinText1;

    [SerializeField] private Text scoreText2; // Score Ekranı
    [SerializeField] private Text bestText2;

    [SerializeField] private Text coinTotalText;
    [SerializeField] private Text coinText;


    private void Update()
    {
        bestText1.text = "best:\n" + GameManager.singleton.best;
        scoreText1.text = "" + GameManager.singleton.score;
        
        bestText2.text = "best: " + GameManager.singleton.best;
        scoreText2.text = "" + GameManager.singleton.score;

        coinTotalText.text = "" + GameManager.singleton.coinTotal;
        coinText.text = "+ " + GameManager.singleton.coin;

        coinText1.text = "" + GameManager.singleton.coin;
    }
}