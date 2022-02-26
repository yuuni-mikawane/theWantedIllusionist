using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    private GameController gameController;
    private FocalSpell focalSpell;
    [SerializeField] private int id;

    private void Start()
    {
        gameController = GameController.Instance;
        focalSpell = FocalSpell.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == (int)LayerInGame.Player)
        {
            gameController.TriggerCutscene(id);
            focalSpell.TurnOff();
            gameObject.SetActive(false);
        }
    }
}
