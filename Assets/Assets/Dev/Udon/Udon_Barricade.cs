
using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Udon_Barricade : UdonSharpBehaviour
{
    public GameObject barricade_mesh;
    [UdonSynced, SerializeField] bool netWorkBool = true;

    public override void Interact()
    {
        if (Networking.IsMaster)
        {
            barricade_mesh.SetActive(!barricade_mesh.activeInHierarchy);
            netWorkBool = barricade_mesh.activeInHierarchy;
            RequestSerialization();
        }
    }

    public override void OnDeserialization()
    {
        barricade_mesh.SetActive(netWorkBool);
    }

}
