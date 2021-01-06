using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float jumpSpeed;

    private bool ignoreNextCollision;
    public bool isGameOver;

    private Rigidbody rb;
    private Vector3 startPos;

    AudioSource audioS;
    [SerializeField] private AudioClip jumpingSound;
    [SerializeField] private AudioClip coinSound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        isGameOver = false;

        audioS = GetComponent<AudioSource>();
        

    }

    private void OnCollisionEnter(Collision col)
    {
        if (ignoreNextCollision) return;

        if(col.gameObject.tag == "block" || col.gameObject.tag == "ground") 
        {
            if(!isGameOver)
            {
                rb.velocity = Vector3.zero;
                rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse); // Zıplama

                ignoreNextCollision = true;


                Invoke("AllowCollision", .2f);
            }
            
        }

        if(col.gameObject.tag == "spike" || col.gameObject.tag == "deadFall")
        {
            GameOver();
        }

        if(col.gameObject.tag == "ground" && GameManager.singleton.score > 10)
        {
            GameOver();
        }

        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "coin")
        {
            audioS.clip = coinSound;
            audioS.volume = 0.3f;
            audioS.Play();
            GameManager.singleton.CoinKeeper();
            Destroy(col.gameObject);
        }
    }
    public void ResetBall()
    {
        transform.position = startPos;
    }

    private void AllowCollision()
    {
        audioS.clip = jumpingSound;
        audioS.volume = 0.3f;
        audioS.Play();
        ignoreNextCollision = false;
    }

    public void GameOver()
    {
        isGameOver = true;
    }
}
