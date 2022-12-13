using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class GameUi : MonoBehaviour
{
    //tiedot voitaisiin myˆhemmin hakea gunScirtableobjektista suoraan;

    [Header("InGameUi UIDocument")]
    [SerializeField] UIDocument m_UIDocument;
    [Space]

    [Header("AmmoNumber? VisualElement")]
    VisualElement container; //haetaan InGameUi.uxml
    [Space]

    [Header("Gun/Ammo")]
    Label gunName;
    Label currentAmmo;
    VisualElement gunPic;

    GunStatsSO gunStats; //t‰‰lt‰ saadaan currentAmmo

    private void Awake()
    {
        var rootElement = m_UIDocument.rootVisualElement;
    }


    void Start()
    {
        //viitataan/yhdistet‰‰n koodi ui-ikkunaan

        //yhdistet‰‰n Label/teksti (Label nimi = currentammo)
        currentAmmo = container.Q<Label>("currentammo");
    }

  
    void Update()
    {
        
    }


    private void UpdatecurrentAmmo(string ammoText) //vastaa yht‰ teht‰v‰‰
    {
       
        currentAmmo.text = ammoText;
    }
}
