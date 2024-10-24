using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    GameObject onPlayingPanel;
    GameObject pausePanel;
    GameObject stageOverPanel;
    void Awake()
    {
        onPlayingPanel = transform.GetChild(0).gameObject;
        pausePanel = transform.GetChild(1).gameObject;
        stageOverPanel = transform.GetChild(2).gameObject;
    }

    void OnEnable()
    {
        GameManager.Instance.Player.onDie += StageOver;
    }

    void OnDisable()
    {
        //GameManager.Instance.onStageOver -= StageOver;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.Pause();
            onPlayingPanel.SetActive(false);
            pausePanel.SetActive(true);
        }
    }

    void StageOver()
    {
        onPlayingPanel.SetActive(false);
        stageOverPanel.SetActive(true);
        GameManager.Instance.StageOver();
    }
}
