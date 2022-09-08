using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DirectoryManager : MonoBehaviour
{
    private static DirectoryManager _instance;
    public static DirectoryManager instance { get { return _instance; } }

    int numofsystems;

    public GameObject SystemmenuPosition;
    public GameObject SystemBtnPrefab;
    public List<string> SystemNames;
    public List<RectTransform> SystemsUI;

    public ScrollRect scrollRect;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

    }
    private void Update()
    {
       
        SpawnSystemUI();

    }

    public void SpawnSystemUI()
    {
        string root = Application.persistentDataPath;

        // Get all subdirectories
        string[] subdirectoryEntries = Directory.GetDirectories(root);
        // Loop through them to see if they have any other subdirectories
        numofsystems = subdirectoryEntries.Length;

        foreach (string subdirectory in subdirectoryEntries)
        {
            //Debug.Log(subdirectory.ToString().Split('\\'));
            if (SystemNames.Contains(subdirectory.Split('.').Last()))
            {
                //It does
            }
            else
            {
                SystemNames.Add(subdirectory.Split('.').Last());
               
                GameObject go = (GameObject)Instantiate(SystemBtnPrefab);
                  //SystemsUI.Add(go.GetComponent<RectTransform>());
                go.name = subdirectory.Split('.').Last();
                go.GetComponentInChildren<Text>().text = subdirectory.Split('.').Last();
                go.transform.parent = SystemmenuPosition.gameObject.transform;
                go.GetComponent<RectTransform>().transform.position = SystemmenuPosition.gameObject.transform.position;
                go.GetComponent<PropogateDrag>().scrollView = scrollRect;


                //It not does
            }

            Debug.Log(subdirectory.Split('.').Last());
        }
        Debug.Log("Numbers of systems" + numofsystems);
      


    }
}
