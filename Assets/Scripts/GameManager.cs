using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCommon;

public class GameManager : SingletonBindAlive<GameManager>
{
    [SerializeField] private int focalLevel = 1;
    [SerializeField] private float focalBaseSize = 5f;
    [SerializeField] private float focalSizeUpPerLevel = 1f;

    public GameState gameState;

    public int FocalLevel { get => focalLevel; }

    public float CurrentFocalSize()
    {
        return focalBaseSize + focalSizeUpPerLevel * (focalLevel - 1);
    }

    public void LevelUpFocal(int level = 1)
    {
        focalLevel += level;
    }
}