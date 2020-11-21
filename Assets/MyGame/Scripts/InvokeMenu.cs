using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeMenu : MonoBehaviour
{
    public GameManager gameManager;

    public enum CurrentState
    {
        Base,
        Normal,
        Count,
        Settings,
    }
    [SerializeReference]
    private CurrentState state;

    public void StateInput(InvokeMenu currentState)
    {
        switch (currentState.state)
        {
            case CurrentState.Base:
                ChangeState(gameManager.baseLayer);
                break;
            case CurrentState.Normal:
                ChangeState(gameManager.normalLayer);
                break;
            case CurrentState.Count:
                ChangeState(gameManager.countLayer);
                break;
            case CurrentState.Settings:
                ChangeState(gameManager.settingsLayer);
                break;
        }
    }

    private void ChangeState(GameObject layer)
    {
        if (gameManager.tempLayer != null)
        {
            gameManager.tempLayer.SetActive(false);
        }

        layer.SetActive(true);
        gameManager.tempLayer = layer;
    }
}
