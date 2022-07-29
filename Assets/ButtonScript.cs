using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public TMP_InputField iField;
    private string folderPath;
    public RawImage r;

    private string fileName;


    private void Awake()
    {
        folderPath = iField.text;
        fileName = transform.GetChild(0).GetComponent<TMP_Text>().text;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Do something.
        //Debug.Log("<color=red>Event:</color> Completed mouse highlight.");



        DirectoryInfo d = new DirectoryInfo(folderPath);

        FileInfo[] fis = d.GetFiles();

        byte[] fileData;
       

        fileData = File.ReadAllBytes(folderPath + "/" + fileName);

        Texture2D tex = null;

        tex = new Texture2D(2, 2);

        tex.LoadImage(fileData);

        r.texture = tex;

    }




    bool isSelected = false;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("<color=yellow>Event:</color> Clicked");

        if (!isSelected)
        {
            isSelected = true;

            GetComponent<Image>().color = Color.red;

            FileManager.fileToRemove.Add(fileName);

            FileManager.buttonToRemove.Add(gameObject);
        }
        else
        {
            isSelected = false;

            GetComponent<Image>().color = Color.white;

            FileManager.fileToRemove.Remove(fileName);

            FileManager.buttonToRemove.Remove(gameObject);
        }
      
    }
}
