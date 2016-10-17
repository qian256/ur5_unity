// Author: Long Qian
// Email: lqian8@jhu.edu

using UnityEngine;
using System.Collections;

public class UR5Controller : MonoBehaviour {

    public GameObject RobotBase;
    public float[] jointValues = new float[6];
    private GameObject[] jointList = new GameObject[6];
    private float[] upperLimit = { 180f, 180f, 180f, 180f, 180f, 180f };
    private float[] lowerLimit = { -180f, -180f, -180f, -180f, -180f, -180f };

    // Use this for initialization
    void Start () {
        initializeJoints();
	    
	}
	
	// Update is called once per frame
	void LateUpdate () {
        for ( int i = 0; i < 6; i ++) {
            Vector3 currentRotation = jointList[i].transform.localEulerAngles;
            Debug.Log(currentRotation);
            currentRotation.z = jointValues[i];
            jointList[i].transform.localEulerAngles = currentRotation;
        }
	}

    void OnGUI() {
        int boundary = 20;
        int labelHeight = 20;
        GUI.skin.label.alignment = TextAnchor.MiddleLeft;
        for (int i = 0; i < 6; i++) {
            GUI.Label(new Rect(boundary, boundary + i * labelHeight, 60, 20), "Joint " + i + ": ");
            jointValues[i] = GUI.HorizontalSlider(new Rect(boundary + 60, boundary + i * labelHeight + 4, 100, 20), jointValues[i], lowerLimit[i], upperLimit[i]);
        }
    }


    // Create the list of GameObjects that represent each joint of the robot
    void initializeJoints() {
        var RobotChildren = RobotBase.GetComponentsInChildren<Transform>();
        for (int i = 0; i < RobotChildren.Length; i++) {
            if (RobotChildren[i].name == "control0") {
                jointList[0] = RobotChildren[i].gameObject;
            }
            else if (RobotChildren[i].name == "control1") {
                jointList[1] = RobotChildren[i].gameObject;
            }
            else if (RobotChildren[i].name == "control2") {
                jointList[2] = RobotChildren[i].gameObject;
            }
            else if (RobotChildren[i].name == "control3") {
                jointList[3] = RobotChildren[i].gameObject;
            }
            else if (RobotChildren[i].name == "control4") {
                jointList[4] = RobotChildren[i].gameObject;
            }
            else if (RobotChildren[i].name == "control5") {
                jointList[5] = RobotChildren[i].gameObject;
            }
        }
    }
}
