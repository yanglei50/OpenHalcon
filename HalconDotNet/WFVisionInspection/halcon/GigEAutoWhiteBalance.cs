
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using DALSA.SaperaLT.SapClassBasic;


namespace WFVisionInspection
{
    class GigEAutoWhiteBalance
    {

        const double MAX_COEF =1.05;
        const int MAX_CALIBRATION_ITERATION = 100;
        const int GVSP_PIX_BAYRG8  =  (0x01000000 | 0x00080000 | 0x0009);
   

        static void Xfer_XferNotify(object sender, SapXferNotifyEventArgs args)
        {
            SapView view = args.Context as SapView;
            view.Show();
        }
        
        //static void Main(string[] args)
        public static void Done()
        {
            SapAcqDevice camera = null;
            SapView view = null;
            SapTransfer transfer = null;
            SapBuffer buffer = null;

            Console.WriteLine("Sapera Console GigE Cameras AutoWhiteBalance Example (C# version)\n");

            MyAcquisitionParams acqParams = new MyAcquisitionParams();

            /*if (!GetOptions(args, acqParams))
            {
                Console.WriteLine("\nPress any key to terminate\n");
                Console.ReadKey();
                return;
            }*/
            SapLocation location = new SapLocation(acqParams.ServerName, acqParams.ResourceIndex);
                 

            camera = new SapAcqDevice(location, acqParams.ConfigFileName);
            buffer = new SapBufferWithTrash(2, camera, SapBuffer.MemoryType.ScatterGather);
            transfer = new SapAcqDeviceToBuf(camera, buffer);
            view = new SapView(buffer);

            // End of frame event
            transfer.Pairs[0].EventType = SapXferPair.XferEventType.EndOfFrame;
            transfer.XferNotify += new SapXferNotifyHandler(Xfer_XferNotify);
            transfer.XferNotifyContext = view;

            if (!camera.Create())
            {
                Console.WriteLine("Error during SapAcquisition creation!\n");
                DestroysObjects(camera, buffer, transfer, view);
                return;
            }

            // Monochrome models are not supported for White Balance Calibration.
            int colorType = 0;
            bool isAvailable = false;
            if (isAvailable = camera.IsFeatureAvailable("ColorType"))
            {
                if (camera.GetFeatureValue("ColorType", out colorType))
                {
                    if (colorType == 0)
                    {
                        Console.WriteLine("This camera model does not support Auto White Balance calibration.\n");
                        DestroysObjects(camera, buffer, transfer, view);
                        return;
                    }
                }
            }


            //activate feature only if camera has 3 separate gains

            Boolean bRedGain = false;
            Boolean bGreenGain = false;
            Boolean bBlueGain = false;
            bRedGain = camera.IsFeatureAvailable("GainRed");
            bGreenGain = camera.IsFeatureAvailable("GainGreen");
            bBlueGain = camera.IsFeatureAvailable("GainBlue");
            if (!bRedGain && !bGreenGain && !bBlueGain)
            {
                Console.WriteLine("This camera model does not support Auto White Balance calibration.\n");
                DestroysObjects(camera, buffer, transfer, view);
                return;
            }

            // Create buffer object
            if (!buffer.Create())
            {
                Console.WriteLine("Error during SapBuffer creation!\n");
                DestroysObjects(camera, buffer, transfer, view);
                return;
            }

            // Create transfer object
            if (!transfer.Create())
            {
                Console.WriteLine("Error during SapTransfer creation!\n");
                DestroysObjects(camera, buffer, transfer, view);
                return;
            }

            // Create view object
            if (!view.Create())
            {
                Console.WriteLine("Error during SapView creation!\n");
                DestroysObjects(camera, buffer, transfer, view);
                return;
            }

            Console.WriteLine("Press any key to start Grab. Press 'q' to quit.");
            ConsoleKeyInfo info = Console.ReadKey(true);
            char key = info.KeyChar;
            if (key != 0)
            {
                if (key == 'q')
                {
                   DestroysObjects(camera, buffer, transfer, view);
                   return;
                }
            }

            // Start continous grab
            transfer.Grab();

            Console.WriteLine("Press any key to stop grab\n");
            Console.ReadKey();

            // Stop grab
            transfer.Freeze();
            transfer.Wait(5000);

            Console.WriteLine("Press any key to start Auto White Balance calibration. Press 'q' to quit.\n");
            info = Console.ReadKey(true);
            key = info.KeyChar;
            if (key != 0)
            {
                if (key == 'q')
                {
                   DestroysObjects(camera, buffer, transfer, view);
                   return;
                }
            }

            int oldPixelFormat = 0;
            isAvailable = false;
            if (isAvailable = camera.IsFeatureAvailable("PixelFormat"))
            {
                camera.GetFeatureValue("PixelFormat", out oldPixelFormat);
            }
            else
            {
                Console.WriteLine("This camera model does not support Auto White Balance calibration.\n");
                DestroysObjects(camera, buffer, transfer, view);
                return;
            }
            
            if (oldPixelFormat != GVSP_PIX_BAYRG8)
            {
                // Camera Pixel Format defined is not Raw Bayer.
                // We change the value

               DestroysObjects(null, buffer, transfer, view);
             
                camera.SetFeatureValue("PixelFormat", GVSP_PIX_BAYRG8);
              
                // Instantiation of new buffer object
                buffer = new SapBufferWithTrash(2, camera, SapBuffer.MemoryType.ScatterGather);
                // Instantiation of new view object
                view = new SapView(buffer);
                // Instantiation of new transfer object
                transfer = new SapAcqDeviceToBuf(camera, buffer);

                // End of frame event
                transfer.Pairs[0].EventType = SapXferPair.XferEventType.EndOfFrame;
                transfer.XferNotify += new SapXferNotifyHandler(Xfer_XferNotify);
                transfer.XferNotifyContext = view;

                if (!camera.Create())
                {
                    Console.WriteLine("Error during SapAcquisition creation!\n");
                    DestroysObjects(camera, buffer, transfer, view);
                    return;
                }

                // Create buffer object
                if (!buffer.Create())
                {
                    Console.WriteLine("Error during SapBuffer creation!\n");
                    DestroysObjects(camera, buffer, transfer, view);
                    return;
                }

                // Create transfer object
                if (!transfer.Create())
                {
                    Console.WriteLine("Error during SapTransfer creation!\n");
                    DestroysObjects(camera, buffer, transfer, view);
                    return;
                }

                // Create view object
                if (!view.Create())
                {
                    Console.WriteLine("Error during SapView creation!\n");
                    DestroysObjects(camera, buffer, transfer, view);
                    return;
                }           
            }


            if (!AutoWhiteBalanceOperations(camera, buffer, transfer))
            {
               Console.WriteLine("Auto WhiteBalamce has failed");
               DestroysObjects(camera, buffer, transfer, view);
               return;
            }

            if (oldPixelFormat != GVSP_PIX_BAYRG8)
            {
                // Camera Pixel Format was changed for Raw Bayer.
                // We set the original value.
               DestroysObjects(null, buffer, transfer, view);
               
                camera.SetFeatureValue("PixelFormat", oldPixelFormat);

                // Instantiation of new buffer object
                buffer = new SapBufferWithTrash(2, camera, SapBuffer.MemoryType.ScatterGather);
                // Instantiation of new view object
                view = new SapView(buffer);
                // Instantiation of new transfer object
                transfer = new SapAcqDeviceToBuf(camera, buffer);

                // End of frame event
                transfer.Pairs[0].EventType = SapXferPair.XferEventType.EndOfFrame;
                transfer.XferNotify += new SapXferNotifyHandler(Xfer_XferNotify);
                transfer.XferNotifyContext = view;

                // Create buffer object
                if (!buffer.Create())
                {
                    Console.WriteLine("Error during SapBuffer creation!\n");
                    DestroysObjects(camera, buffer, transfer, view);
                    return;
                }

                // Create transfer object
                if (!transfer.Create())
                {
                    Console.WriteLine("Error during SapTransfer creation!\n");
                    DestroysObjects(camera, buffer, transfer, view);
                    return;
                }

                // Create view object
                if (!view.Create())
                {
                    Console.WriteLine("Error during SapView creation!\n");
                    DestroysObjects(camera, buffer, transfer, view);
                    return;
                }
            }

            Console.WriteLine("Press any key to start Grab. Press 'q' to quit.\n");
            info = Console.ReadKey(true);
            key = info.KeyChar;
            if (key != 0)
            {
                if (key == 'q')
                {
                   DestroysObjects(camera, buffer, transfer, view);
                   return;
                }
            }

            // Start continous grab
            transfer.Grab();

            Console.WriteLine("Press any key to stop grab\n");
            Console.ReadKey();

            // Stop grab
            transfer.Freeze();
            transfer.Wait(5000);

            DestroysObjects(camera, buffer, transfer, view);
            location.Dispose();      
        }

