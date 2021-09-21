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
    private List<PrefabsPanel> list = new List<PrefabsPanel>();

    public void HistoryDates() {


        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        list.Clear();
        list = new List<PrefabsPanel>();


        foreach (var item in UserData.Instance.items)
        {
            PrefabsPanel tempInstantiate = Instantiate(prefabsPanel, transform);
            tempInstantiate.Setup(item);
            list.Add(tempInstantiate);

        } 

        string text = $"HISTÓRICO DE RENDIMIENTO DE {UserData.Instance.usuario.name}";
        name.text = text.ToUpper();
 
    }



    public void ListSad() {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        foreach (var item in UserData.Instance.items)
        {
            if (item.estado == 0) {
                PrefabsPanel tempInstantiate = Instantiate(prefabsPanel, transform);
                tempInstantiate.Setup(item);
                list.Add(tempInstantiate);
            }

        }


        foreach (var item in UserData.Instance.items)
        {
            if (item.estado == 1)
            {
                PrefabsPanel tempInstantiate = Instantiate(prefabsPanel, transform);
                tempInstantiate.Setup(item);
                list.Add(tempInstantiate);
            }

        }

    }


    public void ListHappy()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        foreach (var item in UserData.Instance.items)
        {
            if (item.estado == 1)
            {
                PrefabsPanel tempInstantiate = Instantiate(prefabsPanel, transform);
                tempInstantiate.Setup(item);
                list.Add(tempInstantiate);
            }

        }

        foreach (var item in UserData.Instance.items)
        {
            if (item.estado == 0)
            {
                PrefabsPanel tempInstantiate = Instantiate(prefabsPanel, transform);
                tempInstantiate.Setup(item);
                list.Add(tempInstantiate);
            }

        }

    }
}
