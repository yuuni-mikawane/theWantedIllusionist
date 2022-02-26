using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    private GameController gameController;
    private FocalSpell focalSpell;
    [SerializeField] private int id;
    private PlayerStats player;

    private void Start()
    {
        gameController = GameController.Instance;
        focalSpell = FocalSpell.Instance;
        player = PlayerStats.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == (int)LayerInGame.Player)
        {
            gameController.TriggerCutscene(id);
            focalSpell.TurnOff();
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.SetActive(false);
        }
    }
}
