using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class History : MonoBehaviour
{
    [SerializeField]
    private PrefabsPanel prefabsPanel;
    [SerializeField]
    private Transform transform;
    [SerializeField]
    private Text name;

    public void HistoryDates() {


        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }


        foreach (var item in UserData.Instance.items)
        {
            PrefabsPanel tempInstantiate = Instantiate(prefabsPanel, transform);
            tempInstantiate.Setup(item);
        } 

        string text = $"HISTÓRICO DE RENDIMIENTO DE {UserData.Instance.usuario.name}";
        name.text = text.ToUpper();
 
    }


}