        static bool AutoWhiteBalanceOperations(SapAcqDevice Camera, SapBuffer Buffers, SapTransfer Transfer)
        {

            Console.WriteLine("\nCalibration in progress ...........\n\n");
   
            double coefBlueGain      = MAX_COEF+1;
            double coefGreenGain     = MAX_COEF+1;
            double coefRedGain       = MAX_COEF+1;
            int calibrationIteration = 0;
           
           // Create a new Bayer object
            SapBayer Bayer = new SapBayer(Buffers);
            SapFeature FeatureInfo = new SapFeature(Camera.Location);

            if (!FeatureInfo.Create())
            {
               DestroysFeaturesAndBayer(FeatureInfo, Bayer);
               return false;
            }

            // Create Bayer object
            if (!Bayer.Create())
            {
               DestroysFeaturesAndBayer(FeatureInfo, Bayer);
               return false;
            }

            // Initialize all Gain colors to 0
            Camera.SetFeatureValue("GainBlue", 0);
            Camera.SetFeatureValue("GainGreen", 0);
            Camera.SetFeatureValue("GainRed", 0);  
            
            // Choose alignment used
            Bayer.Align = SapBayer.AlignMode.RGGB;

            // Definition of ROI used for calibration
            int fixSelectedRoiLeft = 0;
            int fixSelectedRoiTop = 0;
            // Half buffer width
            int fixSelectedRoiWidth = Buffers.Width / 2;
            // Half buffer height
            int fixSelectedRoiHeight = Buffers.Height / 2;

            // Start loop for calibration until each coefficient is under 1.05
            while(coefBlueGain > MAX_COEF || coefGreenGain > MAX_COEF || coefRedGain > MAX_COEF)
            {

               if (!Transfer.Snap())
               {
                  Console.WriteLine("Unable to acquire an image");
                  return false;
               }
                
                Thread.Sleep(500);
                // Call WhiteBalance function
                if (!Bayer.WhiteBalance(Buffers, fixSelectedRoiLeft, fixSelectedRoiTop, fixSelectedRoiWidth, fixSelectedRoiHeight))
		            break;

                // New coefficients values are reused.
               coefBlueGain = Bayer.WBGain.Blue;
               coefGreenGain = Bayer.WBGain.Green;
               coefRedGain = Bayer.WBGain.Red;

	            if(coefRedGain > MAX_COEF)
	            {
                    if (!ComputeGain("GainRed", Camera, FeatureInfo, coefRedGain))
                       break;
	            }
	            if(coefGreenGain > MAX_COEF)
	            {
                  if (!ComputeGain("GainGreen", Camera, FeatureInfo, coefGreenGain))
                     break;
	            }
	            if(coefBlueGain > MAX_COEF)
	            {
                  if (!ComputeGain("GainBlue", Camera, FeatureInfo, coefBlueGain))
                     break;
               }

	            if(calibrationIteration >= MAX_CALIBRATION_ITERATION)
	            {
                    Console.WriteLine("Iterations for calibration are at the maximum.\n");
		              break;
	            }
	            calibrationIteration++;
            }

            // Uncomment this part if you want to get new values after calibration.
            /*
            int gainBlue=0, gainRed=0, gainGreen=0;
            Camera.GetFeatureValue("GainBlue", out gainBlue);
            Camera.GetFeatureValue("GainRed", out gainRed);
            Camera.GetFeatureValue("GainGreen", out gainGreen);
            */

            DestroysFeaturesAndBayer(FeatureInfo, Bayer);
            Console.WriteLine("\nCalibration finished ...........\n\n");
            return true;
        }

