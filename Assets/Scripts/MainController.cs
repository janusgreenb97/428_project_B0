using System;
using UnityEngine;

public class MainController : MonoBehaviour {

    #region Enums

    public enum TOGGLE_MODE : int {
        TARGET_OBJECT = KeyCode.F1,
        TARGET_CAMERA = KeyCode.F2
    }

    public enum KEYBOARD_INPUT : int {
        SPEED_MODIFIER = KeyCode.LeftShift,
        SPACE_MODIFIER = KeyCode.F3,
        YAW_POS = KeyCode.D,
        YAW_NEG = KeyCode.A,
        PITCH_POS = KeyCode.W,
        PITCH_NEG = KeyCode.S,
        ROLL_POS = KeyCode.Q,
        ROLL_NEG = KeyCode.E
    }

    #endregion

    #region Members

    public Transform TargetObject;
    [Range(1f, 20f)] public float ObjectRotationSpeed = 5f;
    public TOGGLE_MODE ToggleMode = TOGGLE_MODE.TARGET_CAMERA;
    
    private Transform g_Camera;

    private Space g_SpaceTarget = Space.World;

    #endregion

    #region Unity_Functions

    public void Start() {
        g_Camera = Camera.main.transform;
    }
    
    // Update is called once per frame
    void Update () {

        float speedMod = Input.GetKey((KeyCode)KEYBOARD_INPUT.SPEED_MODIFIER) ? 2f : 1f;

        if(Input.GetKeyDown((KeyCode)KEYBOARD_INPUT.SPACE_MODIFIER)) {
            if (g_SpaceTarget == Space.World) {
                g_SpaceTarget = Space.Self;
                Debug.Log("Space::Self");
            } else {
                g_SpaceTarget = Space.World;
                Debug.Log("Space::World");
            }
        }

        if (Input.GetKeyDown( (KeyCode) TOGGLE_MODE.TARGET_OBJECT) ) {
            ToggleMode = TOGGLE_MODE.TARGET_OBJECT;
            Debug.Log("Object Selected");
        } else if (Input.GetKeyDown((KeyCode)TOGGLE_MODE.TARGET_CAMERA)) {
            ToggleMode = TOGGLE_MODE.TARGET_CAMERA;
            Debug.Log("Camera Selected");
        }

        if(ToggleMode == TOGGLE_MODE.TARGET_OBJECT && TargetObject != null) {
            foreach (KEYBOARD_INPUT val in Enum.GetValues(typeof(KEYBOARD_INPUT))) {
                if(Input.GetKey((KeyCode) val)) {
                    switch(val) {
                        case KEYBOARD_INPUT.YAW_POS:
                            switch(g_SpaceTarget) {
                                case Space.World:
                                    TargetObject.RotateAround(Vector3.zero, Vector3.up, speedMod * ObjectRotationSpeed * Time.deltaTime);
                                    break;
                                case Space.Self:
                                    TargetObject.Rotate(TargetObject.up, speedMod * ObjectRotationSpeed * Time.deltaTime, Space.World);
                                    break;
                            }
                            break;
                        case KEYBOARD_INPUT.YAW_NEG:
                            switch (g_SpaceTarget) {
                                case Space.World:
                                    TargetObject.RotateAround(Vector3.zero, Vector3.up, -(speedMod * ObjectRotationSpeed * Time.deltaTime));
                                    break;
                                case Space.Self:
                                    TargetObject.Rotate(TargetObject.up, -(speedMod * ObjectRotationSpeed * Time.deltaTime), Space.World);
                                    break;
                            }
                            break;
                        case KEYBOARD_INPUT.PITCH_POS:
                            switch (g_SpaceTarget) {
                                case Space.World:
                                    TargetObject.RotateAround(Vector3.zero, Vector3.right, speedMod * ObjectRotationSpeed * Time.deltaTime);
                                    break;
                                case Space.Self:
                                    TargetObject.Rotate(TargetObject.right, speedMod * ObjectRotationSpeed * Time.deltaTime, Space.World);
                                    break;
                            }
                            break;
                        case KEYBOARD_INPUT.PITCH_NEG:
                            switch (g_SpaceTarget) {
                                case Space.World:
                                    TargetObject.RotateAround(Vector3.zero, Vector3.right, -(speedMod * ObjectRotationSpeed * Time.deltaTime));
                                    break;
                                case Space.Self:
                                    TargetObject.Rotate(TargetObject.right, -(speedMod * ObjectRotationSpeed * Time.deltaTime), Space.World);
                                    break;
                            }
                            break;
                        case KEYBOARD_INPUT.ROLL_POS:
                            switch (g_SpaceTarget) {
                                case Space.World:
                                    TargetObject.RotateAround(Vector3.zero, Vector3.forward, speedMod * ObjectRotationSpeed * Time.deltaTime);
                                    break;
                                case Space.Self:
                                    TargetObject.Rotate(TargetObject.forward, speedMod * ObjectRotationSpeed * Time.deltaTime, Space.World);
                                    break;
                            }
                            break;
                        case KEYBOARD_INPUT.ROLL_NEG:
                            switch (g_SpaceTarget) {
                                case Space.World:
                                    TargetObject.RotateAround(Vector3.zero, Vector3.forward, -(speedMod * ObjectRotationSpeed * Time.deltaTime));
                                    break;
                                case Space.Self:
                                    TargetObject.Rotate(TargetObject.forward, -(speedMod * ObjectRotationSpeed * Time.deltaTime), Space.World);
                                    break;
                            }
                            break;
                    }
                }
                
            }
        } else if (ToggleMode == TOGGLE_MODE.TARGET_CAMERA && g_Camera != null) {
            foreach (KEYBOARD_INPUT val in Enum.GetValues(typeof(KEYBOARD_INPUT))) {
                // TODO - YOU complete the camera transformations now!
            }
        }

        // DEBUG INFO
        if (TargetObject != null) {
            if(g_SpaceTarget == Space.World) {
                Debug.DrawRay(TargetObject.position, Vector3.forward, Color.blue);
                Debug.DrawRay(TargetObject.position, Vector3.right, Color.red);
                Debug.DrawRay(TargetObject.position, Vector3.up, Color.green);
            } else {
                Debug.DrawRay(TargetObject.position, TargetObject.forward, Color.blue);
                Debug.DrawRay(TargetObject.position, TargetObject.right, Color.red);
                Debug.DrawRay(TargetObject.position, TargetObject.up, Color.green);
            }
        }

    }

    #endregion


}
