using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : Singleton<TurnManager>
{
    [SerializeField]
    private GameObject menu;

    public enum TurnState { 
        WaitingPlayerInput,
        PlayerTurn,
        EnemyTurn,
        BattleEnd
    }

    public TurnState State { get; set; }

    protected override void Awake()
    {
        base.Awake();
        State = TurnState.WaitingPlayerInput;
    }

    private void Update()
    {
        Debug.Log("[TurnManager Update] Current State: " + State);
        if(State == TurnState.WaitingPlayerInput)
        {
            menu.SetActive(true);
        }
        else
        { 
            menu.SetActive(false);
        }
    }

    public void PlayerInputSelected()
    {
        State = TurnState.PlayerTurn;
        Debug.Log(State);
    }

    public void ChangeTurn()
    {
        if (State == TurnState.BattleEnd)
            return;
        if (State == TurnState.PlayerTurn)
            State = TurnState.EnemyTurn;
        else
            State = TurnState.WaitingPlayerInput;
    }

    public void BattleEnd()
    {
        State = TurnState.BattleEnd;
    }
}
