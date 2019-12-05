// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HWindowControlDesigner
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms.Design;

namespace HalconDotNet
{
    public class HWindowControlDesigner : ControlDesigner
    {
        private HWindowControl windowControl;

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            this.windowControl = (HWindowControl)component;
        }

        protected override void PreFilterProperties(IDictionary properties)
        {
            base.PreFilterProperties(properties);
            Attribute[] attributeArray = new Attribute[3]
            {
        (Attribute) CategoryAttribute.Layout,
        (Attribute) DesignOnlyAttribute.Yes,
        (Attribute) new DescriptionAttribute("This design-time property allows you to configure Size and ImagePart by providing a reference image of the desired size.")
            };
            properties[(object)"LayoutBitmap"] = (object)TypeDescriptor.CreateProperty(typeof(HWindowControlDesigner), "LayoutBitmap", typeof(Bitmap), attributeArray);
            properties.Remove((object)"BorderStyle");
        }

        public Bitmap LayoutBitmap
        {
            get
            {
                return (Bitmap)null;
            }
            set
            {
                if (value == null)
                    return;
                HalconWindowLayoutDialog windowLayoutDialog = new HalconWindowLayoutDialog(value.Size);
                int num = (int)windowLayoutDialog.ShowDialog();
                if (windowLayoutDialog.resultCancel)
                    return;
                this.windowControl.WindowSize = new Size(value.Size.Width * windowLayoutDialog.resultPercent / 100, value.Size.Height * windowLayoutDialog.resultPercent / 100);
                this.windowControl.ImagePart = new Rectangle(Point.Empty, value.Size);
            }
        }
    }
}
