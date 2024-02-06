using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class FileProvider
{
    public static string DefaultApplicationPersistentDataPath = Application.persistentDataPath + "/";

    public static void SaveObjectToJSONFile<T>(T data, string path)
    {
        FileStream fs = null;
        try
        {
            fs = new FileStream(DefaultApplicationPersistentDataPath + path, FileMode.Create);
            string jsonFile = JsonUtility.ToJson(data);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, jsonFile);        
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
        finally
        {
            fs.Close();
        }
    }

    public static string LoadJSONFileAsString(string pathToFile)
    {
 
        if(File.Exists(DefaultApplicationPersistentDataPath + pathToFile))
        {
            FileStream fs = null;
            try
            {
                fs = File.Open(DefaultApplicationPersistentDataPath + pathToFile, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                string jsonFile = (string)bf.Deserialize(fs);
                return jsonFile;
            }
            catch (System.Exception e)
            {
                Debug.Log(e.Message);
                return "";
            }
            finally
            {
                fs.Close();
            }
        } 
        return "";
    }

    public static T LoadObjectFromJSONFile<T>(string pathToFile)
    {
        string jsonFile = LoadJSONFileAsString(pathToFile);
        if (jsonFile == "") return default;
        return JsonUtility.FromJson<T>(jsonFile);
    }

    public static void GetObjectFromJSONFile<T>(T Object,string pathToFile)
    {
        string jsonFile = LoadJSONFileAsString(pathToFile);
        if (jsonFile == "") return;
        JsonUtility.FromJsonOverwrite(jsonFile, Object);
    }

    public static bool IsFileExist(string file)
    {
        return File.Exists(DefaultApplicationPersistentDataPath + file);
    }

    public static void SaveToBFFile<T>(T data, string path)
    {
        FileStream fs = null;
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            fs = new FileStream(DefaultApplicationPersistentDataPath + path, FileMode.Create);
            bf.Serialize(fs,data);
            fs.Close();
        }
        catch(System.Exception Exception)
        {
            Debug.Log(Exception.Message);
        }
        finally
        {
            fs.Close();
        }
    }

    public static T LoadFromBFFile<T>(string pathToFile)
    {
        FileStream fs = null;
        
        try
        {
            fs = File.Open(DefaultApplicationPersistentDataPath + pathToFile, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            T temp = (T)bf.Deserialize(fs);     
            return temp;
        }
        catch(System.Exception Exception)
        {
            Debug.Log(Exception.Message);
        }
        finally
        {
            fs.Close();
        }
        
        return default;
    }

    public static void ResetFile(string pathToFile)
    {
        File.Delete(DefaultApplicationPersistentDataPath + pathToFile);
    }
}