using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SplineMesh
{
    /// <summary>
    /// Example of component to show that the spline is an independant mathematical component and can be used for other purposes than mesh deformation.
    /// 
    /// This component is only for demo purpose and is not intended to be used as-is.
    /// 
    /// We only move an object along the spline. Imagine a camera route, a ship patrol...
    /// </summary>
    [ExecuteInEditMode]
    [RequireComponent(typeof(Spline))]
    public class ExampleFollowSpline : MonoBehaviour
    {
        private GameObject generated;
        private Spline spline;
        private float rate = 0;

        public GameObject Follower;
        public float DurationInSecond;

        private void OnEnable()
        {
            rate = 0;
            string generatedName = "generated by " + GetType().Name;
            var generatedTranform = transform.Find(generatedName);
            generated = generatedTranform != null ? generatedTranform.gameObject : Instantiate(Follower, gameObject.transform);
            generated.name = generatedName;

            spline = GetComponent<Spline>();
#if UNITY_EDITOR
            EditorApplication.update += EditorUpdate;
#endif
        }

        void OnDisable()
        {
#if UNITY_EDITOR
            EditorApplication.update -= EditorUpdate;
#endif
        }

        void EditorUpdate()
        {
            rate += Time.deltaTime / DurationInSecond;
            if (rate > spline.nodes.Count - 1)
            {
                rate -= spline.nodes.Count - 1;
            }
            PlaceFollower();
        }

        private void PlaceFollower()
        {
            if (generated != null)
            {
                CurveSample sample = spline.GetSample(rate);
                generated.transform.localPosition = sample.location;
                generated.transform.localRotation = sample.Rotation;
            }
        }
    }
}