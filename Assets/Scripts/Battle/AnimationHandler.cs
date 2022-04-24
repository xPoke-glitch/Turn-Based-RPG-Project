using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimationHandler : MonoBehaviour
{
    private Animator _animator;

    void Awake  ()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void PlayActionAnimation(IBattleCharacter target, string actionAnimation, Action OnAnimationComplete)
    {
        if (actionAnimation.ToLower().Equals("attack"))
        {
            _animator.Play("Base Layer.attack");
            StartCoroutine(WaitForAnimationEnd(_animator.GetCurrentAnimatorStateInfo(0).length, OnAnimationComplete));
        } 
        else if (actionAnimation.ToLower().Equals("defend"))
        {
            _animator.Play("Base Layer.defend");
            StartCoroutine(WaitForAnimationEnd(_animator.GetCurrentAnimatorStateInfo(0).length, OnAnimationComplete));
        }
        else
        {
            foreach (AbilityData ability in target.Data.abilities)
            {
                if (ability.Name.ToLower().Equals(actionAnimation.ToLower()))
                {
                    _animator.Play("Base Layer."+ability.AnimationName.ToLower());
                    StartCoroutine(WaitForAnimationEnd(_animator.GetCurrentAnimatorStateInfo(0).length, OnAnimationComplete));
                }
            }
        }
    }

    public void PlayAnimationByName(string name)
    {
        _animator.Play("Base Layer." + name.ToLower());
    }

    public void PlayAnimationByName(string name, Action OnAnimationComplete)
    {
        _animator.Play("Base Layer." + name.ToLower());
        StartCoroutine(WaitForAnimationEnd(_animator.GetCurrentAnimatorStateInfo(0).length, OnAnimationComplete));
    }

    private IEnumerator WaitForAnimationEnd(float delay, Action Callback)
    {
        yield return new WaitForSeconds(delay);
        Callback?.Invoke();
    }
}
