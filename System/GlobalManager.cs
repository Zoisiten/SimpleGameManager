using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager
{
    protected GlobalHelper globalHelper;
    private ModelManager modelManager;

    /// <summary>
    /// 初始化！
    /// </summary>
    public void IniManage()
    {
        globalHelper = new GlobalHelper();
        modelManager = new ModelManager();
        modelManager.IniModel();
    }

    /// <summary>
    /// 委托注册
    /// </summary>
    public void RegisterEvent()
    {

    }

    /// <summary>
    /// 文件解析到游戏
    /// </summary>
    /// <typeparam name="T">数据模型类</typeparam>
    /// <param name="fileDictionary">文件字典，组成模式为K = 文件名字， V = 模型名字</param>
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
    /// 游戏数据存到文件
    /// </summary>
    /// <typeparam name="T">数据模型类</typeparam>
    /// <param name="model">数据模型</param>
    /// <param name="filePath">文件路径，字符串List</param>
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
    /// 获取游戏模型实例
    /// </summary>
    /// <returns>返回数据模型</returns>
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
    /// 自定义错误拼接
    /// </summary>
    /// <param name="status">状态</param>
    /// <param name="functionName">函数名</param>
    /// <param name="fileName">文件名</param>
    /// <param name="message">消息，默认为“NONE”</param>
    /// <returns>返回自定义错误字符串</returns>
    public string ExceptionMessageCombine(string status, string functionName, string fileName, string message = "None")
    {
        string errorBuffer = $"Run {status}, FunctionName:{functionName}, In:{fileName}, Message:{message}";
        return errorBuffer;
    }

    /// <summary>
    /// 路径拼接
    /// </summary>
    /// <param name="pathList">路径List</param>
    /// <returns>返回完整路径</returns>
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
