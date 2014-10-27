using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;

[XmlRoot("SpawnableEntityCollection")]
public class SpawnableEntityContainer
{ 
	[XmlArray("SpawnableEntities")]
	[XmlArrayItem("SpawnableEntity")]
	public List<SpawnableEntity> SpawnableEntities = new List<SpawnableEntity>();

	public void Save(string path)
	{
		var serializer = new XmlSerializer(typeof(SpawnableEntityContainer));
		using(var stream = new FileStream(path, FileMode.Create))
		{
			serializer.Serialize(stream, this);
		}
	}
	
	public static SpawnableEntityContainer Load(string path)
	{
		var serializer = new XmlSerializer(typeof(SpawnableEntityContainer));
		using(var stream = new FileStream(path, FileMode.Open))
		{
			return serializer.Deserialize(stream) as SpawnableEntityContainer;
		}
	}
	
	//Loads the xml directly from the given string. Useful in combination with www.text.
	public static SpawnableEntityContainer LoadFromText(string text) 
	{
		var serializer = new XmlSerializer(typeof(SpawnableEntityContainer));
		return serializer.Deserialize(new StringReader(text)) as SpawnableEntityContainer;
	}
}

