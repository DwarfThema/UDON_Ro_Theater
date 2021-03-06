
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class SpotSlider_cen : UdonSharpBehaviour
{
    public Animator[] spotAnim;
    public int poolSize = 4;

    public string SpotLightParam;
    public Slider slider;
    [UdonSynced, SerializeField] float sliderValue;

    public void Start()
    {
        slider.value = 0.5f;
    }

    public void spotSlider_cen()
    {
        for (int i = 0; i < poolSize; ++i)
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
