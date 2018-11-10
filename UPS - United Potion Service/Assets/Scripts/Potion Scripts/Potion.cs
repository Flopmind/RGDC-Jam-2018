using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Potion : MonoBehaviour 
{
	[SerializeField]
	protected float timeUntilEffect = 1;
    [SerializeField]
    protected PotionEffect myEffect = null;

	protected IEnumerator WaitUntilEffect()
	{
		yield return new WaitForSeconds(timeUntilEffect);
		TriggerEffect();
	}

    protected virtual void PotionStart()
    {
        //print("If an error is after this, fix potion start");
        if (myEffect != null)
        {
            myEffect = GetComponent<PotionEffect>();
        }
    }

    protected abstract void TriggerEffect();
}
