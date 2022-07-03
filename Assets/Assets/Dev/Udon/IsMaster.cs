
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class IsMaster : UdonSharpBehaviour
{
    public int heightPos = 1;

    void Start()
    {
        if (Networking.IsMaster)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Networking.IsMaster)
        {
            VRCPlayerApi.TrackingData tData = Networking.LocalPlayer.GetTrackingData(VRCPlayerApi.TrackingDataType.Head);
            transform.position = new Vector3(tData.position.x, tData.position.y + heightPos, tData.position.z);
        }
    }
}
