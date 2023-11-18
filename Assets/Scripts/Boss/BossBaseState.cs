using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBaseState : MonoBehaviour
{
    protected Camera cam;

    protected float maxLeft;
    protected float maxRight;
    protected float maxDown;
    protected float maxUp;
    protected BossController bossController;

    private void Awake()
    {
        bossController = GetComponent<BossController>();
        cam = Camera.main;
    }
    protected virtual void Start()
    {
        maxLeft = cam.ViewportToWorldPoint(new Vector2(0.3f, 0)).x;
        maxRight = cam.ViewportToWorldPoint(new Vector2(0.7f, 0)).x;

        maxDown = cam.ViewportToWorldPoint(new Vector2(0, 0.06f)).y;
        maxUp = cam.ViewportToWorldPoint(new Vector2(0, 0.9f)).y;
    }

    public virtual void RunState()
    {

    }

    public virtual void StopState()
    {
        StopAllCoroutines();
    }
}
