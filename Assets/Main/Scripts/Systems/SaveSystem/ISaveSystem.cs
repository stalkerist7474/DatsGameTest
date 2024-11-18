using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveSystem
{
    void Save(SaveData data);


    SaveData Load();
}