using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class History : MonoBehaviour
{
    [SerializeField]

    private PrefabsPanel prefabsPanel;
    [SerializeField]
   private Transform transform;
    public void HistoryDates() {

        foreach(var item in UserData.Instance.items)
        {
            PrefabsPanel tempInstantiate = Instantiate(prefabsPanel, transform);
            tempInstantiate.Setup(item);
        }

    }
}
