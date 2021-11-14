using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
using PDollarGestureRecognizer; // for recognizer algorithm


public class Drawing : MonoBehaviour
{
    // Input
    public InputHelpers.Button drawInput;
    XRController _controller;

    // Line
    LineRenderer currentLine;
    public Transform drawPositionSource; //Source to draw the line
    List<Vector3> currentLinePosition = new List<Vector3>(); // Store the position of the line that is currently being created
    public float lineWidth = 0.03f;
    public Material lineMaterial;
    public float distanceThreshold = 0.01f;

    // Logic
    public bool isDrawing = false;

    // Unity Event
    public UnityEvent startDrawingEvent;
    public UnityEvent stopDrawingEvent;


    // Gestures
    public bool creationMode = true;
    public string newGestureName;
    private List<Gesture> trainingSet = new List<Gesture>();



    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<XRController>();
        
    }

    // Update is called once per frame
    void Update()
    {

        // Check for Input
        InputHelpers.IsPressed(_controller.inputDevice, drawInput, out bool isPressed);


        // Logic

        if (!isDrawing && isPressed)
            StartDrawing();

        else if (isDrawing && !isPressed)
            StopDrawing();

        else if (isDrawing && isPressed)
            UpdateDrawing();      
    }

    // Functions Needed

    void UpdateLine()
    {
        // Update Line's Position
        currentLinePosition.Add(drawPositionSource.position);
        currentLine.positionCount = currentLinePosition.Count;
        currentLine.SetPositions(currentLinePosition.ToArray());

        // Update the visual of the line
        currentLine.material = lineMaterial;
        currentLine.startWidth = lineWidth;

    }

    void StartDrawing()
    {
        isDrawing = true;
        startDrawingEvent?.Invoke();

        // Create the Line
        GameObject lineGameObject = new GameObject("Line");
        currentLine = lineGameObject.AddComponent<LineRenderer>();

        //Update Line (position and visual)
        UpdateLine();

    }

    void StopDrawing()
    {
        isDrawing = false;
        currentLinePosition.Clear();
        currentLine = null;

        stopDrawingEvent?.Invoke();

        Point[] pointArray = new Point[currentLinePosition.Count - 1];


        //solves the 3D to 2D 
        for (int i = 0; i < currentLinePosition.Count; i++)
        {
            Vector2 screenPoint = Camera.main.WorldToScreenPoint(currentLinePosition[i]);
            pointArray[i] = new Point(screenPoint.x, screenPoint.y, 0);
        }


        Gesture newGesture = new Gesture(pointArray);


        // Add new Gesture to training set
        if (creationMode)
        {
            newGesture.Name = newGestureName;
            trainingSet.Add(newGesture);
        }
        else // Recognize Gesture
        {
            Result result = PointCloudRecognizer.Classify(newGesture, trainingSet.ToArray());
        }
    }

    void UpdateDrawing()
    {
        if (!currentLine || currentLinePosition.Count == 0)
            return;

        Vector3 lastSetPosition = currentLinePosition[currentLinePosition.Count - 1];

        if (Vector3.Distance(lastSetPosition, drawPositionSource.position) > distanceThreshold)
            UpdateLine();

    }

    public void SetLineMaterial (Material newMaterial)
    {
        lineMaterial = newMaterial;
    }
}
