using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetandBack : MonoBehaviour
{

    [SerializeField]
    private SpawnARItem spawnARItem;
    public void ResetMesh()
    {
        ItemsCreator.Instance.ResetMesh();
        spawnARItem.CreateItem();
    }

    public void Back()
    {
        ItemsCreator.Instance.GeneratedItems[ItemsCreator.Instance.GeneratedItems.Count - 1].gameObject.Destroy();
        ItemsCreator.Instance.GeneratedItems.RemoveAt(ItemsCreator.Instance.GeneratedItems.Count - 1);
    }
}
