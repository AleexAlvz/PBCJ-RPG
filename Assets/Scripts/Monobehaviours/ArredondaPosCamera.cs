using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ArredondaPosCamera : CinemachineExtension
{

    public float PixelsPerUnit = 32;

    //Corrige a posi��o da camera p�s movimento
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            Vector3 pos = state.FinalPosition;
            Vector3 pos2 = new Vector3(Round(pos.x), Round(pos.y), pos.z);
            state.PositionCorrection += pos2 - pos;
        }
    }

    //Respons�vel por arredondar os valores de posi��o de acordo com os PixelsPerUnit
    float Round(float value)
    {
        return Mathf.Round(value * PixelsPerUnit) / PixelsPerUnit;
    }

}
