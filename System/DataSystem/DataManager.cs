using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class DataManager : GlobalManager
{
    /// <summary>
    /// 反序列化获取数据模型 - using TRY
    /// </summary>
    /// <typeparam name="T">数据模型类型</typeparam>
    /// <param name="filePath">文件路径</param>
    /// <returns>返回解析的数据模型</returns>
    public T GetDataModel<T>(string filePath) where T : BaseModel
    {
        try
        {
            T buffer = default;
            buffer  = JsonConvert.DeserializeObject<T>(Resources.Load<TextAsset>("GameData/wine").text);
            return buffer;
        }
        catch (JsonException ex)
        {
            Debug.Log(globalHelper.ExceptionMessageCombine("falut", "GetDataModel", "DataMessager.cs"));
            Debug.Log(ex.Message);
            return default;
        }
    }

    /// <summary>
    /// 序列化存储数据到文件
    /// </summary>
    /// <typeparam name="T">数据模型类</typeparam>
    /// <param name="filePath">文件路径</param>
    /// <param name="model">数据模型</param>
    public void SaveDataModel<T>(string filePath, T model) where T : BaseModel
    {
        using (StreamWriter streamWriter = new StreamWriter(filePath))
        {
            streamWriter.WriteLine(JsonConvert.SerializeObject(model));
            streamWriter.Close();
        }
    }

}
