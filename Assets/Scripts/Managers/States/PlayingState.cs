using Player;
using System;
using UnityEngine;

public class PlayingState : State
{
    [SerializeField] PlayerMovement player;
    public override void EnterState() {

    }

    public override void UpdateState() {
        player.UpdatePlayer();
    }
    public override void ExitState() {

    }
}
