// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using PoteitronCore.Converters;
using PoteitronCore.Handlers;
using PoteitronCore.Models;
using System.CommandLine;
using System.CommandLine.IO;

//string inputFile = Environment.GetCommandLineArgs()[1];
//string inputType = Environment.GetCommandLineArgs()[2];
//string inputComponentName = Environment.GetCommandLineArgs()[2];
//Console.WriteLine(inputFile);


Option<string> componentTypeOption = new(
    name: "--component-type",
    description: "Type of component: grid | form | formPopup | filters | emptyPage | gridPopup");
Option<string> inputFileOption = new(
    name: "--input-file",
    description: "input json file");
Option<string> componentNameOption = new(
    name: "--component-name",
    description: "Name of the component");

RootCommand rootCommand = new(description: "Generate React componet base on json file input")
{
    componentTypeOption,
    inputFileOption,
    componentNameOption,
};

rootCommand.SetHandler(async (string componentType, string inputFile, string componentName) =>
{

    var code = "";
    if (componentType == "grid")
    {
        var gridHandler = new GridHandler();
        code = gridHandler.GenerateCode(inputFile, "Template\\GridLocal.txt", componentName);
    }
    else if (componentType == "form")
    {
        var formRender = new FormRender();

        code = formRender.GenerateCode(inputFile, "Template\\FormComponent.txt", componentName);
    }
    else if (componentType == "gridPopup")
    {
        var gridHandler = new GridHandler();

        code = gridHandler.GenerateCode(inputFile, "Template\\GridPopup.txt", componentName);
    }
    else if (componentType == "formPopup")
    {
        var formRender = new FormRender();

        code = formRender.GenerateCode(inputFile, "Template\\FormPopup.txt", componentName);
    }
    else if (componentType == "filters")
    {
        var filterHandler = new FilterHandler();

        code = filterHandler.GenerateCode(inputFile, "Template\\FiltersComponent.txt", componentName);
    }
    else if (componentType == "emptyPage")
    {
        var emptyHandler = new EmptyHandler();
        code = emptyHandler.GenerateCode(componentName);
    }
    Console.WriteLine(code);
    Console.ReadLine();


}, componentTypeOption,
    inputFileOption,
    componentNameOption);

await rootCommand.InvokeAsync(args);

//Option<Verbosity> verbosityOption = new(
//    aliases: new[] { "--verbosity", "-v" },
//    description: "The verbosity of the output");


//var inputFilePath = "FormDefinition\\quantity.json";
//var inputFilePath = inputFile;//"GridDefinition\\studiesSelect.json"; 
//var type = inputType; //"grid"; //grid/form/formPopup/filters/emptyPage/gridPopup
//var componentName = inputComponentName;//= "StudiesGrid";



