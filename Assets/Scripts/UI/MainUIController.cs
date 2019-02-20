using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class MainUIController : MonoBehaviour
{
    public Dropdown sceneDropdown;

    private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        var optionDatas = new List<Dropdown.OptionData>();
        for( int i = 1; i < SceneManager.sceneCountInBuildSettings; ++i)
        {
            string path = SceneUtility.GetScenePathByBuildIndex(i);
            FileInfo file = new FileInfo(path);

            var v = file.Name.Split('.');
            var data = new Dropdown.OptionData(v[0]);
            optionDatas.Add(data);
        }

        if (optionDatas.Count > 0)
        {
            sceneName = optionDatas[0].text;
            sceneDropdown.AddOptions(optionDatas);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onDropdownValueChanged(Text Label)
    {
        sceneName = Label.text;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
