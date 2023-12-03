#include <iostream>
#include <fstream>
#include <vector>
using namespace std;
class Shape {
public:
    virtual void Show() const = 0;
    virtual void Save(ofstream& file) const = 0;
    virtual void Load(ifstream& file) = 0;
    virtual ~Shape() {}
};

class Square : public Shape {
public:
    Square(int x, int y, int sideLength) : x(x), y(y), sideLength(sideLength) {}

    void Show() const override {
        cout << "Square: Left Top Corner(" << x << ", " << y << "), Side Length: " << sideLength << endl;
    }

    void Save(ofstream& file) const override {
        file << "Square " << x << " " << y << " " << sideLength << endl;
    }

    void Load(ifstream& file) override {
        file >> x >> y >> sideLength;
    }

private:
    int x, y;
    int sideLength;
};

class Rectangle : public Shape {
public:
    Rectangle(int x, int y, int width, int height) : x(x), y(y), width(width), height(height) {}

    void Show() const override {
        cout << "Rectangle: Left Top Corner(" << x << ", " << y << "), Width: " << width << ", Height: " << height << endl;
    }

    void Save(ofstream& file) const override {
        file << "Rectangle " << x << " " << y << " " << width << " " << height << endl;
    }

    void Load(ifstream& file) override {
        file >> x >> y >> width >> height;
    }

private:
    int x, y;
    int width, height;
};

class Circle : public Shape {
public:
    Circle(int centerX, int centerY, int radius) : centerX(centerX), centerY(centerY), radius(radius) {}

    void Show() const override {
        cout << "Circle: Center(" << centerX << ", " << centerY << "), Radius: " << radius << endl;
    }

    void Save(ofstream& file) const override {
        file << "Circle " << centerX << " " << centerY << " " << radius << endl;
    }

    void Load(ifstream& file) override {
        file >> centerX >> centerY >> radius;
    }

private:
    int centerX, centerY;
    int radius;
};

class Ellipse : public Shape {
public:
    Ellipse(int x, int y, int majorAxis, int minorAxis) : x(x), y(y), majorAxis(majorAxis), minorAxis(minorAxis) {}

    void Show() const override {
        cout << "Ellipse: Left Top Corner(" << x << ", " << y << "), Major Axis: " << majorAxis << ", Minor Axis: " << minorAxis << endl;
    }

    void Save(ofstream& file) const override {
        file << "Ellipse " << x << " " << y << " " << majorAxis << " " << minorAxis << endl;
    }

    void Load(ifstream& file) override {
        file >> x >> y >> majorAxis >> minorAxis;
    }

private:
    int x, y;
    int majorAxis, minorAxis;
};


Shape* loadShape(ifstream& file) {
    string shapeType;
    file >> shapeType;

    Shape* newShape = nullptr;

    if (shapeType == "Square") {
        newShape = new Square(0, 0, 0);
    }
    else if (shapeType == "Rectangle") {
        newShape = new Rectangle(0, 0, 0, 0);
    }
    else if (shapeType == "Circle") {
        newShape = new Circle(0, 0, 0);
    }
    else if (shapeType == "Ellipse") {
        newShape = new Ellipse(0, 0, 0, 0);
    }

    if (newShape) {
        newShape->Load(file);
    }

    return newShape;
}

int main() {
  
    vector<Shape*> shapes;

   
   shapes.push_back(new Square(0, 0, 5));
   shapes.push_back(new Rectangle(1, 2, 6, 4));
   shapes.push_back(new Circle(3, 3, 2));
   shapes.push_back(new Ellipse(2, 1, 7, 3));

    
    ofstream outputFile("shapes.txt");
    for (const auto& shape : shapes) {
        shape->Save(outputFile);
    }
    outputFile.close();

    ifstream inputFile("shapes.txt");
    vector<Shape*> loadedShapes;

    while (!inputFile.eof()) {
        Shape* newShape = loadShape(inputFile);
        if (newShape) {
            loadedShapes.push_back(newShape);
        }
    }

    for (const auto& shape : loadedShapes) {
        shape->Show();
    }


    for (const auto& shape : shapes) {
        delete shape;
    }
    for (const auto& shape : loadedShapes) {
        delete shape;
    }

    return 0;
}
