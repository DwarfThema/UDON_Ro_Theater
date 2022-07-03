
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class SpotSlider : UdonSharpBehaviour
{
    public Animator[] spotAnim;
    public int poolSize = 10;

    public string SpotLightParam;
    public Slider slider;
    [UdonSynced, SerializeField] float sliderValue;

    public void spotSlider()
    {
        for(int i = 0; i <poolSize; ++i)
        {
            spotAnim[i].SetFloat(SpotLightParam, slider.value);
        }
        sliderValue = slider.value;
        RequestSerialization();
    }

    public override void OnDeserialization()
    {
        slider.value = sliderValue;
    }

}
