using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using StateMachine;
using DG.Tweening;
using System;

namespace Boss
{
  public enum BossAction
  {
     INIT,
     IDLE,
     WALK,
     ATTACK,
     DEATH
  }

  public class BossBase : MonoBehaviour
  {
    [Header("Animation")]
    public float startAnimationDuration = .5f;
    public Ease startAnimationEase= Ease.OutBack;

    [Header("Attack")]
    public int attackAmount = 5;
    public float timeBetweenAttacks = .5f;

    public float speed = 5f;
    public List<Transform> waypoints;

     [Header("Health")]
     public HealthBase healthBase;

    private StateMachine<BossAction> stateMachine;

    private void OnValidate() 
    {
        if(healthBase == null) healthBase = GetComponent<HealthBase>();
    }

    private void Awake()
    {
      Init();
      OnValidate();
      if(healthBase != null) 
      {
        healthBase.OnKill += OnBossKill;
      }
    }

    private void Init()
    {
      stateMachine = new StateMachine<BossAction>();
      stateMachine.Init();

      stateMachine.RegisterStates(BossAction.INIT, new BossStateInit());
      stateMachine.RegisterStates(BossAction.WALK, new BossStateWalk());
      stateMachine.RegisterStates(BossAction.ATTACK, new BossStateAttack());
      stateMachine.RegisterStates(BossAction.DEATH, new BossStateDeath());

    }

    private void OnBossKill (HealthBase h) 
    {
      SwitchState(BossAction.DEATH);
    }

    #region ATTACK
    public void StartAttack(Action endCallBack = null)
    {
       StartCoroutine(AttackCoroutine(endCallBack));
    }

    IEnumerator AttackCoroutine(Action endCallBack)
    {
      int attacks = 0;
      while(attacks < attackAmount) 
      {
        attacks++;
        transform.DOScale(1.1f, .1f).SetLoops(2, LoopType.Yoyo);
        yield return new WaitForSeconds(timeBetweenAttacks);
      }

      if(endCallBack != null) endCallBack.Invoke();
    }
    #endregion

    #region WALK
    public void GoToRandomPoint(Action onArrive = null)
    {
       StartCoroutine(GoToPointCoroutine(waypoints[UnityEngine.Random.Range(0,waypoints.Count)], onArrive));
    }

    IEnumerator GoToPointCoroutine(Transform t, Action onArrive = null)
    {
      while(Vector3.Distance(transform.position, t.position) > 1f)
      {
        transform.position = Vector3.MoveTowards(transform.position, t.position, Time.deltaTime * speed);
        yield return new WaitForEndOfFrame();
      }
      if(onArrive != null) onArrive.Invoke();
    }
    #endregion

    #region ANIMATION
    public void StartInitAnimation()
    {
      transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();
    }
    #endregion

    #region DEBUG
    [NaughtyAttributes.Button]
    public void SwitchInit()
    {
       SwitchState(BossAction.INIT);
    }
    [NaughtyAttributes.Button]
    public void SwitchWalk()
    {
       SwitchState(BossAction.WALK);
    }
    [NaughtyAttributes.Button]
    public void SwitchAttack()
    {
       SwitchState(BossAction.ATTACK);
    }
    #endregion

    #region STATE MACHINE
    public void SwitchState(BossAction state)
    {
       stateMachine.SwitchState(state, this);
    }
    #endregion
  }
    
}
