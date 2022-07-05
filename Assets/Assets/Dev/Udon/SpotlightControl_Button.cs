
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SpotlightControl_Button : UdonSharpBehaviour
{
    public GameObject[] light;
    public int lightPool;

    public bool isOn = true;

    [UdonSynced, SerializeField] bool netWorkBool;


    public override void Interact()
    {
        for(int i = 0; i < lightPool; ++i)
        {
            bool unaryNegation = !light[i].activeSelf;
            light[i].SetActive(unaryNegation);
        }
        netWorkBool = light[0].activeSelf;
        if (isOn)
        {
            isOn = !isOn;
            gameObject.GetComponent<MeshRenderer>().materials[0].color = Color.gray;
        }
        else
        {
            isOn = !isOn;
            gameObject.GetComponent<MeshRenderer>().materials[0].color = new Color(0, 180 / 255f, 0);
        }
        
        RequestSerialization();
    }
    public override void OnDeserialization()
    {
        for(int i = 0; i < lightPool; ++i)
        {
            light[i].SetActive(netWorkBool);
        }
    }
}
