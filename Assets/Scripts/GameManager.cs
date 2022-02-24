using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCommon;

public class GameManager : SingletonBindAlive<GameManager>
{
    [SerializeField] private int focalLevel = 1;
    [SerializeField] private float focalBaseSize = 5f;
    [SerializeField] private float focalSizeUpPerLevel = 1f;

    [SerializeField] private int playerHP = 0;
    [SerializeField] private int deaths = 0;

    public GameObject currentCheckpoint;
    public GameState gameState;

    public int FocalLevel { get => focalLevel; }
    public int PlayerHP { get => playerHP; set => playerHP = value; }
    public int Deaths { get => deaths; }

    public void ResetForNewGame()
    {
        focalLevel = 1;
        deaths = 0;
    }

    public float CurrentFocalSize()
    {
        return focalBaseSize + focalSizeUpPerLevel * (focalLevel - 1);
    }

    public void LevelUpFocal(int level = 1)
    {
        focalLevel += level;
    }

    public void IncreaseDeathCount(int amount = 1)
    {
        deaths += amount;
    }
}