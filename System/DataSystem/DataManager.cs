using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class DataManager : GlobalManager
{
    /// <summary>
    /// �����л���ȡ����ģ�� - using TRY
    /// </summary>
    /// <typeparam name="T">����ģ������</typeparam>
    /// <param name="filePath">�ļ�·��</param>
    /// <returns>���ؽ���������ģ��</returns>
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
    /// ���л��洢���ݵ��ļ�
    /// </summary>
    /// <typeparam name="T">����ģ����</typeparam>
    /// <param name="filePath">�ļ�·��</param>
    /// <param name="model">����ģ��</param>
    public void SaveDataModel<T>(string filePath, T model) where T : BaseModel
    {
        using (StreamWriter streamWriter = new StreamWriter(filePath))
        {
            streamWriter.WriteLine(JsonConvert.SerializeObject(model));
            streamWriter.Close();
        }
    }

}
