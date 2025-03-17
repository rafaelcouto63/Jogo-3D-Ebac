using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Ebac.Singleton;

public class CheckpointManager : Singleton<CheckpointManager>
{
    public int lastCheckpointKey = 0;

    public List<CheckpointBase> checkpoints;

    public bool HasCheckpoint()
    {
        return lastCheckpointKey > 0;
    }


    public void SaveCheckpoint(int i)
    {
        if(i > lastCheckpointKey) 
        {
            lastCheckpointKey = i;
        }
    }

    public Vector3 GetPositionLastCheckpoint()
    {
        var checkpoint  = checkpoints.Find(i => i.key == lastCheckpointKey);
        return checkpoint.transform.position;
    }

}
