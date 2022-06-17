using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text debugText;
    public TMP_Text FPSView;

    private ItemPanel itemPanel;
    private GlobalManager globalManager;
    protected ObjectCollection objectCollection;
    private ObjectPoolManager objectPoolManager;


    private void Update()
    {
        float FPS = 1 / Time.deltaTime;
        FPSView.text = "FPS:" + FPS.ToString();
    }

    private void Start()
    {
        Application.targetFrameRate = -1;
        IniManager();
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("GameInWine", Application.persistentDataPath + "\\GameData\\xx.json");
        globalManager.FileToGame<GameWineRoots>(dic);
        objectPoolManager.IniObjectPool(20);
    }

    private void IniManager()
    {
        itemPanel = new ItemPanel();
        globalManager = new GlobalManager();
        objectCollection = GetComponent<ObjectCollection>();
        objectPoolManager = GetComponent<ObjectPoolManager>();
        globalManager.IniManage();
        objectPoolManager.IniObjectPool(10);
    }

    public void SetPanelAction(GameObject gameObject)
    {
        itemPanel.SetGameObjectAction(gameObject);
    }
    public void SetPanelItem(GameObject itemPrefab)
    {
        GameObject onClickButton = EventSystem.current.currentSelectedGameObject;
        ModelCollection model = globalManager.GetGameModel();
        if (onClickButton.name == "Brew")
        {
            GameWineRoots modelBuffer = model.gameWineRoots;
            foreach (GameWineItem gameWineItem in modelBuffer.GameWineRoot)
            {
                if (gameWineItem.isEnable == 1)
                {
                    GameObject itemBrewPanel = Instantiate(itemPrefab, objectCollection.brewPanel.transform);
                    itemBrewPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = gameWineItem.name;
                    itemBrewPanel.transform.GetChild(1).GetComponent<TMP_Text>().text = gameWineItem.pricePreTick + "/s";
                    itemBrewPanel.transform.GetChild(2).GetComponent<TMP_Text>().text = gameWineItem.fromWhere;
                    itemBrewPanel.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(() => TestFunction());
                    itemBrewPanel.transform.GetChild(4).GetComponent<RawImage>().color = Color.blue;
                }
            }
        }
    }
    public void DestroyAllItem(GameObject itemPanel)
    {
        for (int i = 0; i < itemPanel.transform.childCount; i++){
            Destroy(itemPanel.transform.GetChild(i).gameObject);
        }
    }

    public void TestFunction()
    {

    }
}
