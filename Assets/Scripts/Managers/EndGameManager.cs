using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager endManager;
    public bool gameOver;

    private PanelController panelController;

    private void Awake()
    {
        if (endManager ==null)
        {
            endManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    void Start()
    {
        
    }
    public void StartResolveSequence()
    {
        StopCoroutine(nameof(ResolveSequence));
        StartCoroutine(ResolveSequence());
    }
    private IEnumerator ResolveSequence()
    {
        yield return new WaitForSeconds(2f);
        ResolveGame();

    }

    public void ResolveGame()
    {
        if (gameOver==true)
        {
            LoseGame();
        }
        else
        {
            WinGame();
        }
    }

    public void WinGame()
    {
        panelController.ActivateWin();
    }

    public void LoseGame()
    {
        panelController.ActivateLose();
    }

    public void RegisterPanelController(PanelController pC)
    {
        panelController = pC;
    }

    

    
}
