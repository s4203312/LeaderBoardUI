using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingToUI : MonoBehaviour
{
    public GameObject leaderboardNameText;
    public GameObject leaderboardNumberText;

    public string[] currentLeaderboardNameArray;
    public int[] currentLeaderboardNumberArray;

    private string currentLeaderboardName;
    private string currentLeaderboardNumber;

    private int aboveScore = 0;
    private bool Changed;
    private int currentPos;


    void Start()
    {
        leaderboardNameText.GetComponent<TMP_Text>().text = string.Empty;
        leaderboardNumberText.GetComponent<TMP_Text>().text = string.Empty;
    }

    public void UpdateLeaderboard()
    {
        SortLeaderboard();
        if (Changed)
        {
            SortLeaderboard();
        }

        currentLeaderboardName = string.Empty;
        currentLeaderboardNumber = string.Empty;

        foreach (var highscore in currentLeaderboardNameArray) 
        {
            currentLeaderboardName = currentLeaderboardName + highscore + System.Environment.NewLine;
        }
        foreach (var highscore in currentLeaderboardNumberArray)
        {
            currentLeaderboardNumber = currentLeaderboardNumber + highscore.ToString() + System.Environment.NewLine;
        }

        leaderboardNameText.GetComponent<TMP_Text>().text = currentLeaderboardName;
        leaderboardNumberText.GetComponent<TMP_Text>().text = currentLeaderboardNumber;
    }

    private void SortLeaderboard()
    {
        Changed = false;
        foreach (var highscore in currentLeaderboardNumberArray)
        {
            if (currentPos != 0)
            {
                if (highscore > aboveScore)
                {
                    int previousScore = currentLeaderboardNumberArray[currentPos - 1];
                    currentLeaderboardNumberArray[currentPos - 1] = currentLeaderboardNumberArray[currentPos];
                    currentLeaderboardNumberArray[currentPos] = previousScore;

                    string previousName = currentLeaderboardNameArray[currentPos - 1];
                    currentLeaderboardNameArray[currentPos - 1] = currentLeaderboardNameArray[currentPos];
                    currentLeaderboardNameArray[currentPos] = previousName;

                    Changed = true;
                }
            }
            aboveScore = currentLeaderboardNumberArray[currentPos];
            currentPos++;
        }
        currentPos = 0;
    }
}
