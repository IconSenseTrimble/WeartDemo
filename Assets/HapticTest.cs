using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeArt.Components;
using WeArt.Core;

public class HapticTest : MonoBehaviour
{
    // Start is called before the first frame update

    public WeArtHapticObject actuator;
    private WeArtTouchEffect effect;
    void Start()
    {

    }

    private void Actuator_OnActiveEffectsUpdate()
    {
        Debug.Log("Event invoked");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ApplyEffect();
            Debug.Log("space presed");
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            actuator.RemoveEffect(effect);
        }
    }

    void ApplyEffect()
    {
         effect = new WeArtTouchEffect();

        Temperature temperature = Temperature.Default;
        temperature.Active = true; //you have to active 
        temperature.Value = 1f; //hot

        // create force component
        Force force = Force.Default;
        force.Active = true;
        force.Value = 1f;

        effect.Set(temperature, force, WeArt.Core.Texture.Default, new WeArtTouchEffect.WeArtImpactInfo()
        {
            Position = transform.position,
            Time = Time.time,
            Multiplier = WeArtConstants.defaultCollisionMultiplier
        });

       
         
            actuator.AddEffect(effect);
        
      

    }
}
