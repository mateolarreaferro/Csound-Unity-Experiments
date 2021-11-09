using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;


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
    public float distanceThreshold = 0.05f;

    // Logic
    public bool isDrawing = false;

    // Unity Event
    public UnityEvent startDrawingEvent;
    public UnityEvent stopDrawingEvent;


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
