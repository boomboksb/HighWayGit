using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarSelection : MonoBehaviour
{
    public GameObject[] cars;
    public Button Next;
    public Button Prev;
    public int index;

    public void Start()
    {
        index = PlayerPrefs.GetInt("car Index");
        for (int i = 0; i < cars.Length; i++)
        {
            cars[i].SetActive(false);
            cars[index].SetActive(true);
        }
    }

    public void Update()
    {
        if (index >= 1)
        {
            Next.interactable = false;
        }
        else 
        {
            Next.interactable= true;
        }

        if (index <= 0)
        {
            Prev.interactable = false;
        }
        else
        {
            Prev.interactable = true;
        }          

    }
    public void NextBut()
    {
        index++;
        for (int i = 0; i < cars.Length; i++)
        {
            cars[(i)].SetActive(false);
            cars[(index)].SetActive(true);
        }
        PlayerPrefs.SetInt("carIndex", index);
        PlayerPrefs.Save();
    }
    public void PrevBut()
    {
        index--;
        for (int i = 0; i < cars.Length; i++)
        {
            cars[(i)].SetActive(false);
            cars[(index)].SetActive(true);
        }
        PlayerPrefs.SetInt("carIndex", index);
        PlayerPrefs.Save();
    }

    public void Confirm()
    {
        SceneManager.LoadSceneAsync("level 1");
    }

}
