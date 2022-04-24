using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class TransitionManager : Singleton<TransitionManager>
{
    [SerializeField]
    private Transition[] transitions;

    [SerializeField]
    private bool playOnStart;
    [SerializeField]
    private string startTransitionName;

    private void Start()
    {
        if(playOnStart)
            PlayTransition(startTransitionName, ()=>{ ShareData.PreviousLevel = SceneManager.GetActiveScene().name; });
        PlayTransition("BattleToWorld", "BattleScene", () => { ShareData.PreviousLevel = SceneManager.GetActiveScene().name; });
    }

    public void PlayTransition(string name, Action OnTransitionComplete)
    {
        foreach(Transition transition in transitions)
        {
            if (transition.TransitionName.Equals(name))
            {
                transition.PlayTransition(OnTransitionComplete);
                break;
            }
        }
    }

    private void PlayTransition(string transitionName, string sceneName, Action OnTransitionComplete)
    {
        if (ShareData.PreviousLevel == null || ShareData.PreviousLevel.Equals(""))
            return;
        if (ShareData.PreviousLevel.Equals(sceneName))
        {
            PlayTransition(transitionName, OnTransitionComplete);
        }
    }
}
