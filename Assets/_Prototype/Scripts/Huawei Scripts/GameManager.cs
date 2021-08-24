﻿using UnityEngine;
using UnityEngine.SceneManagement;
//using HmsPlugin;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    #region Variables
    public Helicopter HCPlayer;

    public bool isEnded;
    public bool isWonLevel;

    #endregion

    #region General Functions
    private void Awake()
    {
        instance = this;
    }
    #endregion

    #region Core Functions
    public void EndGame(bool success, float landingSpeed)
    {
        if (isEnded)
            return;

        isEnded = true;

        if (success)
            Success(landingSpeed);
        else Failed();

        CheckResults();
    }

    public void Success(float landingSpeed)
    {
        isEnded = true;
        isWonLevel = true;

        UIManager.instance.ResultsPopup(true, landingSpeed);

        GiveScore(landingSpeed);

        if (SceneManager.GetActiveScene().name == "Level01")
        {
            //HMSAchievementsManager.Instance.UnlockAchievement(HMSAchievementConstants.FirstLevelComplete); // Unlocks the achievement mentioned in the Constants Class
            //HMSAchievementsManager.Instance.RevealAchievement(HMSAchievementConstants.SecondLevelComplete); // Reveals the achievement of completing the second level, which can now be shown in the native UI on the main menu.
        }

        if (landingSpeed < 0.33f)
        {
            Debug.Log("Give achievement for getting 3 stars for first time"); // Can be replaced with an achievement when completing a level with a score of 3 stars.
            //HMSAchievementsManager.Instance.UnlockAchievement(HMSAchievementConstants.LandinglikeaPro);
        }
    }

    public void Failed()
    {
        isEnded = true;
        isWonLevel = false;

        UIManager.instance.ResultsPopup(false, 0);

        Debug.Log("Give Achievement for losing level");

        //HuaweiManager.instance.OpenAd(0); // When failing the level, trigger a banner-based advertisement to start.
    }

    public void GiveScore(float landingSpeed)
    {
        if (landingSpeed < 0.33f)
        {
            UIManager.instance.StarsPopup(2);
        }
        else if (landingSpeed > 0.33f && landingSpeed < 0.76f)
        {
            UIManager.instance.StarsPopup(1);
        }
        else
        {
            UIManager.instance.StarsPopup(0);
            
        }
    }

    public void CheckResults()
    {
        HCPlayer.rb.isKinematic = true;
    }
    #endregion
}
