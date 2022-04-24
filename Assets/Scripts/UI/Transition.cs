using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TransitionMode
{
    Open,
    Close
}

[RequireComponent(typeof(Animator))]
public class Transition : MonoBehaviour
{
    public string TransitionName { get { return transitionName; } set { transitionName = value; } }
    [SerializeField]
    private TransitionMode mode;
    [SerializeField]
    private string transitionName;

    private Animator _animator;

    private bool _isPlaying = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayTransition(Action OnTransitionComplete)
    {
        if (_isPlaying)
            return;

        _isPlaying = true;

        string clip = "";
        if(TransitionMode.Open == mode)
        {
            clip = "Open";
        }
        else
        {
            clip = "Close";
        }
        _animator.Play(clip);
        StartCoroutine(COWaitForAnimatorLoadingTime(OnTransitionComplete));
    }

    private IEnumerator COWaitForAnimatorLoadingTime(Action Callback)
    {
        yield return new WaitForEndOfFrame(); // Needed clip info after play loaded in the next frame
        StartCoroutine(COWaitForAnimationEnd(_animator.GetCurrentAnimatorStateInfo(0).length, Callback));
    }

    private IEnumerator COWaitForAnimationEnd(float delay, Action Callback)
    {
        yield return new WaitForSeconds(delay);
        Callback?.Invoke();
    }
}
