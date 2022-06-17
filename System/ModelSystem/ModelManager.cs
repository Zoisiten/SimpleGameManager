using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ModelManager: GlobalManager
{
    private ModelCollection modelCollection;

    public void IniModel()
    {
        modelCollection = new ModelCollection();
    }

    public ModelCollection ReturnModel()
    {
        return modelCollection;
    }
    public void ModelUpdata<T>(T model) where T : BaseModel
    {
        if (model is GameWineRoots)
        {
            modelCollection.gameWineRoots = model as GameWineRoots;
        }else if (model is PlayerInfomation)
        {
            modelCollection.playerInfomation = model as PlayerInfomation;
        }else if (model is PlayerStoreRoots)
        {
            modelCollection.playerStoreRoots = model as PlayerStoreRoots;
        }
    }
    public void ModifyValue(int modelType, int valueID)
    {
        if (modelType == 1)
        {
            //playerInfo
        }else if (modelType == 2)
        {
            //wineInfo
        }else if (modelType == 3)
        {
            //test
            var linqFind = 
                from linqFlag in modelCollection.gameWineRoots.GameWineRoot
                where linqFlag.ID == valueID
                select linqFlag;
            foreach(var linq in linqFind)
            {
                linq.cost = linq.cost + 1;
            }
        }
    }
}