using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MonsterAnimation : MonoBehaviour
{
    [SerializeField] Animator MonsterAnimator;
    void Start()
    {
        MonsterAnimator = this.gameObject.GetComponent<Animator>();
        MonsterAnimated1();
    }
    void MonsterAnimated1()
    {
        FindPathNode Monsteanimated1 = GetComponentInParent<FindPathNode>();
        Monsteanimated1.monsteranimationevent(Setanimation1);
    }
    void Setanimation1(int AnimationID)
    {
        MonsterAnimator.SetInteger("EMAnimationID",AnimationID);
    }
    void MonsterAnimated2()
    {
        DistractedMode Monsteanimated1 = GetComponentInParent<DistractedMode>();
        Monsteanimated1.monsteranimationevent(Setanimation1);
    }
    void Setanimation2(int AnimationID)
    {
        MonsterAnimator.SetInteger("EMAnimationID",AnimationID);
    }
    void MonsterAnimated3()
    {
        ChaseNode Monsteanimated1 = GetComponentInParent<ChaseNode>();
        Monsteanimated1.monsteranimationevent(Setanimation1);
    }
    void Setanimation3(int AnimationID)
    {
        MonsterAnimator.SetInteger("EMAnimationID",AnimationID);
    }
}
