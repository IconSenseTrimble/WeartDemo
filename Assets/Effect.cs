using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeArt.Components;
using WeArt.Core;

public class Effect : MonoBehaviour
{
    // Start is called before the first frame update
    public List<WeArtHapticObject> hapticobject;
    [SerializeField]
    private Force force;
    [SerializeField]
    private Temperature temperature;
    [SerializeField]
    private WeArt.Core.Texture texture;

    private WeArtTouchEffect _effect;

    public float PowerTime;
    public event Action PowerTimeUp;


    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
  
    }


    public void ApplyEffect()

    {
        _effect = new WeArtTouchEffect();

        _effect.Set(temperature, Force.Default, WeArt.Core.Texture.Default, new WeArtTouchEffect.WeArtImpactInfo()
        {
            Position = transform.position,
            Time = Time.time,
            Multiplier = WeArtConstants.defaultCollisionMultiplier
        });
       // GetComponent<WeArtTouchableObject>().enabled = false;
    

       Invoke(nameof(temp),0.5f);
       Invoke(nameof(RemoveEffect), PowerTime+0.5f);
    }
    void temp()
    {
        foreach (var item in hapticobject)
        {
            item.AddEffect(_effect);
        }
      
    }
    public void RemoveEffect()
    {
        foreach (var item in hapticobject)
        {
            item.RemoveEffect(_effect);
        }
        PowerTimeUp?.Invoke();
      
    }
}
