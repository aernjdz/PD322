#pragma once
#include <iostream>

template <typename T, int Rows, int Cols>
class Matrix {
public:
    Matrix() = default;
    Matrix(const T& value);

    void display() const;
    T getMax() const;
    T getMin() const;
    bool searchValue(const T& value) const;
    T& operator()(int r, int c);
    T operator()(int r, int c) const;
    T getSum() const;

    Matrix operator+(const Matrix& other) const;
    Matrix operator+(const T& value) const;
    Matrix operator-(const Matrix& other) const;
    Matrix operator-(const T& value) const;

    Matrix& operator+=(const T& value);
    Matrix& operator-=(const T& value);
    bool operator==(const Matrix& other) const;
    bool operator!=(const Matrix& other) const;

private:
    T data[Rows][Cols];
};

template <typename T, int Rows, int Cols>
Matrix<T, Rows, Cols>::Matrix(const T& value) {
    for (int i = 0; i < Rows; ++i) {
        for (int j = 0; j < Cols; ++j) {
            data[i][j] = value;
        }
    }
}

template <typename T, int Rows, int Cols>
void Matrix<T, Rows, Cols>::display() const {
    for (int i = 0; i < Rows; ++i) {
        for (int j = 0; j < Cols; ++j) {
            std::cout << data[i][j] << ' ';
        }
        std::cout << std::endl;
    }
}

template <typename T, int Rows, int Cols>
T Matrix<T, Rows, Cols>::getMax() const {
    T maxElement = data[0][0];
    for (int i = 0; i < Rows; ++i) {
        for (int j = 0; j < Cols; ++j) {
            if (data[i][j] > maxElement) {
                maxElement = data[i][j];
            }
        }
    }
    return maxElement;
}

template <typename T, int Rows, int Cols>
T Matrix<T, Rows, Cols>::getMin() const {
    T minElement = data[0][0];
    for (int i = 0; i < Rows; ++i) {
        for (int j = 0; j < Cols; ++j) {
            if (data[i][j] < minElement) {
                minElement = data[i][j];
            }
        }
    }
    return minElement;
}

template <typename T, int Rows, int Cols>
bool Matrix<T, Rows, Cols>::searchValue(const T& value) const {
    for (int i = 0; i < Rows; ++i) {
        for (int j = 0; j < Cols; ++j) {
            if (data[i][j] == value) {
                return true;
            }
        }
    }
    return false;
}


template <typename T, int Rows, int Cols>
T& Matrix<T, Rows, Cols>::operator()(int r, int c) {
    return data[r][c];
}

template <typename T, int Rows, int Cols>
T Matrix<T, Rows, Cols>::operator()(int r, int c) const {
    return data[r][c];
}

template <typename T, int Rows, int Cols>
T Matrix<T, Rows, Cols>::getSum() const {
    T sum = 0;
    for (int i = 0; i < Rows; ++i) {
        for (int j = 0; j < Cols; ++j) {
            sum += data[i][j];
        }
    }
    return sum;
}

template <typename T, int Rows, int Cols>
Matrix<T, Rows, Cols> Matrix<T, Rows, Cols>::operator+(const Matrix& other) const {
    Matrix<T, Rows, Cols> result;
    for (int i = 0; i < Rows; ++i) {
        for (int j = 0; j < Cols; ++j) {
            result(i, j) = data[i][j] + other(i, j);
        }
    }
    return result;
}

template <typename T, int Rows, int Cols>
Matrix<T, Rows, Cols> Matrix<T, Rows, Cols>::operator+(const T& value) const {
    Matrix<T, Rows, Cols> result(*this);
    for (int i = 0; i < Rows; ++i) {
        for (int j = 0; j < Cols; ++j) {
            result(i, j) += value;
        }
    }
    return result;
}

template <typename T, int Rows, int Cols>
Matrix<T, Rows, Cols> operator+(const T& value, const Matrix<T, Rows, Cols>& matrix) {
    return matrix + value;
}

template <typename T, int Rows, int Cols>
Matrix<T, Rows, Cols>& Matrix<T, Rows, Cols>::operator+=(const T& value) {
    for (int i = 0; i < Rows; ++i) {
        for (int j = 0; j < Cols; ++j) {
            data[i][j] += value;
        }
    }
    return *this;
}

template <typename T, int Rows, int Cols>
bool Matrix<T, Rows, Cols>::operator==(const Matrix& other) const {
    for (int i = 0; i < Rows; ++i) {
        for (int j = 0; j < Cols; ++j) {
            if (data[i][j] != other(i, j)) {
                return false;
            }
        }
    }
    return true;
}

template <typename T, int Rows, int Cols>
Matrix<T, Rows, Cols> Matrix<T, Rows, Cols>::operator-(const Matrix& other) const {
    Matrix<T, Rows, Cols> result;
    for (int i = 0; i < Rows; ++i) {
        for (int j = 0; j < Cols; ++j) {
            result(i, j) = data[i][j] - other(i, j);
        }
    }
    return result;
}

template <typename T, int Rows, int Cols>
Matrix<T, Rows, Cols> Matrix<T, Rows, Cols>::operator-(const T& value) const {
    Matrix<T, Rows, Cols> result(*this);
    for (int i = 0; i < Rows; ++i) {
        for (int j = 0; j < Cols; ++j) {
            result(i, j) -= value;
        }
    }
    return result;
}

template <typename T, int Rows, int Cols>
Matrix<T, Rows, Cols>& Matrix<T, Rows, Cols>::operator-=(const T& value) {
    for (int i = 0; i < Rows; ++i) {
        for (int j = 0; j < Cols; ++j) {
            data[i][j] -= value;
        }
    }
    return *this;
}
template <typename T, int Rows, int Cols>
bool Matrix<T, Rows, Cols>::operator!=(const Matrix& other) const {
    return !(*this == other);
}