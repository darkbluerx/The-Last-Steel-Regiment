using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIManager : VisualElement
{
    VisualElement m_MainMenuScreen;
    VisualElement credits;

    string m_SceneName = "TestMap";

    public new class UxmlFactory : UxmlFactory<TitleScreenManager, UxmlTraits> { }

    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        UxmlStringAttributeDescription m_StartScene = new UxmlStringAttributeDescription { name = "start-scene", defaultValue = "TestMap" };

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            var sceneName = m_StartScene.GetValueFromBag(bag, cc);

            ((UIManager)ve).Init(sceneName);
        }
    }

    public UIManager()
    {
        this.RegisterCallback<GeometryChangedEvent>(OnGeometryChange);
    }

    void OnGeometryChange(GeometryChangedEvent evt)
    {
        m_MainMenuScreen = this.Q("Buttons");
        credits = this.Q("Credits");

        m_MainMenuScreen?.Q("PlayButton")?.RegisterCallback<ClickEvent>(ev => StartGame());
        m_MainMenuScreen?.Q("CreditsButton")?.RegisterCallback<ClickEvent>(ev => EnableOptionsScreen());

        credits?.Q("BackButtonC")?.RegisterCallback<ClickEvent>(ev => EnableTitleScreen());

        //lis‰‰ quit button

        this.UnregisterCallback<GeometryChangedEvent>(OnGeometryChange);
    }

    void EnableTitleScreen()
    {
        m_MainMenuScreen.style.display = DisplayStyle.Flex;
        credits.style.display = DisplayStyle.None;
    }

    void EnableOptionsScreen()
    {
        m_MainMenuScreen.style.display = DisplayStyle.None;
        credits.style.display = DisplayStyle.Flex;
    }

    void StartGame()
    {
        //#if UNITY_EDITOR
        if (Application.isPlaying)
            //#endif
            SceneManager.LoadSceneAsync(m_SceneName);
        //#if UNITY_EDITOR
        else Debug.Log("Loading: " + m_SceneName);
        //#endif
    }

    void Init(string sceneName)
    {
        m_SceneName = sceneName;
    }
}


