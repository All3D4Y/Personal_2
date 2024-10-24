using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float stageOverTime = 100f;

    Player player;

    int stageLevel = 1;
    float elapsedTime = 0;

    public Action onStageOver;

    public float ElapsedTime
    {
        get => elapsedTime;
        set
        {
            elapsedTime = value;
            if (elapsedTime > stageOverTime)
            {
                StageOver();
            }
        }
    }

    void Update()
    {
        ElapsedTime += Time.deltaTime;
    }

    public Player Player
    {
        get
        {
            if (player == null)
                player = FindAnyObjectByType<Player>();
            return player;
        }
    }

    public int StageLevel
    {
        get => stageLevel;
        set
        {
            stageLevel = value;
        }
    }

    protected override void OnInitialize()
    {
        player = FindAnyObjectByType<Player>();
    }

    public void StageOver()
    {
        Debug.Log("Stage Over");
        onStageOver?.Invoke();
        ElapsedTime = 0;
        Pause();
    }
    public void Pause()
    {
        Time.timeScale = 0.0f;
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
    }

    public void NextStage()
    {
        StageLevel++;
        // 다음 스테이지로
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
