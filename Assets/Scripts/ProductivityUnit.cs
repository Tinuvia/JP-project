using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    private ResourcePile m_CurrentPile = null;
    public float ProductivityMultiplier = 2;

    protected override void BuildingInRange()
    {
        // this prevents the code from running more than once
        if (m_CurrentPile == null)
        {
            //Checking wether m_Target is a resource pile type, with "as ResourcePile"
            ResourcePile pile = m_Target as ResourcePile; 
                        
            if (pile != null)
            {
                m_CurrentPile = pile;
                m_CurrentPile.ProductionSpeed *= ProductivityMultiplier;
            }
        }
    }

    void ResetProductivity()
    {
        if (m_CurrentPile != null)
        {
            m_CurrentPile.ProductionSpeed /= ProductivityMultiplier;
            m_CurrentPile = null;
        }
    }

    public override void GoTo(Building target)
    {
        ResetProductivity();
        base.GoTo(target); // run the method from the base class, in addition to the added functionality
    }

    public override void GoTo(Vector3 position)
    {
        ResetProductivity();
        base.GoTo(position); // run the method from the base class, in addition to the added functionality
    }
}
