using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViewManagerItem : MonoBehaviour
{
    [SerializeField]
    private TMP_Text name;
    [SerializeField]
    private TMP_Text autor;
    [SerializeField]
    private TMP_Text likes;
    [SerializeField]
    private TMP_Text description;
    [SerializeField]
    private GameObject heart;
    [SerializeField]
    private GameObject heartlike;
    public int id;
    private float like;
    private Tridy item;
    private bool herat;
    public void ViewSpecificItem(Tridy item)
    {
        name.text = item.name;
        autor.text = $"Autor : {item.name_user}";
        like = item.likes;
        likes.text = item.likes.ToString();
        description.text = item.description;
        id = item.id;
        if (!herat) { 
        foreach (var s in UserData.Instance.PlayerData.likes) {
            if (this.id == s.tridy_id) {
                heart.SetActive(false);
                heartlike.SetActive(true);
            }
                else
                {
                    heart.SetActive(true);
                    heartlike.SetActive(false);
                }
                herat = true;
            }
       
        this.item = item;
    }
    }

    public void Like() {
        like = (like + 1);
        item.likes++;
        likes.text = like.ToString();
        heart.SetActive(false);
        heartlike.SetActive(true);
    }

    public void Dislike() {
        item.likes--;
        like = (like - 1);
        likes.text = like.ToString();
        heart.SetActive(true);
        heartlike.SetActive(false);
    }

}
