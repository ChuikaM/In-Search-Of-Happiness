using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static List<EffectManager> instances = new List<EffectManager>();
    public string EffectAnimation;

    public static Animator animator;

    private void OnEnable()
    {
        instances.Clear();
        instances.AddRange(GameObject.FindObjectsOfType<EffectManager>());
    }

    private void OnLevelWasLoaded(int level)
    {
        instances.Clear();
        instances.AddRange(GameObject.FindObjectsOfType<EffectManager>());
    }

    public static void PlayEffect(string name)
    {
        
        foreach (var effect in instances)
        {
            if(effect.gameObject.name == name)
            {
                if (animator != null && !isPlaying(animator, effect.EffectAnimation))
                {
                    ResetAnimtion(effect.EffectAnimation);
                }
                animator = effect.GetComponent<Animator>();
                animator.Play(effect.EffectAnimation);           
            }
        }
    }

    public static void DestroyHUDEffects()
    {
        UnDestroyableObject.DestoyObjectByName("HUD Effects");
    }
    
    public static void ResetAnimtion(string name)
    {
        foreach (var effect in instances)
        {
            if (effect.gameObject.name == name)
            {
                animator = effect.GetComponent<Animator>();
                animator.Play(name, 0, -1);
            }
        }
    }

    private static bool isPlaying(Animator anim, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
                anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }
}
