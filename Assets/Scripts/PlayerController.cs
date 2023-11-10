using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;


public class PlayerController : MonoBehaviour
{
    private Camera cam;

    private Vector3 offset;

    private float maxLeft;
    private float maxRight;
    private float maxDown;
    private float maxUp;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        StartCoroutine(SetBoundaries());

    }

    // Update is called once per frame
    void Update()
    {
        if (Touch.fingers[0].isActive)
        {
            Touch myTouch = Touch.activeTouches[0];
            Vector3 touchPos = myTouch.screenPosition;
            touchPos = cam.ScreenToWorldPoint(touchPos);

            if (Touch.activeTouches[0].phase == TouchPhase.Began)
            {
                offset = touchPos - transform.position;
            }
            if (Touch.activeTouches[0].phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(touchPos.x-offset.x, touchPos.y-offset.y, 0);
            }
            if (Touch.activeTouches[0].phase == TouchPhase.Stationary)
            {
                transform.position = new Vector3(touchPos.x - offset.x, touchPos.y - offset.y, 0);
            }

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, maxLeft, maxRight),
                                             Mathf.Clamp(transform.position.y, maxDown, maxUp), 0);

                
            
        }
    }

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    private IEnumerator SetBoundaries()
    {
        yield return new WaitForSeconds(0.4f);

        maxLeft = cam.ViewportToWorldPoint(new Vector2(0.15f, 0)).x;
        maxRight = cam.ViewportToWorldPoint(new Vector2(0.85f, 0)).x;

        maxDown = cam.ViewportToWorldPoint(new Vector2(0, 0.08f)).y;
        maxUp = cam.ViewportToWorldPoint(new Vector2(0, 0.5f)).y;
    }
}
