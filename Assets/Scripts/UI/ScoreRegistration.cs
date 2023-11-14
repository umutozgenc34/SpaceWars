using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreRegistration : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI textForRegistration = GetComponent<TextMeshProUGUI>();
        EndGameManager.endManager.RegisterScoreText(textForRegistration);
        textForRegistration.text = "Score : 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
