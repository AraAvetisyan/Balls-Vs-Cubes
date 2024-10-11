using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelsUIController : MonoBehaviour
{
    [SerializeField] CubeScript[] cubes;
    [SerializeField] private Slider progress;
    [SerializeField] private int maxValue;
    [SerializeField] private TextMeshProUGUI levelText;
    private int progressValue;
    //[SerializeField] private GameObject nextLevel; 
    //[SerializeField] private GameObject thisLevel;
    private bool levelAdded;

    private Coroutine enumerator;

    public Transform SpawnPoint;
    public TextMeshProUGUI SpawnText;
    void Start()
    {
        StartCoroutine(WaitFrameBeforeStart());

    }
    public IEnumerator WaitFrameBeforeStart()
    {
        yield return new WaitForEndOfFrame();
        for (int i = 0; i < cubes.Length; i++)
        {
            maxValue += cubes[i].Health;
        }
        progress.maxValue = maxValue;

        if(LevelChooser.Instance.CurrentLevelCount > 45)
        {
            levelText.text = "Level " + LevelChooser.Instance.CurrentLevelCount;
        }
    }
    public void ChangeValue(int value)
    {
        progressValue+= value;
        MoneyScript.Instance.AddMoney();
        progress.value = progressValue;
        if(progressValue >= maxValue) 
        {
            StartCorutine();
        }
    }
    public void StartCorutine()
    {
        enumerator = StartCoroutine(LevelPass());
        
    }
    public IEnumerator LevelPass()
    {
        
        yield return new WaitForSeconds(0.1f);
        //nextLevel.SetActive(true);
        //thisLevel.SetActive(false);
        for(int i = 0;i< BallSpawner.Instance.SpawnedObjects.Count; i++)
        {
            Destroy(BallSpawner.Instance.SpawnedObjects[i]);
        }
        BallSpawner.Instance.SpawnedObjects.Clear();
        BallSpawner.Instance.SpawnCount = BallSpawner.Instance.MaximumBallCount;
        StopCorutine();
    }
    public void StopCorutine()
    {
        if (enumerator != null)
        {
            StopCoroutine(enumerator);
            enumerator = null;
        }
        if (!levelAdded)
        {
            levelAdded = true;
            Geekplay.Instance.PlayerData.Level += 1;
        }
        levelAdded = false;
        LevelChooser.Instance.SpawnNewLevel();
    }
}
