using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

using Firefighter.Scenes;

public class StageSelect : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public SceneLoader sceneLoader;
    private string selectedStage = "Track 0";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadTargetScene()
    {
        sceneLoader.LoadSpecificScene(MapSelectedToScene());
    }

    public void SetSelectedStage()
    {
        selectedStage = dropdown.captionText.text;
    }

    public string GetSelectedStage()
    {
        return selectedStage;
    }

    public string GetSelectedScene()
    {
        return MapSelectedToScene();
    }

    private string MapSelectedToScene()
    {
        if (selectedStage == "Track 0")
        {
            return "Stage0";
        }
        else if (selectedStage == "Track 1")
        {
            return "Stage2";
        }
        else
        {
            return "Stage3";
        }
    }
}
