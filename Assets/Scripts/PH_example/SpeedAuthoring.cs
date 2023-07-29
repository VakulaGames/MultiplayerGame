using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class SpeedAuthoring : MonoBehaviour
{
    public float Value;
}

public class SpeedBaker : Baker<SpeedAuthoring>
{
    public override void Bake(SpeedAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new Speed
        {
            Value = authoring.Value
        });
    }
}


// Examples
//public struct DependentData : IComponentData
//{
//    public float Distance;
//    public int VertexCount;
//}

//public class DependentDataAuthoring : MonoBehaviour
//{
//    public GameObject Other;
//    public Mesh Mesh;
//}

//public class GetComponentBaker : Baker<DependentDataAuthoring>
//{
//    public override void Bake(DependentDataAuthoring authoring)
//    {
//        // Before any early out, declare a dependency towards the external references.
//        // Because even if those evaluate to null, they might still be a proper Unity
//        // reference to a missing object. The dependency ensures that the baker will
//        // be triggered when those objects are restored.

//        DependsOn(authoring.Other);
//        DependsOn(authoring.Mesh);

//        if (authoring.Other == null) return;
//        if (authoring.Mesh == null) return;

//        var transform = GetComponent<Transform>();
//        var transformOther = GetComponent<Transform>(authoring.Other);

//        // The checks below that ensure the component exists aren't necessary in this
//        // case, because Transform will always be present on any GameObject.
//        // As a general principle, checking against missing components is recommended.

//        if (transform == null) return;
//        if (transformOther == null) return;

//        var entity = GetEntity(TransformUsageFlags.Dynamic);
//        AddComponent(entity, new DependentData
//        {
//            Distance = Vector3.Distance(transform.position, transformOther.position),
//            VertexCount = authoring.Mesh.vertexCount
//        });
//    }
