﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public void NewGame(int lvl1)
    {
        SceneManager.LoadScene(lvl1);

    }

}
