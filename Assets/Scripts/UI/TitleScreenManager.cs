using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TitleScreenManager : VisualElement
{
    VisualElement m_MainMenuScreen;
    VisualElement m_OptionsScreen;

    string m_SceneName = "Game";

   public new class UxmlFactory: UxmlFactory<TitleScreenManager, UxmlTraits> { }

    public new class UxmlTraits: VisualElement.UxmlTraits
    {
        UxmlStringAttributeDescription m_StartScene = new UxmlStringAttributeDescription { name = "start-scene", defaultValue = "Game" };

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            var sceneName = m_StartScene.GetValueFromBag(bag, cc);

            ((TitleScreenManager)ve).Init(sceneName);
        }
    }

    public TitleScreenManager()
    {
        this.RegisterCallback<GeometryChangedEvent> (OnGeometryChange);
    }

    void OnGeometryChange (GeometryChangedEvent evt)
    {
        m_MainMenuScreen = this.Q("MainMenuScreen");
        m_OptionsScreen = this.Q("OptionsScreen");

        m_MainMenuScreen?.Q("start-button")?.RegisterCallback<ClickEvent>(ev => StartGame());
        m_MainMenuScreen?.Q("options-button")?.RegisterCallback<ClickEvent>(ev => EnableOptionsScreen());

        m_OptionsScreen?.Q("back-button")?.RegisterCallback<ClickEvent>(ev => EnableTitleScreen());

        //add quit button

        this.UnregisterCallback<GeometryChangedEvent>(OnGeometryChange);
    }

    void EnableTitleScreen()
    {
        m_MainMenuScreen.style.display = DisplayStyle.Flex;
        m_OptionsScreen.style.display = DisplayStyle.None;
    }

    void EnableOptionsScreen()
    {
        m_MainMenuScreen.style.display = DisplayStyle.None;
        m_OptionsScreen.style.display = DisplayStyle.Flex;
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
