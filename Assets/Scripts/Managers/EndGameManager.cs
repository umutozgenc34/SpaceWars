using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager endManager;
    public bool gameOver;
    public bool posibleWin;

    private PanelController panelController;
    private TextMeshProUGUI scoreTextComponent;
    public int score;
    private PlayerStats player;
    private RewardedAd rewardedAd;

    [HideInInspector]
    public string levelUnlock = "LevelUnlock";

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

    public void UpdateScore(int addScore)
    {
        score += addScore;
        scoreTextComponent.text = "Score : " + score.ToString();
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
        if (posibleWin==true && gameOver==false)
        {
            WinGame();
            
        }
        else if(posibleWin==false && gameOver==true)
        {
            AdLoseGame();
        }
        else if (posibleWin == true && gameOver == true)
        {
            LoseGame();
        }
    }

    public void WinGame()
    {
        player.canTakeDmg = false;
        ScoreSet();
        panelController.ActivateWin();
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevel > PlayerPrefs.GetInt(levelUnlock,0))
        {
            PlayerPrefs.SetInt(levelUnlock, nextLevel);
        }
    }

    public void LoseGame()
    {
        ScoreSet();
        panelController.ActivateLose();
    }
    public void AdLoseGame()
    {
        ScoreSet();
        if (rewardedAd.adNumber > 0)
        {
            rewardedAd.adNumber -= 1;
            panelController.ActivateAdLose();
        }
        else
        {
            panelController.ActivateLose();
        }
        
    }
    private void ScoreSet()
    {
        PlayerPrefs.SetInt("Score " + SceneManager.GetActiveScene().name, score);
        int highScore = PlayerPrefs.GetInt("High Score " + SceneManager.GetActiveScene().name, 0);
        if (score > highScore)
            PlayerPrefs.SetInt("High Score " + SceneManager.GetActiveScene().name, score);

        score = 0;
        
    }

    public void RegisterPanelController(PanelController pC)
    {
        panelController = pC;
    }

    public void RegisterScoreText(TextMeshProUGUI scoreTextComp)
    {
        scoreTextComponent = scoreTextComp;
    }
    
    public void RegisterPlayerStats(PlayerStats statsPlayer)
    {
        player = statsPlayer;
    }

    public void RegisterRewardedAd(RewardedAd ad)
    {
        rewardedAd = ad;
    }

    
}
