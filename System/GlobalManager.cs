using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager
{
    protected GlobalHelper globalHelper;
    private ModelManager modelManager;

    /// <summary>
    /// ��ʼ����
    /// </summary>
    public void IniManage()
    {
        globalHelper = new GlobalHelper();
        modelManager = new ModelManager();
        modelManager.IniModel();
    }

    /// <summary>
    /// ί��ע��
    /// </summary>
    public void RegisterEvent()
    {

    }

    /// <summary>
    /// �ļ���������Ϸ
    /// </summary>
    /// <typeparam name="T">����ģ����</typeparam>
    /// <param name="fileDictionary">�ļ��ֵ䣬���ģʽΪK = �ļ����֣� V = ģ������</param>
    public void FileToGame<T>(Dictionary<string, string> fileDictionary) where T : BaseModel
    {
        DataManager dataManager = new DataManager();
        ModelCollection modelCollection = GetGameModel();
        T modelBuffer = default;
        foreach (string modelName in fileDictionary.Keys)
        {
            modelBuffer = dataManager.GetDataModel<T>(fileDictionary[modelName]);
            if (modelName == "GameInWine")
            {
                ModelUpdatas<GameWineRoots>(modelBuffer as GameWineRoots);
            }else if (modelName == "PlayerStore")
            {
                ModelUpdatas<PlayerStoreRoots>(modelBuffer as PlayerStoreRoots);
            }else if (modelName == "PlayerInfomation")
            {
                ModelUpdatas<PlayerInfomation>(modelBuffer as PlayerInfomation);
            }
        }
   
    }

    /// <summary>
    /// ��Ϸ���ݴ浽�ļ�
    /// </summary>
    /// <typeparam name="T">����ģ����</typeparam>
    /// <param name="model">����ģ��</param>
    /// <param name="filePath">�ļ�·�����ַ���List</param>
    public void GameToFile<T>(T model, params string[] filePath) where T : BaseModel
    {
        DataManager dataManager = new DataManager();
        string path = globalHelper.PathCombine(filePath);
        dataManager.SaveDataModel(path, model);
    }

    public void UpdataModel(int modelType, int valueID, int valueContext)
    {
        modelManager.ModifyValue(modelType, valueID);
    }

    /// <summary>
    /// ��ȡ��Ϸģ��ʵ��
    /// </summary>
    /// <returns>��������ģ��</returns>
    public ModelCollection GetGameModel()
    {
        return modelManager.ReturnModel();
    }

    public void ModelUpdatas<T>(T model) where T : BaseModel
    {
        modelManager.ModelUpdata(model);
    }
}

public class GlobalHelper: GlobalManager
{
    /// <summary>
    /// �Զ������ƴ��
    /// </summary>
    /// <param name="status">״̬</param>
    /// <param name="functionName">������</param>
    /// <param name="fileName">�ļ���</param>
    /// <param name="message">��Ϣ��Ĭ��Ϊ��NONE��</param>
    /// <returns>�����Զ�������ַ���</returns>
    public string ExceptionMessageCombine(string status, string functionName, string fileName, string message = "None")
    {
        string errorBuffer = $"Run {status}, FunctionName:{functionName}, In:{fileName}, Message:{message}";
        return errorBuffer;
    }

    /// <summary>
    /// ·��ƴ��
    /// </summary>
    /// <param name="pathList">·��List</param>
    /// <returns>��������·��</returns>
    public string PathCombine(string[] pathList)
    {
        string path = null;
        foreach (string item in pathList)
        {
            path += item;
        }
        return path;
    }
}
