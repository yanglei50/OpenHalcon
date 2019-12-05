using DALSA.SaperaLT.SapClassBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFVisionInspection
{
    public partial class CameraSetting : Form
    {
        private int serverCount;
        private int cameraIndex = 0;
        private string serverName = "";
        private string userDefinedName = "";
        private SapAcqDevice acqDevice = null;

        public CameraSetting()
        {
            InitializeComponent();
        }

        private void CameraSetting_Load(object sender, EventArgs e)
        {
            //BaseForm_Load(sender, e);
            SapManager.DisplayStatusMode = SapManager.StatusMode.Log;
            serverCount = SapManager.GetServerCount();
            cameraIndex = 0;

        }

        private void btn_findcamera_Click(object sender, EventArgs e)
        {
            Console.WriteLine(cb_cameraselect.SelectedIndex);
            switch (cb_cameraselect.SelectedIndex)
            {
                case 0:
                    Console.WriteLine("\n\nCameras listed by User Defined Name:\n");

                    for (int serverIndex = 0; serverIndex < serverCount; serverIndex++)
                    {
                        if (SapManager.GetResourceCount(serverIndex, SapManager.ResourceType.AcqDevice) != 0)
                        {
                            SapLocation location = new SapLocation(SapManager.GetServerName(serverIndex), 0);
                            acqDevice = new SapAcqDevice(location);

                            // Create acquisition device object
                            bool status = acqDevice.Create();
                            if (status && acqDevice.FeatureCount > 0)
                            {
                                // Get User Defined Name Feature Value
                                status = acqDevice.GetFeatureValue("DeviceUserID", new SapLut(tx_commandparameter.Text.ToString()));
                                Console.WriteLine("{0}/ {1}", cameraIndex + 1, status ? userDefinedName : "N/A");
                                cameraIndex++;
                            }

                            // Destroy acquisition device object
                            acqDevice.Destroy();
                        }
                    }
                    if (cameraIndex == 0)
                        Console.WriteLine("No camera found !");
                    if (acqDevice != null)
                        acqDevice.Dispose();
                    break;
                case 1:
                    Console.WriteLine("\n\nCameras listed by Serial Number:\n");
                    string serialNumberName = "";

                    for (int serverIndex = 0; serverIndex < serverCount; serverIndex++)
                    {
                        if (SapManager.GetResourceCount(serverIndex, SapManager.ResourceType.AcqDevice) != 0)
                        {
                            SapLocation location = new SapLocation(SapManager.GetServerName(serverIndex), 0);
                            acqDevice = new SapAcqDevice(location);

                            // Create acquisition device object
                            bool status = acqDevice.Create();
                            if (status && acqDevice.FeatureCount > 0)
                            {
                                // Get Serial Number Feature Value
                                status = acqDevice.GetFeatureValue("DeviceID", out serialNumberName);
                                Console.WriteLine("{0}/ {1}", cameraIndex + 1, status ? serialNumberName : "N/A");
                                cameraIndex++;
                            }

                            // Destroy acquisition device object
                            acqDevice.Destroy();
                        }
                    }
                    if (cameraIndex == 0)
                        Console.WriteLine("No camera found !");
                    if (acqDevice != null)
                        acqDevice.Dispose();
                    break;
                case 2:
                    Console.WriteLine("\n\nCameras listed by Server Name:\n");

                    for (int serverIndex = 0; serverIndex < serverCount; serverIndex++)
                    {
                        if (SapManager.GetResourceCount(serverIndex, SapManager.ResourceType.AcqDevice) != 0)
                        {
                            SapLocation location = new SapLocation(SapManager.GetServerName(serverIndex), 0);
                            acqDevice = new SapAcqDevice(location);

                            // Create acquisition device object
                            bool status = acqDevice.Create();
                            if (status && acqDevice.FeatureCount > 0)
                            {
                                // Get Server Name Value
                                Console.WriteLine("{0}/ {1}", cameraIndex + 1, SapManager.GetServerName(serverIndex));
                                cameraIndex++;
                            }

                            // Destroy acquisition device object
                            acqDevice.Destroy();
                        }
                    }
                    if (cameraIndex == 0)
                        Console.WriteLine("No camera found !");
                    if (acqDevice != null)
                        acqDevice.Dispose();
                    break;
                case 3:
                    Console.WriteLine("\n\nCameras listed by Model Name:\n");
                    string deviceModelName = "";

                    for (int serverIndex = 0; serverIndex < serverCount; serverIndex++)
                    {
                        if (SapManager.GetResourceCount(serverIndex, SapManager.ResourceType.AcqDevice) != 0)
                        {
                            SapLocation location = new SapLocation(SapManager.GetServerName(serverIndex), 0);
                            acqDevice = new SapAcqDevice(location);

                            // Create acquisition device object
                            bool status = acqDevice.Create();
                            if (status && acqDevice.FeatureCount > 0)
                            {
                                // Get Model Name Feature Value
                                status = acqDevice.GetFeatureValue("DeviceModelName", out deviceModelName);
                                Console.WriteLine("{0}/ {1}", cameraIndex + 1, status ? deviceModelName : "N/A");
                                cameraIndex++;
                            }

                            // Destroy acquisition device object
                            acqDevice.Destroy();
                        }
                    }
                    if (cameraIndex == 0)
                        Console.WriteLine("No camera found !");
                    if (acqDevice != null)
                        acqDevice.Dispose();
                    break;
                case 4:
                    Console.WriteLine("Please type the user defined name:\n");
                    userDefinedName = Console.ReadLine();
                    serverName = SapManager.GetServerName(userDefinedName);
                    if (serverName.Length > 0)
                        Console.WriteLine("\nServer name for {0} is {1}", userDefinedName, serverName);
                    else
                        Console.WriteLine("\nNo server found for {0}", userDefinedName);
                    break;
                case 5:
                    Console.Write("\nDetecting new CameraLink camera servers... ");
                    if (SapManager.DetectAllServers(SapManager.DetectServerType.All))
                    {
                        // let time for the detection to execute
                        Thread.Sleep(5000);

                        // get the new server count
                        serverCount = SapManager.GetServerCount();

                        Console.WriteLine("complete\n");
                    }
                    else
                    {
                        Console.WriteLine("failed\n");
                    }
                    break;
            }
        }

        private void btn_autowhitebalance_Click(object sender, EventArgs e)
        {
            GigEAutoWhiteBalance.Done();
        }
    }
}
