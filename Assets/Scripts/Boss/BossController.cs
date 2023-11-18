using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    enter,
    fire,
    special,
    death
}

public class BossController : MonoBehaviour
{
    [SerializeField] private BossEnter bossEnter;
    [SerializeField] private BossFire bossFire;
    [SerializeField] private bool test;
    [SerializeField] private BossState testState;
    
    // Start is called before the first frame update
    void Start()
    {
        if (test)
        {
            ChangeState(testState);
        } 
    }

    public void ChangeState(BossState state)
    {

        switch (state)
        {
            case BossState.enter:
                bossEnter.RunState();
                break;
            case BossState.fire:
                bossFire.RunState();
                break;
            case BossState.special:
                Debug.Log("Do Something");
                break;
            case BossState.death:
                Debug.Log("Do Something");
                break;
        }
    }

   
}
