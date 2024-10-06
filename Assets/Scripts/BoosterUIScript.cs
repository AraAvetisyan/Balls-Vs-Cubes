using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoosterUIScript : MonoBehaviour
{
    [SerializeField] private Button incomeButton;
    [SerializeField] private Button autoClickButton;
    [SerializeField] private Button doubleBallButton;
    public void Pressed2XBall()
    {
        BallSpawner.Instance.BallMaxCountBooster = 2;
        BallSpawner.Instance.SpawnCount += BallSpawner.Instance.MaximumBallCount;
        BallSpawner.Instance.MaximumBallCount = Geekplay.Instance.PlayerData.MaxSpawnCount * BallSpawner.Instance.BallMaxCountBooster;
        doubleBallButton.interactable = false;
        StartCoroutine(DoubleBall());
    }

    public void Pressed5XIncome()
    {
        BallSpawner.Instance.IncomeBoost = 5;
        incomeButton.interactable = false;
        StartCoroutine(IncomeTimer());
    }

    public void PressedAutoClick()
    {
        StartCoroutine(AutoClickTimer());
        autoClickButton.interactable = false;
    }

    public IEnumerator DoubleBall()
    {
        float duration = 60f;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }
        BallSpawner.Instance.MaximumBallCount = Geekplay.Instance.PlayerData.MaxSpawnCount;
        BallSpawner.Instance.BallMaxCountBooster = 1;
        doubleBallButton.interactable = true;
    }
    public IEnumerator AutoClickTimer()
    {
        float duration = 60f;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            BallSpawner.Instance.SpawnBall();
            yield return null;
        }

        autoClickButton.interactable = true;
    }
    public IEnumerator IncomeTimer()
    {
        float duration = 120f;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }
        BallSpawner.Instance.IncomeBoost = 1;
        incomeButton.interactable = true;
    }
}
