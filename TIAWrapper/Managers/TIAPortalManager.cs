using TIAWrapper.Interfaces;
using TIAWrapper.Models.Requests;
using TIAWrapper.Models.Responses;
using System;
using System.IO;
using System.Linq;
using Siemens.Engineering;
using Siemens.Engineering.HW;
using Siemens.Engineering.HW.Features;
using Siemens.Engineering.SW;
using Siemens.Engineering.SW.Blocks;

// ==========================================================
// Uncomment after adding Siemens Openness DLL
// ==========================================================

// using Siemens.Engineering;
// using Siemens.Engineering.HW;
// using Siemens.Engineering.Hmi;
// using Siemens.Engineering.Compiler;

namespace TIAWrapper.Managers;

public class TIAPortalManager : ITIAPortalManager
{
    private bool _connected = false;

    // ==========================================================
    // Siemens Objects
    // Uncomment after adding Siemens DLL
    // ==========================================================

    // private TiaPortal? _tiaPortal;
    // private Project? _currentProject;

    public async Task<ApiResponse> ConnectAsync()
    {
        _connected = true;
        return await Task.FromResult(
            new ApiResponse
            {
                Success = true,
                Message = "Connected Successfully"
            });
    }



    // public async Task<ApiResponse> ConnectAsync()
    // {
    //     try
    //     {
    //         Console.WriteLine("=================================");
    //         Console.WriteLine("CONNECTING TO TIA PORTAL");
    //         Console.WriteLine("=================================");

            // ==========================================================
            // TODO
            //
            // Start new TIA Portal
            //
            // _tiaPortal =
            //      new TiaPortal(
            //          TiaPortalMode.WithUserInterface
            //      );
            //
            // OR
            //
            // Attach to existing TIA process
            //
            // TiaPortal.GetProcesses()
            //
            // ==========================================================

    //         _connected = true;

    //         return await Task.FromResult(
    //             new ApiResponse
    //             {
    //                 Success = true,
    //                 Message = "Connected Successfully"
    //             });
    //     }
    //     catch (Exception ex)
    //     {
    //         return new ApiResponse
    //         {
    //             Success = false,
    //             Message = ex.Message
    //         };
    //     }
    // }

    public async Task<ApiResponse> DisconnectAsync()
    {
        _connected = false;
        return await Task.FromResult(
            new ApiResponse
            {
                Success = true,
                Message = "Disconnected Successfully"
            });
    }

    // public async Task<ApiResponse> DisconnectAsync()
    // {
    //     try
    //     {
    //         Console.WriteLine("Disconnecting...");

            // ==========================================================
            // TODO
            //
            // _currentProject?.Dispose();
            //
            // _tiaPortal?.Dispose();
            //
            // ==========================================================

    //         _connected = false;

    //         return await Task.FromResult(
    //             new ApiResponse
    //             {
    //                 Success = true,
    //                 Message = "Disconnected Successfully"
    //             });
    //     }
    //     catch (Exception ex)
    //     {
    //         return new ApiResponse
    //         {
    //             Success = false,
    //             Message = ex.Message
    //         };
    //     }
    // }

