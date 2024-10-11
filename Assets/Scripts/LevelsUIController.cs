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

        if (Geekplay.Instance.language == "en")
            levelText.text = "LEVEL " + LevelChooser.Instance.CurrentLevelCount;
        
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
        progressValue = 0;
        yield return new WaitForSeconds(0.1f);
        for(int i = 0;i< BallSpawner.Instance.SpawnedObjects.Count; i++)
        {
            Destroy(BallSpawner.Instance.SpawnedObjects[i]);
        }
        BallSpawner.Instance.SpawnedObjects.Clear();
        BallSpawner.Instance.SpawnCount = BallSpawner.Instance.MaximumBallCount;            
        Geekplay.Instance.PlayerData.Level += 1;   
        LevelChooser.Instance.SpawnNewLevel();
        StopCorutine();
    }
    public void StopCorutine()
    {
        if (enumerator != null)
        {
            StopCoroutine(enumerator);
            enumerator = null;
        }
        
    }
}
