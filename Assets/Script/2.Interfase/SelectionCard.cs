﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionCard : MonoBehaviour
{
    private static SelectionCard _instans;
    private GameObject _prefabPanel;
    private GameObject _prefabItem;
    private GameObject _panel;

    private Transform _hud;
    private int _quantityItem;
    private int _quantityGetcard;
    private int _quantityGetcardNow;
    public static bool IsActivate => _instans._panel.activeSelf == true;

    public static void StaticShowSelectionCard(int QuantityItem, int QuantityGetcard, Invetory invetory, Card.TypeCard typeCard)
    {
        _instans.ShowSelectionCard(QuantityItem, QuantityGetcard, invetory, typeCard);
    }

    private void Awake()
    {
        _prefabPanel = Resources.Load<GameObject>("Object/SelectionCard");
        _prefabItem = Resources.Load<GameObject>("Object/ItemCard");
        _hud = GameObject.Find("HUD").transform;
        _instans = GameObject.Find("GameMeneger").GetComponent<SelectionCard>(); 
    }

    private void ShowSelectionCard(int QuantityItem,int QuantityGetcard , Invetory invetory, Card.TypeCard typeCard)
    {
        _quantityGetcard = QuantityGetcard;
        _quantityItem = QuantityItem;
        _quantityGetcardNow = 0;
        _panel  = Instantiate(_instans._prefabPanel, _hud);
        Transform ItemsPerrent = _panel.transform.Find("ItemsPerrent");
        for(int i=0;i<_quantityItem;i++)
        {
            GameObject tmp = Instantiate(_instans._prefabItem, ItemsPerrent);
            Card CardTmp = CardMenegercr.StaticRandCard(typeCard);
            tmp.transform.GetChild(0).GetChild(0).GetComponent<CardInfo>().SetCardInfo(CardTmp);
            tmp.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() =>
            {
                invetory.AddCard(tmp.transform.GetChild(0).GetChild(0).GetComponent<CardInfo>().GetCard);//исправить
                _quantityGetcardNow++;
                if(_quantityGetcardNow == _quantityGetcard)
                {
                    Destroy(_panel);
                }
                Destroy(tmp);
            });
        }
    }
}
