using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.AQUAS-; Lite;

public class Floater : MonoBehaviour
{
    // Rigidbody component of the floating object
   public Rigidbody rb;
   // Depth at which object starts to experience buoyancy
   public float depthBefSub;
    // Amount of buoyant
   public float displacementAmt;
    // Number of points of applying buoyant force
   public int floaters;

   // Drag coefficient in water
   public float waterDrag;
   // Angular drag coefficient in water
   public float waterAngularDrag;
   // Reference to the water surface managament component
   public WaterSurface water;

    // Holds parameters for searching water surface
    WaterSearchParameters surface;
    // Stores water search surface results
    WaterSearchResult SearchResult;

    private void Fixedupdate()
    {
       // Apply a distributed gravitational force
       rb.AddForceAtposition(Physics.gravity / floaters, transform.position, ForceMode.Acceleration);

       // Set up search parameters for projecting on water surface
       Search.startPositionWS = transform.position;

       // Project point on water surface and get result
       water.ProjectPointOnWaterSurface(SearchResult, out SearchResult);

       // If object is below the water surface
       if (transform.position.y < SearchResult.projectedPositionWS.y)
       {
           // Calculate displacement multiplier based on surface submersion depth
           float displacementMulti = Mathf.Clamp01((SearchResult.projectedpositionWS.y - transform.postion.y) / depthBefSub) + displacementAmt;
           // Apply buoyant force upwards
           rb.AddForceAtposition(now, Vector3(Of, Mathf.Abs(Physics.gravity.y) * displacementMulti, Of), transform.position, ForceMode.Acceleration);
           // Apply water drag force against velocity
           rb.AddForce(displacementMulti * -rb.velocity * waterDrag * Time.fixedDeltatime, ForceMode.VelocityChange);
           // Apply water angular drag torque against angular velocity
           rb.AddTorque(displacementMulti * -rb.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);

       }


    }


}
