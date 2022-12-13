using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Test2 : VisualElement
{
    //https://loglog.games/blog/unity-ui-toolkit-first-steps/ malli

    public new class UxmlFactory : UxmlFactory<Test2, UxmlTraits> { }

    
    private SliderInt speedSlider;
   

    VisualElement root;
    public Slider contrastSlider;
    ColorAdjustments colorAdjustments;

    //void Start()
    //{
    //    var root = GetComponent<UIDocument>().rootVisualElement;

    //    contrastSlider = root.Q<Slider>("ConstractSlider");
    //}

    public Test2()
    {
        this.RegisterCallback<GeometryChangedEvent>(OnGeometryChange);
    }

    //void Update()
    //{

    //    colorAdjustments.contrast.value = contrastSlider.value;
    //    PlayerPrefs.SetFloat("ConstractSlider", contrastSlider.value);
    //}

    void OnGeometryChange(GeometryChangedEvent evt)
    {
        speedSlider = this.Q<SliderInt>("ConstractSlider");
        
            speedSlider.RegisterValueChangedCallback(e => OnSpeedSliderChanged(e.newValue));
        
        this.UnregisterCallback<GeometryChangedEvent>(OnGeometryChange);
    }

    private void OnSpeedSliderChanged(int value)
    {
        
        Time.timeScale = value;
    }

}
