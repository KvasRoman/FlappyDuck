using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField] TMP_Text ScoreTextField;
    private int _score;
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("ScoreManager should be only one");
        }
    }
    public void AddScorePoint(int poinst = 1)
    {
        _score += poinst;
        ScoreTextField.text = $"Score: {_score}";
    }
}
