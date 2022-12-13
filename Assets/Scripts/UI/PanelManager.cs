using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    //https://docs.unity3d.com/2022.2/Documentation/Manual/UIE-HowTo-CreateRuntimeUI.html
    //https://docs.unity3d.com/2022.2/Documentation/Manual/UIE-UXML.html

    //[SerializeField] VisualTreeAsset MainMenuScreen;

    public Button startButton;
    public Button optionsButton;
    public Button quitButton;

    void Start()
    {
      var root = GetComponent<UIDocument>().rootVisualElement;

        startButton = root.Q<Button>("start-button");
        optionsButton = root.Q<Button>("options-button");
        quitButton = root.Q<Button>("quit-button");

        startButton.clicked += startGameButtonPressed;
        optionsButton.clicked += optionsButtonPressed;
        quitButton.clicked += quitButtonPressed;
    }

    void startGameButtonPressed()
    {
        SceneManager.LoadScene("Game");
    }

    //luultavasti tehd‰‰n eritavalla -> uibuilder
    void optionsButtonPressed()
    {
        SceneManager.LoadScene("Options");
    }

    void quitButtonPressed()
    {
        Debug.Log("RageQuit");
        Application.Quit();
    }

    private void OnEnable()
    {
        

        //n‰ytet‰‰n t‰ss‰ peli-ikkunan toimintoja
        //var ui = new UI();
        
    }


   
}
