public static class FileHelper
{
    public static string GetFileName(string path)
    {
        return Path.GetFileName(path);
    }
    public static string GetFileNameWithoutExtension(string path)
    {
        return Path.GetFileNameWithoutExtension(path);
    }
    public static string GetExtension(string path)
    {
        return Path.GetExtension(path);
    }
    public static string GetDirectoryName(string path)
    {
        return Path.GetDirectoryName(path);
    }
    public static string Combine(string path1, string path2)
    {
        return Path.Combine(path1, path2);
    }
    public static string Combine(string path1, string path2, string path3)
    {
        return Path.Combine(path1, path2, path3);
    }
    public static string Combine(string path1, string path2, string path3, string path4)
    {
        return Path.Combine(path1, path2, path3, path4);
    }
    //Write a file
    public static void WriteAllText(string path, string content)
    {
        File.WriteAllText(path, DateTime.Now.ToString() + Environment.NewLine + content);
        //File.WriteAllText(path, content, Encoding.UTF8);
    }
    //Create a directory
    public static void CreateDirectory(string path)
    {
        Directory.CreateDirectory(path);
    }
    //Create a file
    public static void CreateFile(string path)
    {
        File.Create(path);
    }
    //read a file
    public static string ReadAllText(string path)
    {
        return File.ReadAllText(path);

    }
    //append a file
    public static void AppendAllText(string path, string content)
    {
        File.AppendAllText(path, DateTime.Now.ToString() + Environment.NewLine + content);
        File.AppendAllText(path,"----------------------------------------------------" + Environment.NewLine);
    }
}