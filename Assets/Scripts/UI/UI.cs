using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//https://blog.unity.com/technology/ui-toolkit-at-runtime-get-the-breakdown
[RequireComponent(typeof(UIDocument))]
public class UI : MonoBehaviour
{
    //katso mallia UiToolkitUnityRoyaleRuntime

    [SerializeField] UIDocument m_UIDocument;

    Label ammoText;

    GunStatsSO gunStats;
    
    int ammo =0;

    private void Awake()
    {
        var rootElement = m_UIDocument.rootVisualElement;
      
        //var root = GetComponent<UIDocument>().rootVisualElement;
        ammoText = rootElement.Q<Label>("Ammo");
        ammoText.text = ammo.ToString();
    }
    private void Start()
    {
        UpdateAmmo();
    }

    void Update()
    {
        UpdateAmmo();
    }

    public void InitializePlayerData(VisualElement root, VisualTreeAsset listElementTemplate)
    {
        //
    }

    private void UpdateAmmo()
    {
        ammoText.text = ammo.ToString();
    }

}
