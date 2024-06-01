using API.Entities;

namespace API.Helpers;
public static class Utils
{
    public readonly static List<Product> seedingProducts = [
        new () { Name = "iPhone 12", Price = 1200 },
        new () { Name = "Galaxy S21", Price = 1100 },
        new () { Name = "Pixel 5", Price = 1000 },
        new () { Name = "Echo Dot", Price = 50 },
        new () { Name = "iPad Pro", Price = 1300 },
        new () { Name = "Surface Pro", Price = 1400 },
        new () { Name = "MacBook Pro", Price = 1500 },
        new () { Name = "Galaxy Tab", Price = 800 },
        new () { Name = "Pixelbook", Price = 900 },
        new () { Name = "Surface Laptop", Price = 1000 },
    ];

    public readonly static List<Brand> seedingBrands = [
        new () { Name = "Microsoft" },
        new () { Name = "Apple" },
        new () { Name = "Samsung" },
        new () { Name = "Google" },
        new () { Name = "Amazon" },
        new () { Name = "Facebook" },
        new () { Name = "Twitter" },
        new () { Name = "Instagram" },
        new () { Name = "Snapchat" },
        new () { Name = "TikTok" }
    ];
}


/*

public readonly static List<Product> seedingProducts = [
        new () { Name = "iPhone 12", Price = 1200,
            ProductPhotos = [ new () {Photo = new ("https://i.pinimg.com/736x/0d/be/eb/0dbeeb010c9cf22fec89f6ef1cc699f0.jpg")} ]
        },
        new () { Name = "Galaxy S21", Price = 1100,
            ProductPhotos = [ new () {Photo = new ("https://i.pinimg.com/736x/0d/be/eb/0dbeeb010c9cf22fec89f6ef1cc699f0.jpg")} ]
        },
        new () { Name = "Pixel 5", Price = 1000,
            ProductPhotos = [ new () {Photo = new ("https://i.pinimg.com/736x/0d/be/eb/0dbeeb010c9cf22fec89f6ef1cc699f0.jpg")} ]
        },
        new () { Name = "Echo Dot", Price = 50,
            ProductPhotos = [ new () {Photo = new ("https://i.pinimg.com/736x/0d/be/eb/0dbeeb010c9cf22fec89f6ef1cc699f0.jpg")} ]
        },
        new () { Name = "iPad Pro", Price = 1300,
            ProductPhotos = [ new () {Photo = new ("https://i.pinimg.com/736x/0d/be/eb/0dbeeb010c9cf22fec89f6ef1cc699f0.jpg")} ]
        },
        new () { Name = "Surface Pro", Price = 1400,
            ProductPhotos = [ new () {Photo = new ("https://i.pinimg.com/736x/0d/be/eb/0dbeeb010c9cf22fec89f6ef1cc699f0.jpg")} ]
        },
        new () { Name = "MacBook Pro", Price = 1500,
            ProductPhotos = [ new () {Photo = new ("https://i.pinimg.com/736x/0d/be/eb/0dbeeb010c9cf22fec89f6ef1cc699f0.jpg")} ]
        },
        new () { Name = "Galaxy Tab", Price = 800,
            ProductPhotos = [ new () {Photo = new ("https://i.pinimg.com/736x/0d/be/eb/0dbeeb010c9cf22fec89f6ef1cc699f0.jpg")} ]
        },
        new () { Name = "Pixelbook", Price = 900,
            ProductPhotos = [ new () {Photo = new ("https://i.pinimg.com/736x/0d/be/eb/0dbeeb010c9cf22fec89f6ef1cc699f0.jpg")} ]
        },
        new () { Name = "Surface Laptop", Price = 1000,
            ProductPhotos = [ new () {Photo = new ("https://i.pinimg.com/736x/0d/be/eb/0dbeeb010c9cf22fec89f6ef1cc699f0.jpg")} ]
        },
    ];

*/