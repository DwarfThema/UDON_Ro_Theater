
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SpotlightControl_Button : UdonSharpBehaviour
{
    public Animator[] anim;

    public int poolSize = 18;

    [UdonSynced, SerializeField] bool netWorkBool = true;


    public override void Interact()
    {
        for (int i = 0; i < poolSize; ++i)
        {
            bool unaryNegation = !anim[i].GetBool("SpotLightToggle");
            anim[i].SetBool("SpotLightToggle", unaryNegation);
            netWorkBool = unaryNegation;
        }
        
        RequestSerialization();
    }
    public override void OnDeserialization()
    {
        for (int i = 0; i < poolSize; ++i)
        {
            anim[i].SetBool("SpotLightToggle", netWorkBool);
        }
    }
}
