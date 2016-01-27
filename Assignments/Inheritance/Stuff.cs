using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    interface I3DShape
    {
        double Area { get; }
        double Volume { get; }
    }

    interface IBox : I3DShape
    {
        double Width { get; }
        double Length { get; }
        double Height { get; }
    }

    class Box : IBox
    {
        public double Width { get { return width; } }
        public double Length { get { return length; } }
        public double Height { get { return height; } }
        public double TopArea { get { return width * height; } }
        public double Area { get { return 2 * width * length + 2 * width * height + 2 * length * height; } }
        public double Volume { get { return Width * Height * Length; } }

        private double width, length, height;

        public Box(double width, double length, double height)
        {
            this.width = width;
            this.length = length;
            this.height = height;
        }
    }
    
    class ElectronicDevice : Box
    {
        public bool IsOn { get { return isOn; } }

        private bool isOn;

        public ElectronicDevice(double width, double length, double height)
            : base (width, length, height)
        {

        }

        public void TogglePower()
        {
            isOn = !isOn;
        }
    }

    class Phone : ElectronicDevice
    {
        public Phone(double width, double length, double height)
            : base (width, length, height)
        {

        }
    }

    class Tablet : ElectronicDevice
    {
        public Tablet(double width, double length, double height)
            : base(width, length, height)
        {

        }
    }

    class Laptop : ElectronicDevice
    {
        public Laptop(double width, double length, double height)
            : base(width, length, height)
        {

        }
    }

    class PaperDevice : IBox
    {
        public PaperSheet[] Pages;

        public virtual double Width { get { return Pages.Max(p => p.Width); } }
        public virtual double Length { get { return Pages.Max(p => p.Length); } }
        public virtual double Height { get { return Pages.Sum(p => p.Height); } }
        public double Area { get { return 2 * Width * Length + 2 * Width * Height + 2 * Length * Height; } }
        public double Volume { get { return Width * Length * Height; } }

        public PaperDevice(params PaperSheet[] pages)
        {
            Pages = pages;
        }
    }

    class PaperSheet : Box
    {
        public string Content;

        public static PaperSheet A4 { get { return new PaperSheet(0.297, 0.210, 0.00005); } }
        public static PaperSheet A5 { get { return new PaperSheet(0.210, 0.148, 0.00005); } }

        public PaperSheet(double width, double length, double thickness, string content = "")
            : base(width, length, thickness)
        {
            Content = content;
        }
    }

    class Book : PaperDevice
    {
        private Cover frontCover;
        private Cover backCover;

        public Cover FrontCover { get { return frontCover; } }
        public Cover BackCover { get { return backCover; } }
        public override double Width { get { return Math.Max(Math.Max(base.Width, frontCover.Width), backCover.Width); } }
        public override double Length { get { return Math.Max(Math.Max(base.Length, frontCover.Length), backCover.Length); } }
        public override double Height { get { return Math.Max(Math.Max(base.Height, frontCover.Height), backCover.Height); } }

        public Book(double coverThickness, params PaperSheet[] pages)
            : base(pages)
        {
            frontCover = new Cover(Width, Height, coverThickness);
            backCover = new Cover(Width, Height, coverThickness);
        }

        public class Cover : Box
        {
            public Cover(double width, double lenght, double thickness)
                : base(width, lenght, thickness)
            {

            }
        }
    }


    class Magazine : PaperDevice
    {
        public Magazine(params PaperSheet[] pages)
            : base(pages)
        {

        }
    }

    class Disk : I3DShape
    {
        public double Diameter
        {
            get { return radius * 2; }
        }
        public double Radius
        {
            get { return radius; }
        }
        public double Circumference
        {
            get { return 2 * Math.PI * radius; }
        }
        public double Area
        {
            get { return Math.PI * radius * radius; }
        }
        public double Volume
        {
            get { return Area * thickness; }
        }

        protected readonly double radius;
        protected readonly double thickness;

        public Disk(double radius, double thickness)
        {
            this.radius = radius;
            this.thickness = thickness;
        }
    }

    class OpticalDisc : Disk
    {
        protected byte[] data;

        public OpticalDisc(double radius, double thickness)
            : base (radius, thickness)
        {

        }
    }

    class CD : OpticalDisc
    {
        public CD(int bytes)
            : base(0.06, 0.0012)
        {
            data = new byte[bytes];
        }
    }

    class DVD : OpticalDisc
    {
        public DVD(int bytes)
            : base(0.06, 0.0012)
        {
            data = new byte[bytes];
        }
    }
}
