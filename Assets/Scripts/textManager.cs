using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextAsset textfile;
    private bool finish;
    List<string> textList = new List<string>();
    public int index;
    bool textFinish;
    public Text textLabel;
    void Start()
    {
        fileReader(textfile);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && index == textList.Count)
        {
            
            this.gameObject.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0) && textFinish && finish == false)
        {
            StartCoroutine(SetTextUI());
        }
    }

    void fileReader(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineData = file.text.Split('\n');

        foreach (var line in lineData)
        {
            textList.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        for (int i = 0; i < textList[index].Length; i++)
        {
            textLabel.text += textList[index][i];
            yield return new WaitForSeconds(0.01f);

        }
        textFinish = true;
        index++;

    }
}


