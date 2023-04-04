using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Assertions;

namespace UI
{
    public class MenuController : MonoBehaviour
    {
        [Header("Mute Button")]
        [SerializeField] Sprite mutedSprite;
        [SerializeField] Sprite unmutedSprite;
        bool muted;

        [Header("Settings")]
        [SerializeField] VisualTreeAsset settingsButtonsTemplate;
        VisualElement settingButtons;
        VisualElement buttonsWrapper;

        [Header("Credits")]
        [SerializeField] VisualTreeAsset creditsButtonTemplate;
        VisualElement creditsButtons;
        VisualElement creditsWrapper; 

        UIDocument doc;
        Button playButton;
        Button settingsButton;
        Button creditsButton;
        Button exitButton;
        Button muteButton;  

        private void Awake()
        {
            doc = GetComponent<UIDocument>();

            playButton= doc.rootVisualElement.Q<Button>("PlayButton");

            settingsButton = doc.rootVisualElement.Q<Button>("SettingsButton");       
            buttonsWrapper = doc.rootVisualElement.Q<VisualElement>("Buttons");

            creditsButton = doc.rootVisualElement.Q<Button>("CreditsButton");
            creditsWrapper = doc.rootVisualElement.Q<VisualElement>("Credits");
            //Assert.IsNotNull(creditsWrapper);

            exitButton = doc.rootVisualElement.Q<Button>("ExitButton");
            muteButton = doc.rootVisualElement.Q<Button>("MuteButton");

            playButton.clicked += PlayButtonOnClicked;
            settingsButton.clicked += SettingsButtonOnClicked;
            creditsButton.clicked += CreditsButtonOnClicked;
            exitButton.clicked += ExitButtonOnClicked;
            muteButton.clicked += MuteButtonOnClicked;

            creditsButtons = creditsButtonTemplate.CloneTree();
            var backButtonCredits = creditsButtons.Q<Button>("BackButtonCredits");

            backButtonCredits.clicked += BackButtonsOnClicked2;

            settingButtons = settingsButtonsTemplate.CloneTree();
            var backButton = settingButtons.Q<Button>("BackButton");

            backButton.clicked += BackButtonsOnClicked;
           

        }

        private void BackButtonsOnClicked()
        {
            buttonsWrapper.Clear();
            buttonsWrapper.Add(playButton);
            buttonsWrapper.Add(settingsButton);
            buttonsWrapper.Add(creditsButton);
            buttonsWrapper.Add(exitButton);
        }

        private void BackButtonsOnClicked2()
        {
            creditsWrapper.Clear();
            creditsWrapper.Add(playButton);
            creditsWrapper.Add(settingsButton);
            creditsWrapper.Add(creditsButton);
            creditsWrapper.Add(exitButton);
        }

        private void MuteButtonOnClicked()
        {
            muted = !muted;
            var bg = muteButton.style.backgroundImage;
            bg.value = Background.FromSprite(muted ? mutedSprite : unmutedSprite);
            muteButton.style.backgroundImage = bg;
            AudioListener.volume = muted ? 1 : 0;
        }

        private void SettingsButtonOnClicked()
        {
            buttonsWrapper.Clear();
            buttonsWrapper.Add(settingButtons);
        }

        private void CreditsButtonOnClicked()
        {
            creditsWrapper.Clear();
            creditsWrapper.Add(creditsButtons);
        }

        private void ExitButtonOnClicked()
        {
            Application.Quit();
            Debug.Log("Quit Game!");
        }

        private void PlayButtonOnClicked()
        {
            SceneManager.LoadScene("TestMap");
        }
    }
}
