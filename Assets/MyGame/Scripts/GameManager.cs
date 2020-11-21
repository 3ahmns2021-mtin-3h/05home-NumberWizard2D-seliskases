using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Menu")]
    public GameObject baseLayer;
    public GameObject normalLayer;
    public GameObject countLayer;
    public GameObject settingsLayer;
    [HideInInspector]
    public GameObject tempLayer;

    private void OnEnable()
    {
        tempLayer = baseLayer;
    }

    #region Singleton

    public void ChangeRange(bool isTrue)
    {
        rangeIsChanging = isTrue;
    }
    public static bool rangeIsChanging;

    public void SelfDestruction(bool isTrue)
    {
        selfDestruction = isTrue;
    }
    public static bool selfDestruction;

    #endregion
}
