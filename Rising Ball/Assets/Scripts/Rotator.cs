using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Vector2 lastTapPos;

    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {

            Vector2 curTapPos = Input.mousePosition;

            if (lastTapPos == Vector2.zero)
                lastTapPos = curTapPos;

            float delta = lastTapPos.x - curTapPos.x;
            lastTapPos = curTapPos;

            transform.Rotate(Vector3.up * delta);
        }

        if (Input.GetMouseButtonUp(0))
        {
            lastTapPos = Vector2.zero;
        }
    }

    /*
    // Başka bir çözüm (mouse olmadan)
    [SerializeField] private float rotationSpeed;

    void FixedUpdate()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) // Kuleyi çevirme
        {
            Vector3 rotation = Input.GetTouch(0).deltaPosition;
            transform.Rotate(0, -rotation.x * rotationSpeed * Time.deltaTime, 0);
        }
    }*/
}
