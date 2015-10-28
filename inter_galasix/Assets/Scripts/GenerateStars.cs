using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateStars : MonoBehaviour {
	List<Vector3> vertices = new List<Vector3>();
	List<int> triangles = new List<int>();


	
	int[] relative_square_indexes = new int[6] {2, 1, 0, 2, 3, 1 }; //raspored indexa tacaka za pravljenje kvadrata
	Vector3[] relative_square_vectors = new Vector3[4];

	public int number_of_stars;
	public float default_star_size = 0.05f;
	public float star_size_variation = 0;
	public float space_width, space_height, space_depth;
	void Start () {
		CreateStars();
	}


	void CreateStars() {
		//ciscenje svemira

		vertices.Clear();
		triangles.Clear();


		//referenciranje i inicijalizacija
		Mesh mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;

		float vary_size = Random.Range(0, star_size_variation);
		float star_size = default_star_size + vary_size;
		
																			//							__________
		relative_square_vectors[0] = Vector3.zero;							//nulta tacka			   2|		  |3
		relative_square_vectors[1] = new Vector3(star_size, 0, 0);			//samo desno				|  zvezda |
		relative_square_vectors[2] = new Vector3(0, star_size, 0);			//samo gore					|		  |
		relative_square_vectors[3] = new Vector3(star_size, star_size, 0);	//desno gore			   0|_________|1


		//generisanje random pozicija tacaka u prostoru
		List<Vector3> random_places_for_stars = new List<Vector3>();

		for (int i = 0; i < number_of_stars; i++)
		{
			float x = Random.Range(-space_width, space_width);
			float y = Random.Range(-space_height, space_height);
			float z = Random.Range(-space_depth, space_depth);
			Vector3 position = new Vector3(x, y, z);
			random_places_for_stars.Add(position);	 
		}


		//generisanje niza vekora i indeksa za svaku poziciju

		for (int i = 0; i < number_of_stars; i++) {
			//indexi
			foreach (int index in relative_square_indexes) {
				int new_index = 4 * i + index;
				triangles.Add(new_index);
			}

			//vektori
			foreach (Vector3 vektor in relative_square_vectors) {
				Vector3 new_vector = vektor + random_places_for_stars[i];
				vertices.Add(new_vector);
			}
		}


		//pravljenje mesha
		mesh.vertices = vertices.ToArray();
		mesh.triangles = triangles.ToArray();
		mesh.RecalculateNormals();	

	}

	void Update() {

		if (Input.GetKeyDown(KeyCode.A)) {
			CreateStars();
		}
	}



}
