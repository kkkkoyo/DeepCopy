using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
//using System.Threading.Tasks;

public static class ObjectExtention
{
	/// <summary>
	/// ディープコピーを作成する
	/// クローンするクラスには SerializableAttribute 属性、
	/// 不要なフィールドは NonSerializedAttribute 属性をつける
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="target"></param>
	/// <returns></returns>
	public static T DeepClone<T>(this T target)
	{
		object clone = null;
		using (MemoryStream stream = new MemoryStream())
		{
			BinaryFormatter formatter = new BinaryFormatter();
			formatter.Serialize(stream, target);
			stream.Position = 0;
			clone = formatter.Deserialize(stream);
		}

		return (T)clone;
	}
}
