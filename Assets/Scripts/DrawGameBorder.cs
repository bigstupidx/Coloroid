using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter)), ExecuteInEditMode]
public class DrawGameBorder : MonoBehaviour {
		public int SegmentCount;
		public float OuterRadius;
		public float InnerRadius;
		public float DeltaStart;
		public float DeltaSize;
		public string parentName;
		private Mesh _mesh;
		private Vector3[] vertices;

		private void Start() {
			_mesh = new Mesh();
		    GetComponent<MeshFilter>().sharedMesh = _mesh;
			UpdateMesh ();	
		}
			
		private void UpdateMesh() {
			_mesh.Clear();
			vertices = new Vector3[(SegmentCount + 1) * 2];
			int[] indices = new int[SegmentCount * 6];
			for (int i = 0; i <= SegmentCount; ++i)
			{
				float angle = (DeltaStart * Mathf.Deg2Rad) + ((DeltaSize * Mathf.Deg2Rad) / SegmentCount) * i;
				Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
				vertices[i * 2] = direction * OuterRadius;
				vertices[(i * 2) + 1] = direction * InnerRadius;
			}
			for (int i = 0; i < SegmentCount; ++i)
			{
				int baseIndex = i * 6;
				indices[baseIndex] = (i * 2);
				indices[baseIndex + 1] = ((i * 2) + 1);
				indices[baseIndex + 2] = (((i + 1) * 2) + 1);
				indices[baseIndex + 3] = (((i + 1) * 2) + 1);
				indices[baseIndex + 4] = ((i + 1) * 2);
				indices[baseIndex + 5] = (i * 2);
			}
			_mesh.vertices = vertices;
			_mesh.triangles = indices;

			Color[] colors = new Color[vertices.Length];

			for (int i = 0; i < vertices.Length; i++)
				colors[i] = Color.Lerp(Color.red, Color.green, vertices[i].y);

			_mesh.colors = colors;	

			AddColliderToDraw (vertices);
		}

	public void AddColliderToDraw(Vector3[] vertices) {
		GameObject col = new GameObject("EdgeCollider");
		col.AddComponent<EdgeCollider2D>();
		col.tag = "BorderCollider";
		col.transform.parent = GameObject.Find(parentName).transform;
		int arrayLength = vertices.Length / 2;
		Vector2[] vertices2 = new Vector2[arrayLength];

		int j = 0;
		for(int i = 0; i < vertices.Length; i++) {
			if((i % 2) != 0) {
				vertices2[j] = (Vector2)vertices[i];
				j++;
			}
		}
	
		col.GetComponent<EdgeCollider2D>().points = vertices2;
	}
}
