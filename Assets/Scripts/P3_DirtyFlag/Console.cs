using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;
using Random = UnityEngine.Random;

public class Console : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private int _redParameter;
    private int _greenParameter;
    private int _blueParameter;
    private Color _computedColor;
    private int _tick;

#region information on how many updates would've been necessary
    private Color _previousColor; // IGNORE THIS
    private static int _totalUpdateCount; // IGNORE THIS
    private static int _requiredUpdateCount; // IGNORE THIS
#endregion

    void Start()
    {
        this._spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void FixedUpdate()
    {
        // This will on random occasion change one or more parameters
        SimulateVariousChangesOfParameters();

        // This will on random occasion return true
        if (ShouldUseComputedParameterThisFrame())
            UtilizeComputedParameter(); // this is where the computed parameter is used
    }

    /// <summary>
    /// This method simulates that various parameters can change on this class.
    /// </summary>
    void SimulateVariousChangesOfParameters()
    {
        float randomRoll = Random.Range(0f, 1f);
        if (randomRoll < 0.2f)
        {
            SetRed(Random.Range(0, 256));
        }
        if (randomRoll < 0.05f)
        {
            SetGreen(Random.Range(0, 256));
        }
        if (randomRoll < 0.1f)
        {
            SetBlue(Random.Range(0, 256));
        }
    }
    
    /// <summary>
    /// This is one of the parameters that can be changed on this class
    /// </summary>
    /// <param name="red"></param>
    void SetRed(int red)
    {
        this._redParameter = red;
        // When the parameter has changed, the computed parameter needs to be updated
        CalculateComputedDataFromParameters();
    }

    /// <summary>
    /// This is one of the parameters that can be changed on this class
    /// </summary>
    /// <param name="green"></param>
    void SetGreen(int green)
    {
        this._greenParameter = green;
        // When the parameter has changed, the computed parameter needs to be updated
        CalculateComputedDataFromParameters();
    }

    /// <summary>
    /// This is one of the parameters that can be changed on this class
    /// </summary>
    /// <param name="blue"></param>
    void SetBlue(int blue)
    {
        this._blueParameter = blue;
        // When the parameter has changed, the computed parameter needs to be updated
        CalculateComputedDataFromParameters();
    }

    /// <summary>
    /// This method simulates information that needs to be processed whenever one of many parameters change.
    /// In real scenarios, this could be:
    /// - The position of the parent Transform that affects our position
    /// - The Layout of the parent RectTransform that affects our Layout
    /// - The health of the player that can change 100x in a frame in a very busy game that affects all sorts of UIs
    /// </summary>
    void CalculateComputedDataFromParameters()
    {
        _totalUpdateCount++;
        this._computedColor = new Color(_redParameter / 255f, _greenParameter / 255f, _blueParameter / 255f);
        Thread.Sleep(1); // DO NOT REMOVE
    }

    bool ShouldUseComputedParameterThisFrame()
    {
        this._tick++;
        return this._tick % 50 == 0;
    }

    void UtilizeComputedParameter()
    {
        #region debug information on how many updates would've been necessary
        if (this._previousColor != new Color(_redParameter / 255f, _greenParameter / 255f, _blueParameter / 255f)) // IGNORE THIS
        { // IGNORE THIS
            _requiredUpdateCount++; // IGNORE THIS
            this._previousColor = this._computedColor; // IGNORE THIS
        } // IGNORE THIS
        Debug.Log($"Updated: {_totalUpdateCount}/{_requiredUpdateCount} times."); // IGNORE THIS
        #endregion // debug information on how many updates would've been necessary
            
        this._spriteRenderer.color = this._computedColor;
    }
}
