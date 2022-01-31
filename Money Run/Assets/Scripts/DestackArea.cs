using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestackArea : MonoBehaviour
{
    public Bounds myBounds;
    Renderer myrenderer;
   float limitX;
   float maxLimitZ;
    float minLimitZ;


    public Vector2 upperLeft;
    public Vector2 upperRight;
    public Vector2 downLeft;
    public Vector2 downRight;
    private void Awake()
    {
        myrenderer = GetComponent<Renderer>();
        myBounds = myrenderer.bounds;
        limitX = myBounds.extents.x;
        maxLimitZ = myBounds.extents.z + myBounds.center.z;
        minLimitZ = myBounds.center.z - myBounds.extents.z ;
        upperRight = new Vector2(limitX, maxLimitZ);
        downRight = new Vector2(limitX, minLimitZ);
        upperLeft = new Vector2(-limitX, maxLimitZ);
        downLeft = new Vector2(-limitX, minLimitZ);
    }


}
