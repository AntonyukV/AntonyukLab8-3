using System;

// Абстрактний клас для екрану
abstract class Screen
{
    public abstract void Display();
}

// Конкретні класи для різних типів екранів
class LCD : Screen
{
    public override void Display()
    {
        Console.WriteLine("LCD screen is displaying.");
    }
}

class OLED : Screen
{
    public override void Display()
    {
        Console.WriteLine("OLED screen is displaying.");
    }
}

// Абстрактний клас для процесора
abstract class Processor
{
    public abstract void Process();
}

// Конкретні класи для різних типів процесорів
class SnapDragon : Processor
{
    public override void Process()
    {
        Console.WriteLine("SnapDragon processor is processing.");
    }
}

class MediaTek : Processor
{
    public override void Process()
    {
        Console.WriteLine("MediaTek processor is processing.");
    }

}

// Абстрактний клас для камери
abstract class Camera
{
    public abstract void Capture();
}

// Конкретні класи для різних типів камер
class DualCamera : Camera
{
    public override void Capture()
    {
        Console.WriteLine("Dual camera is capturing.");
    }
}

class TripleCamera : Camera
{
    public override void Capture()
    {
        Console.WriteLine("Triple camera is capturing.");
    }
}

// Абстрактна фабрика для створення компонентів
abstract class TechProductFactory
{
    public abstract Screen CreateScreen();
    public abstract Processor CreateProcessor();
    public abstract Camera CreateCamera();
}

// Конкретні фабрики для різних типів технологічних продуктів
class SmartphoneFactory : TechProductFactory
{
    public override Screen CreateScreen()
    {
        return new OLED();
    }

    public override Processor CreateProcessor()
    {
        return new SnapDragon();
    }

    public override Camera CreateCamera()
    {
        return new DualCamera();
    }
}

class LaptopFactory : TechProductFactory
{
    public override Screen CreateScreen()
    {
        return new LCD();
    }

    public override Processor CreateProcessor()
    {
        return new MediaTek();
    }

    public override Camera CreateCamera()
    {
        return new TripleCamera();
    }
}

// Клас, який використовує фабрику для створення технологічного продукту
class TechProduct
{
    private Screen screen;
    private Processor processor;
    private Camera camera;

    public TechProduct(TechProductFactory factory)
    {
        screen = factory.CreateScreen();
        processor = factory.CreateProcessor();
        camera = factory.CreateCamera();
    }

    public void Assemble()
    {
        Console.WriteLine("Assembling the tech product:");
        screen.Display();
        processor.Process();
        camera.Capture();
    }
}

// Головний клас програми
class Program
{
    static void Main()
    {
        Console.WriteLine("Choose a type of tech product (Smartphone/Laptop):");
        string productType = Console.ReadLine();

        TechProductFactory factory;
        switch (productType.ToLower())
        {
            case "smartphone":
                factory = new SmartphoneFactory();
                break;
            case "laptop":
                factory = new LaptopFactory();
                break;
            default:
                Console.WriteLine("Invalid tech product type.");
                return;
        }

        TechProduct techProduct = new TechProduct(factory);
        techProduct.Assemble();

        Console.ReadLine();
    }
}
