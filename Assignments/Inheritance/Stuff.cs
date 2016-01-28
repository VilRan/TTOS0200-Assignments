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

    abstract class BoxBase : IBox
    {
        public abstract double Width { get; }
        public abstract double Length { get; }
        public abstract double Height { get; }
        public double TopArea { get { return Width * Length; } }
        public double LengthwiseArea { get { return Length * Height; } }
        public double WidthwiseArea { get { return Width * Height; } }
        public double Area { get { return 2 * TopArea + 2 * LengthwiseArea + 2 * WidthwiseArea; } }
        public double Volume { get { return Width * Height * Length; } }
    }

    class Box : BoxBase
    {
        public override double Width { get { return width; } }
        public override double Length { get { return length; } }
        public override double Height { get { return height; } }
        
        public Box(double width, double length, double height)
        {
            this.width = width;
            this.length = length;
            this.height = height;
        }

        private readonly double width, length, height;
    }
    
    class ElectronicDevice : Box
    {
        public bool IsOn { get { return isOn; } }
        
        public ElectronicDevice(double width, double length, double height)
            : base (width, length, height)
        {

        }

        public void TogglePower()
        {
            isOn = !isOn;
        }

        private bool isOn;
    }

    class Computer : ElectronicDevice
    {
        public Computer(double width, double length, double height)
            : base (width, length, height)
        {

        }

        protected DataStorage hardDrive;
    }

    class Phone : Computer
    {
        public Phone(double width, double length, double height)
            : base (width, length, height)
        {
            hardDrive = new DataStorage(16000);
        }
    }

    class Tablet : Computer
    {
        public Tablet(double width, double length, double height)
            : base(width, length, height)
        {
            hardDrive = new DataStorage(16000);
        }
    }

    class Laptop : Computer
    {
        public Laptop(double width, double length, double height)
            : base(width, length, height)
        {
            discDrive = new OpticalDiscDrive();
            hardDrive = new DataStorage(512000);
        }

        private OpticalDiscDrive discDrive;
    }

    class OpticalDiscDrive
    {
        private OpticalDisc disc;

        private bool Insert(OpticalDisc disc)
        {
            if (disc == null)
            {
                this.disc = disc;
                return true;
            }
            return false;
        }

        private OpticalDisc Eject()
        {
            OpticalDisc ejected = disc;
            disc = null;
            return disc;
        }
    }

    class Cylinder : I3DShape
    {
        public double Diameter { get { return radius * 2; } }
        public double Radius { get { return radius; } }
        public double Circumference { get { return 2 * Math.PI * radius; } }
        public double TopArea { get { return Math.PI * radius * radius; } }
        public double SideArea { get { return Circumference * height; } }
        public double Area { get { return 2 * TopArea + SideArea; } }
        public double Volume { get { return TopArea * height; } }
        
        public Cylinder(double radius, double height)
        {
            this.radius = radius;
            this.height = height;
        }

        protected readonly double radius;
        protected readonly double height;
    }

    abstract class OpticalDisc : Cylinder
    {
        public DataStorage Data;
        public abstract int MaxBytes { get; }

        public OpticalDisc(double radius, double thickness)
            : base(radius, thickness)
        {
            Data = new DataStorage(MaxBytes);
        }
    }

    class CD : OpticalDisc
    {
        public override int MaxBytes { get { return 700; } }

        public CD(int bytes)
            : base(0.06, 0.0012)
        {

        }
    }

    class DVD : OpticalDisc
    {
        public override int MaxBytes { get { return 4500; } }

        public DVD(int bytes)
            : base(0.06, 0.0012)
        {

        }
    }

    class DataStorage
    {
        public DataStorage(int bytes)
        {
            data = new byte[bytes];
        }

        public void WriteString(int position, string str)
        {
            foreach (char c in str)
            {
                foreach (byte b in BitConverter.GetBytes(c))
                {
                    if (position >= data.Length)
                        position -= data.Length;
                    data[position] = b;
                    position++;
                }
            }
        }

        public string ReadString(int position, int length)
        {
            StringBuilder str = new StringBuilder();
            for (int i = position; i < position + length * 2; i += 2)
                str.Append(BitConverter.ToChar(data, i));
            return str.ToString();
        }

        private byte[] data;
    }

    class PaperDevice : BoxBase
    {
        public PaperSheet[] Sheets;

        public override double Width { get { return Sheets.Max(p => p.Width); } }
        public override double Length { get { return Sheets.Max(p => p.Length); } }
        public override double Height { get { return Sheets.Sum(p => p.Height); } }
        public int PageCount { get { return Sheets.Length * 2; } }

        public PaperDevice(params PaperSheet[] sheet)
        {
            Sheets = sheet;
        }
    }

    class PaperSheet : Box
    {
        public string LeftContent = "";
        public string RightContent = "";

        public static PaperSheet A4 { get { return new PaperSheet(0.297, 0.210, 0.00005); } }
        public static PaperSheet A5 { get { return new PaperSheet(0.210, 0.148, 0.00005); } }

        public PaperSheet(double width, double length, double thickness)
            : base(width, length, thickness)
        {

        }
    }

    class Book : PaperDevice
    {
        public Cover FrontCover;
        public Cover BackCover;
        
        public override double Width { get { return Math.Max(Math.Max(base.Width, FrontCover.Width), BackCover.Width); } }
        public override double Length { get { return Math.Max(Math.Max(base.Length, FrontCover.Length), BackCover.Length); } }
        public override double Height { get { return Math.Max(Math.Max(base.Height, FrontCover.Height), BackCover.Height); } }

        public Book(double coverThickness, params PaperSheet[] pages)
            : base(pages)
        {
            FrontCover = new Cover(Width, Height, coverThickness);
            BackCover = new Cover(Width, Height, coverThickness);
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
}
