using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class LeaderBoardScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] namesInGame;
    [SerializeField] private TextMeshProUGUI[] maxLevelInGame;
    [SerializeField] private TextMeshProUGUI remainingTimeView;
    private Coroutine timer;
    
    
    void Start()
    {
        StartCoroutine(IETimer());
        //Запустить корутину, которая каждые 60 секунд будет заново запрашивать данные лидерборда ++
        //и заполнять их в твои тексты через Geekplay.Instance.lS и Geekplay.Instance.lN ++
    }
    IEnumerator IETimer()
    {
       
        yield return new WaitForSeconds(5);
        Geekplay.Instance.remainingTimeUntilUpdateLeaderboard = 60;
        Geekplay.Instance.leaderNumber = 0;
        Geekplay.Instance.leaderNumberN = 0;
        Utils.GetLeaderboard("score", 0, "Levels");
        Utils.GetLeaderboard("name", 0, "Levels");
        StartTimerCoroutine();
        yield return new WaitForSeconds(1);
        for (int i = 0; i < namesInGame.Length; i++)
        {
            namesInGame[i].text = Geekplay.Instance.lN[i];
            maxLevelInGame[i].text = Geekplay.Instance.lS[i];
        }
    }

    public void StartTimerCoroutine()
    {
        if(timer == null)
        {
            timer = StartCoroutine(RemainingTimer());
        }
    }
    public void StopTimerCoroutine()
    {
        if( timer != null)
        {
            StopCoroutine(timer);
            timer = null;
        }
        StartTimerCoroutine();
    }
    public IEnumerator RemainingTimer()
    {
        yield return new WaitForSeconds(60);
        Geekplay.Instance.leaderNumber = 0;
        Geekplay.Instance.leaderNumberN = 0;
        Utils.GetLeaderboard("score", 0, "Levels");
        Utils.GetLeaderboard("name", 0, "Levels");
        yield return new WaitForSeconds(1);
        for (int i = 0; i < namesInGame.Length; i++)
        {
            namesInGame[i].text = Geekplay.Instance.lN[i];
            maxLevelInGame[i].text = Geekplay.Instance.lS[i];
        }
        StopTimerCoroutine();
    }
    void Update()
    {
        if(Geekplay.Instance.remainingTimeUntilUpdateLeaderboard <= 0)
        {
            Geekplay.Instance.remainingTimeUntilUpdateLeaderboard = 60;
        }
        remainingTimeView.text = string.Format("{0:f0}", Geekplay.Instance.remainingTimeUntilUpdateLeaderboard);
    }

    //при прохождении уровня ++
    //определяем, наивысший ли это уровень ++
    //сохраняем его и посылаем ++
    //Geekplay.Instance.Leaderboard("Levels", {количество_уровня}); ++
}
