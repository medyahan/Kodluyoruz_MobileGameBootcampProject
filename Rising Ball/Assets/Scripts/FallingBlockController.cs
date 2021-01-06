using System.Collections;
using UnityEngine;

public class FallingBlockController : MonoBehaviour
{
    [SerializeField ]private float fallDelay = 2.0f;

    private Animation anim;

    private void Start()
    {
        anim = GetComponent<Animation>();
        anim["VibrationAnimation"].layer = 123;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ball")
        {

            anim.Play("Vibrationanimation");
            StartCoroutine(FallAfterDelay());
        }
    }

    IEnumerator FallAfterDelay()
    {
        yield return new WaitForSeconds(fallDelay);
        GetComponent<Rigidbody>().isKinematic = false;
    }
}