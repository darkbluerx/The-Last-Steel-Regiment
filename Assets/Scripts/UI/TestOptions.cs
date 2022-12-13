using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class TestOptions : MonoBehaviour
{
    //https://loglog.games/blog/unity-ui-toolkit-first-steps/ malli

    VisualElement root;
    public Slider contrastSlider;
    ColorAdjustments colorAdjustments;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        contrastSlider = root.Q<Slider>("ConstractSlider");
        //if (profile.TryGet<ColorAdjustments>(out var tmp))
        //{
        //    colorAdjustments = tmp;
        //}
    }

 

    void Update()
    {
        
       
    }

    public void SetContrast() //pystyt‰‰n s‰‰t‰m‰‰n kontrastia
    {
        colorAdjustments.contrast.value = contrastSlider.value;
        PlayerPrefs.SetFloat("ConstractSlider", contrastSlider.value);
    }

}
