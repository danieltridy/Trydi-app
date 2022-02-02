using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mapbox.Examples
{
	public class DragableDirectionWaypoint : MonoBehaviour
	{
        public event Action MouseDown;
        public event Action MouseDraging;
        public event Action MouseDrop;
        public Transform MoveTarget;
		private Vector3 screenPoint;
		private Vector3 offset;
		private Plane _yPlane;

		public void Start()
		{
			_yPlane = new Plane(Vector3.up, Vector3.zero);
		}

		void OnMouseDrag()
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			float enter = 0.0f;
            if (MouseDraging != null)
                MouseDraging();
			if (_yPlane.Raycast(ray, out enter))
			{
				MoveTarget.position = ray.GetPoint(enter);
			}
		}

        private void OnMouseDown()
        {
            if (MouseDown != null)
                MouseDown();
        }

        private void OnMouseUp()
        {
            if (MouseDrop != null)
                MouseDrop();
        }
    }
}
