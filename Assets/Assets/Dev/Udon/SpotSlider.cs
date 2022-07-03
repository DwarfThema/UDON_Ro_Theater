
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class SpotSlider : UdonSharpBehaviour
{
    public Animator spotAnim;
    public string SpotLightParam;
    public Slider slider;
    [UdonSynced, SerializeField] float sliderValue;

    public void spotSlider()
    {
        spotAnim.SetFloat(SpotLightParam, slider.value);
        sliderValue = slider.value;
        RequestSerialization();
    }

    public override void OnDeserialization()
    {
        slider.value = sliderValue;
    }

}
