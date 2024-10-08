using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    private Coroutine boosterCorutine;
    [SerializeField] private HeaderButtonsScript _headerButtonsScript;
    public void StartFireCorutine()
    {
        boosterCorutine = StartCoroutine(StartFireBallTimer());

        _headerButtonsScript.Pressed = true;
    }
    public void StopFireCorutine()
    {
        if(boosterCorutine != null)
        {
            StopCoroutine(boosterCorutine);
            boosterCorutine = null;
        }
    }
    public IEnumerator StartFireBallTimer()
    {
        float duration = 15;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            BallSpawner.Instance.PowerBoostTenTimes = 10;
            BallSpawner.Instance.FireSpeedBoost = 1.5f;
            yield return null;
        }
        BallSpawner.Instance.PowerBoostTenTimes = 1;
        BallSpawner.Instance.FireSpeedBoost = 1;
        _headerButtonsScript.Pressed = false;
        StopFireCorutine();

    }
}
