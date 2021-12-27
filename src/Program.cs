// <copyright file="Progam.cs" company="Magic City Code">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
// <author>Justin Mooney</author>
// <date>12/26/2021</date>
// <summary>Program to generate code for a new entity object in Full Stack Hero Web API.</summary>

// See https://aka.ms/new-console-template for more information
using System.Globalization;

Console.WriteLine("Welcome to Full Stack Hero Web API Code Generator");


Console.Write("Template Directory: ");
var templateDir = Console.ReadLine();

if (!Directory.Exists(templateDir))
{
    Console.WriteLine($"Failed to find template directory {templateDir}");
}
else
{
    var outputDir = Path.Combine(templateDir, "Output");
    var brandDir = Path.Combine(templateDir, "Brand");

    // entity name
    Console.Write("Entity Name: ");
    var entityName = Console.ReadLine();
    // TODO: add a null/empty check

    // entity output directory
  //  var entityOutputDir = Path.Combine(outputDir, entityName);
   // if(Directory.Exists(entityOutputDir)) Directory.Delete(entityOutputDir, true);
    //Directory.CreateDirectory(entityOutputDir);

    // Get all files in the Brand directory.
    var files = Directory.GetFiles(brandDir, "*", SearchOption.AllDirectories);
    foreach (var file in files)
    {
        var fileInfo = new FileInfo(file);

        // TODO: replace text matching the case.
        // right now brands.json is not duplicated for the new entity name
        var newDirPath = fileInfo.DirectoryName.Replace("Brand", entityName);
        var newFilePath = fileInfo.FullName.Replace("Brand", entityName);
        var newFileName = fileInfo.Name.Replace("Brand", entityName);

        Directory.CreateDirectory(newDirPath);

        using(var newSileStream = File.Create(newFilePath))
        {
            // this is ugly, but it temporarily works :)
        }

        var newFileText = File.ReadAllText(file);
        newFileText = newFileText.Replace("Brand", entityName);
        newFileText = newFileText.Replace("brand", entityName.ToLower());

        await File.WriteAllTextAsync(newFilePath, newFileText);

        Console.WriteLine($"Created file: {newFilePath}");
    }
}