       static bool ComputeGain(String Name, SapAcqDevice Camera, SapFeature featureInfo, double coefGain)
       {
          int featureExponent, gainCameraValue, gainGreenMin, gainGreenMax;
          float powValue;
          double NewGainValuePrecision;
          int NewGainRounded;

          if (!Camera.GetFeatureInfo(Name, featureInfo))
             return false;
        
          // Get Gain Green minimum
          featureInfo.GetValueMin(out gainGreenMin);
          // Get Gain Green maximum
          featureInfo.GetValueMax(out gainGreenMax);
          // Get Gain Value
          Camera.GetFeatureValue(Name, out gainCameraValue);
          // Get Gain exponent
          featureExponent = featureInfo.SiToNativeExp10;
          powValue = (float)Math.Pow(10, featureExponent);

          if (gainCameraValue == 0)
             NewGainValuePrecision = (coefGain * powValue);
          else
             NewGainValuePrecision = (coefGain * gainCameraValue);

          NewGainRounded = (int)Math.Round(NewGainValuePrecision);

          if (!ValidateWhiteBalance(NewGainRounded, gainGreenMin, gainGreenMax))
             return false;

          Camera.SetFeatureValue(Name, NewGainRounded);
          return true;
       }

        static bool ValidateWhiteBalance(double value, double minValue, double maxValue)
        {
            if (value < minValue || value > maxValue)
            {
               Console.WriteLine("Auto White Balance has failed.\n");
               return false;
            }
            return true;
        }

        static bool GetOptions(string[] args, MyAcquisitionParams acparams)
        {
            // Check if arguments were passed
            if (args.Length > 1)
                return ExampleUtils.GetAcqDeviceOptionsFromCommandLine(args, acparams);
            else
                return ExampleUtils.GetCorAcqDeviceOptionsFromQuestions(acparams, true);
        }

        static void DestroysFeaturesAndBayer(SapFeature feature, SapBayer bayer)
        {
            if (feature != null && feature.Initialized)
            {
                feature.Destroy();
                feature.Dispose();
            }

            if (bayer != null && bayer.Initialized)
            {
               bayer.Destroy();
               bayer.Dispose();
            }   
        }

        static void DestroysObjects(SapAcqDevice acq, SapBuffer buf, SapTransfer xfer, SapView view)
        {

            if (xfer != null && xfer.Initialized)
            {
                xfer.Destroy();
                xfer.Dispose();
            }         

            if (acq != null && acq.Initialized)
            {
                acq.Destroy();
                acq.Dispose();
            }

            if (buf != null && buf.Initialized)
            {
                buf.Destroy();
                buf.Dispose();
            }

            if (view != null && view.Initialized)
            {
               view.Destroy();
               view.Dispose();
            }

        }
    }
}
