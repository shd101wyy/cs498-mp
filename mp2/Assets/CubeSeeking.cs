using UnityEngine;
using System.Collections;

public class CubeSeeking : MonoBehaviour {

    public float cubeSize;
    public float moveSpeed;
    public int moves;
    private Vector3 nextPosition;
    enum State {Start, Moving, Done}
    State currentState;
    // Use this for initialization
	void Start () {
        moves = 0;
        currentState = State.Start;
        Vector3 startPosition = this.transform.position;
	}
	
	// Update is called once per frame
    void Update()
    {

        switch (currentState)
        {
            case State.Start:
                nextPosition = GameObject.Find("StartCube").transform.position;
                currentState = State.Moving;
                moves = moves + 1;
                break;

            case State.Moving:
                
                this.transform.position = Vector3.MoveTowards(this.transform.position, nextPosition, moveSpeed);
                if (this.transform.position == nextPosition)
                    nextPosition = DecideNextPosition();
                break;
        }
    }

    Vector3 DecideNextPosition()
{
    moves = moves + 1;
        //Debug.Log("Deciding next position");
    if (moves == 2)
        return GameObject.Find("Curved").transform.position;
    if (moves == 3)
        return GameObject.Find("Straight").transform.position;
    if (moves == 4)
        return new Vector3 (nextPosition.x, nextPosition.y, nextPosition.z + cubeSize);

    return nextPosition;

}

}
