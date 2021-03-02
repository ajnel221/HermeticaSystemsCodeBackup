﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTerrainTexture : MonoBehaviour
{
    public Transform playerTransform;
    public Terrain t;

    public int posX;
    public int posZ;
    public float[] textureValues;

    public AudioSource source;
    public AudioClip[] stoneClips;
    public AudioClip[] dirtClips;
    public AudioClip[] sandClips;
    public AudioClip[] grassClips;
    AudioClip previousClip;

    void Start () 
    {
        t = Terrain.activeTerrain;
        playerTransform = gameObject.transform;
    }

    void Update()
    {
        // For better performance, move this out of update 
        // and only call it when you need a footstep.
        GetTerrainTexture();
    }

    public void GetTerrainTexture()
    {
        ConvertPosition(playerTransform.position);
        CheckTexture();
    }

    void ConvertPosition(Vector3 playerPosition)
    {
        Vector3 terrainPosition = playerPosition - t.transform.position;

        Vector3 mapPosition = new Vector3
        (terrainPosition.x / t.terrainData.size.x, 0,
        terrainPosition.z / t.terrainData.size.z);

        float xCoord = mapPosition.x * t.terrainData.alphamapWidth;
        float zCoord = mapPosition.z * t.terrainData.alphamapHeight;

        posX = (int)xCoord;
        posZ = (int)zCoord;
    }

    void CheckTexture()
    {
        float[,,] aMap = t.terrainData.GetAlphamaps (posX, posZ, 1, 1);
        textureValues[0] = aMap[0,0,0];
        textureValues[1] = aMap[0,0,1];
        textureValues[2] = aMap[0,0,2];
        textureValues[3] = aMap[0,0,3];
        textureValues[4] = aMap[0,0,4];
        textureValues[5] = aMap[0,0,5];
        textureValues[6] = aMap[0,0,6];
    }

    public void PlayFootstep()
    {   
        GetTerrainTexture();

        if (textureValues[0] > 0)
        {
            source.PlayOneShot(GetClip(dirtClips), textureValues[0]);
        }
        if (textureValues[1] > 0)
        {
            source.PlayOneShot(GetClip(grassClips), textureValues[1]);
        }
        if (textureValues[2] > 0)
        {
            source.PlayOneShot(GetClip(sandClips), textureValues[2]);
        }
        if (textureValues[3] > 0)
        {
            source.PlayOneShot(GetClip(stoneClips), textureValues[3]);
        }
        if (textureValues[4] > 0)
        {
            source.PlayOneShot(GetClip(stoneClips), textureValues[4]);
        }
        if (textureValues[5] > 0)
        {
            source.PlayOneShot(GetClip(dirtClips), textureValues[5]);
        }
        if (textureValues[6] > 0)
        {
            source.PlayOneShot(GetClip(stoneClips), textureValues[6]);
        }
    }

    AudioClip GetClip(AudioClip[] clipArray)
    {
        int attempts = 3;
        AudioClip selectedClip = 
        clipArray[Random.Range(0, clipArray.Length - 1)];

        while (selectedClip == previousClip && attempts > 0)
        {
            selectedClip = clipArray[Random.Range(0, clipArray.Length - 1)];
                
            attempts--;
        }

        previousClip = selectedClip;
        return selectedClip;
    }
}