    public bool IsConnected()
    {
        return _connected;
    }


        
    public Task<ApiResponse> CreateProjectAsync(CreateProjectRequest request)
    {
        try
        {
            Console.WriteLine($"Project : {request.ProjectName}");
            Console.WriteLine($"Directory : {request.Directory}");

            using (var tiaPortal =
                new TiaPortal(TiaPortalMode.WithUserInterface))
            {
                Console.WriteLine("TIA Portal started");

                //------------------------------------
                // Create Project
                //------------------------------------

                Project project = tiaPortal.Projects.Create(
                    new DirectoryInfo(request.Directory),
                    request.ProjectName);

                Console.WriteLine($"Project created: {project.Name}");

                //------------------------------------
                // Create CPU
                //------------------------------------

                Device device =
                    project.Devices.CreateWithItem(
                        "OrderNumber:6ES7 517-3FP00-0AB0/V3.0",
                        "PLC_1",
                        "PLC_1");

                Console.WriteLine("CPU created");

                //------------------------------------
                // Find PLC Software
                //------------------------------------

                DeviceItem softwareItem =
                    FindSoftwareContainer(device.DeviceItems);

                if (softwareItem == null)
                {
                    return Task.FromResult(new ApiResponse
                    {
                        Success = false,
                        Message = "Software container not found"
                    });
                }

                SoftwareContainer softwareContainer =
                    softwareItem.GetService<SoftwareContainer>();

                PlcSoftware plcSoftware =
                    softwareContainer?.Software as PlcSoftware;

                if (plcSoftware == null)
                {
                    return Task.FromResult(new ApiResponse
                    {
                        Success = false,
                        Message = "PLC software not found"
                    });
                }

                //------------------------------------
                // Create FB under Program Blocks
                //------------------------------------

                FB fb = plcSoftware.BlockGroup.Blocks.CreateFB(
                    "FB_Test",
                    true,
                    0,
                    ProgrammingLanguage.SCL);

                Console.WriteLine($"Created FB: {fb.Name}");

                //------------------------------------
                // Save Project
                //------------------------------------

                project.Save();

                return Task.FromResult(new ApiResponse
                {
                    Success = true,
                    Message = $"Project '{project.Name}' created successfully with CPU and FB_Test block."
                });
            }
        }
        catch (Exception ex)
        {
            return Task.FromResult(new ApiResponse
            {
                Success = false,
                Message = ex.ToString()
            });
        }
    }

    static DeviceItem FindSoftwareContainer(
            DeviceItemComposition items)
        {
            foreach (DeviceItem item in items)
            {
                var container =
                    item.GetService<SoftwareContainer>();

                if (container != null)
                    return item;

                DeviceItem child =
                    FindSoftwareContainer(item.DeviceItems);

                if (child != null)
                    return child;
            }

            return null;
        }

        static void PrintItems(
            DeviceItemComposition items,
            string indent)
        {
            foreach (DeviceItem item in items)
            {
                Console.WriteLine(
                    $"{indent}- {item.Name}");

                PrintItems(
                    item.DeviceItems,
                    indent + "  ");
            }
        }
    

    public Task<ApiResponse> SaveProjectAsync()
    {
        Console.WriteLine("Saving Project");
        // ==========================================================
        // TODO
        //
        // _currentProject.Save();
        //
        // ==========================================================
        return Task.FromResult(new ApiResponse
        {
            Success = true,
            Message = "Project Saved"
        });
    }

    public Task<ApiResponse> OpenProjectAsync(string projectPath)
    {
        Console.WriteLine($"Opening : {projectPath}");
        // ==========================================================
        // TODO
        //
        // FileInfo project =
        //
        //      new FileInfo(projectPath);
        //
        // _currentProject =
        //
        //      _tiaPortal
        //          .Projects
        //          .Open(project);
        //
        // ==========================================================
        return Task.FromResult(new ApiResponse
        {
            Success = true,
            Message = "Project Opened"
        });
    }

    public Task<ApiResponse> CreatePLCAsync(CreatePLCRequest request)
    {
        Console.WriteLine("=================================");
        Console.WriteLine("TIA PLC CREATE");
        Console.WriteLine("=================================");

        // ==========================================================
        // TODO 
        //
        // Use Siemens Openness
        //
        // Create PLC
        //
        // DeviceComposition.Create(...)
        //
        // Select catalog entry
        //
        // Assign Device Name
        //
        // ==========================================================

        Console.WriteLine($"PLC Type : {request.PlcType}");
        Console.WriteLine($"Device Name : {request.DeviceName}");

        return Task.FromResult(new ApiResponse
        {
            Success = true,
            Message = "PLC Created Successfully"
        });
    }
    public Task<ApiResponse> CreateHMIAsync(CreateHMIRequest request)
    {
        Console.WriteLine("=================================");
        Console.WriteLine("TIA HMI CREATE");
        Console.WriteLine("=================================");

        // ==========================================================
        // TODO
        //
        // Use Siemens Openness
        //
        // Create HMI
        //
        // DeviceComposition.Create(...)
        //
        // Assign Device Name
        //
        // ==========================================================

        Console.WriteLine($"HMI Type : {request.HmiType}");
        Console.WriteLine($"Device Name : {request.DeviceName}");

        return Task.FromResult(new ApiResponse
        {
            Success = true,
            Message = "HMI Created Successfully"
        });
    }
}