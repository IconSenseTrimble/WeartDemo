using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeArt.Components;
using WeArt.Core;
public class PowerUp : MonoBehaviour
{
    public WeArtHandController rightHand;
    public GameObject FireEffect;
    public Transform Target;
    private bool used = false;
    private GameObject eff;
    private void Awake()
    {
        rightHand.OnGraspingEvent += GraspHandler;
        GetComponent<Effect>().PowerTimeUp += PowerUp_PowerTimeUp;
    }

    private void PowerUp_PowerTimeUp()
    {
       Destroy(eff); eff = null;
    }

    void GraspHandler(HandSide handSide, GameObject go)
    {
        if(!used) {

            if (go == this.gameObject)
            {


                // Calculate the rotation to align the Y axis of fireeffect with the Z axis of Indexfinger
                Quaternion targetRotation = Quaternion.FromToRotation(Vector3.up, Target.TransformDirection(Vector3.forward));

                // Instantiate the fireeffect
                eff = Instantiate(FireEffect, Target.position, targetRotation, Target);



                GetComponent<Effect>().ApplyEffect();

                used = true;

                gameObject.SetActive(false);
            }
        }
    }


   
}
