
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SpotSlider_SpotOn : UdonSharpBehaviour
{
    public Animator anim;
    [UdonSynced, SerializeField] bool netWorkBool = false;

    public override void Interact()
    {
        bool unaryNegation = !anim.GetBool("SpotOn");
        anim.SetBool("SpotOn", unaryNegation);
        netWorkBool = unaryNegation;

        RequestSerialization();
    }

    public override void OnDeserialization()
    {
        anim.SetBool("SpotOn", netWorkBool);
    }
}
