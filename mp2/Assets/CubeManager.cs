using UnityEngine;
using System.Collections;

public class CubeManager : MonoBehaviour
{
    public int gridSize;
    public int gridScale;
    public Vector3 startPosition;
    private int startNum;
    private Vector3 endPosition;
    private GameObject emptyPrefab;
    private GameObject straightPrefab;
    private GameObject curvyPrefab;
    private GameObject[] cubes;
    private GameObject seeker;
    private int totalCubes;
    enum State { Deciding, Moving, Done }
    private State currentState;
    // Use this for initialization
    void Start()
    {
        //Makes modifies the start positions from 1-3 to 0-2 because that's how c# counts, for some reason
        startPosition = new Vector3(startPosition.x - 1, startPosition.y - 1, startPosition.z - 1);
        startNum = Mathf.FloorToInt((startPosition.x * 9f) + (startPosition.y * 3) + startPosition.z);
        endPosition = new Vector3 (gridSize,gridSize,gridSize);
        totalCubes = gridSize * gridSize * gridSize;
        emptyPrefab = Resources.Load("Empty") as GameObject;
        straightPrefab = Resources.Load("Straight") as GameObject;
        curvyPrefab = Resources.Load("Curvy") as GameObject;
        cubes = new GameObject[totalCubes];
        currentState = State.Deciding;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentState);
        switch (currentState)
        {
            case State.Deciding:
                PlaceEmptyCubes();
                PlacePath();
                PlaceSphere();
                currentState = State.Moving;
                break;

            case State.Moving:
                MoveSphere();
                break;
        }

    }

    void PlaceEmptyCubes()
    {
        //Makes a grid of empty cubes
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                for (int z = 0; z < gridSize; z++)
                {
                    int cubeCounter = x * 9 + y * 3 + z;
                    Vector3 cubePosition = new Vector3(x, y, z) * gridScale;
                    cubes[cubeCounter] = Instantiate(emptyPrefab, cubePosition, Quaternion.identity) as GameObject;
                    Debug.Log(cubeCounter);
                }
            }
        }
    }

    void PlacePath()
    {
        bool pathComplete = false;
        bool yFixed = false;
        bool xFixed = false;
        bool zFixed = false;
        Vector3 currentPosition = startPosition;
        //Makes The Path
        while (!pathComplete)
        {
            int cubeCounter = Mathf.FloorToInt((currentPosition.x * 9f) + (currentPosition.y * 3) + currentPosition.z);
            Destroy(cubes[cubeCounter]);
            //Y Difference
            if (!yFixed)
            {
                float yDiff = (endPosition.y - currentPosition.y);
                if (yDiff > 1)
                {
                    cubes[cubeCounter] = Instantiate(straightPrefab, currentPosition, Quaternion.identity) as GameObject;
                    currentPosition.y += 1;
                }
                else
                {
                    cubes[cubeCounter] = Instantiate(curvyPrefab, currentPosition, Quaternion.identity) as GameObject;
                    //currentPosition.y += 1;
                    yFixed = true;
                    currentPosition.z += 1;
                    Debug.Log("Going to try and put a straight one in " + currentPosition);
                }
            }
            else if (!zFixed)
            {
                float zDiff = (endPosition.z - currentPosition.z);
                Debug.Log("zDiff = " + zDiff);
                if (zDiff > 1)
                {
                    Debug.Log("Making straight because the ydiff is " + zDiff);
                    Debug.Log("Inserting straight at " + cubeCounter);
                    cubes[cubeCounter] = Instantiate(straightPrefab, currentPosition, Quaternion.Euler(90f, 0f, 0f)) as GameObject;
                    currentPosition.z += 1;
                }
                else
                {
                    cubes[cubeCounter] = Instantiate(curvyPrefab, currentPosition, Quaternion.Euler(0f, 180f, -90f)) as GameObject;
                    currentPosition.x += 1;
                    zFixed = true;
                }
            }
            else if (!xFixed)
            {
                float xDiff = (endPosition.x - currentPosition.x);
                Debug.Log("xDiff = " + xDiff);
                if (xDiff > 1)
                {
                    Debug.Log("Making straight because the xdiff is " + xDiff);
                    Debug.Log("Inserting straight at " + cubeCounter);
                    cubes[cubeCounter] = Instantiate(straightPrefab, currentPosition, Quaternion.Euler(0f, 0f, 90f)) as GameObject;
                    currentPosition.x += 1;
                }
                else
                {
                    cubes[cubeCounter] = Instantiate(straightPrefab, currentPosition, Quaternion.Euler(0f, 0f, 90f)) as GameObject;
                    currentPosition.x += 1;
                    xFixed = true;
                }
            }
            if (zFixed && yFixed && xFixed)
                pathComplete = true;
        }
    }

    void PlaceSphere()
    {
        Debug.Log("Placing Sphere");
        Vector3 seekerStartPosition = new Vector3 (cubes[startNum].transform.position.x, cubes[startNum].transform.position.y-1, cubes[startNum].transform.position.z);
        seeker = Instantiate(Resources.Load("Seeker"), seekerStartPosition, Quaternion.identity) as GameObject;
    }
    void MoveSphere()
    {
    }
}
