using System;
using System.IO;

public static class FindFile
{
    private static void TraverseDirDFS(DirectoryInfo dir, string spaces, string fileName)
    {
        try
        {
            Console.WriteLine(spaces + dir.FullName);
            DirectoryInfo[] children = dir.GetDirectories();
            foreach (DirectoryInfo child in children)
            {
                TraverseDir($"{file.Name} is found in { dir.FullName}.");
            }
        }
        catch
        {
            Console.WriteLine($"No access to {dir}");
        }
    }

    public static void TraverseDirDFS(string directoryPath, string fileName)
    {
        TraverseDirDFS(new DirectoryInfo(directoryPath), string.Empty, fileName);
    }

    static void Main()
    {
        
        TraverseDirDFS(@"E:\BOBO\C#\TreesBfsDfsExer"); 
    }
}