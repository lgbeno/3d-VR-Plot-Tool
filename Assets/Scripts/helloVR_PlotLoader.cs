using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;  

public class helloVR_PlotLoader : MonoBehaviour {
	private Vector3 offset;
	private Quaternion angles;
	public GameObject plotPointPrefab;

	// Use this for initialization
	void Start () {
		offset = transform.position;
		angles = transform.rotation;
		Load("C://DataSet.csv");
	}

	// Update is called once per frame
	void Update () {

	}

	private bool Load(string fileName)
	{
			string line;
			// Create a new StreamReader, tell it which file to read and what encoding the file
			// was saved as
			StreamReader theReader = new StreamReader(fileName, Encoding.Default);
			// Immediately clean up the reader after this block of code is done.
			// You generally use the "using" statement for potentially memory-intensive objects
			// instead of relying on garbage collection.
			// (Do not confuse this with the using directive for namespace at the 
			// beginning of a class!)
			using (theReader)
			{
				// While there's lines left in the text file, do this:
				do
				{
					line = theReader.ReadLine();

					if (line != null)
					{
						// Do whatever you need to do with the text line, it's a string now
						// In this example, I split it into arguments based on comma
						// deliniators, then send that array to DoStuff()
						string[] entries = line.Split(',');
						if (entries.Length > 0)
						{
							if (entries[0]=="C4") {
							Vector3 point_position = new Vector3(float.Parse(entries[1])*2,float.Parse(entries[2])*2,float.Parse(entries[3])*2);
							GameObject bPrefab = Instantiate(plotPointPrefab, point_position, Quaternion.identity) as GameObject;
							}
						}

					}
				}
				while (line != null);
				// Done reading, close the reader and return true to broadcast success    
				theReader.Close();
				return true;
			}
	}
}