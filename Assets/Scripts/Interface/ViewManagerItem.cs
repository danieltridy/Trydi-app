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
    private TMP_Text looks;
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
    public Tridy item;
    private bool herat;
    public void ViewSpecificItem(Tridy item)
    {
        name.text = item.name;
        autor.text = $"Autor : {item.name_user}";
        like = item.likes;
        likes.text = item.likes.ToString();
        description.text = item.description;
        item.looks++;
        looks.text = item.looks.ToString();
        id = item.id;
        if (!herat) {
            if (UserData.Instance.PlayerData.likes != null) { 
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
            }
        }
        else
        {
            if (item.like) {
                heart.SetActive(false);
                heartlike.SetActive(true);
            }
            else if (!item.like) {
                heart.SetActive(true);
                heartlike.SetActive(false);
            }
        }
        this.item = item;
    }

    public void ViewSpecificItemM(MTridys item)
    {
        name.text = item.name;
        autor.text = $"Autor : {item.name_user}";
        like = item.likes;
        likes.text = item.likes.ToString();
        description.text = item.description;
        looks.text = item.looks.ToString();
        id = item.id;
    }

    public void Like() {
        like = (like + 1);
        item.likes++;
        item.like = true;
        likes.text = like.ToString();
        heart.SetActive(false);
        heartlike.SetActive(true);
    }

    public void Dislike() {
        item.likes--;
        like = (like - 1);
        likes.text = like.ToString();
        item.like = false;
        heart.SetActive(true);
        heartlike.SetActive(false);
    }

}
