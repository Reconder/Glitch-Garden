using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winText;
    [SerializeField] GameObject loseText;
    bool TimerExpired;
    bool baseIsDestroyed;
    [SerializeField] int AttackersAlive;
    float time;

    [SerializeField] float WinScreenDelay = 5f;

    public delegate void GameStopEventHandler();

    public event GameStopEventHandler OnGameStop;
    public Action IncreaseDifficulty;

    void Start()
    {
        baseIsDestroyed = false;
        loseText.SetActive(false);

        winText.SetActive(false);
        TimerExpired = false;
        AttackersAlive = 0;
        Time.timeScale = 1;
        time = 0;
    }

    public void OnAttackerSpawn() => AttackersAlive++;
    public void OnAttackerDestroyed(int score) => AttackersAlive--;

    // Update is called once per frame
    void Update()
    {
        bool AllAttackersAreDead = (AttackersAlive <= 0);
        
        if (TimerExpired && AllAttackersAreDead)
        {
            StartCoroutine(HandleWinCondition());
        }
        if (baseIsDestroyed)
        {
            HandleLoseCondition();
        }
        time += Time.deltaTime;
        if (time > 60f) { IncreaseDifficulty?.Invoke(); }
    }

    public void HandleLoseCondition()
    {

        Time.timeScale = 0;
        loseText.SetActive(true);
        StopSpawners();
    }

    private IEnumerator HandleWinCondition()
    {
        StopSpawners();
        winText.SetActive(true);
        yield return new WaitForSeconds(WinScreenDelay);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    private void StopSpawners() => OnGameStop?.Invoke();

    public void TimerHasFinished() => TimerExpired = true;

    public void BaseIsDestroyed() => baseIsDestroyed = true;
}
