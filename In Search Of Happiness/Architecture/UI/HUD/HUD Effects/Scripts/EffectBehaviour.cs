using UnityEngine;

public class EffectBehaviour : MonoBehaviour
{
    public void DestroyHUDEffectsAnimation()
    {
        EffectManager.DestroyHUDEffects();
    }
    
    public void ResetAnimtion(string name)
    {
        EffectManager.ResetAnimtion(name);
    }

    public void DisappearMenu(string name)
    {
        HUDMenuManager.SetActiveMenu(name, false);
    }
}
