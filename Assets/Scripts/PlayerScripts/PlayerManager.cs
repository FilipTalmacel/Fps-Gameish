﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager playerInstance;

    private void Awake()
    {
        playerInstance = this;
    }

    #endregion
    public GameObject player;
    public GameObject body;
}
