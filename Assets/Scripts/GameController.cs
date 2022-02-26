using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCommon;

public class GameController : SingletonBind<GameController>
{
    private PlayerStats player;
    private GameManager gameManager;
    [SerializeField] private Transform[] cutsceneTeleportPos;
    [SerializeField] private GameObject[] cutscenes;
    private float teleportDelay = 0;
    private int cutsceneId;

    private void Start()
    {
        player = PlayerStats.Instance;
        gameManager = GameManager.Instance;
    }

    public void TriggerCutscene(int id)
    {
        cutsceneId = id;
        cutscenes[id].SetActive(true);
        gameManager.gameState = GameState.Cutscene;
        if (cutsceneTeleportPos[id] != null)
        {
            teleportDelay = cutscenes[id].GetComponent<CutsceneController>().fadeInOutDuration;
            StartCoroutine(TeleportPlayer());
        }
    }

    private IEnumerator TeleportPlayer()
    {
        yield return new WaitForSeconds(teleportDelay);
        player.transform.position = cutsceneTeleportPos[cutsceneId].position;
    }
}
