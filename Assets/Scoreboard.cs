using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] TMP_Text scoreLabel;
    [SerializeField] TMP_Text bufferLabel;
/*    TMP_Text highscoreLabel;
*/
    int bufferedPoints = 0;
    int score = 0;
    /*    int highscore = 0;
    */

    private void Start()
    {
        bufferLabel.text = $"+{bufferedPoints}";
        scoreLabel.text = $"{score}";
    }

    void ResetBufferedPoints()
    {
        bufferedPoints = 0;
        bufferLabel.text = $"+{bufferedPoints}";
    }

    public void AddBufferedPoints(int points)
    {
        bufferedPoints += points;
        bufferLabel.text = $"+{bufferedPoints}";
    }

    public void IncreaseScore()
    {
        score += bufferedPoints;
        ResetBufferedPoints();
        scoreLabel.text = $"{score}";
    }

    /*    public void UpdateHighScore()
        {
            if (score > highscore)
            {
                highscore = score;
            }
        }*/
}
