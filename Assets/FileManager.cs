using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FileManager : MonoBehaviour
{
    public static List<string> fileToRemove = new List<string>();
    public static List<GameObject> buttonToRemove = new List<GameObject>();

    public Dictionary<string, string> traitMap = new Dictionary<string, string>();


    public void UpdateToggle()
    {
        Debug.Log("TOSOTOTOT");
        reserveOriginalNameFile = toggleReserveOriginalData.isOn;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateToggle();
        toggleReserveOriginalData.onValueChanged.AddListener(delegate { UpdateToggle(); });

        buttonElement.SetActive(false);

        // background
        traitMap.Add("bg01", "gradation tan");
        traitMap.Add("bg02", "gradation lightgrey");
        traitMap.Add("bg03", "gradation lavenderblush");
        traitMap.Add("bg04", "gradation lightblue");
        traitMap.Add("bg05", "gradation thistle");
        traitMap.Add("bg06", "gradation mediumpurple");
        traitMap.Add("bg07", "gradation honeydew");
        traitMap.Add("bg08", "gradation peru");
        traitMap.Add("bg09", "gradation lightpink");
        traitMap.Add("bg10", "gradation lightcyan");

        traitMap.Add("smoke01", "smoke darkgoldenrod");
        traitMap.Add("smoke02", "smoke royalblue");
        traitMap.Add("smoke03", "smoke firebrick");
        traitMap.Add("smoke04", "smoke darkolivegreen");

        traitMap.Add("speed01", "speed mistyrose");
        traitMap.Add("speed02", "speed royalblue");
        traitMap.Add("speed03", "speed oldlace");
        traitMap.Add("speed04", "speed darkblue");

        traitMap.Add("car01", "car white");
        traitMap.Add("car02", "car dimgrey");
        traitMap.Add("car03", "car palevioletred");
        traitMap.Add("car04", "car mediumorchid");
        traitMap.Add("car05", "car mediumturquoise");
        traitMap.Add("car06", "car aqua");
        traitMap.Add("car07", "car burlywood");
        traitMap.Add("car08", "car plum");



        // halo
        traitMap.Add("hol00", "no halo");

        traitMap.Add("cir01", "circle azure");
        traitMap.Add("cir02", "circle violet ");
        traitMap.Add("cir03", "circle lemonchiffon");
        traitMap.Add("cir04", "circle palegreen");

        traitMap.Add("dia01", "diamond azure");
        traitMap.Add("dia02", "diamond violet ");
        traitMap.Add("dia03", "diamond lemonchiffon");
        traitMap.Add("dia04", "diamond palegreen");

        traitMap.Add("hex01", "hexagon azure");
        traitMap.Add("hex02", "hexagon violet ");
        traitMap.Add("hex03", "hexagon lemonchiffon");
        traitMap.Add("hex04", "hexagon palegreen");

        traitMap.Add("tri01", "triangle azure");
        traitMap.Add("tri02", "triangle violet ");
        traitMap.Add("tri03", "triangle lemonchiffon");
        traitMap.Add("tri04", "triangle palegreen");


        // cloth
        traitMap.Add("suit01", "suit red");
        traitMap.Add("suit02", "suit green");
        traitMap.Add("suit03", "suit blue");
        traitMap.Add("suit04", "suit mint");
        traitMap.Add("suit05", "suit yellow");
        traitMap.Add("suit06", "suit pink");
        traitMap.Add("suit07", "suit olive");
        traitMap.Add("suit08", "suit purple");
        traitMap.Add("suit09", "suit mediumblue");
        traitMap.Add("suit10", "suit deepskyblue");
        traitMap.Add("suit11", "suit darkseagreen");
        traitMap.Add("suit12", "suit indianred");
        traitMap.Add("suit13", "suit black");
        traitMap.Add("suit14", "suit white");

        traitMap.Add("rain01", "raincoat red");
        traitMap.Add("rain02", "raincoat green");
        traitMap.Add("rain03", "raincoat blue");
        traitMap.Add("rain04", "raincoat mint");
        traitMap.Add("rain05", "raincoat yellow");
        traitMap.Add("rain06", "raincoat pink");
        traitMap.Add("rain07", "raincoat olive");
        traitMap.Add("rain08", "raincoat purple");
        traitMap.Add("rain09", "raincoat mediumblue");
        traitMap.Add("rain10", "raincoat deepskyblue");
        traitMap.Add("rain11", "raincoat darkseagreen");
        traitMap.Add("rain12", "raincoat indianred");
        traitMap.Add("rain13", "raincoat black");
        traitMap.Add("rain14", "raincoat white");

        traitMap.Add("shirta01", "shirt A type black");
        traitMap.Add("shirta02", "shirt A type white");
        traitMap.Add("shirta03", "shirt A type red");
        traitMap.Add("shirta04", "shirt A type green");
        traitMap.Add("shirta05", "shirt A type purple");
        traitMap.Add("shirta06", "shirt A type mint");

        traitMap.Add("shirtb01", "shirt B type black");
        traitMap.Add("shirtb02", "shirt B type white");
        traitMap.Add("shirtb03", "shirt B type red");
        traitMap.Add("shirtb04", "shirt B type green");
        traitMap.Add("shirtb05", "shirt B type purple");
        traitMap.Add("shirtb06", "shirt B type mint");

        traitMap.Add("jaca01", "jacket grey");
        traitMap.Add("jaca02", "jacket black");
        traitMap.Add("jaca03", "jacket red");
        traitMap.Add("jaca04", "jacket green");
        traitMap.Add("jaca05", "jacket blue");
        traitMap.Add("jaca06", "jacket darkcyan");


        // badge
        traitMap.Add("bad00", "no badge");
        traitMap.Add("bad01", "B1");
        traitMap.Add("bad02", "B2");
        traitMap.Add("bad03", "B3");
        traitMap.Add("bad04", "B4");
        traitMap.Add("bad05", "E1");
        traitMap.Add("bad06", "E2");
        traitMap.Add("bad07", "E3");
        traitMap.Add("bad08", "E4");


        // emblem
        traitMap.Add("emb00", "no emblem");
        traitMap.Add("emb01", "aud");
        traitMap.Add("emb02", "bmw");
        traitMap.Add("emb03", "hyu");
        traitMap.Add("emb04", "jag");
        traitMap.Add("emb05", "kia");
        traitMap.Add("emb06", "lex");
        traitMap.Add("emb07", "mb");
        traitMap.Add("emb08", "pol");
        traitMap.Add("emb09", "por");
        traitMap.Add("emb10", "tes");
        traitMap.Add("emb11", "vol");


        // mos       
        traitMap.Add("mos01", "aud");
        traitMap.Add("mos02", "bmw");
        traitMap.Add("mos03", "hyu");
        traitMap.Add("mos04", "jag");
        traitMap.Add("mos05", "kia");
        traitMap.Add("mos06", "lex");
        traitMap.Add("mos07", "mb");
        traitMap.Add("mos08", "pol");
        traitMap.Add("mos09", "por");
        traitMap.Add("mos10", "tes");
        traitMap.Add("mos11", "vol");


        // coin
        traitMap.Add("coi00", "no coin");
        traitMap.Add("coi01", "ADA");
        traitMap.Add("coi02", "BTC");
        traitMap.Add("coi03", "DOGE");
        traitMap.Add("coi04", "DOT");
        traitMap.Add("coi05", "ETH");
        traitMap.Add("coi06", "SAND");
        traitMap.Add("coi07", "SOL");
        traitMap.Add("coi08", "SPGY");


        // hair
        traitMap.Add("hai00", "no hair");

        traitMap.Add("sho01", "short white");
        traitMap.Add("sho02", "short brown");
        traitMap.Add("sho03", "short red");
        traitMap.Add("sho04", "short green");
        traitMap.Add("sho05", "short blue");
        traitMap.Add("sho06", "short cyan");
        traitMap.Add("sho07", "short yellow");
        traitMap.Add("sho08", "short purple");

        traitMap.Add("mid01", "medium white");
        traitMap.Add("mid02", "medium brown");
        traitMap.Add("mid03", "medium red");
        traitMap.Add("mid04", "medium green");
        traitMap.Add("mid05", "medium blue");
        traitMap.Add("mid06", "medium cyan");
        traitMap.Add("mid07", "medium yellow");
        traitMap.Add("mid08", "medium purple");

        traitMap.Add("long01", "long white");
        traitMap.Add("long02", "long brown");
        traitMap.Add("long03", "long red");
        traitMap.Add("long04", "long green");
        traitMap.Add("long05", "long blue");
        traitMap.Add("long06", "long cyan");
        traitMap.Add("long07", "long yellow");
        traitMap.Add("long08", "long purple");


        // helmet
        traitMap.Add("hel00", "no helmet");

        traitMap.Add("hel01", "helmet red");
        traitMap.Add("hel02", "helmet green");
        traitMap.Add("hel03", "helmet blue");
        traitMap.Add("hel04", "helmet mint");
        traitMap.Add("hel05", "helmet yellow");
        traitMap.Add("hel06", "helmet pink");
        traitMap.Add("hel07", "helmet olive");
        traitMap.Add("hel08", "helmet purple");
        traitMap.Add("hel09", "helmet mediumblue");
        traitMap.Add("hel10", "helmet deepskyblue");
        traitMap.Add("hel11", "helmet darkseagreen");
        traitMap.Add("hel12", "helmet indianred");
        traitMap.Add("hel13", "helmet black");
        traitMap.Add("hel14", "helmet white");

        traitMap.Add("check01", "check helmet red");
        traitMap.Add("check02", "check helmet green");
        traitMap.Add("check03", "check helmet blue");
        traitMap.Add("check04", "check helmet mint");
        traitMap.Add("check05", "check helmet yellow");
        traitMap.Add("check06", "check helmet pink");
        traitMap.Add("check07", "check helmet olive");
        traitMap.Add("check08", "check helmet purple");
        traitMap.Add("check09", "check helmet mediumblue");
        traitMap.Add("check10", "check helmet deepskyblue");
        traitMap.Add("check11", "check helmet darkseagreen");
        traitMap.Add("check12", "check helmet indianred");
        traitMap.Add("check13", "check helmet black");
        traitMap.Add("check14", "check helmet white");

        traitMap.Add("decal01", "decal helmet red");
        traitMap.Add("decal02", "decal helmet green");
        traitMap.Add("decal03", "decal helmet blue");
        traitMap.Add("decal04", "decal helmet mint");
        traitMap.Add("decal05", "decal helmet yellow");
        traitMap.Add("decal06", "decal helmet pink");
        traitMap.Add("decal07", "decal helmet olive");
        traitMap.Add("decal08", "decal helmet purple");
        traitMap.Add("decal09", "decal helmet mediumblue");
        traitMap.Add("decal10", "decal helmet deepskyblue");
        traitMap.Add("decal11", "decal helmet darkseagreen");
        traitMap.Add("decal12", "decal helmet indianred");
        traitMap.Add("decal13", "decal helmet black");
        traitMap.Add("decal14", "decal helmet white");

        traitMap.Add("racing01", "racing helmet red");
        traitMap.Add("racing02", "racing helmet green");
        traitMap.Add("racing03", "racing helmet blue");
        traitMap.Add("racing04", "racing helmet mint");
        traitMap.Add("racing05", "racing helmet yellow");
        traitMap.Add("racing06", "racing helmet pink");
        traitMap.Add("racing07", "racing helmet olive");
        traitMap.Add("racing08", "racing helmet purple");
        traitMap.Add("racing09", "racing helmet mediumblue");
        traitMap.Add("racing10", "racing helmet deepskyblue");
        traitMap.Add("racing11", "racing helmet darkseagreen");
        traitMap.Add("racing12", "racing helmet indianred");
        traitMap.Add("racing13", "racing helmet black");
        traitMap.Add("racing14", "racing helmet white");

        traitMap.Add("hem01", "full helmet red");
        traitMap.Add("hem02", "full helmet green");
        traitMap.Add("hem03", "full helmet blue");
        traitMap.Add("hem04", "full helmet mint");
        traitMap.Add("hem05", "full helmet yellow");
        traitMap.Add("hem06", "full helmet pink");
        traitMap.Add("hem07", "full helmet olive");
        traitMap.Add("hem08", "full helmet purple");
        traitMap.Add("hem09", "full helmet mediumblue");
        traitMap.Add("hem10", "full helmet deepskyblue");
        traitMap.Add("hem11", "full helmet darkseagreen");
        traitMap.Add("hem12", "full helmet indianred");
        traitMap.Add("hem13", "full helmet black");
        traitMap.Add("hem14", "full helmet white");

        traitMap.Add("chm01", "full helmet check red");
        traitMap.Add("chm02", "full helmet check green");
        traitMap.Add("chm03", "full helmet check blue");
        traitMap.Add("chm04", "full helmet check mint");
        traitMap.Add("chm05", "full helmet check yellow");
        traitMap.Add("chm06", "full helmet check pink");
        traitMap.Add("chm07", "full helmet check olive");
        traitMap.Add("chm08", "full helmet check purple");
        traitMap.Add("chm09", "full helmet check mediumblue");
        traitMap.Add("chm10", "full helmet check deepskyblue");
        traitMap.Add("chm11", "full helmet check darkseagreen");
        traitMap.Add("chm12", "full helmet check indianred");
        traitMap.Add("chm13", "full helmet check black");
        traitMap.Add("chm14", "full helmet check white");

        // tattoo
        traitMap.Add("tat00", "no tattoo");
        traitMap.Add("tat01", "A type");
        traitMap.Add("tat02", "B type");
        traitMap.Add("tat03", "C type");
        traitMap.Add("tat04", "D type");
        traitMap.Add("tat05", "E type");

        // earring
        traitMap.Add("ear00", "no earring");
        traitMap.Add("eara", "A type");
        traitMap.Add("earb", "B type");
        traitMap.Add("earc", "C type");
        traitMap.Add("eard", "D type");
        traitMap.Add("eare", "E type");
        traitMap.Add("earf", "F type");
        traitMap.Add("earg", "G type");


        // piercing
        traitMap.Add("pie00", "no piercing");
        traitMap.Add("eye", "eye piercing");
        traitMap.Add("nos", "nose piercing");
        traitMap.Add("lip", "lip piercing");
        traitMap.Add("ino", "eye nose piercing");
        traitMap.Add("ili", "eye lip piercing");
        traitMap.Add("lis", "lipside piercing");


        // mask
        traitMap.Add("mask01", "mask red");
        traitMap.Add("mask02", "mask green");
        traitMap.Add("mask03", "mask blue");
        traitMap.Add("mask04", "mask mint");
        traitMap.Add("mask05", "mask yellow");
        traitMap.Add("mask06", "mask pink");
        traitMap.Add("mask07", "mask olive");
        traitMap.Add("mask08", "mask purple");
        traitMap.Add("mask09", "mask mediumblue");
        traitMap.Add("mask10", "mask deepskyblue");
        traitMap.Add("mask11", "mask darkseagreen");
        traitMap.Add("mask12", "mask indianred");
        traitMap.Add("mask13", "mask black");
        traitMap.Add("mask14", "mask white");

        traitMap.Add("o2m01", "O2 mask red");
        traitMap.Add("o2m02", "O2 mask green");
        traitMap.Add("o2m03", "O2 mask blue");
        traitMap.Add("o2m04", "O2 mask mint");
        traitMap.Add("o2m05", "O2 mask yellow");
        traitMap.Add("o2m06", "O2 mask pink");
        traitMap.Add("o2m07", "O2 mask olive");
        traitMap.Add("o2m08", "O2 mask purple");
        traitMap.Add("o2m09", "O2 mask mediumblue");
        traitMap.Add("o2m10", "O2 mask deepskyblue");
        traitMap.Add("o2m11", "O2 mask darkseagreen");
        traitMap.Add("o2m12", "O2 mask indianred");
        traitMap.Add("o2m13", "O2 mask black");
        traitMap.Add("o2m14", "O2 mask white");

        // eyewear
        traitMap.Add("eye00", "no eyewear");

        traitMap.Add("bio01", "bionic A");
        traitMap.Add("bio02", "bionic B");
        traitMap.Add("bio03", "bionic C");

        traitMap.Add("biomid01", "bionic A");
        traitMap.Add("biomid02", "bionic B");
        traitMap.Add("biomid03", "bionic C");

        traitMap.Add("biolong01", "bionic A");
        traitMap.Add("biolong02", "bionic B");
        traitMap.Add("biolong03", "bionic C");


        traitMap.Add("suna01", "sunglasses A black");
        traitMap.Add("suna02", "sunglasses A blue");
        traitMap.Add("suna03", "sunglasses A red");
        traitMap.Add("suna04", "sunglasses A purple");

        traitMap.Add("sunb01", "sunglasses B black");
        traitMap.Add("sunb02", "sunglasses B blue");
        traitMap.Add("sunb03", "sunglasses B red");
        traitMap.Add("sunb04", "sunglasses B purple");

        traitMap.Add("vis01", "visor blue");
        traitMap.Add("vis02", "visor green");
        traitMap.Add("vis03", "visor orange");
        traitMap.Add("vis04", "visor purple");
        traitMap.Add("vis05", "visor pink");
        traitMap.Add("vis06", "visor brown");
        traitMap.Add("vis07", "visor red");
        traitMap.Add("vis08", "visor cyan");


        // hologram
        traitMap.Add("holo00", "no hologram");
        traitMap.Add("holo01", "hologram olive");
        traitMap.Add("holo02", "hologram yellow");
        traitMap.Add("holo03", "hologram purple");
        traitMap.Add("holo04", "hologram green");


    }



    public TMP_InputField inputFieldFolderPath;

    public TMP_Text textFileCount;

    public GameObject scrollViewContent;

    public GameObject buttonElement;

    public TMP_InputField inputFieldForbiddenRule;

    public TMP_InputField inputFieldDependencyRule;

    public string folderPath;

    private void Awake()
    {

    }

    int displayedFileCounter = 0;
    public void AnalizeFolder()
    {

        foreach (Transform child in scrollViewContent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }


        folderPath = inputFieldFolderPath.text;

        try
        {
            Debug.Log("Analize Folder...");

            DirectoryInfo d = new DirectoryInfo(folderPath);

            FileInfo[] fis = d.GetFiles();


            displayedFileCounter = 0;
            for (int i = 0; i < fis.Length; i++)
            {
              

                if (fis[i].Name.Contains(".png") || fis[i].Name.Contains(".PNG"))
                {
                    if (!fis[i].Name.Contains("@@") && fis[i].Name.Contains("_"))
                    {
                        GameObject g = Instantiate(buttonElement);

                        g.transform.SetParent(scrollViewContent.transform);

                        g.transform.localScale = Vector3.one;

                        g.transform.GetChild(0).GetComponent<TMP_Text>().text = fis[i].Name;

                        g.SetActive(true);


                        displayedFileCounter++;

                        textFileCount.text = displayedFileCounter.ToString();

                    }                    
                }
            }
        }
        catch (System.Exception)
        {
            throw;
        }

    }


    public static long CountDirectoryFile(DirectoryInfo d)
    {
        long i = 0;
        // Add file sizes.
        FileInfo[] fis = d.GetFiles();
        foreach (FileInfo fi in fis)
        {
            if (fi.Extension.Contains("png") || fi.Extension.Contains("PNG"))
                i++;
        }
        return i;
    }


    public void RemoveSelectedFile()
    {
        DirectoryInfo d = new DirectoryInfo(folderPath);
        FileInfo[] fis = d.GetFiles();

        for (int i = 0; i < fileToRemove.Count; i++)
        {
            //FileUtil.DeleteFileOrDirectory(folderPath + "\\" + fileToRemove[i]);

            File.Delete(folderPath + "\\" + fileToRemove[i]);

            Debug.Log(folderPath + "\\" + fileToRemove[i] + " : file deleted");

            displayedFileCounter--;

            for (int j = 0; j < fis.Length; j++)
            {
                if (fis[j].Name.Contains(fileToRemove[i]))
                {
                    File.Delete(fis[j].FullName);
                }
            }
        }

        for (int i = 0; i < buttonToRemove.Count; i++)
        {
            Destroy(buttonToRemove[i]);
        }

        fileToRemove.Clear();
        buttonToRemove.Clear();
       
        textFileCount.text = displayedFileCounter.ToString();
    }



    public List<string> listedForbiddenRule = new List<string>();
    public List<int> filteredIndexList = new List<int>();
    public void ApplyForbiddenRule()
    {
        filteredIndexList.Clear();
        listedForbiddenRule.Clear();

        for (int j = 0; j < inputFieldForbiddenRule.text.Split("/").Length; j++)
        {
            listedForbiddenRule.Add(inputFieldForbiddenRule.text.Split("/")[j]);
        }

        DirectoryInfo d = new DirectoryInfo(folderPath);
        FileInfo[] fis = d.GetFiles();


        //Parallel.For(0, fis.Length, (i) =>
        //{
        //    for (int j = 0; j < listedForbiddenRule.Count; j++)
        //    {
        //        if (fis[i].Name.Contains(listedForbiddenRule[j].Split("&")[0]) && fis[i].Name.Contains(listedForbiddenRule[j].Split("&")[1]))
        //        {
        //            //FileUtil.DeleteFileOrDirectory(folderPath + "\\" + fis[i].Name);
        //            //File.Delete(folderPath + "\\" + fis[i].Name);
        //            filteredIndexList.Add(i);

        //        }
        //    }
        //});

        for (int i = 0; i < fis.Length; i++)
        {
            for (int j = 0; j < listedForbiddenRule.Count; j++)
            {
                if (fis[i].Name.Contains(listedForbiddenRule[j].Split("&")[0]) && fis[i].Name.Contains(listedForbiddenRule[j].Split("&")[1]))
                {
                    //FileUtil.DeleteFileOrDirectory(folderPath + "\\" + fis[i].Name);
                    //File.Delete(folderPath + "\\" + fis[i].Name);
                    filteredIndexList.Add(i);
                }
            }
        }

        filteredIndexList.Reverse();


        for (int i = 0; i < filteredIndexList.Count; i++)
        {

            File.Delete(folderPath + "\\" + fis[filteredIndexList[i]].Name);

            Destroy(scrollViewContent.transform.GetChild(filteredIndexList[i]).gameObject);

        }

        textFileCount.text = CountDirectoryFile(d).ToString();

    }

    public List<string> listedDependencyRule = new List<string>();
    public void ApplyDependencyRule()
    {
        filteredIndexList.Clear();
        listedDependencyRule.Clear();

        for (int i = 0; i < inputFieldDependencyRule.text.Split("/").Length; i++)
        {
            listedDependencyRule.Add(inputFieldDependencyRule.text.Split("/")[i]);
        }

        DirectoryInfo d = new DirectoryInfo(folderPath);
        FileInfo[] fis = d.GetFiles();

        Parallel.For(0, fis.Length, (i) =>
        {
            for (int j = 0; j < listedDependencyRule.Count; j++)
            {
                if (fis[i].Name.Contains(listedDependencyRule[j].Split("&")[0]))
                {
                    int ruleLength = listedDependencyRule[j].Split("&").Length;

                    switch (ruleLength)
                    {
                        case 2:

                            if (fis[i].Name.Contains(listedDependencyRule[j].Split("&")[0]) && fis[i].Name.Contains(listedDependencyRule[j].Split("&")[1]))
                            {
                            }
                            else
                            {
                                filteredIndexList.Add(i);
                            }

                            break;

                        case 3:

                            if (fis[i].Name.Contains(listedDependencyRule[j].Split("&")[0]) && fis[i].Name.Contains(listedDependencyRule[j].Split("&")[1])
                            && fis[i].Name.Contains(listedDependencyRule[j].Split("&")[2]))
                            {
                            }
                            else
                            {
                                filteredIndexList.Add(i);
                            }

                            break;
                        case 4:

                            if (fis[i].Name.Contains(listedDependencyRule[j].Split("&")[0]) && fis[i].Name.Contains(listedDependencyRule[j].Split("&")[1])
                            && fis[i].Name.Contains(listedDependencyRule[j].Split("&")[2]) && fis[i].Name.Contains(listedDependencyRule[j].Split("&")[3]))
                            {
                            }
                            else
                            {
                                filteredIndexList.Add(i);
                            }

                            break;
                        case 5:

                            if (fis[i].Name.Contains(listedDependencyRule[j].Split("&")[0]) && fis[i].Name.Contains(listedDependencyRule[j].Split("&")[1])
                            && fis[i].Name.Contains(listedDependencyRule[j].Split("&")[2]) && fis[i].Name.Contains(listedDependencyRule[j].Split("&")[3])
                            && fis[i].Name.Contains(listedDependencyRule[j].Split("&")[4]))
                            {
                            }
                            else
                            {
                                filteredIndexList.Add(i);
                            }

                            break;
                        case 6:

                            if (fis[i].Name.Contains(listedDependencyRule[j].Split("&")[0]) && fis[i].Name.Contains(listedDependencyRule[j].Split("&")[1])
                            && fis[i].Name.Contains(listedDependencyRule[j].Split("&")[2]) && fis[i].Name.Contains(listedDependencyRule[j].Split("&")[3])
                            && fis[i].Name.Contains(listedDependencyRule[j].Split("&")[4]) && fis[i].Name.Contains(listedDependencyRule[j].Split("&")[5]))
                            {
                            }
                            else
                            {
                                filteredIndexList.Add(i);
                            }

                            break;
                        case 7:

                            if (fis[i].Name.Contains(listedDependencyRule[j].Split("&")[0]) && fis[i].Name.Contains(listedDependencyRule[j].Split("&")[1])
                            && fis[i].Name.Contains(listedDependencyRule[j].Split("&")[2]) && fis[i].Name.Contains(listedDependencyRule[j].Split("&")[3])
                            && fis[i].Name.Contains(listedDependencyRule[j].Split("&")[4]) && fis[i].Name.Contains(listedDependencyRule[j].Split("&")[5])
                            && fis[i].Name.Contains(listedDependencyRule[j].Split("&")[6]))
                            {
                            }
                            else
                            {
                                filteredIndexList.Add(i);
                            }

                            break;

                        default:
                            break;
                    }
                }
            }
        });


        filteredIndexList.Reverse();

        for (int i = 0; i < filteredIndexList.Count; i++)
        {
            File.Delete(folderPath + "\\" + fis[filteredIndexList[i]].Name);

            Destroy(scrollViewContent.transform.GetChild(filteredIndexList[i]).gameObject);
        }

        textFileCount.text = CountDirectoryFile(d).ToString();

    }



    public int initialIndex;
    public List<string> nameToMakeMetaFile = new List<string>();
    public List<string> copiedNameToMakeMetaFile = new List<string>();
    public List<int> generatedIndex = new List<int>();

    public void GenerateMetaFile()
    {
        StartCoroutine(CoGenerateMetaFile());
    }
    public IEnumerator CoGenerateMetaFile()
    {
        generatedIndex.Clear();
        nameToMakeMetaFile.Clear();
        copiedNameToMakeMetaFile.Clear();

        DirectoryInfo d = new DirectoryInfo(folderPath);
        FileInfo[] fis = d.GetFiles();


        for (int i = 0; i < fis.Length; i++)
        {
            generatedIndex.Add(i);
        }


        for (int i = 0; i < generatedIndex.Count; i++)
        {
            int temp = generatedIndex[i];
            int randomIndex = Random.Range(i, generatedIndex.Count);
            generatedIndex[i] = generatedIndex[randomIndex];
            generatedIndex[randomIndex] = temp;
        }


        for (int i = 0; i < fis.Length; i++)
        {
            nameToMakeMetaFile.Add(fis[generatedIndex[i]].Name.Replace(".png", "").Replace(".PNG", ""));
            copiedNameToMakeMetaFile.Add(fis[generatedIndex[i]].Name.Replace(".png", "").Replace(".PNG", ""));
        }


        MetaFile metaFile = new MetaFile();
        metaFile.traits = new Trait[fis.Length];


        bool isMaskSet;
        bool isMorseCodeSet;
        bool isPiercingSet;
        bool isEarringSet;
        for (int i = 0; i < nameToMakeMetaFile.Count; i++)
        {

            isMaskSet = false;
            isMorseCodeSet = false;
            isPiercingSet = false;
            isEarringSet = false;
            /////////////////////////////////////////
            Trait trait = new Trait();
            trait.name = "CryptoFomula #" + (initialIndex + i).ToString();
            trait.description = "CryptoFormula is a collection of NFTs built for international racing fans. Your CryptoFormula acts as a Biverse membership, both across Universe and Metaverse. Special events tailored for racing fans are in the works, starting with Formula E Korea in August 2022. Visit cryptoformula.io for our detailed roadmap.";
            trait.image = "/" + (initialIndex + i).ToString() + ".png";
            trait.edition = initialIndex + i;

            trait.attributes = new Attribute[15];

            trait.compiler = "Forest256 Art Engine";
            /////////////////////////////////////////


            trait.attributes[0].trait_type = "background";
            trait.attributes[0].value = ReplaceAcronym(nameToMakeMetaFile[i].Split("##")[0].Split("_")[0]);

            trait.attributes[1].trait_type = "halo";
            trait.attributes[1].value = ReplaceAcronym(nameToMakeMetaFile[i].Split("##")[0].Split("_")[1]);

            nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace(nameToMakeMetaFile[i].Split("##")[0] + "##", "");
            nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("##", "_");


            // earring
            if (nameToMakeMetaFile[i].Contains("eara"))
            {
                trait.attributes[10].trait_type = "earring";
                trait.attributes[10].value = "A type";

                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("eara", "");
                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("__", "_");
                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("####", "##");
                isEarringSet = true;
            }
            else if (nameToMakeMetaFile[i].Contains("earb"))
            {
                trait.attributes[10].trait_type = "earring";
                trait.attributes[10].value = "B type";

                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("earb", "");
                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("__", "_");
                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("####", "##");
                isEarringSet = true;
            }
            else if (nameToMakeMetaFile[i].Contains("earc"))
            {
                trait.attributes[10].trait_type = "earring";
                trait.attributes[10].value = "C type";

                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("earc", "");
                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("__", "_");
                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("####", "##");
                isEarringSet = true;
            }
            else if (nameToMakeMetaFile[i].Contains("eard"))
            {
                trait.attributes[10].trait_type = "earring";
                trait.attributes[10].value = "D type";

                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("eard", "");
                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("__", "_");
                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("####", "##");
                isEarringSet = true;
            }
            else if (nameToMakeMetaFile[i].Contains("eare"))
            {
                trait.attributes[10].trait_type = "earring";
                trait.attributes[10].value = "E type";

                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("eare", "");
                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("__", "_");
                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("####", "##");
                isEarringSet = true;
            }
            else if (nameToMakeMetaFile[i].Contains("earf"))
            {
                trait.attributes[10].trait_type = "earring";
                trait.attributes[10].value = "F type";

                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("earf", "");
                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("__", "_");
                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("####", "##");
                isEarringSet = true;
            }
            else if (nameToMakeMetaFile[i].Contains("earg"))
            {
                trait.attributes[10].trait_type = "earring";
                trait.attributes[10].value = "G type";

                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("earg", "");
                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("__", "_");
                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("####", "##");
                isEarringSet = true;
            }
            else
            {
                trait.attributes[10].trait_type = "earring";
                trait.attributes[10].value = "no earring";
            }





            // piercing
            if (nameToMakeMetaFile[i].Contains("eye"))
            {
                trait.attributes[11].trait_type = "piercing";
                trait.attributes[11].value = "eye piercing";

                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("eye", "");
                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("__", "_");
                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("####", "##");
                isPiercingSet = true;
            }
            else if (nameToMakeMetaFile[i].Contains("nos"))
            {
                trait.attributes[11].trait_type = "piercing";
                trait.attributes[11].value = "nose piercing";

                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("nos", "");
                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("__", "_");
                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("####", "##");
                isPiercingSet = true;
            }
            else if (nameToMakeMetaFile[i].Contains("lip"))
            {
                trait.attributes[11].trait_type = "piercing";
                trait.attributes[11].value = "lip piercing";

                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("lip", "");
                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("__", "_");
                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("####", "##");
                isPiercingSet = true;
            }
            else if (nameToMakeMetaFile[i].Contains("ili"))
            {
                trait.attributes[11].trait_type = "piercing";
                trait.attributes[11].value = "eye lip piercing";

                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("ili", "");
                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("__", "_");
                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("####", "##");
                isPiercingSet = true;
            }
            else if (nameToMakeMetaFile[i].Contains("lis"))
            {
                trait.attributes[11].trait_type = "piercing";
                trait.attributes[11].value = "lipside piercing";

                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("lis", "");
                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("__", "_");
                nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("####", "##");
                isPiercingSet = true;
            }
            else
            {
                trait.attributes[11].trait_type = "piercing";
                trait.attributes[11].value = "no piercing";
            }




            for (int j = 2; j < 15; j++)
            {
                switch (j)
                {
                    case 2:

                        if (nameToMakeMetaFile[i].Split("_")[0].Contains("suit") ||
                            nameToMakeMetaFile[i].Split("_")[0].Contains("shirt") ||
                            nameToMakeMetaFile[i].Split("_")[0].Contains("rain") ||
                            nameToMakeMetaFile[i].Split("_")[0].Contains("jac"))
                        {

                            if (nameToMakeMetaFile[i].Split("_")[0].Contains("suit"))
                            {
                                if (nameToMakeMetaFile[i].Contains("mos01"))
                                {
                                    trait.attributes[4].trait_type = "emblem";
                                    trait.attributes[4].value = "aud";

                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("mos01", "");
                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("__", "_");
                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("####", "##");
                                    isMorseCodeSet = true;
                                }
                                if (nameToMakeMetaFile[i].Contains("mos02"))
                                {
                                    trait.attributes[4].trait_type = "emblem";
                                    trait.attributes[4].value = "bmw";

                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("mos02", "");
                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("__", "_");
                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("####", "##");
                                    isMorseCodeSet = true;
                                }
                                if (nameToMakeMetaFile[i].Contains("mos03"))
                                {
                                    trait.attributes[4].trait_type = "emblem";
                                    trait.attributes[4].value = "hyu";

                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("mos03", "");
                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("__", "_");
                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("####", "##");
                                    isMorseCodeSet = true;
                                }
                                if (nameToMakeMetaFile[i].Contains("mos04"))
                                {
                                    trait.attributes[4].trait_type = "emblem";
                                    trait.attributes[4].value = "jag";

                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("mos04", "");
                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("__", "_");
                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("####", "##");
                                    isMorseCodeSet = true;
                                }
                                if (nameToMakeMetaFile[i].Contains("mos05"))
                                {
                                    trait.attributes[4].trait_type = "emblem";
                                    trait.attributes[4].value = "kia";

                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("mos05", "");
                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("__", "_");
                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("####", "##");
                                    isMorseCodeSet = true;
                                }
                                if (nameToMakeMetaFile[i].Contains("mos06"))
                                {
                                    trait.attributes[4].trait_type = "emblem";
                                    trait.attributes[4].value = "lex";

                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("mos06", "");
                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("__", "_");
                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("####", "##");
                                    isMorseCodeSet = true;
                                }
                                if (nameToMakeMetaFile[i].Contains("mos07"))
                                {
                                    trait.attributes[4].trait_type = "emblem";
                                    trait.attributes[4].value = "mb";

                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("mos07", "");
                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("__", "_");
                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("####", "##");
                                    isMorseCodeSet = true;
                                }
                                if (nameToMakeMetaFile[i].Contains("mos08"))
                                {
                                    trait.attributes[4].trait_type = "emblem";
                                    trait.attributes[4].value = "pol";

                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("mos08", "");
                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("__", "_");
                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("####", "##");
                                    isMorseCodeSet = true;
                                }
                                if (nameToMakeMetaFile[i].Contains("mos09"))
                                {
                                    trait.attributes[4].trait_type = "emblem";
                                    trait.attributes[4].value = "por";

                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("mos09", "");
                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("__", "_");
                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("####", "##");
                                    isMorseCodeSet = true;
                                }
                                if (nameToMakeMetaFile[i].Contains("mos10"))
                                {
                                    trait.attributes[4].trait_type = "emblem";
                                    trait.attributes[4].value = "tes";

                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("mos10", "");
                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("__", "_");
                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("####", "##");
                                    isMorseCodeSet = true;
                                }
                                if (nameToMakeMetaFile[i].Contains("mos11"))
                                {
                                    trait.attributes[4].trait_type = "emblem";
                                    trait.attributes[4].value = "vol";

                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("mos11", "");
                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("__", "_");
                                    nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace("####", "##");
                                    isMorseCodeSet = true;
                                }
                            }

                            trait.attributes[2].trait_type = "cloth";
                            trait.attributes[2].value = ReplaceAcronym(nameToMakeMetaFile[i].Split("_")[0]);
                            nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace(nameToMakeMetaFile[i].Split("_")[0] + "_", "");

                        }
                        else
                        {
                            trait.attributes[2].trait_type = "cloth";
                            trait.attributes[2].value = "null";
                        }

                        break;

                    case 3:

                        if (nameToMakeMetaFile[i].Split("_")[0].Contains("bad"))
                        {
                            trait.attributes[3].trait_type = "badge";
                            trait.attributes[3].value = ReplaceAcronym(nameToMakeMetaFile[i].Split("_")[0]);
                            nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace(nameToMakeMetaFile[i].Split("_")[0] + "_", "");
                        }
                        else
                        {
                            trait.attributes[3].trait_type = "badge";
                            trait.attributes[3].value = "no badge";
                        }

                        break;

                    case 4:

                        if (nameToMakeMetaFile[i].Split("_")[0].Contains("emb"))
                        {
                            trait.attributes[4].trait_type = "emblem";
                            trait.attributes[4].value = ReplaceAcronym(nameToMakeMetaFile[i].Split("_")[0]);
                            nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace(nameToMakeMetaFile[i].Split("_")[0] + "_", "");
                        }
                        else
                        {
                            if (!isMorseCodeSet)
                            {
                                trait.attributes[4].trait_type = "emblem";
                                trait.attributes[4].value = "no emblem";
                            }


                        }

                        break;

                    case 5:

                        if (nameToMakeMetaFile[i].Split("_")[0].Contains("coi"))
                        {
                            trait.attributes[5].trait_type = "coin";
                            trait.attributes[5].value = ReplaceAcronym(nameToMakeMetaFile[i].Split("_")[0]);
                            nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace(nameToMakeMetaFile[i].Split("_")[0] + "_", "");
                        }
                        else
                        {
                            trait.attributes[5].trait_type = "coin";
                            trait.attributes[5].value = "no coin";
                        }

                        break;

                    case 6:
                        string sex = "";
                        string race = "";
                        if (nameToMakeMetaFile[i].Split("_")[0].Contains("mb") ||
                         nameToMakeMetaFile[i].Split("_")[0].Contains("mw") ||
                         nameToMakeMetaFile[i].Split("_")[0].Contains("my") ||
                         nameToMakeMetaFile[i].Split("_")[0].Contains("fb") ||
                         nameToMakeMetaFile[i].Split("_")[0].Contains("fy") ||
                         nameToMakeMetaFile[i].Split("_")[0].Contains("fw") ||
                         nameToMakeMetaFile[i].Split("_")[0].Contains("ac") ||
                         nameToMakeMetaFile[i].Split("_")[0].Contains("ab") ||
                         nameToMakeMetaFile[i].Split("_")[0].Contains("ap"))
                        {

                            if (nameToMakeMetaFile[i].Split("_")[0].Contains("mb"))
                            {
                                sex = "male";
                                race = "black";
                            }
                            else if (nameToMakeMetaFile[i].Split("_")[0].Contains("mw"))
                            {
                                sex = "male";
                                race = "white";
                            }
                            else if (nameToMakeMetaFile[i].Split("_")[0].Contains("my"))
                            {
                                sex = "male";
                                race = "yellow";
                            }
                            else if (nameToMakeMetaFile[i].Split("_")[0].Contains("fb"))
                            {
                                sex = "female";
                                race = "black";
                            }
                            else if (nameToMakeMetaFile[i].Split("_")[0].Contains("fw"))
                            {
                                sex = "female";
                                race = "white";
                            }
                            else if (nameToMakeMetaFile[i].Split("_")[0].Contains("fy"))
                            {
                                sex = "female";
                                race = "yellow";
                            }
                            else if (nameToMakeMetaFile[i].Split("_")[0].Contains("ac"))
                            {
                                sex = "alien";
                                race = "cyan";
                            }
                            else if (nameToMakeMetaFile[i].Split("_")[0].Contains("ab"))
                            {
                                sex = "alien";
                                race = "brown";
                            }
                            else if (nameToMakeMetaFile[i].Split("_")[0].Contains("ap"))
                            {
                                sex = "alien";
                                race = "purple";
                            }


                            trait.attributes[6].trait_type = "sex race";
                            trait.attributes[6].value = sex + " " + race;

                            nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace(nameToMakeMetaFile[i].Split("_")[0] + "_", "");
                        }
                        else
                        {
                            trait.attributes[6].trait_type = "sex race";
                            trait.attributes[6].value = "null";
                        }

                        break;


                    case 7:

                        if (nameToMakeMetaFile[i].Split("_")[0].Contains("sho") ||
                       nameToMakeMetaFile[i].Split("_")[0].Contains("mid") ||
                       nameToMakeMetaFile[i].Split("_")[0].Contains("long"))
                        {
                            trait.attributes[7].trait_type = "hair";
                            trait.attributes[7].value = ReplaceAcronym(nameToMakeMetaFile[i].Split("_")[0]);
                            nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace(nameToMakeMetaFile[i].Split("_")[0] + "_", "");
                        }
                        else if (nameToMakeMetaFile[i].Split("_")[0].Contains("hai"))
                        {
                            trait.attributes[7].trait_type = "hair";
                            trait.attributes[7].value = "no hair";
                            nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace(nameToMakeMetaFile[i].Split("_")[0] + "_", "");
                        }
                        else
                        {
                            trait.attributes[7].trait_type = "hair";
                            trait.attributes[7].value = "no hair";
                        }

                        break;

                    case 8:

                        if (nameToMakeMetaFile[i].Split("_")[0].Contains("hel") ||
                        nameToMakeMetaFile[i].Split("_")[0].Contains("check") ||
                        nameToMakeMetaFile[i].Split("_")[0].Contains("decal") ||
                        nameToMakeMetaFile[i].Split("_")[0].Contains("racing") ||
                        nameToMakeMetaFile[i].Split("_")[0].Contains("hem") ||
                        nameToMakeMetaFile[i].Split("_")[0].Contains("chm"))
                        {

                            if (nameToMakeMetaFile[i].Split("_")[0].Contains("decal"))
                            {

                                trait.attributes[12].trait_type = "mask";
                                trait.attributes[12].value = ReplaceAcronym("mask" + nameToMakeMetaFile[i].Split("_")[0].Replace("decal", ""));

                                isMaskSet = true;

                            }
                            if (nameToMakeMetaFile[i].Split("_")[0].Contains("chm"))
                            {
                                trait.attributes[12].trait_type = "mask";
                                trait.attributes[12].value = ReplaceAcronym("mask" + nameToMakeMetaFile[i].Split("_")[0].Replace("chm", ""));

                                isMaskSet = true;

                            }
                            if (nameToMakeMetaFile[i].Split("_")[0].Contains("hem"))
                            {
                                trait.attributes[12].trait_type = "mask";
                                trait.attributes[12].value = ReplaceAcronym("mask" + nameToMakeMetaFile[i].Split("_")[0].Replace("hem", ""));

                                isMaskSet = true;

                            }

                            trait.attributes[8].trait_type = "helmet";
                            trait.attributes[8].value = ReplaceAcronym(nameToMakeMetaFile[i].Split("_")[0]);
                            nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace(nameToMakeMetaFile[i].Split("_")[0] + "_", "");
                        }
                        else
                        {
                            trait.attributes[8].trait_type = "helmet";
                            trait.attributes[8].value = "no helmet";
                        }

                        break;

                    case 9:

                        if (nameToMakeMetaFile[i].Split("_")[0].Contains("tat"))
                        {
                            trait.attributes[9].trait_type = "tattoo";
                            trait.attributes[9].value = ReplaceAcronym(nameToMakeMetaFile[i].Split("_")[0]);
                            nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace(nameToMakeMetaFile[i].Split("_")[0] + "_", "");
                        }
                        else
                        {
                            trait.attributes[9].trait_type = "tattoo";
                            trait.attributes[9].value = "no tattoo";
                        }

                        break;

                    case 10:

                        // earring

                        break;

                    case 11:

                        // piercing

                        break;

                    case 12:

                        if (nameToMakeMetaFile[i].Split("_")[0].Contains("mask") ||
                           nameToMakeMetaFile[i].Split("_")[0].Contains("o2m"))
                        {
                            trait.attributes[12].trait_type = "mask";
                            trait.attributes[12].value = ReplaceAcronym(nameToMakeMetaFile[i].Split("_")[0]);
                            nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace(nameToMakeMetaFile[i].Split("_")[0] + "_", "");
                        }
                        else
                        {
                            if (!isMaskSet)
                            {
                                trait.attributes[12].trait_type = "mask";
                                trait.attributes[12].value = "no mask";
                            }
                        }

                        break;

                    case 13:

                        if (nameToMakeMetaFile[i].Split("_")[0].Contains("sun") ||
                          nameToMakeMetaFile[i].Split("_")[0].Contains("vis") ||
                          nameToMakeMetaFile[i].Split("_")[0].Contains("bio"))
                        {
                            trait.attributes[13].trait_type = "eyewear";
                            trait.attributes[13].value = ReplaceAcronym(nameToMakeMetaFile[i].Split("_")[0]);
                            nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace(nameToMakeMetaFile[i].Split("_")[0] + "_", "");
                        }
                        else
                        {
                            trait.attributes[13].trait_type = "eyewear";
                            trait.attributes[13].value = "no eyewear";
                        }

                        break;

                    case 14:

                        if (nameToMakeMetaFile[i].Split("_")[0].Contains("holo"))
                        {
                            trait.attributes[14].trait_type = "hologram";
                            trait.attributes[14].value = ReplaceAcronym(nameToMakeMetaFile[i].Split("_")[0]);
                            nameToMakeMetaFile[i] = nameToMakeMetaFile[i].Replace(nameToMakeMetaFile[i].Split("_")[0] + "_", "");
                        }
                        else
                        {
                            trait.attributes[14].trait_type = "hologram";
                            trait.attributes[14].value = "no hologram";
                        }

                        break;

                    default:
                        break;
                }

            }

            string json = JsonUtility.ToJson(trait);
            File.WriteAllText(folderPath + "/" + (i + initialIndex) + ".json", json);

            metaFile.traits[i] = trait;


            if (reserveOriginalNameFile)
            {
                File.Copy(folderPath + "/" + copiedNameToMakeMetaFile[i] + ".png", folderPath + "/" + (i + initialIndex) + "@@" + copiedNameToMakeMetaFile[i] + ".png");
                File.Copy(folderPath + "/" + copiedNameToMakeMetaFile[i] + ".png", folderPath + "/" + (i + initialIndex) + ".png");
            }
            else
            {
                File.Move(folderPath + "/" + copiedNameToMakeMetaFile[i] + ".png", folderPath + "/" + (i + initialIndex) + ".png");
            }



            yield return null;

        }


        string jsonMetaFile = JsonUtility.ToJson(metaFile);
        File.WriteAllText(folderPath + "/" + "_metadata" + ".json", jsonMetaFile);
    }
    public bool reserveOriginalNameFile;
    public Toggle toggleReserveOriginalData;






    private string ReplaceAcronym(string s)
    {
        if (traitMap.ContainsKey(s))
        {
            string fullName = traitMap[s];

            return fullName;
        }
        else
        {
            return s;
        }

    }


    [Serializable]
    public class MetaFile
    {
        public Trait[] traits;
    }

    [Serializable]
    public class Trait
    {
        public string name;
        public string description;
        public string image;
        public int edition;

        public Attribute[] attributes;

        public string compiler;
    }

    [Serializable]
    public struct Attribute
    {
        public string trait_type;
        public string value;
    }

    public TMP_InputField inputFieldNumToSelect;
    public TMP_InputField inputFieldTargetPath;

    private List<string> listedFilesToMove = new List<string>();
    private List<int> listedRandomNumbers = new List<int>();

    public void MoveRandomlySelectedFiles()
    {
        StartCoroutine(CoMoveRandomlySelectedFiles());
    }
    public IEnumerator CoMoveRandomlySelectedFiles()
    {
        Debug.Log(int.Parse(inputFieldNumToSelect.text));

        for (int i = 0; i < int.Parse(inputFieldNumToSelect.text); i++)
        {
            DirectoryInfo d = new DirectoryInfo(folderPath);

            FileInfo[] fis = d.GetFiles();

            int ran = (int)(UnityEngine.Random.Range(0, fis.Length - 1));
            File.Copy(fis[ran].FullName, inputFieldTargetPath.text + "\\" + fis[ran].Name);

            File.Delete(fis[ran].FullName);

            yield return null;
        }
    }


    // ERROR on deleting "copied##"
    int suffixIndex = 2;
    string folderPathToCopy = "Z:\\fek\\studio\\tmp\\7_round_male\\hologram\\hologram_rarity";
    public void CopyBackgroundImage()
    {
        DirectoryInfo d = new DirectoryInfo(folderPath);

        FileInfo[] fis = d.GetFiles();



        for (int i = 0; i < fis.Length; i++)
        {
            suffixIndex = 2;

            if (fis[i].Name.Contains("holo02"))
            {
                for (int j = 0; j < 1; j++)
                {
                    File.Copy(fis[i].FullName, folderPathToCopy + "\\" + fis[i].Name.Replace(".png", "") + "_copied" + suffixIndex.ToString() + ".png");

                    suffixIndex++;
                }
            }
            if (fis[i].Name.Contains("holo03"))
            {
                for (int j = 0; j < 2; j++)
                {
                    File.Copy(fis[i].FullName, folderPathToCopy + "\\" + fis[i].Name.Replace(".png", "") + "_copied" + suffixIndex.ToString() + ".png");

                    suffixIndex++;
                }
            }
            if (fis[i].Name.Contains("holo04"))
            {
                for (int j = 0; j < 3; j++)
                {
                    File.Copy(fis[i].FullName, folderPathToCopy + "\\" + fis[i].Name.Replace(".png", "") + "_copied" + suffixIndex.ToString() + ".png");

                    suffixIndex++;
                }
            }




            ///////////////////////////////////////////////////////////
            //if (fis[i].Name.Contains("cir02"))
            //{
            //    for (int j = 0; j < 1; j++)
            //    {
            //        File.Copy(fis[i].FullName, folderPathToCopy + "\\" + fis[i].Name.Replace(".png", "") + "_copied" + suffixIndex.ToString() + ".png");

            //        suffixIndex++;
            //    }               
            //}
            //if (fis[i].Name.Contains("cir03"))
            //{
            //    for (int j = 0; j < 2; j++)
            //    {
            //        File.Copy(fis[i].FullName, folderPathToCopy + "\\" + fis[i].Name.Replace(".png", "") + "_copied" + suffixIndex.ToString() + ".png");

            //        suffixIndex++;
            //    }
            //}
            //if (fis[i].Name.Contains("cir04"))
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        File.Copy(fis[i].FullName, folderPathToCopy + "\\" + fis[i].Name.Replace(".png", "") + "_copied" + suffixIndex.ToString() + ".png");

            //        suffixIndex++;
            //    }
            //}


            //if (fis[i].Name.Contains("tri01"))
            //{
            //    for (int j = 0; j < 4; j++)
            //    {
            //        File.Copy(fis[i].FullName, folderPathToCopy + "\\" + fis[i].Name.Replace(".png", "") + "_copied" + suffixIndex.ToString() + ".png");

            //        suffixIndex++;
            //    }
            //}
            //if (fis[i].Name.Contains("tri02"))
            //{
            //    for (int j = 0; j < 5; j++)
            //    {
            //        File.Copy(fis[i].FullName, folderPathToCopy + "\\" + fis[i].Name.Replace(".png", "") + "_copied" + suffixIndex.ToString() + ".png");

            //        suffixIndex++;
            //    }
            //}
            //if (fis[i].Name.Contains("tri03"))
            //{
            //    for (int j = 0; j < 6; j++)
            //    {
            //        File.Copy(fis[i].FullName, folderPathToCopy + "\\" + fis[i].Name.Replace(".png", "") + "_copied" + suffixIndex.ToString() + ".png");

            //        suffixIndex++;
            //    }
            //}


            //if (fis[i].Name.Contains("tri04"))
            //{
            //    for (int j = 0; j < 7; j++)
            //    {
            //        File.Copy(fis[i].FullName, folderPathToCopy + "\\" + fis[i].Name.Replace(".png", "") + "_copied" + suffixIndex.ToString() + ".png");

            //        suffixIndex++;
            //    }
            //}
            //if (fis[i].Name.Contains("dia01"))
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        File.Copy(fis[i].FullName, folderPathToCopy + "\\" + fis[i].Name.Replace(".png", "") + "_copied" + suffixIndex.ToString() + ".png");

            //        suffixIndex++;
            //    }
            //}
            //if (fis[i].Name.Contains("dia02"))
            //{
            //    for (int j = 0; j < 9; j++)
            //    {
            //        File.Copy(fis[i].FullName, folderPathToCopy + "\\" + fis[i].Name.Replace(".png", "") + "_copied" + suffixIndex.ToString() + ".png");

            //        suffixIndex++;
            //    }
            //}
            //if (fis[i].Name.Contains("dia03"))
            //{
            //    for (int j = 0; j < 10; j++)
            //    {
            //        File.Copy(fis[i].FullName, folderPathToCopy + "\\" + fis[i].Name.Replace(".png", "") + "_copied" + suffixIndex.ToString() + ".png");

            //        suffixIndex++;
            //    }
            //}
            //if (fis[i].Name.Contains("dia04"))
            //{
            //    for (int j = 0; j < 11; j++)
            //    {
            //        File.Copy(fis[i].FullName, folderPathToCopy + "\\" + fis[i].Name.Replace(".png", "") + "_copied" + suffixIndex.ToString() + ".png");

            //        suffixIndex++;
            //    }
            //}


            //if (fis[i].Name.Contains("hex01"))
            //{
            //    for (int j = 0; j < 12; j++)
            //    {
            //        File.Copy(fis[i].FullName, folderPathToCopy + "\\" + fis[i].Name.Replace(".png", "") + "_copied" + suffixIndex.ToString() + ".png");

            //        suffixIndex++;
            //    }
            //}
            //if (fis[i].Name.Contains("hex02"))
            //{
            //    for (int j = 0; j < 13; j++)
            //    {
            //        File.Copy(fis[i].FullName, folderPathToCopy + "\\" + fis[i].Name.Replace(".png", "") + "_copied" + suffixIndex.ToString() + ".png");

            //        suffixIndex++;
            //    }
            //}
            //if (fis[i].Name.Contains("hex03"))
            //{
            //    for (int j = 0; j < 14; j++)
            //    {
            //        File.Copy(fis[i].FullName, folderPathToCopy + "\\" + fis[i].Name.Replace(".png", "") + "_copied" + suffixIndex.ToString() + ".png");

            //        suffixIndex++;
            //    }
            //}
            //if (fis[i].Name.Contains("hex04"))
            //{
            //    for (int j = 0; j < 15; j++)
            //    {
            //        File.Copy(fis[i].FullName, folderPathToCopy + "\\" + fis[i].Name.Replace(".png", "") + "_copied" + suffixIndex.ToString() + ".png");

            //        suffixIndex++;
            //    }
            //}

        }


    }


    public string prevPath;
    public string originalPath;
    public string outputPath;
    public bool isHolo;
    public List<string> listToCopy = new List<string>();
    public void DoFuckingJob()
    {
        listToCopy.Clear();

        DirectoryInfo d = new DirectoryInfo(prevPath);

        FileInfo[] fis = d.GetFiles();

        Debug.Log(fis.Length);


        if (!isHolo)
        {
            for (int i = 0; i < fis.Length; i++)
            {
                listToCopy.Add(fis[i].Name.Replace(fis[i].Name.Split("##")[0], "").Substring(2));

            }
        }
        else
        {
            for (int i = 0; i < fis.Length; i++)
            {

                listToCopy.Add((fis[i].Name.Replace(fis[i].Name.Split("##")[0], "").Replace(fis[i].Name.Split("##")[fis[i].Name.Split("##").Length-1], "").Substring(2) + ".png").Replace("##.", "."));

            }
        }

       


       

        for (int i = 0; i < listToCopy.Count; i++)
        {
            File.Copy(originalPath + "\\" + listToCopy[i], outputPath + "\\" + listToCopy[i]);
        }
        

    }

    public void DoFuckingChangePNG()
    {
        DirectoryInfo d = new DirectoryInfo(originalPath);

        FileInfo[] fis = d.GetFiles();


        for (int i = 0; i < fis.Length; i++)
        {
            File.Move(originalPath + "\\" + fis[i].Name, originalPath + "\\" + fis[i].Name.Replace(".PNG", ""));
            //File.Move(originalPath + "\\" + fis[i].Name, originalPath + "\\" + fis[i].Name.Replace("##empty", ""));
        }

    }

}
